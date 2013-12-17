#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.loginAlertaInvalido.Visible = false;
        if (DebeValidar())
        {
            Validar(UsuarioIngresado(), PasswordIngresado());
        }
    }

    private void Validar(string nombre_usuario, string password)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        if (ws.Login(nombre_usuario, password)){
            Session[ConstantesDeSesion.USUARIO] = ws.GetUsuario(nombre_usuario);
            Response.Redirect("Menu.aspx");
        }
        else
        {
            InformarLoginIncorrecto();
        }
    }

    private void InformarLoginIncorrecto()
    {
        this.loginAlertaInvalido.Visible = true;
    }

    private bool DebeValidar()
    {
        return IngresoUsuario() && IngresoPassword();
    }

    private bool IngresoUsuario()
    {
        return !EsVacio(UsuarioIngresado());
    }

    private bool IngresoPassword()
    {
        return !EsVacio(PasswordIngresado());
    }

    private bool EsVacio(string texto)
    {
        return texto == null || texto.Equals(string.Empty);
    }

    private string UsuarioIngresado()
    {
        return Request.Form["usuario"];
    }

    private string PasswordIngresado()
    {
        return Request.Form["password"];
    }


}