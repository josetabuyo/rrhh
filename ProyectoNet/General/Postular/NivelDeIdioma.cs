using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class NivelDeIdioma
    {
        public int Id;
        public string Descripcion;

        public NivelDeIdioma()
        {

        }
        public NivelDeIdioma(int id, string desc)
        {
            this.Id = id;
            this.Descripcion = desc;
        }
    }
}
