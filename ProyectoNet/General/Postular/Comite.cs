using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Comite
    {
        protected int _id;
        protected string _integrantes;
        protected Puesto _puesto;
        protected int _numero;
       


        public int Id { get { return _id; } set { _id = value; } }
        public string Integrantes { get { return _integrantes; } set { _integrantes = value; } }
        public Puesto Puesto { get { return _puesto; } set { _puesto = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }


        public Comite(int id, int numero, string integrantes)
        {
            this._id = id;
            this._integrantes = integrantes;
            this._numero = numero;
            
        }

        public Comite() { }

    }
}
