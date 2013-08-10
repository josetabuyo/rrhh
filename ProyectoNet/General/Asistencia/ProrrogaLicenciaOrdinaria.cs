using System;
using System.Collections.Generic;

using System.Text;
//using RRHH.Framework;
using System.Data.SqlClient;

namespace General
{
    public class ProrrogaLicenciaOrdinaria
    {

        private int _UsufructoDesde;
        public int UsufructoDesde
        {
            get { return _UsufructoDesde; }
            set { _UsufructoDesde = value;  }
        }

        private int _UsufructoHasta;
        public int UsufructoHasta
        {
            get { return _UsufructoHasta; }
            set { _UsufructoHasta = value;  }
        }

        private int _Periodo;
        public int Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value;  }
        }

        public int PeriodoDeUsufructoActual()
        {
            if (DateTime.Today.Month == 12)
            {
                return DateTime.Today.Year;
            }
            else
            {
                return DateTime.Today.Year - 1;
            }
        }

        public bool SeAplicaAlTipoDePlanta(TipoDePlanta planta)
        {
            return (planta.Id != 22);
        }
    }
}
