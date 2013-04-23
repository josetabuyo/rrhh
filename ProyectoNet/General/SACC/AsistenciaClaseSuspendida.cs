using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaClaseSuspendida : Asistencia
    {
        public override DateTime Fecha { get; set; }
        public override string Descripcion { get { return "Clase Suspendida"; } }
        public override int Valor { get { return 5; } }
        public override int IdCurso { get; set; }
        public override int IdAlumno { get; set; }
        
        public AsistenciaClaseSuspendida(DateTime fecha, int id_curso, int id_alumno)
        {
            this.Fecha = fecha;
            this.IdCurso = id_curso;
            this.IdAlumno = id_alumno;
        }

        public AsistenciaClaseSuspendida(DateTime fecha)
        {
            this.Fecha = fecha;
        }


        
    }
}
