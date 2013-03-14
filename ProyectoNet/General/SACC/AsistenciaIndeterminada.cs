using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaIndeterminada : Asistencia
    {
        public override DateTime Fecha { get; set; }
        public override string Descripcion { get { return "Asistencia Indeterminada"; } }
        public override int Valor { get{return 0;} }
        public override int IdCurso { get; set; }
        public override int IdAlumno { get; set; }
        
        public AsistenciaIndeterminada(DateTime fecha, int id_curso, int id_alumno)
        {
            this.Fecha = fecha;
            this.IdCurso = id_curso;
            this.IdAlumno = id_alumno;
        }

        public AsistenciaIndeterminada(DateTime fecha)
        {
            this.Fecha = fecha;
        }




        
       
    }
}
