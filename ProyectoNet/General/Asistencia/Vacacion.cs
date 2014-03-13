using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class Vacacion
    {
        public Vacacion()
        {
           
        }

        public abstract int Dias { get; set; }
        public abstract int Concepto { get; set; }
        public abstract Persona Persona { get; set; }
        public abstract Periodo Periodo { get; set; }
    }
}
