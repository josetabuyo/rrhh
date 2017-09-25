using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace General.Repositorios
{
    public class RepositorioDeImagenes
    {
        IConexionBD conexion;
        private RepositorioDeArchivos repo_archivos;

        public RepositorioDeImagenes(IConexionBD una_conexion)
        {
            this.conexion = una_conexion;
            this.repo_archivos = new RepositorioDeArchivos(una_conexion);
        }

        public Imagen GetThumbnail(int id_imagen, int alto, int ancho)
        {
            var imagen_original = GetImagen(id_imagen);
            if (imagen_original.reintentar) return imagen_original;

            byte[] imageBytes = Convert.FromBase64String(imagen_original.bytes);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);

            var imagen_resizeada = FixedSize(imagen, ancho, alto);

            var ms_thumb = new MemoryStream();
            imagen_resizeada.Save(ms_thumb, System.Drawing.Imaging.ImageFormat.Jpeg);
            imageBytes = ms_thumb.ToArray();
            var img_resizeada = new Imagen();
            img_resizeada.bytes = Convert.ToBase64String(imageBytes);
            img_resizeada.reintentar = false;
            return img_resizeada;
        }

        public Imagen GetImagen(int id_imagen)
        {
            var img = new Imagen();
            img.bytes = repo_archivos.GetArchivoAsync(id_imagen);
            img.reintentar = false;
            if (img.bytes == "reintentar") img.reintentar = true;
            return img;           
        }

        public int SubirImagen(string bytes_imagen)
        {
            var parametros_subir_imagen = new Dictionary<string, object>();
            parametros_subir_imagen.Add("@bytes", bytes_imagen);
            var id_imagen = int.Parse(this.conexion.EjecutarEscalar("dbo.FS_SubirArchivo", parametros_subir_imagen).ToString());
            return id_imagen;
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
                else destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2);
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

        //crea una imagen escalada y retorna los bytes que representan a la imagen
        public byte[] GetThumbnailPDF(int id_imagen, int alto, int ancho)
        {
            var imagen_original = GetImagen(id_imagen);  

            byte[] imageBytes = Convert.FromBase64String(imagen_original.bytes);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);

            var imagen_resizeada = FixedSize(imagen, ancho, alto);

            var ms_thumb = new MemoryStream();
            imagen_resizeada.Save(ms_thumb, System.Drawing.Imaging.ImageFormat.Jpeg);
            imageBytes = ms_thumb.ToArray();
           // Image returnImage = Image.FromStream(ms_thumb);
            return imageBytes;
        }

    }
}
