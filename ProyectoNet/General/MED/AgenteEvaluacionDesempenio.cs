using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class AgenteEvaluacionDesempenio
    {
        public int id;
        public string apellido;
        public string nombre;
        public int nro_documento;
        public string situacion_escalafonaria;
        public string nivel;
        public string grado;
        public string agrupamiento;
        public string puesto_o_cargo;
        public string nivel_educativo;
        public DescripcionAreaEvaluacion area;
        

        public AgenteEvaluacionDesempenio(int id, string apellido, string nombre, int nro_documento, string situacion_escalafonaria,
            string nivel, string grado, string agrupamiento, string puesto_o_cargo, string nivel_educativo, DescripcionAreaEvaluacion area)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.nro_documento = nro_documento;
            this.situacion_escalafonaria = situacion_escalafonaria;
            this.nivel = nivel;
            this.grado = grado;
            this.agrupamiento = agrupamiento;
            this.puesto_o_cargo = puesto_o_cargo;
            this.nivel_educativo = nivel_educativo;
            this.area = area;
        }

        public AgenteEvaluacionDesempenio()
        {
        }

        public static AgenteEvaluacionDesempenio Nulo()
        {
            return new AgenteEvaluacionDesempenio(0, "No Especificado", "No Especificado", 0, "No Especificado", "No Especificado", "No Especificado", "No Especificado", "No Especificado", "No Especificado", DescripcionAreaEvaluacion.Nula());
        }
    }
}
