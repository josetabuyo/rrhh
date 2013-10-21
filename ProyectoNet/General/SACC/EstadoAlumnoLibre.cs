using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EstadoAlumnoLibre : EstadoDeAlumno
    {
        public override string Descripcion { get { return "Libre"; } }

        public EstadoAlumnoLibre()
        {
           
        }
 
    }
}
