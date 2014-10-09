using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ItemCv
    {
        public string Descripcion { get; protected set; }
        public ItemCv(string descripcion) {
            this.Descripcion = descripcion;
        }

        public ItemCv() { }
    }
}
