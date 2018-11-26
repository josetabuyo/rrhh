using General.MAU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class RespuestaGetAgentesEvaluablesParaComites
    {
        public List<AsignacionEvaluadoEvaluadorDTO> asignaciones;
        public bool EsAgenteVerificador { get; set; }
        public Usuario UsuarioRequest { get; set; }

        public RespuestaGetAgentesEvaluablesParaComites()
        {
        }

        public RespuestaGetAgentesEvaluablesParaComites(List<AsignacionEvaluadoAEvaluador> asignaciones, bool es_agente_verificador, Usuario usuarioRequest)
        {
            this.asignaciones = asignaciones.Select(x => new AsignacionEvaluadoEvaluadorDTO(x.agente_evaluado, x.periodo, x.unidad_de_evaluacion, x.evaluacion)).ToList();
            this.EsAgenteVerificador = es_agente_verificador;
            this.UsuarioRequest = usuarioRequest;
        }
    }
}
