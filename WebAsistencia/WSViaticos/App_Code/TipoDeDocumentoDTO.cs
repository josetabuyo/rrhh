using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class TipoDeDocumentoDTO
{
    public TipoDeDocumentoDTO()
    {

    }
    public TipoDeDocumentoDTO(TipoDeDocumentoSICOI tipoDoc)
    {
        id = tipoDoc.Id;
        descripcion = tipoDoc.descripcion;
        sigla = tipoDoc.sigla;
    }

    public int id { get; set; }
    public string descripcion { get; set; }
    public string sigla { get; set; }
}
