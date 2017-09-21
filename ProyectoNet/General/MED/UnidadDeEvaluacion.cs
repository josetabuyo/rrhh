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


        public UnidadDeEvaluacion(int id, string codigo)
        {
            this.Id = id;
            this.Codigo = codigo;
        }

        public UnidadDeEvaluacion()
        {
        }

        public static UnidadDeEvaluacion Nulio()
        {
            var instancia = new UnidadDeEvaluacion();
            instancia.Id = 0;
            instancia.Codigo = String.Empty;
            return instancia;
        }
    }
}
