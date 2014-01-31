using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesPendientesDeAprobacion
    {
        private Persona _persona;
        private DateTime _desde;
        private DateTime _hasta;
        protected int _dias_ya_imputados;
        protected CreadorDePeriodosImputables _creador_dias_por_periodo;

        public VacacionesPendientesDeAprobacion(Persona persona, DateTime desde, DateTime hasta)
        {
            // TODO: Complete member initialization
            this._persona = persona;
            this._desde = desde;
            this._hasta = hasta;
            this._creador_dias_por_periodo = SeDivideEnDosPeriodos();
        }


        public int CantidadDeDias()
        {
            return (_hasta - _desde).Days + 1;
        }

        public int AnioMinimoImputable()
        {
            return _creador_dias_por_periodo.AnioMaximoImputable(this).First().Periodo() - 1;
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

        public void DiasYaImputados(int dias_ya_imputados)
        {
            this._dias_ya_imputados = this._dias_ya_imputados + dias_ya_imputados;
        }

        public VacacionesPendientesDeAprobacion Clonar()
        {
            return new VacacionesPendientesDeAprobacion(_persona, _desde, _hasta);
        }

        public DateTime Hasta()
        {
            return _hasta;
        }

        public DateTime Desde()
        {
            return _desde;
        }

    }
}
