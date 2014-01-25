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

        public int Periodo()
        {
            return this._perido;
        }

        public int CantidadDeDias()
        {
            return this._dias;
        }

    }
}
