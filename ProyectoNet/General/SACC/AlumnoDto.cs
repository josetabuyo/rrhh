using System;
using System.Collections.Generic;

namespace General
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Documento { get; set; }
        public List<Area> Areas { get; set; }
        public object Modalidad { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public string LugarDeTrabajo { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string EstadoDeCursada { get; set; }
        public string EstadoDeAlumno { get; set; }
        public int Organismo { get; set; }
        public string CicloCursado { get; set; }
        public string FechaDeIngreso { get; set; }
        public int Baja { get; set; }

        public AlumnoDto() { }
    
    }
        
    
}
