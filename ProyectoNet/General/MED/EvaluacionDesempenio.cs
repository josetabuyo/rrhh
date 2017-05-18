using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class EvaluacionDesempenio
    {
        public NivelEvaluacionDesempenio nivel { get; set; }
        public AgenteEvaluacionDesempenio agente_evaluado { get; set; }
        public AgenteEvaluacionDesempenio agente_evaluador { get; set; }

        public PeriodoEvaluacion periodo { get; set; }

        public int id_evaluacion { get; set; }
        public int estado_evaluacion { get; set; }
        public int puntaje { 
            get { 
                return this.detalle_preguntas.Sum(p => p.opcion_elegida); 
            } 
            set { 
                 
            } 
        }
        public string calificacion { get { return this.nivel.CalificacionPara(this.puntaje); } set { return; } }

        public DescripcionAreaEvaluacion area { get; set; }

        public List<DetallePreguntas> detalle_preguntas { get; set; }

        public EvaluacionDesempenio(AgenteEvaluacionDesempenio agente_evaluado, AgenteEvaluacionDesempenio agente_evaluador, int id_evaluacion, int estado_evaluacion,
            PeriodoEvaluacion periodo, NivelEvaluacionDesempenio nivel, List<DetallePreguntas> detalle_preguntas, DescripcionAreaEvaluacion area)
        {
            this.agente_evaluado = agente_evaluado;
            this.agente_evaluador = agente_evaluador;
            this.id_evaluacion = id_evaluacion;
            this.estado_evaluacion = estado_evaluacion;
            this.periodo = periodo;
            this.area = area;
            this.nivel = nivel;
            this.detalle_preguntas = detalle_preguntas;
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

        public EvaluacionDesempenio()
        {
            // TODO: Complete member initialization
        }

        public bool Es(int idEvaluacion)
        {
            return idEvaluacion.Equals(this.id_evaluacion);
        }
    }
}
