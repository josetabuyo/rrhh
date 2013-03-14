using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class MedioDeTransporte
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

        public MedioDeTransporte(int id, string nombre)
        {
            this._Id = id;
            this._Nombre = nombre;
        }

        public MedioDeTransporte()
        { }
    }
}
