using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MNL
{
    public class NovedadDeLiquidacion
    {
        public string Descripcion;
        public DateTime Fecha;
        public ObraSocial ObraSocial;

        public NovedadDeLiquidacion()
        {
        }

        public NovedadDeLiquidacion(string Descripcion, DateTime Fecha, ObraSocial ObraSocial)
        {
            this.Descripcion = Descripcion;
            this.Fecha = Fecha;
            this.ObraSocial = ObraSocial;
        }

        public static NovedadDeLiquidacion CambioDeObraSocial(DateTime Fecha, ObraSocial ObraSocial)
        {
            return new NovedadDeLiquidacion("Cambio de Obra Social", Fecha, ObraSocial);
        }
    }
}
