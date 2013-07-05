using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace General.Modi
{
    public class FileSystem:IFileSystem
    {
        public List<string> getPathsArchivosEnCarpeta(string path)
        {
            try
            {
                return Directory.GetFiles(path).ToList();
            }
            catch(DirectoryNotFoundException e){
                throw new ExcepcionDeCarpetaDeLegajoNoEncontrada();
            }
        }


        public Image getImagenFromPath(string pathImagen)
        {
            return Image.FromFile(pathImagen);
        }
    }
}
