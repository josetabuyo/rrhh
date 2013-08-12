namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public class FiltroDeDocumentosPorFechaDesde : FiltroDeDocumentos
    {
        private DateTime fechaDesde;

        public FiltroDeDocumentosPorFechaDesde(Dictionary<String, String> filtroDto)
        {
            fechaDesde = DateTime.ParseExact(filtroDto["fechaDesde"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
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

