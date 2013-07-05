using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace General.Modi
{
    public class ThumbnailImagenModi
    {
        public string nombre { get; set; }
        public string bytesImagen { get; set; }

        public ThumbnailImagenModi()
        {

        }

        public ThumbnailImagenModi(string un_nombre)
        {
            this.nombre = un_nombre;
        }

        public ThumbnailImagenModi(string un_nombre, Image imagen_tamanio_completo)
        {
            this.nombre = un_nombre;
            var ms = new MemoryStream();
            imagen_tamanio_completo.GetThumbnailImage(90, 90, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            this.bytesImagen = Convert.ToBase64String(imageBytes);
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
