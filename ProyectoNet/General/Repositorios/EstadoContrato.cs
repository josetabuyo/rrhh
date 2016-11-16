using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class EstadoContrato
    {
        public EstadoContrato()
        {

        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string NombreCorto { get; set; }

        public int Orden { get; set; }
    }
}
