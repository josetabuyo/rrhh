using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class VacacionesAprobadas : SolicitudesDeVacaciones
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

    }
}
