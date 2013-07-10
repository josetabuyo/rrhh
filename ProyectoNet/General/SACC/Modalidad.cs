using System.Collections.Generic;

namespace General
{
    public class Modalidad
    {
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual List<InstanciaDeEvaluacion> InstanciasDeEvaluacion { get; set; }

        public Modalidad()
        {
        }

        public Modalidad(int id, string descripcion, List<InstanciaDeEvaluacion> instanciasDeEvaluacion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.InstanciasDeEvaluacion = instanciasDeEvaluacion;
        }

    }
}
