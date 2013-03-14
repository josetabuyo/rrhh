using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PlanillaMensualDto
    {
        public Curso Curso { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public List<AsistenciaDto> Asistencias { get; set; }
        public CalendarioDeCurso Calendario { get; set; }

        public PlanillaMensualDto()
        {
           
        }
    }
}
