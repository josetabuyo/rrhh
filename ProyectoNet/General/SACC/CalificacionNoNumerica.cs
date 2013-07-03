using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionNoNumerica:Calificacion
    {
        public override string Apreciacion { get; set; }
        public override int Nota { get; set; }

        public CalificacionNoNumerica(string apreciacion)
        {
            this.Apreciacion = apreciacion;
        }
    }
}
