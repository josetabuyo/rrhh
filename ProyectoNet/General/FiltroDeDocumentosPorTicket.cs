namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorTicket : FiltroDeDocumentos
    {
        private string ticket;

        public FiltroDeDocumentosPorTicket(Dictionary<String,String> filtroDto)
        {
            ticket = filtroDto["ticket"];
        }

        public FiltroDeDocumentosPorTicket(string _ticket)
        {
            ticket= _ticket;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.ticket.ToUpper().Contains(ticket.ToUpper());
        }
    }
}

