using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministracionDeUsuarios
{
    public class Funcionalidad
    {

        public Funcionalidad(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public string Nombre { get; set; }
        public int Id { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return this.Id == ((Funcionalidad)obj).Id;
        }

    }
}
