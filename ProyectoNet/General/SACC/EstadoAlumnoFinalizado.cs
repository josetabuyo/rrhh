using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EstadoAlumnoFinalizado : EstadoDeAlumno
    {
        public override string Descripcion { get { return "Finalizado"; } }

        public EstadoAlumnoFinalizado()
        {
           
        }
 
    }
}
