#region

using System;

#endregion

public partial class FormulariosDeLicencia_MPAusentesConAviso : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }
}
