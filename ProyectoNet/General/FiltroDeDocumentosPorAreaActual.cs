namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorAreaActual : FiltroDeDocumentos
    {
        private Mensajeria mensajeria;
        private int idArea;

        public FiltroDeDocumentosPorAreaActual(Dictionary<String, String> filtroDto, Mensajeria _mensajeria)
        {
            idArea = int.Parse(filtroDto["idArea"]);
            mensajeria = _mensajeria;
        }

        public FiltroDeDocumentosPorAreaActual(Mensajeria una_mensajeria, int id_area)
        {
            mensajeria = una_mensajeria;
            idArea = id_area;
        }

        public override bool aplicaPara(Documento documento)
        {
            return mensajeria.EstaEnElArea(documento).Id == idArea;
        }
    }
}

