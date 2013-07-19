using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace General.Modi
{
    public class ImagenModi
    {
        public string bytesImagen { get; set; }
        public string nombre { get; set; }

        public ImagenModi()
        {

        }

        public ImagenModi(string un_nombre)
        {
            this.nombre = un_nombre;
        }

        public ImagenModi(string nombre_imagen, Image imagen)
        {
            this.nombre = nombre_imagen;
            var ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            this.bytesImagen = Convert.ToBase64String(imageBytes);
        }

        public ImagenModi(string nombre_imagen, String bytecode)
        {
            this.nombre = nombre_imagen;
            this.bytesImagen = bytecode;
        }

        public ImagenModi GetThumbnail(int alto, int ancho)
        {
            byte[] imageBytes = Convert.FromBase64String(this.bytesImagen);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
                imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            var msThumb = new MemoryStream();
            image.GetThumbnailImage(alto, ancho, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero).Save(msThumb, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytesThumb = msThumb.ToArray();
            return new ImagenModi(this.nombre, Convert.ToBase64String(imageBytesThumb));
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
