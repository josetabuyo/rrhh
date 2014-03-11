using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class AccesoAURL
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Funcionalidad Funcionalidad { get; set; }

        public AccesoAURL()
        {
            
        }

        public AccesoAURL(int id, Funcionalidad funcionalidad, string url)
        {
            this.Funcionalidad = funcionalidad;
            this.Url = url;
            this.Id = id;
        }        
    }
}
