using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class DescripcionAreaEvaluacion
    {

        public string jurisdiccion { get; set; }
        public string secretaria { get; set; }
        public string sub_secretaria { get; set; }
        public string direccion { get; set; }
        public string unidad { get; set; }
        public string codigo_unidad_evaluacion { get; set; }
        public string nombre_area { get; set; }

        public DescripcionAreaEvaluacion(string jurisdiccion, string secretaria, string sub_secretaria, string direccion, string unidad, string nombre_area, string codigo_unidad_evaluacion)
        {
            this.jurisdiccion = jurisdiccion;
            this.secretaria = secretaria;
            this.sub_secretaria = sub_secretaria;
            this.direccion = direccion;
            this.unidad = unidad;
            this.codigo_unidad_evaluacion = codigo_unidad_evaluacion;
            this.nombre_area = nombre_area;
        }


        public DescripcionAreaEvaluacion()
        {
        }

        public static DescripcionAreaEvaluacion Nula()
        {
            return new DescripcionAreaEvaluacion("No Especificado", "No Especificado", "No Especificado", "No Especificado", "No Especificado", "No Especificado", "No Especificado");
        }
    }
}

