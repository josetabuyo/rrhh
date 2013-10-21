using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EstadoAlumnoCursando : EstadoDeAlumno
    {
        public override string Descripcion { get { return "Cursando"; } }

        public EstadoAlumnoCursando()
        {
           
        }
 
    }
}
