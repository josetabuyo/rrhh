using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ObservacionDTO
    {
        public int id { get; set; }
        public string FechaCarga { get; set; }
        public string Relacion { get; set; }
        public string PersonaCarga { get; set; }
        public string Pertenece { get; set; }
        public string Asunto { get; set; }
        public string ReferenteMDS { get; set; }
        public string Seguimiento { get; set; }
        public string Resultado { get; set; }
        public string FechaResultado { get; set; }
        public string ReferenteRespuestaMDS { get; set; }
    }
}
