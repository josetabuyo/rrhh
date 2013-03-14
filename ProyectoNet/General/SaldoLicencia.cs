using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class SaldoLicencia
    {
        private Persona _Persona;
        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value;  }
        }

        private int _SaldoMensual;
        public int SaldoMensual
        {
            get { return _SaldoMensual; }
            set { _SaldoMensual = value;  }
        }

        private int _SaldoAnual;
        public int SaldoAnual
        {
            get { return _SaldoAnual; }
            set { _SaldoAnual = value;  }
        }
        public List<SaldoLicenciaDetalle> Detalle { get; set; }
    }
}
