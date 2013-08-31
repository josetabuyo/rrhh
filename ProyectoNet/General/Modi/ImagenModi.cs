using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace General.Modi
{
    public class ImagenModi
    {
        public int id { get; set; }
        public float orden { get; set; }
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

        public ImagenModi(int id, float orden)
        {
            this.id = id;
            this.orden = orden;
        }

        public ImagenModi(int id)
        {
            this.id = id;
        }

        public ImagenModi GetThumbnail(int alto, int ancho)
        {
            byte[] imageBytes = Convert.FromBase64String(this.bytesImagen);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
                imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);

            return new ImagenModi(this.nombre, FixedSize(image, ancho, alto));
        }

        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            if (Width == 0) Width = sourceWidth;
            if (Height == 0) Height = sourceHeight;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.LightGray);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
