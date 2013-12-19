#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class _Default : System.Web.UI.Page
{
    private Usuario usuarioLogueado;
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        usuarioLogueado = ((Usuario)Session[ConstantesDeSesion.USUARIO]);

        var ws = new WSViaticosSoapClient();

        if (!ws.ElUsuarioTienePermisosPara(usuarioLogueado, "ingreso_a_menu_principal"))//mesa de entrada
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}