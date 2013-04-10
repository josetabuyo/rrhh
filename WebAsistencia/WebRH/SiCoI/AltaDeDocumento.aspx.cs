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
        Sesion.VerificarSesion(this);
        usuarioLogueado = ((Usuario)Session[ConstantesDeSesion.USUARIO]);
        
        Sesion.VerificarSesion(this);

        if (!usuarioLogueado.TienePermisosParaSiCoI)//mesa de entrada
        {      
            Response.Redirect("~/SeleccionDeArea.aspx");
        }
            
        var servicio = new WSViaticos.WSViaticosSoapClient();

        this.ListaAreas.Value = servicio.AreasFormalesConInformales_JSON();
        this.TiposDeDocumento.Value = JsonConvert.SerializeObject(servicio.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion));
        this.CategoriasDeDocumento.Value = JsonConvert.SerializeObject(servicio.CategoriasDocumentosSICOI().OrderBy(cd => cd.descripcion));

        var areaDelUsuarioDTO = new
        {
            id = usuarioLogueado.Areas[0].Id,
            descripcion = usuarioLogueado.Areas[0].Nombre
        };
        AreaDelUsuario.Value = JsonConvert.SerializeObject(areaDelUsuarioDTO);
    }    
}
