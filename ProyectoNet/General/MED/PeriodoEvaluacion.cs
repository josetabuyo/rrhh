using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{

    public class PeriodoEvaluacion
    {
        public int id_periodo { get; set; }
        public string descripcion_periodo { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string descripcion_tipo_periodo { get; set; }


        public PeriodoEvaluacion(int id, string descripcion, DateTime desde, DateTime hasta, string descripcion_tipo_periodo)
        {
            this.id_periodo = id;
            this.descripcion_periodo = descripcion;
            this.desde = desde;
            this.hasta = hasta;
            this.descripcion_tipo_periodo = descripcion_tipo_periodo;
        }

        public PeriodoEvaluacion()
        {
        }
    }
}
