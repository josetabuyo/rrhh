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
        if (usuario.TienePermisosParaSiCoI) { Response.Redirect("~/SiCoI/AltaDeDocumento.aspx"); }
        if (usuario.TienePermisosParaSACC) { Response.Redirect("~/SACC/Inicio.aspx"); }
        if (usuario.TienePermisosParaModil) { Response.Redirect("~/Modi/Modi.aspx"); }

        this.areasDelUsuarioJSON.Value = JsonConvert.SerializeObject(usuario.Areas);
    }
}