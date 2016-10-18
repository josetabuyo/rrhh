using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace General.Repositorios
{
    public class Imagen
    {
        public int id { get; set; }
        public string bytes { get; set; }            
        public bool reintentar {get; set;}

        public Imagen()
        {

        }

    }
}
