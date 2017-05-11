using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class NivelEvaluacionDesempenio
    {
        public int id_nivel { get; set; }
        public string descripcion_corta { get; set; }
        public string descripcion_larga_nivel { get; set; }

        public int deficiente { get; set; }
        public int regular { get; set; }
        public int bueno { get; set; }
        public int destacado { get; set; }

        public NivelEvaluacionDesempenio(int id, string descripcion_corta, string descripcion_larga, int deficiente, int regular, int bueno, int destacado)
        {
            this.id_nivel = id;
            this.descripcion_corta = descripcion_corta;
            this.descripcion_larga_nivel = descripcion_larga_nivel;
            this.deficiente = deficiente;
            this.regular = regular;
            this.bueno = bueno;
            this.destacado = destacado;
        }

        public NivelEvaluacionDesempenio()
        {
        }
    }
}
