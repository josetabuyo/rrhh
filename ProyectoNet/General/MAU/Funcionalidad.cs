using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class Funcionalidad
    {
        public string Grupo { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }

        public Funcionalidad()
        {

        }
        public Funcionalidad(int id, string nombre, string grupo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Grupo = grupo;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return this.Id == ((Funcionalidad)obj).Id;
        }

        public override string ToString()
        {
            return this.Grupo + "->" + this.Nombre;
        }

    }
}
