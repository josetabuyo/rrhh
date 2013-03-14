using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class MedioDePago
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value;  }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value;  }
        }

        public MedioDePago(int id, string nombre)
        {
            this._Id = id;
            this._Nombre = nombre;
        }

        public MedioDePago()
        { }
    }
}
