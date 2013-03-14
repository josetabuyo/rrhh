using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FiltroDeDocumentosPorTransicion : FiltroDeDocumentos
    {
        private Mensajeria mensajeria;
        private int idAreaOrigen;
        private int idAreaDestino;

        public FiltroDeDocumentosPorTransicion(Dictionary<String, String> filtroDto, Mensajeria _mensajeria)
        {
            idAreaOrigen = int.Parse(filtroDto["idAreaOrigen"]);
            idAreaDestino = int.Parse(filtroDto["idAreaDestino"]);
            mensajeria = _mensajeria;
        }

        public FiltroDeDocumentosPorTransicion(Mensajeria una_mensajeria, int id_area_origen, int id_area_destino)
        {
            mensajeria = una_mensajeria;
            idAreaOrigen = id_area_origen;
            idAreaDestino = id_area_destino;
        }

        public override bool aplicaPara(Documento documento)
        {
            return mensajeria.HistorialDetransicionesPara(documento).Any(t=> t.AreaOrigen.Id == idAreaOrigen && t.AreaDestino.Id == idAreaDestino);
        }
    }
}

