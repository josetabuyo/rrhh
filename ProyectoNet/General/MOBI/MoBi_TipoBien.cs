using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MoBi_TipoBien
    {
        protected int _Id;
        protected string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
