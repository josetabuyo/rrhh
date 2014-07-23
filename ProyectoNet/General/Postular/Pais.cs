using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Pais
    {
        public int Id;
        public string Descripcion;
        public Pais()
        {

        }
        public Pais(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
