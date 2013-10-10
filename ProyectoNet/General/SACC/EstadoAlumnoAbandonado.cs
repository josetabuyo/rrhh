using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EstadoAlumnoAbandonado : EstadoDeAlumno
    {
        public override string Descripcion { get { return "Abandonado"; } }

        public EstadoAlumnoAbandonado()
        {
           
        }
 
    }
}
