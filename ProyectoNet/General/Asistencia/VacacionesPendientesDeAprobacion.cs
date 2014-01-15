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

        public VacacionesPendientesDeAprobacion(Persona persona, DateTime desde, DateTime hasta)
        {
            // TODO: Complete member initialization
            this._persona = persona;
            this._desde = desde;
            this._hasta = hasta;
        }


        public int CantidadDeDias()
        {
            return (_hasta - _desde).Days + 1;
        }
    }
}
