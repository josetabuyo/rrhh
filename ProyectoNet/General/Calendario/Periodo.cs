using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Periodo
    {

        DateTime fechaDesde;
        DateTime fechaHasta;
        int _anio;

        public int anio { get { return _anio; } set { _anio = value; } } 

        public Periodo()
        { }

        public Periodo(DateTime fechaDesde, DateTime fechaHasta)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
        }

        public bool Incluis(Estadia estadia)
        { 
            return estadia.Desde >= fechaDesde && estadia.Desde <= fechaHasta;
        
        }

        public int CantidadDeDias() 
        {
            return (fechaHasta - fechaDesde).Days;
        }





    }
}
