using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Selector
    {
        public int id;
        public string descripcion;

        public Selector() { }

        public Selector(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

    }
}
