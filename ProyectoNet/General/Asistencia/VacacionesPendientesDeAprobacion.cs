using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class VacacionesPendientesDeAprobacion : SolicitudesDeVacaciones, IConPersona
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

        public override List<SolicitudesDeVacaciones> DoPartir()
        {
            var result = new List<SolicitudesDeVacaciones>();
            result.Add(new VacacionesPendientesDeAprobacion(_persona, _desde, new DateTime(_desde.Year, 11, 30)));
            result.Add(new VacacionesPendientesDeAprobacion(_persona, new DateTime(_desde.Year, 12, 01), _hasta));
            return result;
        }

    }
}
