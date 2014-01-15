using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesAprobadas
    {
        private Persona _persona;
        private Periodo _periodo;
        private int _concepto;
        private Persona juan;
        private DateTime _desde;
        private DateTime _hasta;

        
        public Persona Persona { get { return _persona; } }
        public Periodo Periodo { get { return _periodo; } }
        public int Concepto { get { return _concepto; } }

        public VacacionesAprobadas(Persona persona, Periodo periodo, int concepto) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._concepto = concepto;
        }

        public VacacionesAprobadas(Persona juan, DateTime desde, DateTime hasta)
        {
            // TODO: Complete member initialization
            this.juan = juan;
            this._desde = desde;
            this._hasta = hasta;
        }

        public int CantidadDeDias()
        {
           return (_hasta - _desde).Days +1;
        }

    }
}
