using System.Web.UI;

public static class Sesion
{
    public static void VerificarSesion(Page pagina)
    {
        if (pagina.Session.Count.Equals(0))
        {
            pagina.Response.Redirect("~/Login.aspx");
        }
    }
    public static void VerificarSesion(UserControl control)
    {
        if (control.Session.Count.Equals(0))
        {
            control.Response.Redirect("~/Login.aspx");
        }
    }
}