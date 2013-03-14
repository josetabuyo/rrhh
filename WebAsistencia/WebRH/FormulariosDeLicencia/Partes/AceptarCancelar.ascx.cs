#region

using System;
using System.Web.UI.WebControls;

#endregion

public partial class FormulariosDeLicencia_Partes_AceptarCancelar : System.Web.UI.UserControl
{
    private bool _PuedeAceptar;

    public bool PuedeAceptar
    {
        get { return _PuedeAceptar; }
        set
        {
            _PuedeAceptar = value;
            this.BAceptar.Enabled = value;
        }
    }

    public Button BotonAceptar
    {
        get { return this.BAceptar; }
    }


    public event EventHandler Acepto;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BAceptar_Click(object sender, EventArgs e)
    {
        this.Acepto(sender, e);
    }


    protected void BCancelar_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript> window.close();</script>");
        Response.End();
    }
}
