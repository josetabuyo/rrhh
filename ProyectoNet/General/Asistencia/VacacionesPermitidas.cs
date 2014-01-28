using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class VacacionesPermitidas
    {
        protected Persona _persona;
        protected int _dias;
        protected int _anio;
        protected int _concepto;
        protected int _prorroga;


       
        public Persona Persona { get { return _persona; } }
        public int Periodo { get { return _anio; } }
        public int Concepto { get { return _concepto; } }
        public int Prorroga { get { return _prorroga; } }

        public VacacionesPermitidas(Persona persona, int periodo, int dias, int concepto, int prorroga) 
        {
            this._persona = persona;
            this._anio = periodo;
            this._dias = dias;
            this._concepto = concepto;
            this._prorroga = prorroga;
        }

        public VacacionesPermitidas()
        {
            // TODO: Complete member initialization
        }

        public VacacionesPermitidas(Persona persona, int anio, int dias, int prorroga)
        {
            // TODO: Complete member initialization
            this._persona = persona;
            this._anio = anio;
            this._dias = dias;
            this._prorroga = prorroga;
        }

        public int CantidadDeDias() 
        {
            return _dias;
        }


        internal void CantidadDeDias(int dias_a_setear)
        {
            this._dias = dias_a_setear;
        }
    }
}
