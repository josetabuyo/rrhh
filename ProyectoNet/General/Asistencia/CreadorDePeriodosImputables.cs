using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class CreadorDePeriodosImputables
    {
        public abstract List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(VacacionesAprobadas aprobadas);


        public int GetAnioimputable(DateTime fecha)
        {
            var offset = 1;
            if (fecha.Month == 12) offset = 0;
            return fecha.Year - offset;
        }
    }
}
