using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class TransicionDeDocumentoDTO
{
    public TransicionDeDocumentoDTO(TransicionDeDocumento t)
    {
        areaOrigen = t.AreaOrigen.NombreConAlias();
        areaDestino = t.AreaDestino.NombreConAlias();
        fecha = t.Fecha.ToString("dd/MM/yyyy");
    }

    public string areaOrigen { get; set; }
    public string areaDestino { get; set; }
    public string fecha { get; set; }
}
