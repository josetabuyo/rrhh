using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Campo
    {
        public Campo() {}

        public string clave { get; set; }
        public string valor { get; set; }
        public bool fijo { get; set; }

        public Campo(string clav, string val, bool fijo)
        {
            this.clave = clav;
            this.valor = val;
            this.fijo = fijo;
        }
    }
}
