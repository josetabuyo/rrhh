using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FiltroDeDocumentosPorTipoDocumento : FiltroDeDocumentos
    {
        private int idTipo;

        public FiltroDeDocumentosPorTipoDocumento(Dictionary<String, String> filtroDto)
        {
            idTipo = int.Parse(filtroDto["idTipo"]);
        }
        public FiltroDeDocumentosPorTipoDocumento(int _idTipo)
        {
            idTipo = _idTipo;
        }

        public override bool aplicaPara(Documento documento)
        {
            return documento.tipoDeDocumento.Id == idTipo;
        }
    }
}

