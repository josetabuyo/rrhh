using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    /// <summary>
    /// Encargado de crear "periodos imputables" en los cuales se pueden imputar licencias.
    /// e.g. 
    ///     -> "5 dias imputables al 2005",
    ///     -> "8 dias imputables al 2006"
    /// </summary>
    public abstract class CreadorDePeriodosImputables
    {
        /// <summary>
        /// devuelve las partes en las que sería imputable una licencia (una parte por periodo)
        /// en caso de ser más de un periodo, cada uno tiene la cantidad de dias correspondientes.
        /// </summary>
        /// <param name="aprobadas">La licencia de la que se quiere saber la cantidad de periodos en los cuales es imputable</param>
        /// <returns>Una lista de "periodos imputables" eg 1.10 dias al 2005, 2.5 dias al 2006
        /// </returns>
        public abstract List<CantidadDeDiasPorPeriodo> AnioMaximoImputable(SolicitudesDeVacaciones aprobadas);

        public int GetAnioimputable(DateTime fecha)
        {
            var offset = 1;
            if (fecha.Month == 12) offset = 0;
            return fecha.Year - offset;
        }
    }
}
