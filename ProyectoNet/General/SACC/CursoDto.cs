using System;
using System.Collections.Generic;

namespace General
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Docente Docente { get; set; }
        public Materia Materia { get; set; }
        public List<HorarioDto> Horarios { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public EspacioFisico EspacioFisico { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
