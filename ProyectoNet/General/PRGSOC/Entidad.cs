using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Entidad
    {

        public string Nombre { get; set; }
        public int Id { get; set; }
        public List<Entidad> Dependencias { get; set; }
        public int IncluyeDependencias { get; set; }

        public Entidad() { }

        public Entidad(int IdEntidad, string nombre)
        {
            this.Id = IdEntidad;
            this.Nombre = nombre;
            this.Dependencias = new List<Entidad>();

        }
    }
}

