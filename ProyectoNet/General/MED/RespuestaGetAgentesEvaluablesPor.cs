using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class RespuestaGetAgentesEvaluablesPor
    {
        public List<AsignacionEvaluadoAEvaluador> asignaciones;
        public bool EsAgenteVerificador { get; set; }

        public RespuestaGetAgentesEvaluablesPor()
        {
        }

        public RespuestaGetAgentesEvaluablesPor(List<AsignacionEvaluadoAEvaluador> asignaciones, bool es_agente_verificador)
        {
            this.asignaciones = asignaciones;
            this.EsAgenteVerificador = es_agente_verificador;
        }
    }
}
