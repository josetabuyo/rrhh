using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Cabecera
    {        
        public int Legajo { get; set; }
        public string Agente { get; set; }
        public string CUIL { get; set; }
        public int Oficina { get; set; }
        public int Orden { get; set; }
        public string Bruto { get; set; }
        public string Neto { get; set; }
        public string Descuentos { get; set; }
        public string NivelGrado { get; set; }
        public string Area { get; set; }
        public string Domicilio { get; set; }
        public string FechaLiquidacion { get; set; }

        public Cabecera() { }


    }
}
