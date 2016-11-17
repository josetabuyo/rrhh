using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class VacacionesAprobadas : SolicitudesDeVacaciones, IConPersona
    {
        private Periodo _periodo;
        private int _concepto;

       
        public Periodo Periodo { get { return _periodo; } }
        public int Concepto { get { return _concepto; } }
       

        public VacacionesAprobadas(Persona persona, DateTime desde, DateTime hasta)
        {
            this._persona = persona;
            this._desde = desde;
            this._hasta = hasta;
            this._creador_dias_por_periodo = SeDivideEnDosPeriodos();
        }


        public override SolicitudesDeVacaciones Clonar()
        {
            return new VacacionesAprobadas(_persona, _desde, _hasta);
        }

        public override List<SolicitudesDeVacaciones> DoPartir()
        {
            var result = new List<SolicitudesDeVacaciones>();
            result.Add(new VacacionesAprobadas(_persona, _desde, new DateTime(_desde.Year, 11, 30)));
            result.Add(new VacacionesAprobadas(_persona, new DateTime(_desde.Year, 12, 01), _hasta));
            return result;
        }


    }
}
