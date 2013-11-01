using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Asistencia
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
        public Asistencia()
        {
            //
        }
        public Asistencia(DateTime fecha, int valor, string descripcion, int id_curso, int id_alumno)
        {
            this.Fecha = fecha;
            this.Valor = valor;
            this.Descripcion = descripcion;
            this.IdCurso = id_curso;
            this.IdAlumno = id_alumno;
        }
    }
}
