using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaHoraTres : Asistencia
    {
        public override DateTime Fecha { get; set; }
        public override string Descripcion { get { return "Asistencia Hora Tres"; } }
        public override int Valor { get { return 3; } }
        public override int IdCurso { get; set; }
        public override int IdAlumno { get; set; }
        
        public AsistenciaHoraTres(DateTime fecha, int id_curso, int id_alumno)
        {
            this.Fecha = fecha;
            this.IdCurso = id_curso;
            this.IdAlumno = id_alumno;
        }

        public AsistenciaHoraTres(DateTime fecha)
        {
            this.Fecha = fecha;
        }


        
    }
}
