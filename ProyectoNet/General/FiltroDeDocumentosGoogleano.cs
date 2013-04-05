  using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

namespace General
{
    public class FiltroDeDocumentosGoogleano : FiltroDeDocumentos
    {
        private string Criterio;
     
        
        public FiltroDeDocumentosGoogleano(Dictionary<String, String> filtroDto)
        {
            Criterio = filtroDto["criterio"];
        }

        public FiltroDeDocumentosGoogleano(string criterio)
        {
            Criterio = criterio;
        }

        public override bool aplicaPara(Documento documento)
        {
       
            return Criterio.Split(' ').All(p => documento.extracto.ToUpper().Trim().Contains(p.ToUpper().Trim())) || documento.numero.Contains(Criterio) || documento.ticket.ToUpper().Contains(Criterio.ToUpper()) || documento.tipoDeDocumento.descripcion.ToUpper().Contains(Criterio.ToUpper()) || documento.categoriaDeDocumento.descripcion.ToUpper().Contains(Criterio.ToUpper());
       

        }           



    }
}
