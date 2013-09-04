namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeDocumentosPorComentarios : FiltroDeDocumentos
    {
        private string comentarios;

        public FiltroDeDocumentosPorComentarios(Dictionary<String, String> filtroDto)
        {
            comentarios = filtroDto["comentarios"];
        }

        public FiltroDeDocumentosPorComentarios(string _comentarios)
        {
            comentarios = _comentarios;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.comentarios.Contains(comentarios);
        }
    }
}

