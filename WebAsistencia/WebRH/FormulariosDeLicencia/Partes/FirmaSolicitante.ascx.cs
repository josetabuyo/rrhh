#region

using System;

#endregion

public partial class FormulariosDeLicencia_Partes_FirmaSolicitante : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label3.Text = "Fecha de la Solicitud: " + DateTime.Now.ToShortDateString();
    }
}
