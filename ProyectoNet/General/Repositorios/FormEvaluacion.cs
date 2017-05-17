using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class FormEvaluacion
    {
        public int Orden { get; set; }
        public int idPregunta { get; set; }
        public int idConcepto { get; set; }
        public string Enunciado { get; set; }
        public string Factor { get; set; }
        public int idNivel { get; set; }
        public string DescripcionNivel { get; set; }
        public string DetalleNivel { get; set; }
        public string Rta1 { get; set; }
        public string Rta2 { get; set; }
        public string Rta3 { get; set; }
        public string Rta4 { get; set; }
        public string Rta5 { get; set; }
        public string Concepto { get; set; }
        public int OpcionElegida { get; set; }


        public FormEvaluacion() { }

    }
}
