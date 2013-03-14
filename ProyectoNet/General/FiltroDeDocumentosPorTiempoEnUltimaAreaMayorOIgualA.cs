using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA : FiltroDeDocumentos
    {
        private Mensajeria mensajeria;
        private int dias;

        public FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA(Dictionary<String, String> filtroDto, Mensajeria _mensajeria)
        {
            dias = int.Parse(filtroDto["dias"]);
            mensajeria = _mensajeria;
        }

        public FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA(Mensajeria una_mensajeria, int _dias)
        {
            mensajeria = una_mensajeria;
            dias = _dias;
        }

        public override bool aplicaPara(Documento documento)
        {
            return mensajeria.TiempoEnElAreaActualPara(documento) >= TimeSpan.FromDays(dias);
        }
    }
}

