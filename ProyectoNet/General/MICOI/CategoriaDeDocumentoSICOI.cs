namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CategoriaDeDocumentoSICOI
    {
        private int _id;
        private string _descripcion;

        public int Id { get { return _id; } set { _id = value; } }
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }


        public CategoriaDeDocumentoSICOI()
        {

        }

        public CategoriaDeDocumentoSICOI(int id, string descripcion)
        { 
            this._id = id;
            this._descripcion = descripcion;
        }

    }
}
