using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesPermitidas
    {
        private Persona _persona;
        private Periodo _periodo;
        private int _dias;

        public int Dias { get { return _dias; } set { _dias = value; } }
        public Persona Persona { get { return _persona; } }
        public Periodo Periodo { get { return _periodo; } }

        public VacacionesPermitidas(Persona persona, Periodo periodo, int dias) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._dias = dias;
        }

        public VacacionesPermitidas()
        {
            // TODO: Complete member initialization
        }


        
    }
}
