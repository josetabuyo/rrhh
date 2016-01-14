using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Combo
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private string _descripcion;
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public Combo(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }

        public Combo() { }
    }
}
