using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class DetalleEvaluadosPorUnidadEvaluacion
    {
        public int Destacados { get; set; }
        public int Bueno { get; set; }
        public int Regular { get; set; }
        public int Deficiente { get; set; }
        public int Provisoria { get; set; }
        public int Pendiente { get; set; }

        public DetalleEvaluadosPorUnidadEvaluacion()
        {
        }

        public DetalleEvaluadosPorUnidadEvaluacion(int destacados, int bueno, int regular, int deficiente, int provisoria, int pendiente)
        {
            this.Destacados = destacados;
            this.Bueno = bueno;
            this.Regular = regular;
            this.Deficiente = deficiente;
            this.Provisoria = provisoria;
            this.Pendiente = pendiente;
        }
    }
}
