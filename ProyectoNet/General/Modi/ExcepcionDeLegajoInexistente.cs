using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class ExcepcionDeLegajoInexistente : Exception
    {
        public ExcepcionDeLegajoInexistente(): base("El legajo no existe")
        {
           
        }
    }
}
