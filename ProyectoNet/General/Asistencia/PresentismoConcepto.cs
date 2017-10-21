using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class PresentismoConcepto
    {
        
        private string _concepto;
        public string Concepto { get { return _concepto; } set { _concepto = value; } }

        private DateTime _desde;
        public DateTime Desde { get { return _desde; } set { _desde = value; } }

        private DateTime _hasta;
        public DateTime Hasta { get { return _hasta; } set { _hasta = value; } }


        public PresentismoConcepto()
        {      
        }

        public PresentismoConcepto(string concepto, DateTime desde, DateTime hasta)
        {
            this.Concepto = concepto;
            this.Desde = desde;
            this.Hasta = hasta;
        }

    }

    
}
