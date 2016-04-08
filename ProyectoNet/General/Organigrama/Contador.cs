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
        public int Contador { get; set; }
       
        public Contador() { }

        public Contador(int id, string descripcion, int contador)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Contador = contador; 
        }

    }
}
