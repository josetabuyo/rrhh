using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class TipoDeViatico
    {

        private int _Id;
        private string _Descripcion;
        private int _Nivel;
        private int _Grado;

        public TipoDeViatico()
        { }

        public int Id { get { return _Id; } set { _Id = value; } }
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public int Nivel { get { return _Nivel; } set { _Nivel = value; } }
        public int Grado { get { return _Grado; } set { _Grado = value; } }

        public TipoDeViatico(int id, string nombre)
        {
            this._Id = id;
            this._Descripcion = nombre;
        }

    }
}
