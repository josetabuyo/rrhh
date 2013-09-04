namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorNumero : FiltroDeDocumentos
    {
        private string numero;

        public FiltroDeDocumentosPorNumero(Dictionary<String, String> filtroDto)
        {
            numero = filtroDto["numero"];
        }

        public FiltroDeDocumentosPorNumero(string un_valor)
        {
            numero = un_valor;
        }

        public override bool aplicaPara(Documento documento)
        {

            return documento.numero.Equals(numero) || documento.ticket.ToUpper().Equals(numero.ToUpper());
        }
    }
}

