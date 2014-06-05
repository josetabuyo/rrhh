using System;
using System.Collections.Generic;

namespace General
{
    public class CvDocenciaDto
    {
        public int Id { get; set; }
        public string Asignatura { get; set; }
        public string NivelEducativo  { get; set; }
        public string TipoActividad { get; set; }
        public string CategoriaDocente { get; set; }
        public string CaracterDesignacionterDesignacion { get; set; } //cambiado por Bel
        public string DedicacionDocente { get; set; }
        public string CargaHoraria { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Establecimiento { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }


        public CvDocenciaDto() { }
    
    }
        
    
}
