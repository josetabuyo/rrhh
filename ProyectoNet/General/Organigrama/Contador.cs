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
        public string DescripcionGrafico { get; set; }
        public int Orden { get; set; }

        public List<Dotacion> Personas { get; set; }
        public List<PersonaContrato> PersonasContrato { get; set; }
        
       
        public Contador() { }

        public Contador(int id, string descripcion, string descripcionGrafico)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Personas = new List<Dotacion>();
            this.DescripcionGrafico = descripcionGrafico;
        }
        public Contador(int id, string descripcion, string descripcionGrafico, int orden)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Personas = new List<Dotacion>();
            this.Orden = orden;
            this.DescripcionGrafico = descripcionGrafico;
        }
        public Contador(int id, string descripcion, string descripcionGrafico, int orden,string algo)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.PersonasContrato = new List<PersonaContrato>();
            this.Orden = orden;
            this.DescripcionGrafico = descripcionGrafico;
        }
        
    }
}
