using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionAusente:Calificacion
    {
        public override int Nota { get; set; }
        public override string Descripcion { get; set; }

        public CalificacionAusente(string nota)
        {
            this.Descripcion = nota;
        }
    }
}
