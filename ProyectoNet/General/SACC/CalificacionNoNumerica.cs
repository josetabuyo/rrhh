using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionNoNumerica:Calificacion
    {  
        public override int Nota { get; set; }
        public override string Descripcion  { get; set; }

        public CalificacionNoNumerica(string Descripcion )
        {
            this.Descripcion = Descripcion;
        }

        public CalificacionNoNumerica()
        {
            this.Descripcion = string.Empty;
        }
    }
}
