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
        protected Persona juan;


       
        public Persona Persona { get { return _persona; } }
        public int Periodo { get { return _anio; } }
        public int Concepto { get { return _concepto; } }

        public VacacionesPermitidas(Persona persona, int periodo, int dias, int concepto) 
        {
            this._persona = persona;
            this._anio = periodo;
            this._dias = dias;
            this._concepto = concepto;
        }

        public VacacionesPermitidas()
        {
            // TODO: Complete member initialization
        }

        public VacacionesPermitidas(General.Persona juan, int anio, int dias)
        {
            // TODO: Complete member initialization
            this.juan = juan;
            this._anio = anio;
            this._dias = dias;
        }

        public int CantidadDeDias() 
        {
            return _dias;
        }

    }
}
