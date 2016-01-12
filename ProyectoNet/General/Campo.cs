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

        public Campo(string clav, string val)
        {
            this.clave = clav;
            this.valor = val;
        }
    }
}
