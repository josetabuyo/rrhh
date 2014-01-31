using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CreadorDePeriodosImputablesDivisibles : CreadorDePeriodosImputables
    {
        public override List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(VacacionesAprobadas aprobadas)
        {
            var dias_primer_periodo = (new DateTime(GetAnioimputable(aprobadas.Hasta()), 11, 30) - aprobadas.Desde()).Days + 1;
            var dias_segundo_periodo = (aprobadas.Hasta() - new DateTime(GetAnioimputable(aprobadas.Hasta()), 12, 01)).Days + 1;

            return new List<CantidadDeDiasPorPeriodo>() { new CantidadDeDiasPorPeriodo(GetAnioimputable(aprobadas.Desde()), dias_primer_periodo), new CantidadDeDiasPorPeriodo(GetAnioimputable(aprobadas.Hasta()), dias_segundo_periodo) };
 
        }

        public override List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(VacacionesPendientesDeAprobacion pendientes)
        {
            var dias_primer_periodo = (new DateTime(GetAnioimputable(pendientes.Hasta()), 11, 30) - pendientes.Desde()).Days + 1;
            var dias_segundo_periodo = (pendientes.Hasta() - new DateTime(GetAnioimputable(pendientes.Hasta()), 12, 01)).Days + 1;

            return new List<CantidadDeDiasPorPeriodo>() { new CantidadDeDiasPorPeriodo(GetAnioimputable(pendientes.Desde()), dias_primer_periodo), new CantidadDeDiasPorPeriodo(GetAnioimputable(pendientes.Hasta()), dias_segundo_periodo) };

        }
    }
}
