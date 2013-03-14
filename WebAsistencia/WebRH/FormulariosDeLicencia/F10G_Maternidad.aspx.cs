#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_F10G_Maternidad : System.Web.UI.Page
{
    ConceptoDeLicencia _Concepto;

    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 9;
    } 
    #endregion

    #region LogicaDeEventos

    protected void BCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }

    protected void BAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Licencia l = new Licencia();
            l.Desde = DateTime.Today;
            l.Hasta = DateTime.Today;
            l.Concepto = _Concepto;
            l.Persona = (Persona)Session["persona"];
            l.Persona.Area = (Area)Session["areaActual"];
            l.Auditoria = new Auditoria();
            l.Auditoria.UsuarioDeCarga = (Usuario)Session["usuario"];

            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            string error = s.CargarLicencia(l);
            if (error == null)
            {
                Response.Redirect("~\\Principal.aspx");
            }
            else
            {
                ((Label)this.FindControl("LError")).Text = error;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }
    }

    #endregion
}
