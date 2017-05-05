using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DDJJ104_Consulta
    {
        public int id { get; set; }        
        public int mes { get; set; }        
        public int anio { get; set; }        
        public Area area_generacion { get; set; } 
        public string fecha_generacion { get; set; }
        public string usuario_generacion { get; set; }
        public bool recepcionada { get; set; }
        public string fecha_recibido { get; set; }
        public string usuario_recibido { get; set; }
        public string firmante { get; set; }
        public Persona persona { get; set; }
        public string mod_contratacion { get; set; }
        public int estado { get; set; }
        public string estado_descrip { get; set; }
    }
}
