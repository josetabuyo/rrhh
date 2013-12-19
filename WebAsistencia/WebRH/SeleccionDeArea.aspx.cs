#region

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebRhUI;
using WSViaticos;
using System.Collections;
using Newtonsoft.Json;


#endregion

public partial class SeleccionDeArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        Usuario usuario = ((Usuario)Session["usuario"]);
        var ws = new WSViaticosSoapClient();
        this.areasDelUsuarioJSON.Value = JsonConvert.SerializeObject(ws.GetAreasAdministradasPorElUsuario(usuario));
    }
}