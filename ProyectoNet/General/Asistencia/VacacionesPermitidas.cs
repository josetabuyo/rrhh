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
        private int _concepto;
        private General.Persona juan;
        private int p;
        private int p_2;

        public int Dias { get { return _dias; } set { _dias = value; } }
        public Persona Persona { get { return _persona; } }
        public Periodo Periodo { get { return _periodo; } }
        public int Concepto { get { return _concepto; } }

        public VacacionesPermitidas(Persona persona, Periodo periodo, int dias, int concepto) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._dias = dias;
            this._concepto = concepto;
        }

        public VacacionesPermitidas()
        {
            // TODO: Complete member initialization
        }

        public VacacionesPermitidas(General.Persona juan, int p, int p_2)
        {
            // TODO: Complete member initialization
            this.juan = juan;
            this.p = p;
            this.p_2 = p_2;
        }


    }
}
