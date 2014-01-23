using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CantidadDeDiasPorPeriodo
    {
        protected int _perido;
        protected int _dias;

        public CantidadDeDiasPorPeriodo(int periodo, int dias) 
        {
            this._perido = periodo;
            this._dias = dias;
        }

        public object Periodo()
        {
            return this._perido;
        }

        public object CantidadDeDias()
        {
            return this._dias;
        }

    }
}
