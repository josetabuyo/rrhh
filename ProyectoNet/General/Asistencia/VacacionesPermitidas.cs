using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class VacacionesPermitidas: IConPersona
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

        public string Observacion { get; set; }
        public DateTime Desde()
        {
            return new DateTime(Periodo, 01, 01);
        }

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

        public VacacionesPermitidas(Persona persona, int anio, int dias)
        {
            // TODO: Complete member initialization
            this._persona = persona;
            this._anio = anio;
            this._dias = dias;
        }

        public int CantidadDeDias() 
        {
            return _dias;
        }

        public VacacionesPermitidas Clonar()
        {
            return new VacacionesPermitidas(this._persona, this._anio, this._dias);
        }

        internal void CantidadDeDias(int dias_a_setear)
        {
            this._dias = dias_a_setear;
        }

        public void RestarDias(int dias_a_restar)
        {
            this._dias = this._dias - dias_a_restar;
        }

        public override string ToString()
        {
            return this.Periodo.ToString() + " - " + this.CantidadDeDias().ToString();
        }

    }
}
