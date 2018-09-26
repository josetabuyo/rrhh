using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Detalle
    {    
        public string Concepto { get; set; }
        public decimal Aporte { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }

        public Detalle() { }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            //agrego la cabecera
            s.Append(this.Concepto); s.Append("||");
            s.Append(this.Aporte); s.Append("||");
            s.Append(this.Descuento); s.Append("||");
            s.Append(this.Descripcion); 
           

            return s.ToString();

        } 

    }
}
