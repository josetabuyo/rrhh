using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Dotacion
    {
        public int IdPersona { get; set; }
        public int Legajo { get; set; }
        public int NroDocumento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int IdSexo { get; set; }
        public string Sexo { get; set; }
        public string Nivel { get; set; }
        public int Grado { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public int IdPlanta { get; set; }
        public string Planta { get; set; }

        public Dotacion() { }

        public Dotacion(int id_persona, int legajo, int nro_documento, string apellido, string nombre, int id_sexo, string sexo, string nivel, int grado, int id_area, string area, int id_planta, string planta)
        {
            this.IdPersona = id_persona;
            this.Legajo = legajo;
            this.NroDocumento = nro_documento;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.IdSexo = id_sexo;
            this.Sexo = sexo;
            this.Nivel = nivel;
            this.Grado = grado;
            this.IdArea = id_area;
            this.Area = area;
            this.IdPlanta = id_planta;
            this.Planta = planta;
        }
    }
}
