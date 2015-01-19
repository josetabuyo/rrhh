using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public class RespuestaABusquedaDeLegajos
    {
        public List<LegajoModi> legajos;
        public string codigoDeResultado { get; set; }

        public RespuestaABusquedaDeLegajos()
        {
            this.legajos = new List<LegajoModi>();
            this.codigoDeResultado = "LEGAJO_NO_ENCONTRADO";
        }

        public RespuestaABusquedaDeLegajos(List<LegajoModi>  unos_legajos)
        {
            this.legajos = unos_legajos;
            if(this.legajos.Count>0) this.codigoDeResultado = "OK";
            else this.codigoDeResultado = "LEGAJO_NO_ENCONTRADO";
        }
    }
}
