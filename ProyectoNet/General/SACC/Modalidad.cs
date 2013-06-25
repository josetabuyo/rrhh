using System.Collections.Generic;

namespace General
{
    public class Modalidad
    {
        private int _id;
        private string _descripcion;
        private List<InstanciaDeEvaluacion> _instancias_de_evaluacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public List<InstanciaDeEvaluacion> InstanciasDeEvaluacion { get { return _instancias_de_evaluacion; } set { _instancias_de_evaluacion = value; } }

        public Modalidad()
        {
        }

        public Modalidad(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }

        public Modalidad(int id, string descripcion, List<InstanciaDeEvaluacion> instanciasDeEvaluacion)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._instancias_de_evaluacion = instanciasDeEvaluacion;
        }

    }
}
