using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class Calificacion
    {
        public Calificacion()
        {
            this.Nota = 0;
            this.Descripcion = string.Empty;
        }
        public abstract int Nota { get; set; }
        public abstract string Descripcion { get; set; }
    }
}
