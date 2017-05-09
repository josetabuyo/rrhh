using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class EvaluacionDesempenio
    {
        public int id_evaluado { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int nro_documento { get; set; }
        public int id_evaluacion { get; set; }
        public int estado_evaluacion { get; set; }
        public int id_periodo { get; set; }
        public string descripcion_periodo { get; set; }
        public int id_nivel { get; set; }
        public string descripcion_nivel { get; set; }
        public int deficiente { get; set; }
        public int regular { get; set; }
        public int bueno { get; set; }
        public int destacado { get; set; }
        public List<DetallePreguntas> detalle_preguntas { get; set; }

        public EvaluacionDesempenio(int id_evaluado, string apellido, string nombre, int nro_documento, int id_evaluacion, int estado_evaluacion, 
            int id_periodo, string descripcion_periodo, int id_nivel, string descripcion_nivel, int deficiente, int regular, int bueno, int destacado, List<DetallePreguntas> detalle_preguntas)
        {
            this.id_evaluado = id_evaluado;
            this.apellido = apellido;
            this.nombre = nombre;
            this.nro_documento = nro_documento;
            this.id_evaluacion = id_evaluacion;
            this.estado_evaluacion = estado_evaluacion;
            this.id_periodo = id_periodo;
            this.descripcion_periodo = descripcion_periodo;
            this.id_nivel = id_nivel;
            this.descripcion_nivel = descripcion_nivel;
            this.deficiente = deficiente;
            this.regular = regular;
            this.bueno = bueno;
            this.destacado = destacado;
            this.detalle_preguntas = detalle_preguntas;
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
