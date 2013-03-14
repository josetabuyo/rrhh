namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BuscadorDeDocumentos
    {
        public List<Documento> documentos;


        public BuscadorDeDocumentos(List<Documento> documentos)
        {
            this.documentos = documentos;
        }

        public List<Documento> Buscar(List<FiltroDeDocumentos> filtros)
        {
            return documentos.FindAll(documento => filtros.TrueForAll(d => d.aplicaPara(documento)));
        }
    }
}
