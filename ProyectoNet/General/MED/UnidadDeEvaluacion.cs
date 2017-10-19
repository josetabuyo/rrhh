using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class UnidadDeEvaluacion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreArea { get; set; }


        public UnidadDeEvaluacion(int id, string codigo, string nombre_area)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.NombreArea = nombre_area;
        }

        public UnidadDeEvaluacion()
        {
        }

        public static UnidadDeEvaluacion Nulio()
        {
            var instancia = new UnidadDeEvaluacion();
            instancia.Id = 0;
            instancia.Codigo = String.Empty;
            instancia.NombreArea = String.Empty;
            return instancia;
        }
    }
}
