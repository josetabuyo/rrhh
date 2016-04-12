using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Contador
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }

        public List<Dotacion> Personas { get; set; }
       
        public Contador() { }

        public Contador(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Personas = new List<Dotacion>();
        }
        public Contador(int id, string descripcion, int orden)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Personas = new List<Dotacion>();
            this.Orden = orden;
        }

    }
}
