namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public class FiltroDeDocumentosPorFechaHasta : FiltroDeDocumentos
    {

        private DateTime fechaHasta;

        public FiltroDeDocumentosPorFechaHasta(Dictionary<String, String> filtroDto)
        {
            fechaHasta = DateTime.ParseExact(filtroDto["fechaHasta"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public FiltroDeDocumentosPorFechaHasta(DateTime fecha)
        {
            fechaHasta = fecha;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.fecha.Date <= fechaHasta.Date;
        }
    }
}

