using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ClaveValor
    {
        public string clave;
        public string valor;

        public ClaveValor()
        {
            this.clave = "";
            this.valor = "";
        }

        public ClaveValor(string clave, string valor)
        {
            this.clave = clave;
            this.valor = valor;
        }
    }
}
