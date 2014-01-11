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
        private int _total;

        public int total { get { return _total; } set { _total = value; } }

        public VacacionesPermitidas(Persona persona, Periodo periodo, int total) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._total = total;
        }

        public VacacionesPermitidas()
        {
            // TODO: Complete member initialization
        }


        
    }
}
