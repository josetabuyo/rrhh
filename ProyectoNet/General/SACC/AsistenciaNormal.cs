using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaNormal : Asistencia
    {
        public override DateTime Fecha { get; set; }
        public override string Descripcion { get { return "Asistencia Normal"; } }
        public override int Valor { get { return 1; } }
        public override int IdCurso { get; set; }
        public override int IdAlumno { get; set; }
        
        public AsistenciaNormal(DateTime fecha, int id_curso, int id_alumno)
        {
            this.Fecha = fecha;
            this.IdCurso = id_curso;
            this.IdAlumno = id_alumno;
        }

        public AsistenciaNormal(DateTime fecha)
        {
            this.Fecha = fecha;
        }


        
    }
}
