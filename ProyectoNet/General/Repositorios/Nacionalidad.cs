using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class Nacionalidad
    {
        public int Id;
        public string Descripcion;

        public Nacionalidad()
        {

        }

        public Nacionalidad(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
