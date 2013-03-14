using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class SaldoLicenciaDetalle
    {
        private int _Periodo;
        public int Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value;  }
        }

        private int _Disponible;
        public int Disponible
        {
            get { return _Disponible; }
            set { _Disponible = value;  }
        }
    }
}
