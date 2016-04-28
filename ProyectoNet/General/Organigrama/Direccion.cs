using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Direccion
    {
        public string Calle { get; set; }
        public string CP { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }

        public Direccion()
        {
                
        }

        public Direccion(string calle, string cp, string localidad, string provincia)
        {
            this.Calle = calle;
            this.CP = cp;
            this.Localidad = localidad;
            this.Provincia = provincia;
        }
    }
}
