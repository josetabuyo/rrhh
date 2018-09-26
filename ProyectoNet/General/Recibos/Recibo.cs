using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Recibo
    {
        public Cabecera cabecera { get; set; }
        public List<Detalle> detalles { get; set; }

        public Recibo()
        {
        }

        //NOTA IMPORTANTE: en este ejemplo no se guardan TODOS los datos de la cabecera del recibo y de los detalles, solo se guardan los necesarios para llenar el recibo pdf
        //en caso de querer guardar mas datos o todos , hay que definirlo
        public string getReciboParseado(Recibo r)
        {
            bool primerElem = true;
            /* 
             * |||| separador de primer nivel (cabecera, detalles) 
             * |||  separador de segundo nivel (detalle)
             * ||   separador de tercer nivel  (atributo)
               */
            StringBuilder sb = new StringBuilder();
            //agrego la cabecera
            sb.Append(cabecera.ToString());
            sb.Append("||||");
            //agrego la lista de detalles
            this.detalles.ForEach(detalle =>
            {
                //minimamente hay un elemento detalle en cualquier recibo
                if (!primerElem) {
                    sb.Append("|||");
                    primerElem = false;
                }
                //agrego un detalle
                sb.Append(detalle.ToString());
                
               
            });

            

            return sb.ToString();

        }
    }
}
