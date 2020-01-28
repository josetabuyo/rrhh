using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ConfiguracionReciboDigital
    {
        public int fecha_anioInicio_ReciboDigital { get; set; }
        public int fecha_mesInicio_ReciboDigital { get; set; }
        public int fecha_anioHastaAca_RecibosHistoricos { get; set; }
        public int fecha_mesHastaAca_RecibosHistoricos { get; set; }

        public ConfiguracionReciboDigital(int fecha_anioInicio_ReciboDigital, int fecha_mesInicio_ReciboDigital, int fecha_anioHastaAca_RecibosHistoricos, int fecha_mesHastaAca_RecibosHistoricos)
        {
            this.fecha_anioInicio_ReciboDigital = fecha_anioInicio_ReciboDigital;
            this.fecha_mesInicio_ReciboDigital = fecha_mesInicio_ReciboDigital;
            this.fecha_anioHastaAca_RecibosHistoricos = fecha_mesHastaAca_RecibosHistoricos;
            this.fecha_mesHastaAca_RecibosHistoricos = fecha_anioHastaAca_RecibosHistoricos;
        }

        public ConfiguracionReciboDigital()
        {
        }

    }
}

