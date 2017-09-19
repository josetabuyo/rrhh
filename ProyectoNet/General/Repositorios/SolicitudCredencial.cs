using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class SolicitudCredencial
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Motivo { get; set; }
        public string Organismo { get; set; }
        
        public SolicitudCredencial()
        {
                
        }

    }
}
