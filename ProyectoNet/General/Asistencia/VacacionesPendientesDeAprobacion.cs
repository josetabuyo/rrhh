using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesPendientesDeAprobacion : SolicitudesDeVacaciones
    {


        public VacacionesPendientesDeAprobacion(Persona persona, DateTime desde, DateTime hasta)
        {
            this._persona = persona;
            this._desde = desde;
            this._hasta = hasta;
            this._creador_dias_por_periodo = SeDivideEnDosPeriodos();
        }


        public override SolicitudesDeVacaciones Clonar()
        {
            return new VacacionesPendientesDeAprobacion(_persona, _desde, _hasta);
        }

    }
}
