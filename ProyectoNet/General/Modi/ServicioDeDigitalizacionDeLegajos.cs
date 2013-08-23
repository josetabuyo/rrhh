using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.IO;

namespace General.Modi
{
    public class ServicioDeDigitalizacionDeLegajos: IServicioDeDigitalizacionDeLegajos
    {
        private IConexionBD conexion_db;
        private IFileSystem file_system;
        private string path_imagenes;

        public ServicioDeDigitalizacionDeLegajos(IConexionBD una_conexion, IFileSystem un_file_system, string un_path)
        {
            this.conexion_db = una_conexion;
            this.file_system = un_file_system;
            this.path_imagenes = un_path;
        }

        public RespuestaABusquedaDeLegajos BuscarLegajos(string criterio)
        {
            var legajos = new List<LegajoModi>();
            int numero;
            if (int.TryParse(criterio, out numero))
            {
                legajos.AddRange(this.GetLegajoPorDocumento(numero));
                legajos.AddRange(this.GetLegajoPorIdInterna(numero));
            }
            else
            {
                legajos.AddRange(this.GetLegajosPorApellidoYNombre(criterio));
            }
            return new RespuestaABusquedaDeLegajos(legajos);
        }

        public ImagenModi GetImagenPorId(int id_imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            var tabla_imagen = this.conexion_db.Ejecutar("dbo.MODI_Get_Imagen", parametros);
            var primera_fila = tabla_imagen.Rows.First();
            return new ImagenModi(primera_fila.GetString("nombre_imagen"), primera_fila.GetString("bytes_imagen"));
        }

        public ImagenModi GetThumbnailPorId(int id_imagen, int alto, int ancho)
        {
            return this.GetImagenPorId(id_imagen).GetThumbnail(alto, ancho);
        }

        public void AsignarImagenAFolioDeLegajo(int id_imagen, int nro_folio, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@nro_folio", nro_folio);
            parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Folio_De_Legajo", parametros);
        }

        public void DesAsignarImagen(int id_imagen, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@id_usuario", usuario.Id);

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






        private List<LegajoModi> GetLegajoPorDocumento(int numero_de_documento)
        {
            var legajos = new List<LegajoModi>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@doc", numero_de_documento);
            var tablaLegajos = conexion_db.Ejecutar("dbo.LEG_GET_Datos_Personales", parametros);

            if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
            return legajos;
        }

        private List<LegajoModi> GetLegajoPorIdInterna(int id_interna)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            var tablaLegajos = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Id_interna", parametros);

            if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
            return legajos;
        }

        private List<LegajoModi> GetLegajosPorApellidoYNombre(string criterio)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@criterio", criterio);
            var tablaLegajos = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Apellido_Y_Nombre", parametros);

            if (tablaLegajos.Rows.Count > 0) legajos.AddRange(GetLegajosFromTabla(tablaLegajos));
            return legajos;
        }

        private List<LegajoModi> GetLegajosFromTabla(TablaDeDatos tablaLegajos)
        {
            var legajos = new List<LegajoModi>();
            tablaLegajos.Rows.ForEach(row =>
            {
                var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"),
                                    row.GetString("Cuil_Nro"));

                this.AgregarImagenesSinAsignarDeUnLegajoALaBase(legajo);
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
                    documentos.Add(nuevoDocumento);
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
                var id_imagen = row.GetInt("id_imagen");
  
                var imagen = new ImagenModi(row.GetInt("id_imagen"));

                if (!(row.GetObject("nro_folio") is DBNull))
                {
                    int nro_folio = row.GetInt("nro_folio");
                    var folio = legajo.GetFolio(nro_folio);
                    folio.imagen = imagen;
                }
                else {
                    legajo.imagenesSinAsignar.Add(imagen);                
                }
            });
        }

        private void AgregarImagenesSinAsignarDeUnLegajoALaBase(LegajoModi legajo)
        {
            List<String> paths_imagenes;
            try
            {
                paths_imagenes = this.file_system.getPathsArchivosEnCarpeta(this.path_imagenes + "/" + legajo.cuil).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToList();
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_imagenes = new List<string>();
            }
            paths_imagenes.ForEach(pathImagen =>
            {
                var imagen = new ImagenModi(Path.GetFileNameWithoutExtension(pathImagen), this.file_system.getImagenFromPath(pathImagen));
                this.AgregarImagenSinAsignarALaBase(legajo, imagen);
                this.file_system.moverArchivo(pathImagen, path_imagenes + "/" + legajo.cuil + "/IncorporadasAlSistema");
            });
        }

        private void AgregarImagenSinAsignarALaBase(LegajoModi legajo, ImagenModi imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", legajo.idInterna);
            parametros.Add("@nombre_imagen", imagen.nombre);
            parametros.Add("@bytes_imagen", imagen.bytesImagen);

            this.conexion_db.EjecutarEscalar("dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", parametros);
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

