using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.IO;

namespace General.Modi
{
    public class ServicioDeCompresionYPersistenciaDeImagenes
    {
        private IConexionBD conexion_db;
        private IFileSystem file_system;
        private string path_imagenes;

        public ServicioDeCompresionYPersistenciaDeImagenes(IConexionBD una_conexion, IFileSystem un_file_system, string un_path)
        {
            this.conexion_db = una_conexion;
            this.file_system = un_file_system;
            this.path_imagenes = un_path;
        }

        public void AgregarImagenesSinAsignarDeUnLegajoALaBase(int id_interna)
        {
            List<String> paths_imagenes;
            try
            {
                paths_imagenes = this.file_system.getPathsArchivosEnCarpeta(this.path_imagenes).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".tiff")).ToList();
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_imagenes = new List<string>();
            }
            paths_imagenes.ForEach(pathImagen =>
            {
                var imagen = new ImagenModi(Path.GetFileNameWithoutExtension(pathImagen), this.file_system.getImagenFromPath(pathImagen));
                this.AgregarImagenSinAsignarALaBase(id_interna, imagen);
                this.file_system.moverArchivo(pathImagen, path_imagenes + "/IncorporadasAlSistema/" + id_interna.ToString());
            });
        }

        private void AgregarImagenSinAsignarALaBase(int id_interna, ImagenModi imagen)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_interna", id_interna);
            parametros.Add("@nombre_imagen", imagen.nombre);
            parametros.Add("@bytes_imagen", imagen.bytesImagen);

            this.conexion_db.EjecutarEscalar("dbo.MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo", parametros);
        }
    }
}

