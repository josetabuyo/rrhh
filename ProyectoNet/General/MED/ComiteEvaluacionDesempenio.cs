using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class ComiteEvaluacionDesempenio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public PeriodoEvaluacion Periodo{ get; set; }
        public List<IntegranteComiteEvalDesempenio> Integrantes { get; set; }
        public List<UnidadDeEvaluacion> UnidadesEvaluacion { get; set; }
        public string Lugar { get; set; }
    }
}
