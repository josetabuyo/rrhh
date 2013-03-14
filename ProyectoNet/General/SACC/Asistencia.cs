using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class Asistencia
    {
        public abstract DateTime Fecha { get; set; }
        public abstract string Descripcion { get; }
        public abstract int Valor { get;}
        public abstract int IdCurso { get; set; }
        public abstract int IdAlumno { get; set; }

    }
}
