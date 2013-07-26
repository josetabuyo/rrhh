using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Modi;
using System.IO;
using System.Linq;
using General.Repositorios;
using System.Drawing;

namespace General.Modi
{
    public class RepositorioDeLegajosEscaneados:IRepositorioDeLegajosEscaneados
    {
        private IFileSystem fileSystem;
        private string pathImagenes;
        private IConexionBD conexionDB;

        public RepositorioDeLegajosEscaneados(IFileSystem un_file_system, IConexionBD _conexion, string pathImagenes)
        {
            this.fileSystem = un_file_system;
            this.conexionDB = _conexion;
            this.pathImagenes = pathImagenes;
        }

        public List<int> GetIdsDeImagenesSinAsignarParaElLegajo(int numero_legajo)
        {
            var listaIdsImagenes = new List<int>();
            this.AgregarImagenesSinAsignarDeUnLegajoALaBase(numero_legajo);
                        
            var parametros = new Dictionary<string, object>();
            parametros.Add("@legajo", numero_legajo);
            var tablaIds = this.conexionDB.Ejecutar("dbo.MODI_Get_Ids_De_Imagenes_Sin_Asignar_Para_El_Legajo", parametros);

            if (tablaIds.Rows.Count > 0)
            {
                tablaIds.Rows.ForEach(row =>
                {
                    listaIdsImagenes.Add(row.GetInt("id_imagen"));                 
                });
            }
            return listaIdsImagenes;
        }

        private void AgregarImagenesSinAsignarDeUnLegajoALaBase(int numero_legajo)
        {
            List<String> paths_archivos;
            try
            {
                paths_archivos = this.fileSystem.getPathsArchivosEnCarpeta(this.pathImagenes + "/" + numero_legajo);
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_archivos = new List<string>();
            }
            paths_archivos.ForEach(pathImagen =>
            {
                var imagen = new ImagenModi(Path.GetFileNameWithoutExtension(pathImagen), this.fileSystem.getImagenFromPath(pathImagen));
                this.AgregarImagenSinAsignarALaBase(numero_legajo, imagen);
                this.fileSystem.moverArchivo(pathImagen, pathImagenes + "/" + numero_legajo + "/IncorporadasAlSistema");
            });
        }

        private void AgregarImagenSinAsignarALaBase(int numero_legajo, ImagenModi imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@legajo", numero_legajo);
            parametros.Add("@nombre_imagen", imagen.nombre);
            parametros.Add("@bytes_imagen", imagen.bytesImagen);

            this.conexionDB.EjecutarEscalar("dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", parametros);
        }


        public ImagenModi GetImagenPorId(int id_imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            var tabla_imagen = this.conexionDB.Ejecutar("dbo.MODI_Get_Imagen", parametros);  
            var primera_fila = tabla_imagen.Rows.First();
            return new ImagenModi(primera_fila.GetString("nombre_imagen"), primera_fila.GetString("bytes_imagen"));
        }

        public ImagenModi GetThumbnailPorId(int id_imagen, int alto, int ancho)
        {
            return this.GetImagenPorId(id_imagen).GetThumbnail(alto, ancho);
        }

        public void AsignarImagenADocumento(int id_imagen, string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);

            this.conexionDB.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Un_Documento", parametros);
        }

        public List<int> GetIdsDeImagenesAsignadasAlDocumento(string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);
            var tablaIds = this.conexionDB.Ejecutar("dbo.MODI_Id_Imagenes_Asignadas_A_Un_Documento", parametros);

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

        public void DesAsignarImagen(int id_imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_imagen", id_imagen);

            this.conexionDB.EjecutarSinResultado("dbo.MODI_Des_Asignar_Imagen", parametros);
        }

        public void AsignarCategoriaADocumento(int id_categoria, string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_categoria", id_categoria);
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);

            this.conexionDB.EjecutarSinResultado("dbo.MODI_Asignar_Categoria_A_Un_Documento", parametros);
        }

        public int CategoriaDeUnDocumento(string tabla, int id_documento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id_documento", id_documento);

            var tabla_id = this.conexionDB.Ejecutar("dbo.MODI_Categoria_De_Un_Documento", parametros);

            var id_categoria = -1;
            if (tabla_id.Rows.Count > 0)
            {
                id_categoria = tabla_id.Rows[0].GetInt("id_categoria");
            }
            return id_categoria;
        }
    }
}
