using System;
using System.Collections.Generic;

namespace General
{
    public class EstructuraDeEvaluacion
    {
        
        private  int _id;
        private string _descripcion;
        private List<InstanciasDeEvaluacion> _instanciasDeEvaluaciones;
            

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
       
       
        
        public EstructuraDeEvaluacion()
        { }

        public EstructuraDeEvaluacion(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }       
    }
}
