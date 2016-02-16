using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Tools;
using System.Net;

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
            catch (DirectoryNotFoundException e)
            {
                throw new ExcepcionDeCarpetaDeLegajoNoEncontrada();
            }
        }


        public Image getImagenFromPath(string path)
        {
            //then do whatever, such as getting a list of folders:
                
            FileStream fs = new FileStream(path, FileMode.Open);

            // allocate enough space for the file in memory
            Byte[] b = new Byte[fs.Length];

            // read the file into memory
            fs.Read(b, 0, b.Length);

            // close the file
            fs.Close();

            // create a new memorystream based off of the file bytes.
            MemoryStream ms = new MemoryStream(b);

            // replace Image::FromFile with Image::FromStream
            return Image.FromStream(ms);
        }

        public bool guardarImagenEnPath(string path, string bytes_imagen)
        {
            byte[] imageBytes = Convert.FromBase64String(bytes_imagen);
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(imageBytes, 0, imageBytes.Count());
            fs.Close();
            return true;
        }

        public void moverArchivo(string path, string pathCarpetaDestino)
        {
            if (!System.IO.Directory.Exists(pathCarpetaDestino))
            {
                System.IO.Directory.CreateDirectory(pathCarpetaDestino);
            }
            var fileName = System.IO.Path.GetFileName(path);
            var destFile = pathCarpetaDestino + "/" + fileName;
            try
            {
                File.Move(path, destFile);
            }
            catch (Exception e)
            {
                var a = "";
            }
        }
    }
}
