using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.MED
{
    public class RespuestaGetAgentesEvaluablesPor
    {
        public List<AsignacionEvaluadoAEvaluador> asignaciones;
        public bool EsAgenteVerificador { get; set; }
        public Usuario UsuarioRequest { get; set; }

        public RespuestaGetAgentesEvaluablesPor()
        {
        }

        public RespuestaGetAgentesEvaluablesPor(List<AsignacionEvaluadoAEvaluador> asignaciones, bool es_agente_verificador, Usuario usuarioRequest)
        {
            this.asignaciones = asignaciones;
            this.EsAgenteVerificador = es_agente_verificador;
            this.UsuarioRequest = usuarioRequest;
        }
    }
}
