using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class Funcionalidad
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public Funcionalidad()
        {

        }
        public Funcionalidad(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return this.Id == ((Funcionalidad)obj).Id;
        }

    }
}
