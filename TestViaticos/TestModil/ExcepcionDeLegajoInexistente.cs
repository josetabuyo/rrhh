using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos.TestModil
{
    public class ExcepcionDeLegajoInexistente : Exception
    {
        public ExcepcionDeLegajoInexistente(): base("El legajo no existe")
        {
           
        }
    }
}
