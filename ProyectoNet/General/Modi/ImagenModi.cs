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
    }
}
