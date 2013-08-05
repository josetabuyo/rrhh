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

        public void AsignarImagenADocumento(int id_imagen, string tabla, int id_documento, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);
            parametros.Add("@id_usuario", usuario.Id);

            this.conexion_db.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Un_Documento", parametros);
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
            var tablaLegajo = conexion_db.Ejecutar("dbo.LEG_GET_Datos_Personales", parametros);

            if (tablaLegajo.Rows.Count > 0) legajos.Add(GetLegajoFromTabla(tablaLegajo));
            return legajos;
        }

        private List<LegajoModi> GetLegajoPorIdInterna(int id_interna)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            var tablaLegajo = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Id_interna", parametros);

            if (tablaLegajo.Rows.Count > 0) legajos.Add(GetLegajoFromTabla(tablaLegajo));
            return legajos;
        }

        private List<LegajoModi> GetLegajosPorApellidoYNombre(string criterio)
        {
            var legajos = new List<LegajoModi>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@criterio", criterio);
            var tablaLegajo = conexion_db.Ejecutar("dbo.MODI_GET_Datos_Personales_Por_Apellido_Y_Nombre", parametros);

            if (tablaLegajo.Rows.Count > 0) legajos.Add(GetLegajoFromTabla(tablaLegajo));
            return legajos;
        }

        private LegajoModi GetLegajoFromTabla(TablaDeDatos tablaLegajo)
        {
            var row = tablaLegajo.Rows.First();
            var legajo = new LegajoModi(row.GetInt("id_interna"),
                                    row.GetInt("Nro_Documento"),
                                    row.GetString("Nombre"),
                                    row.GetString("Apellido"),
                                    row.GetString("Cuil_Nro"));

            legajo.agregarDocumentos(this.DocumentosPara(legajo));
            legajo.agregarIdsDeImagenesSinAsignar(this.GetIdsDeImagenesSinAsignarParaElLegajo(legajo));
            return legajo;
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
                var id_imagenes = this.GetIdsDeImagenesAsignadasAlDocumento(doc.tabla, doc.id);
                doc.idImagenesAsignadas.AddRange(id_imagenes);

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

        private List<int> GetIdsDeImagenesSinAsignarParaElLegajo(LegajoModi legajo)
        {
            var listaIdsImagenes = new List<int>();
            this.AgregarImagenesSinAsignarDeUnLegajoALaBase(legajo);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@legajo", legajo.idInterna);
            var tablaIds = this.conexion_db.Ejecutar("dbo.MODI_Get_Ids_De_Imagenes_Sin_Asignar_Para_El_Legajo", parametros);

            if (tablaIds.Rows.Count > 0)
            {
                tablaIds.Rows.ForEach(row =>
                {
                    listaIdsImagenes.Add(row.GetInt("id_imagen"));
                });
            }
            return listaIdsImagenes;
        }

        private void AgregarImagenesSinAsignarDeUnLegajoALaBase(LegajoModi legajo)
        {
            List<String> paths_archivos;
            try
            {
                paths_archivos = this.file_system.getPathsArchivosEnCarpeta(this.path_imagenes + "/" + legajo.cuil);
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_archivos = new List<string>();
            }
            paths_archivos.ForEach(pathImagen =>
            {
                var imagen = new ImagenModi(Path.GetFileNameWithoutExtension(pathImagen), this.file_system.getImagenFromPath(pathImagen));
                this.AgregarImagenSinAsignarALaBase(legajo, imagen);
                this.file_system.moverArchivo(pathImagen, path_imagenes + "/" + legajo.cuil + "/IncorporadasAlSistema");
            });
        }

        private void AgregarImagenSinAsignarALaBase(LegajoModi legajo, ImagenModi imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@legajo", legajo.idInterna);
            parametros.Add("@nombre_imagen", imagen.nombre);
            parametros.Add("@bytes_imagen", imagen.bytesImagen);

            this.conexion_db.EjecutarEscalar("dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", parametros);
        }

        private List<int> GetIdsDeImagenesAsignadasAlDocumento(string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);
            var tablaIds = this.conexion_db.Ejecutar("dbo.MODI_Id_Imagenes_Asignadas_A_Un_Documento", parametros);

            var listaIdsImagenes = new List<int>();
            if (tablaIds.Rows.Count > 0)
            {
                tablaIds.Rows.ForEach(row =>
                {
                    listaIdsImagenes.Add(row.GetInt("id_imagen"));
                });
            }
            return listaIdsImagenes;
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

