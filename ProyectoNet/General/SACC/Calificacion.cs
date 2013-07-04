using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class Calificacion
    {
        public abstract int Nota { get; set; }

        public abstract string Apreciacion { get; set; }

        public abstract string Descripcion { get; set; }


    }
}
