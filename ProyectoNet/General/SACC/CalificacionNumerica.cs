using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.SACC
{
    public class CalificacionNumerica:Calificacion
    {
        private int nota;

        public CalificacionNumerica(int unNumero)
        {
            if (unNumero < 1 || unNumero > 10)
            {
                throw new ExcepcionDeValidacion("La nota no puede ser menor que 1 o mayor que 10");
            }
            this.nota = unNumero;
        }
    }
}
