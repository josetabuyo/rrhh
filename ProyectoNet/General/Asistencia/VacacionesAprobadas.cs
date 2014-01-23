using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

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
        protected CreadorDePeriodosImputables _creador_dias_por_periodo;

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
            this._creador_dias_por_periodo = SeDivideEnDosPeriodos();
        }

        public int CantidadDeDias()
        {
           return (_hasta - _desde).Days +1;
        }

        public List<CantidadDeDiasPorPeriodo> AnioMaximoImputable()
        {
            return this._creador_dias_por_periodo.AnioMaximoImputable(this);
        }

        public DateTime Hasta()
        {
            return _hasta;
        }

        public DateTime Desde()
        {
            return _desde;
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

            //if (_hasta.Year > _desde.Year)
            //{
            //      if(_desde.Month <= 11 && _desde.Day <= 30) return new CreadorDePeriodosImputablesDivisibles();
            //      return new CreadorDePeriodosImputablesSimples();
            //} else
            //{
            //    if (_desde.Month <= 11 && _desde.Day <= 30 && _hasta.Month >= 12 && _hasta.Day >= 1) return new CreadorDePeriodosImputablesDivisibles();
            //    return new CreadorDePeriodosImputablesSimples();
            //}
        }



    }
}
