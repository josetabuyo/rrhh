using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionNumerica:Calificacion
    {
        public override int Nota { get; set; }
        public override string Apreciacion { get; set; }
        public override string Descripcion { get; set; }

        public CalificacionNumerica(int unNumero)
        {
            if (unNumero < 1 || unNumero > 10)
            {
                throw new ExcepcionDeValidacion("La nota no puede ser menor que 1 o mayor que 10");
            }
            this.Nota = unNumero;
        }
    }
}
