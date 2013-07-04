using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionNull:Calificacion
    {

        public override int Nota { get; set; }

        public override string Apreciacion { get; set; }

        public override string Descripcion { get; set; }

        public CalificacionNull(string nota)
        {
            this.Descripcion = nota;
        }

    }
}
