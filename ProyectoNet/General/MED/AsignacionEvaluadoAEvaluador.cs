using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class AsignacionEvaluadoAEvaluador
    {
        public NivelEvaluacionDesempenio nivel { get; set; }
        public AgenteEvaluacionDesempenio agente_evaluado { get; set; }
        public AgenteEvaluacionDesempenio agente_evaluador { get; set; }
        public PeriodoEvaluacion periodo { get; set; }
        public EvaluacionDesempenio evaluacion { get; set; }

        public int id_periodo { get { return this.periodo.id_periodo; } set { } }
        public string descripcion_periodo { get { return this.periodo.descripcion_periodo; } set { } }
        
        public int id_evaluacion { get { return this.evaluacion.id_evaluacion; } set { } }

        public int id_evaluado { get { return this.agente_evaluado.id; } set { } }
        public string apellido_evaluado { get { return this.agente_evaluado.apellido; } set { } }
        public string nombre_evaluado { get { return this.agente_evaluado.nombre; } set { } }

        public int id_nivel { get { return this.nivel.id_nivel; } set { } }
        public string descripcion_corta_nivel { get { return this.nivel.descripcion_corta; } set { } }

        //public List<DetallePreguntas> detalle_preguntas  { get { return evaluacion.detalle_preguntas; } set { } }

        public AsignacionEvaluadoAEvaluador(AgenteEvaluacionDesempenio agente_evaluado, AgenteEvaluacionDesempenio agente_evaluador, EvaluacionDesempenio evaluacion, PeriodoEvaluacion periodo, NivelEvaluacionDesempenio nivel)
        {
            this.agente_evaluado = agente_evaluado;
            this.agente_evaluador = agente_evaluador;
            this.evaluacion = evaluacion;
            this.periodo = periodo;
            this.nivel = nivel;
        }
        public int test
        {
            get
            {
                return 2;
            }
            set
            {
            }
        }

        public AsignacionEvaluadoAEvaluador()
        {
            this.evaluacion = EvaluacionDesempenio.Nula();
            this.agente_evaluado = AgenteEvaluacionDesempenio.Nulo();
            this.agente_evaluador = AgenteEvaluacionDesempenio.Nulo();
            // TODO: Complete member initialization
        }

        public bool Es(int idEvaluacion)
        {
            return idEvaluacion.Equals(this.evaluacion.id_evaluacion);
        }
    }
}
