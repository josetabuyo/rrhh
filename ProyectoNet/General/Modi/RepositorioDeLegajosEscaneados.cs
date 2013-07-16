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

        public List<ThumbnailImagenModi> getThumbnailsDeImagenesSinAsignarParaUnLegajo(int legajo)
        {
            var listaImagenes = new List<ThumbnailImagenModi>();
            List<String> paths_archivos;
            try
            {
                paths_archivos = this.fileSystem.getPathsArchivosEnCarpeta(this.pathImagenes + "/" + legajo);
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_archivos = new List<string>();
            }
            paths_archivos.ForEach(pathImagen =>
            {
                listaImagenes.Add(new ThumbnailImagenModi(Path.GetFileNameWithoutExtension(pathImagen), this.fileSystem.getImagenFromPath(pathImagen)));
            });
            return listaImagenes;
        }


        public ImagenModi getImagenSinAsignarParaUnLegajo(int legajo, string nombre_imagen)
        {
            return new ImagenModi(nombre_imagen, this.fileSystem.getImagenFromPath(this.pathImagenes + "/" + legajo + "/" + nombre_imagen + ".jpg"));
        }


        public List<ThumbnailImagenModi> getThumbnailsDeImagenesAsignadasAlDocumento(string tabla, int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id", id);
            var tablaImagenes = this.conexionDB.Ejecutar("dbo.MODI_Imagenes_Asignadas_A_Documento", parametros);
            return GetImagenesFromTabla(tablaImagenes);
        }


        private List<ThumbnailImagenModi> GetImagenesFromTabla(TablaDeDatos tablaImagenes)
        {
            var imagenes = new List<ThumbnailImagenModi>();

            if (tablaImagenes.Rows.Count > 0)
            {
                tablaImagenes.Rows.ForEach(row =>
                {
                    var strImagen = row.GetString("bytes_imagen");

                    byte[] imageBytes = Convert.FromBase64String(strImagen);
                    MemoryStream ms = new MemoryStream(imageBytes, 0,
                      imageBytes.Length);

                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);

                    var nuevaImagen = new ThumbnailImagenModi(row.GetString("nombre_imagen"),
                                                            image);
                    imagenes.Add(nuevaImagen);
                });
            }

            return imagenes;
        }


        public void asignarImagenADocumento(string nombre_imagen, int legajo, string tabla, int id_documento)
        {
            var imagen = new ImagenModi(nombre_imagen, this.fileSystem.getImagenFromPath(this.pathImagenes + "/" + legajo + "/" + nombre_imagen + ".jpg"));
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tabla", tabla);
            parametros.Add("@id", id_documento);
            parametros.Add("@nombre_imagen", imagen.nombre);
            parametros.Add("@bytes_imagen", imagen.bytesImagen);

            this.conexionDB.EjecutarSinResultado("dbo.MODI_Asignar_Imagen_A_Documento", parametros);
        }
    }
}
