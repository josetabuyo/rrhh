using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class EstadoCivil
    {
        public int Id;
        public string Descripcion;

        public EstadoCivil()
        {

        }

        public EstadoCivil(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }


    }
}
