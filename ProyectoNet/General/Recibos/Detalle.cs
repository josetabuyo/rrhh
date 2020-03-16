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
        public string TipoConcepto { get; set; }/*solo lo uso en la importacion al parsear el txt a importar en las demas
        partes del codigo el tipo de concepto se une al concepto y se lo guarda en la propiedad Concepto*/

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
