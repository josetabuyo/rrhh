#region

using System;
using System.Web.UI.WebControls;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = Titulo();
        ((Label)this.Master.FindControl("LTituloSecundario")).Text = TituloSecundario();
    }

    private string TituloSecundario()
    {
        return "(Decreto 3.413/79 - Anexo I - Cap. VI - Art. 15 a)";
    }

    private string Titulo()
    {
        return "Franquicias - Horarios para estudiantes";
    }
}
