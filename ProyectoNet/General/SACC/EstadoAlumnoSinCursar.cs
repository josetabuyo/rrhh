using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EstadoAlumnoSinCursar : EstadoDeAlumno
    {
        public override string Descripcion { get { return "Sin Cursos"; } }

        public EstadoAlumnoSinCursar()
        {
           
        }
 
    }
}
