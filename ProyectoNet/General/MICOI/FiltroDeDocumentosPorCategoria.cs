namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorCategoria : FiltroDeDocumentos
    {
        private int idCategoria;
        public FiltroDeDocumentosPorCategoria(Dictionary<String, String> filtroDto)
        {
            idCategoria = int.Parse(filtroDto["idCategoria"]);
        }

        public FiltroDeDocumentosPorCategoria(int _idCategoria)
        {
            idCategoria = _idCategoria;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.categoriaDeDocumento.Id == idCategoria;
        }
    }
}

