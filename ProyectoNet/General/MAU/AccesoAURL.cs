using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class AccesoAURL
    {
        public string Url { get; set; }
        public Funcionalidad Funcionalidad { get; set; }

        public AccesoAURL()
        {
            
        }

        public AccesoAURL(Funcionalidad funcionalidad, string url)
        {
            this.Funcionalidad = funcionalidad;
            this.Url = url;
        }
    }
}
