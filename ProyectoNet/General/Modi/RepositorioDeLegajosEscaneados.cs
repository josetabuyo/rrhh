using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Modi;
using System.IO;
using System.Linq;

namespace General.Modi
{
    public class RepositorioDeLegajosEscaneados:IRepositorioDeLegajosEscaneados
    {
        private IFileSystem fileSystem;
        private string pathImagenes;
        public RepositorioDeLegajosEscaneados(IFileSystem un_file_system, string pathImagenes)
        {
            this.fileSystem = un_file_system; 
            this.pathImagenes = pathImagenes;
        }

        public List<ThumbnailImagenModi> getThumbnailsParaUnLegajo(int legajo)
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


        public ImagenModi getImagenSinAsignar(int legajo, string nombre_imagen)
        {
            return new ImagenModi(nombre_imagen, this.fileSystem.getImagenFromPath(this.pathImagenes + "/" + legajo + "/" + nombre_imagen + ".jpg"));
        }
    }
}
