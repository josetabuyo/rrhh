using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Ciclo
    {
        private int _id;
        private string _nombre;

        public Ciclo()
        { }

        public Ciclo(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}
