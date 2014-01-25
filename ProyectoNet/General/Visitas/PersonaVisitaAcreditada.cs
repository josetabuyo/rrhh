using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PersonaVisitaAcreditada: PersonaVisita
    {
        private string _NroCredencial;
        public string NroCredencial
        {
            set { this._NroCredencial = value; }
            get { return this._NroCredencial; }
        }
    }
}
