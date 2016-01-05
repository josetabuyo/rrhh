using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.IO;
using General.MAU;
using System.Drawing;
using System.Configuration;

namespace General.Modi
{
    public class ServicioDeDigitalizacionDeLegajos: IServicioDeDigitalizacionDeLegajos
    {
        private IConexionBD conexion_db;
        private FileSystem file_system { get; set; }

        public ServicioDeDigitalizacionDeLegajos(IConexionBD una_conexion)
        {
            this.conexion_db = una_conexion;
            this.file_system = new FileSystem();
        }

        public RespuestaABusquedaDeLegajos BuscarLegajos(string criterio)
        {          
            //int numero;
            //if (int.TryParse(criterio, out numero))
            //{
            //    legajos.AddRange(this.GetLegajoPorDocumento(numero));
            //    legajos.AddRange(this.GetLegajoPorIdInterna(numero));
            //}
            //else
            //{
            //    legajos.AddRange(this.GetLegajosPorApellidoYNombre(criterio));
            //}
            var legajos = new List<LegajoModi>();
            var repo_pers = RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion_db);
            var personas = repo_pers.BuscarPersonasConLegajo(criterio);

            personas.ForEach(p =>
            {
                var legajo = new LegajoModi(int.Parse(p.Legajo),
                                       p.Documento,
                                       p.Nombre,
                                       p.Apellido);

                legajo.agregarDocumentos(this.DocumentosPara(legajo));
                this.SetearEsqueletoDeImagenesAUnLegajo(legajo);
                legajos.Add(legajo);
            });
            return new RespuestaABusquedaDeLegajos(legajos);
        }

        public ImagenModi GetImagenPorId(int id_imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            var tabla_imagen = this.conexion_db.Ejecutar("dbo.MODI_Get_Imagen", parametros);
            var primera_fila = tabla_imagen.Rows.First();

            var imagen = new ImagenModi();
            imagen.id = primera_fila.GetInt("id_imagen");
            imagen.idInterna = primera_fila.GetInt("id_interna");
            imagen.nombre = primera_fila.GetString("nombre_imagen");
            Image img;
            if (primera_fila.GetObject("bytes_imagen") is DBNull){
                img = file_system.getImagenFromPath(ConfigurationManager.AppSettings["CarpetaDigitalizacion"] +id_imagen + ".jpg");
            }else{
                img = primera_fila.GetImage("bytes_imagen");
            }
            
            imagen.SetImagen(img);

            if (!(primera_fila.GetObject("folio_doc") is DBNull))
            {
                imagen.folioDocumento = primera_fila.GetInt("folio_doc");
                imagen.orden = primera_fila.GetInt("faz");
                imagen.tabla = primera_fila.GetString("tabla");
                imagen.idDocumento = primera_fila.GetInt("id_documento");
                var legajo = GetLegajoPorIdInterna(imagen.idInterna)[0];
                var folio = legajo.GetFolio(imagen.tabla, imagen.idDocumento, imagen.folioDocumento);
            }
            return imagen;
        }


        public ImagenModi GetThumbnailPorId(int id_imagen, int alto, int ancho)
        {
            return this.GetImagenPorId(id_imagen).GetThumbnail(alto, ancho);
        }

        public int AsignarImagenAFolioDeLegajo(int id_imagen, int nro_folio, Usuario usuario)
        {
            var imagen = GetImagenPorId(id_imagen);
            var legajo = GetLegajoPorIdInterna(imagen.idInterna)[0];
            var folio = legajo.GetFolio(nro_folio);
            int orden = 1;
            if(folio.imagenes.Any())orden = folio.imagenes.Max(i => i.orden) + 1;

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@folio_doc", folio.folioDocumento);
            parametros.Add("@faz", orden);
            parametros.Add("@tabla", folio.tabla);
            parametros.Add("@id_documento", folio.idDocumento);
            parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Folio_De_Legajo", parametros);
            return orden;
        }

        public void AsignarImagenAFolioDeLegajoPasandoPagina(int id_imagen, int nro_folio, int pagina, Usuario usuario)
        {
            var imagen = GetImagenPorId(id_imagen);
            var legajo = GetLegajoPorIdInterna(imagen.idInterna)[0];
            var folio = legajo.GetFolio(nro_folio);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@folio_doc", folio.folioDocumento);
            parametros.Add("@faz", pagina);
            parametros.Add("@tabla", folio.tabla);
            parametros.Add("@id_documento", folio.idDocumento);
            parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Folio_De_Legajo", parametros);
        }

        public void DesAsignarImagen(int id_imagen, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            //parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Des_Asignar_Imagen", parametros);
        }

