using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public abstract class SolicitudesDeVacaciones
    {
        protected Persona _persona;
        protected DateTime _desde;
        protected DateTime _hasta;
        protected int _dias_ya_imputados;
        protected CreadorDePeriodosImputables _creador_dias_por_periodo;


        public Persona Persona { get { return _persona; } }


        public DateTime Desde()
        {
            return _desde;
        }

        public DateTime Hasta()
        {
            return _hasta;
        }

        public abstract SolicitudesDeVacaciones Clonar();
        

        public void DiasYaImputados(int dias_ya_imputados)
        {
            this._dias_ya_imputados = this._dias_ya_imputados + dias_ya_imputados;
        }

        public int GetDiasYaImputados()
        {
            return this._dias_ya_imputados;
        }

        public int CantidadDeDias()
        {
            return (_hasta - _desde).Days + 1 - _dias_ya_imputados;
        }

        public int AnioMinimoImputable(Persona persona)
        {
            return persona.TipoDePlanta.Prorroga(this.Desde()).UsufructoDesde;
        }

        public List<CantidadDeDiasPorPeriodo> AnioMaximoImputable()
        {
            return this._creador_dias_por_periodo.AnioMaximoImputable(this); //VER MAÑANA CON AGUS
        }

        protected CreadorDePeriodosImputables SeDivideEnDosPeriodos()
        {

            int a = _desde.CompareTo(new DateTime(_desde.Year, 11, 30));
            int b = _hasta.CompareTo(new DateTime(_desde.Year, 12, 01)); // BEL: tengo dudas sobre el _desde.Year ... ANALIZAR + Casos *4

            if (a <= 0 && b >= 0)
            {
                return new CreadorDePeriodosImputablesDivisibles();
            }

            return new CreadorDePeriodosImputablesSimples();
        }

        public override string ToString()
        {
            return this.Desde().ToString() + " - " + this.Hasta().ToString();
        }

        public List<SolicitudesDeVacaciones> Partir()
        {
            if (this.EsPartible())
            {
                return this.DoPartir();
            }
            else
            {
                return new List<SolicitudesDeVacaciones>() { this };
            }
        }

        public abstract List<SolicitudesDeVacaciones> DoPartir();

        public Boolean EsPartible()
        {
            return (this.Desde() <= new DateTime(this.Desde().Year, 11, 30) && (this.Hasta() >= new DateTime(this.Desde().Year, 12, 01)));
        }
        
    }
}
