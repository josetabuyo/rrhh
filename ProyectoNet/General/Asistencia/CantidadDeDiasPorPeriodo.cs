using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    /// <summary>
    /// Estructura de datos, que contiene dias, y periodo.
    /// e.g. 5 días, año 2005
    /// </summary>
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
