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
        var ws = new WSViaticosSoapClient();

        if (ws.ElUsuarioTieneAccesoA(usuarioLogueado, "SICOI"))
        {
            Response.Redirect("~/SeleccionDeArea.aspx");
            return;
        }
    }    
}
