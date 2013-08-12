namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorExtracto : FiltroDeDocumentos
    {
        private string extracto;

        public FiltroDeDocumentosPorExtracto(Dictionary<String, String> filtroDto)
        {
            extracto = filtroDto["extracto"];
        }

        public FiltroDeDocumentosPorExtracto(string un_valor)
        {
            extracto = un_valor;
        }

        public override bool aplicaPara(Documento documento)
        { 
           return extracto.Split(' ').All(p => documento.extracto.ToUpper().Trim().Contains(p.ToUpper().Trim()));
        }            
    }
}

