using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class Licencia
    {
        private Auditoria _Auditoria;
        public Auditoria Auditoria { get { return _Auditoria; }  set { _Auditoria = value;  } }

        private Persona _Persona;
        public Persona Persona { get { return _Persona; } set { _Persona = value;  } }

        private ConceptoDeLicencia _Concepto;
        public ConceptoDeLicencia Concepto { get { return _Concepto; } set { _Concepto = value;  }}

        private DateTime _Desde;
        public DateTime Desde { get { return _Desde; }set { _Desde = value;  } }

        private DateTime _Hasta;
        public DateTime Hasta { get { return _Hasta; } set { _Hasta = value;  } }

        private int _IdConcepto;
        public int IdConcepto { get { return _IdConcepto; } set { _IdConcepto = value; } }

    }
}
