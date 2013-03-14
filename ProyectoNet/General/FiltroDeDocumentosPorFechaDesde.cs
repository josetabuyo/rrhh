namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorFechaDesde : FiltroDeDocumentos
    {
        private DateTime fechaDesde;

        public FiltroDeDocumentosPorFechaDesde(Dictionary<String, String> filtroDto)
        {
            fechaDesde = DateTime.Parse(filtroDto["fechaDesde"]);
        }

        public FiltroDeDocumentosPorFechaDesde(DateTime _fechaDesde)
        {
            fechaDesde = _fechaDesde;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.fecha.Date >= fechaDesde.Date;
        }
    }
}

