using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{

    /// <summary>
    /// Es un tipo particular de creador de "periodos imputables" que sólo
    /// creara un único periodo imputable.
    ///     e.g. 10 dias imputables a 2005
    /// </summary>
    public class CreadorDePeriodosImputablesSimples:CreadorDePeriodosImputables
    {
        public override List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(SolicitudesDeVacaciones aprobadas)
        {
            var dias_periodo = aprobadas.CantidadDeDias();

            return new List<CantidadDeDiasPorPeriodo>() { new CantidadDeDiasPorPeriodo(GetAnioimputable(aprobadas.Hasta()), dias_periodo) };
        }       
    }
}
