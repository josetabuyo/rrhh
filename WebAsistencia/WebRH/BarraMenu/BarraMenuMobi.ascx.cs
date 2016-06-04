using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Configuration;


public partial class BarraMenu_BarraMenuMobi : System.Web.UI.UserControl
{
    public String UrlEstilos { get; set; }
    public String UrlImagenes { get; set; }
    public String UrlPassword { get; set; }
    public String Feature { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.FormPassword.UrlAjax = UrlPassword;

        try
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            this.LabelUsuario.Text = usuario.Alias;
        }
        catch (Exception)
        {
            Response.Redirect("~\\Login.aspx");
        }
    }

    protected void VolverAInicioLinkButton_Click(object sender, EventArgs e)
    {
        {
            Response.Redirect("~\\MenuPrincipal\\Menu.aspx");
        }
    }

    protected void CerrarSessionLinkButton_Click(object sender, EventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }
    }

}