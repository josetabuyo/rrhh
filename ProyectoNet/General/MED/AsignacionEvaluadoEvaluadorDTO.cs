using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class AsignacionEvaluadoEvaluadorDTO
    {
        public int dni_agente_evaluado;
        public string apellido_agente_evaluado;
        public string nombre_agente_evaluado;
        public int periodo;
        public int id_unidad_eval;
        public string area;
        
        public EvaluacionDesempenio evaluacion;
        
        public AsignacionEvaluadoEvaluadorDTO()
        {

        }

        public AsignacionEvaluadoEvaluadorDTO(AgenteEvaluacionDesempenio agente_evaluado, PeriodoEvaluacion periodo, UnidadDeEvaluacion ue, EvaluacionDesempenio evaluacion)
        {
            this.apellido_agente_evaluado = agente_evaluado.apellido;
            this.nombre_agente_evaluado = agente_evaluado.nombre;
            this.dni_agente_evaluado = agente_evaluado.nro_documento;
            this.periodo = periodo.id_periodo;
            this.id_unidad_eval = ue.Id;
            this.area = ue.NombreArea;
            this.evaluacion = evaluacion;
        }
    }
}
