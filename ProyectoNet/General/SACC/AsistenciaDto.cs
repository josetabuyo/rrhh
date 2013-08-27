using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaDto
    {
        public int IdAlumno { get; set; }
        public int IdCurso { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        
        public AsistenciaDto(int id_alumno, int id_curso, DateTime fecha, int valor, string descripcion)
        {
            this.IdAlumno = id_alumno;
            this.IdCurso = id_curso;
            this.Fecha = fecha;
            this.Valor = valor;
            this.Descripcion = descripcion;
        }
        public AsistenciaDto()
        {

        }
    }
}