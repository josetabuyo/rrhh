using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class EvaluacionDto
    {
        public int idInstancia { get; set; }
        public int idAlumno { get; set; }
        public int idCurso { get; set; }
        public string descripcion { get; set; } //es para la calificacion
        public DateTime _fecha { get; set; }



        public EvaluacionDto(int id_instancia, int id_alumno, int id_curso, string descripcion, DateTime fecha)
        {
            this.idInstancia = id_instancia;
            this.idAlumno = id_alumno;
            this.idCurso = id_curso;
            this.descripcion = descripcion;
            this._fecha = fecha;
        }
        public EvaluacionDto()
        {

        }
    }
}