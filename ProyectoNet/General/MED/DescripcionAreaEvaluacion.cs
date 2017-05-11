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

        public DescripcionAreaEvaluacion(string jurisdiccion, string secretaria, string sub_secretaria, string direccion, string unidad)
        {
            this.jurisdiccion = jurisdiccion;
            this.secretaria = secretaria;
            this.sub_secretaria = sub_secretaria;
            this.direccion = direccion;
            this.unidad = unidad;
        }


        public DescripcionAreaEvaluacion()
        {
        }
    }
}

