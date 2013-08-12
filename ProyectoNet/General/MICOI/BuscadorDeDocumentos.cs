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

            var lista_de_documentos = documentos.FindAll(documento => filtros.TrueForAll(d => d.aplicaPara(documento)));
            return lista_de_documentos;


        }
    }
}
