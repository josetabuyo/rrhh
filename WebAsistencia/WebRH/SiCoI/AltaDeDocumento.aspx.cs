using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebRhUI;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class AltaDeDocumento : System.Web.UI.Page
{
    private Usuario usuarioLogueado;
    protected void Page_Load(object sender, EventArgs e)
    {
        usuarioLogueado = ((Usuario)Session[ConstantesDeSesion.USUARIO]);
      
        var ws = new WSViaticosSoapClient();

        this.ListaAreas.Value = ws.AreasFormalesConInformales_JSON();
        this.TiposDeDocumento.Value = JsonConvert.SerializeObject(ws.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion));
        this.CategoriasDeDocumento.Value = JsonConvert.SerializeObject(ws.CategoriasDocumentosSICOI().OrderBy(cd => cd.descripcion));

        var areas_usuario = ws.AreasAdministradasPor(usuarioLogueado);

        var areaDelUsuarioDTO = new
        {
            id = areas_usuario[0].Id,
            descripcion = areas_usuario[0].Nombre
        };
        AreaDelUsuario.Value = JsonConvert.SerializeObject(areaDelUsuarioDTO);
    }    
}
