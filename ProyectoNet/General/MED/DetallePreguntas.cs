using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class DetallePreguntas
    {
        public int id_pregunta { get; set; }
        public int orden_pregunta { get; set; }
        public int opcion_elegida { get; set; }
        public string enunciado { get; set; }
        public string factor { get; set; }
        public string rpta1 { get; set; }
        public string rpta2 { get; set; }
        public string rpta3 { get; set; }
        public string rpta4 { get; set; }
        public string rpta5 { get; set; }

        public DetallePreguntas()
        {
        }

        public DetallePreguntas(int id_pregunta, int orden_pregunta, int opcion_elegida, string enunciado, string rpta1, 
            string rpta2, string rpta3, string prta4, string rpta5, string factor)
        {
            // TODO: Complete member initialization
            this.id_pregunta = id_pregunta;
            this.orden_pregunta = orden_pregunta;
            this.opcion_elegida = opcion_elegida;
            this.enunciado = enunciado;
            this.rpta1 = rpta1;
            this.rpta2 = rpta2;
            this.rpta3 = rpta3;
            this.rpta4 = prta4;
            this.rpta5 = rpta5;
            this.factor = factor;
        }

        public string RespuestaElegida()
        {
            switch (this.opcion_elegida)
            {
                case 1:
                    return rpta1;
                case 2:
                    return rpta2;
                case 3:
                    return rpta3;
                case 4:
                    return rpta4;
                case 5:
                    return rpta5;
                default:
                    return "No hay respuesta elegida";
                    break;
            }
        }
    }
}
