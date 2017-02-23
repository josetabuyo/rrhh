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
        public string bytesImagen { get; set; }
        public string nombre { get; set; }
        public int folioDocumento { get; set; }
        public int folioLegajo { get; set; }
        public int orden { get; set; }
        public string tabla { get; set; }
        public int idDocumento { get; set; }

        public ImagenModi()
        {

        }

        public void SetImagen(Image imagen)
        {
            var ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            this.bytesImagen = Convert.ToBase64String(imageBytes);
        }

        public ImagenModi GetThumbnail(int alto, int ancho)
        {
            var imagen_ret = new ImagenModi();
            imagen_ret.nombre = this.nombre;
            if (this.bytesImagen != "")
            {
                byte[] imageBytes = Convert.FromBase64String(this.bytesImagen);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                    imageBytes.Length);

                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                imagen_ret.SetImagen(FixedSize(image, ancho, alto));
            }
            else
            {
                imagen_ret.bytesImagen = "";
            }
            return imagen_ret;
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

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);

            if (Height == 0) nPercentH = 1;
            if (Width == 0) nPercentW = 1;

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                if (Width == 0) destX = 0;
                else  destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                if (Height == 0) destY = 0;
                else destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            if (Height == 0) Height = destHeight;
            if (Width == 0) Width = destWidth;

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


        public int idInterna { get; set; }
    }
}
