using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CreadorDePeriodosImputablesSimples:CreadorDePeriodosImputables
    {
        public override List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(VacacionesAprobadas aprobadas)
        {
            var dias_periodo = aprobadas.CantidadDeDias();

            return new List<CantidadDeDiasPorPeriodo>() { new CantidadDeDiasPorPeriodo(GetAnioimputable(aprobadas.Hasta()), dias_periodo) };
        }
    }
}
