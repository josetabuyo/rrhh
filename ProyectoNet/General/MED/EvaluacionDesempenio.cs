using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class EvaluacionDesempenio
    {
        public int id_evaluado { get; protected set; }
        public string apellido { get; protected set; }
        public string nombre { get; protected set; }
        public int nro_documento { get; protected set; }
        public int id_evaluacion { get; protected set; }
        public int estado_evaluacion { get; protected set; }
        public int id_periodo { get; protected set; }
        public string descripcion_periodo { get; protected set; }
        public int id_nivel { get; protected set; }
        public string descripcion_nivel { get; protected set; }
        public int deficiente { get; protected set; }
        public int regular { get; protected set; }
        public int bueno { get; protected set; }
        public int destacado { get; protected set; }
        public List<DetallePreguntas> detalle_preguntas { get; protected set; }

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
