using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AmbitoLaboral
    {
        public int Id;
        public string Descripcion;

        public AmbitoLaboral()
        {

        }

        public AmbitoLaboral(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
