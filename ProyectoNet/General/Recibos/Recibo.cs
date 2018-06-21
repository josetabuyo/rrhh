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


    }
}
