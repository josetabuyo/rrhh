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
        private int _dias;
        private int _concepto;

        public int Dias { get { return _dias; } set { _dias = value; } }
        public Persona Persona { get { return _persona; } }
        public Periodo Periodo { get { return _periodo; } }
        public int Concepto { get { return _concepto; } }

        public VacacionesAprobadas(Persona persona, Periodo periodo, int dias, int concepto) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._dias = dias;
            this._concepto = concepto;
        }



    }
}
