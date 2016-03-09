using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Resumen
    {
        public string Id { get; set; }
        public int Cantidad { get; set; }
        public int Porcentaje { get; set; }
        

        public Resumen() { }

        public Resumen(string id, int cantidad, int porcentaje)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Porcentaje = porcentaje;       
        }
    }
}
