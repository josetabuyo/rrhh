using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MED;

namespace General
{
    public class ComiteEvaluacionDesempenio
    {
        public List<IntegranteComiteEvalDesempenio> Integrantes { get; set; }
        public PeriodoEvaluacion Periodo { get; set; }
        public List<int> UnidadesEvaluacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int Id { get; set; }
    }
}