        public void AsignarCategoriaADocumento(int id_categoria, string tabla, int id_documento, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_categoria", id_categoria);
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);
            parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Asignar_Categoria_A_Un_Documento", parametros);
        }

        public int AgregarImagenSinAsignarAUnLegajo(int id_interna, string nombre_imagen, string bytes_imagen)
        {
            //byte[] imageBytes = Convert.FromBase64String(bytes_imagen);         

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            parametros.Add("@nombre_imagen", nombre_imagen);
            //parametros.Add("@bytes_imagen", imageBytes);

            int id_imagen = int.Parse(this.conexion_db.EjecutarEscalar("dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", parametros).ToString());
            this.file_system.guardarImagenEnPath(ConfigurationManager.AppSettings["CarpetaDigitalizacion"] +id_imagen + ".jpg", bytes_imagen);
            return id_imagen;
        }

        public int AgregarImagenAUnFolioDeUnLegajo(int id_interna, int numero_folio, string nombre_imagen, string bytes_imagen)
        {
            var legajo = GetLegajoPorIdInterna(id_interna)[0];
            var folio = legajo.GetFolio(numero_folio);
            int orden = 1;
            if (folio.imagenes.Any()) orden = folio.imagenes.Max(i => i.orden) + 1;

            byte[] imageBytes = Convert.FromBase64String(bytes_imagen);
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            parametros.Add("@nombre_imagen", nombre_imagen);
            parametros.Add("@bytes_imagen", imageBytes);
            parametros.Add("@folio_doc", folio.folioDocumento);
            parametros.Add("@faz", orden);
            parametros.Add("@tabla", folio.tabla);
            parametros.Add("@id_documento", folio.idDocumento);

            int id_imagen = int.Parse(this.conexion_db.EjecutarEscalar("dbo.MODI_Agregar_Imagen_A_Un_Folio_De_Un_Legajo", parametros).ToString());
            this.file_system.guardarImagenEnPath(ConfigurationManager.AppSettings["CarpetaDigitalizacion"] + id_imagen + ".jpg", bytes_imagen);
            return id_imagen;
        }
        
        //private List<LegajoModi> GetLegajoPorDocumento(int numero_de_documento)
        //{
        //    var legajos = new List<LegajoModi>();
        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@doc", numero_de_documento);
        //    var tablaLegajos = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Documento", parametros);

        //    if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
        //    return legajos;
        //}

        private List<LegajoModi> GetLegajoPorIdInterna(int id_interna)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            var tablaLegajos = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Id_interna", parametros);

            if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
            return legajos;
        }

        //private List<LegajoModi> GetLegajosPorApellidoYNombre(string criterio)
        //{
        //    var legajos = new List<LegajoModi>();

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@criterio", criterio);
        //    var tablaLegajos = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Apellido_Y_Nombre", parametros);

        //    if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
        //    return legajos;
        //}

        private List<LegajoModi> GetLegajosFromTabla(TablaDeDatos tablaLegajos)
        {
            var legajos = new List<LegajoModi>();
            tablaLegajos.Rows.ForEach(row =>
            {
                var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"));

                legajo.agregarDocumentos(this.DocumentosPara(legajo));
                this.SetearEsqueletoDeImagenesAUnLegajo(legajo);
                legajos.Add(legajo);
            });
            return legajos;
        }

        private List<DocumentoModi> DocumentosPara(LegajoModi legajo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", legajo.idInterna);
            parametros.Add("@legajo", legajo.idInterna);
            var tablaDocumentos = conexion_db.Ejecutar("dbo.LEG_GET_Indice_Documentos", parametros);
            var documentos =  GetDocumentosFromTabla(tablaDocumentos);

            documentos.ForEach(doc =>
            {
                var id_categoria = this.CategoriaDeUnDocumento(doc.tabla, doc.id);
                doc.idCategoria = id_categoria;
            });
            return documentos;
        }


        private List<DocumentoModi> GetDocumentosFromTabla(TablaDeDatos tablaDocumentos)
        {
            List<DocumentoModi> documentos = new List<DocumentoModi>();

            if (tablaDocumentos.Rows.Count > 0)
            {
                tablaDocumentos.Rows.ForEach(row =>
                {
                    var nuevoDocumento = new DocumentoModi(row.GetString("tabla"),
                                                            row.GetInt("id"),
                                                            row.GetString("TIPO"),
                                                            row.GetString("JUR"),
                                                            row.GetString("ORG"),
                                                            row.GetString("FOLIO"),
                                                            row.GetDateTime("fecha_comunicacion"));
                    if (!(documentos.SelectMany(d => d.folios).Select(f => f.folioLegajo).Any(num_folio => nuevoDocumento.folios.Select(f => f.folioLegajo).Contains(num_folio)))) documentos.Add(nuevoDocumento);
                });
            }

            return documentos;
        }

        private void SetearEsqueletoDeImagenesAUnLegajo(LegajoModi legajo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", legajo.idInterna);
            var tablaImagenes = this.conexion_db.Ejecutar("dbo.MODI_Imagenes_De_Un_Legajo", parametros);

            tablaImagenes.Rows.ForEach(row =>
            {
                var imagen = new ImagenModi();
                imagen.id = row.GetInt("id_imagen");
                imagen.idInterna = row.GetInt("id_interna");
  
                if (!(row.GetObject("folio_doc") is DBNull))
                {
                    imagen.folioDocumento = row.GetInt("folio_doc");
                    imagen.tabla = row.GetString("tabla");
                    imagen.idDocumento = row.GetInt("id_documento");
                    imagen.orden = row.GetInt("faz");

                    var folio = legajo.GetFolio(imagen.tabla, imagen.idDocumento, imagen.folioDocumento);
                    imagen.folioLegajo = folio.folioLegajo;
                    folio.imagenes.Add(imagen);
                }
                else {
                    legajo.imagenesSinAsignar.Add(imagen);                
                }
            });

            legajo.imagenesSinAsignar = legajo.imagenesSinAsignar.OrderBy(i => i.orden).ToList();
            legajo.documentos.ForEach(doc=>doc.folios.ForEach(f=>f.imagenes = f.imagenes.OrderBy(i=>i.orden).ToList()));
        }
       
        private int CategoriaDeUnDocumento(string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);

            var tabla_id = this.conexion_db.Ejecutar("dbo.MODI_Categoria_De_Un_Documento", parametros);

            var id_categoria = -1;
            if (tabla_id.Rows.Count > 0)
            {
                id_categoria = tabla_id.Rows[0].GetInt("id_categoria");
            }
            return id_categoria;
        }
    }
}

