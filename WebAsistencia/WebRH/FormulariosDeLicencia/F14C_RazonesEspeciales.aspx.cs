#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    private ConceptoDeLicencia _Concepto;

    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = this.Titulo();
        ((Label)this.Master.FindControl("LResumenNormativa")).Text = this.Normativa();
        ((Label)this.Master.FindControl("LProcedimiento")).Text = Procedimiento();
        //this.TextBox1.Attributes.Add("onkeyup", "javascript:activarSubmit(" + this.TextBox1.ClientID + "," + this.TBDesde.ClientID + "," + this.AceptarCancelar1.BotonAceptar.ClientID + ");");
        this.AceptarCancelar1.PuedeAceptar = false;
        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 30;

        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);
    }

    private string Titulo()
    {
        return "Solicitud de Justificación de Inasistencia por Razones Especiales (Decreto 3.413/79 - Anexo I - Cap. III - Art. 14 c) ";
    }

    private string Normativa()
    {
        return @"<b>Art. 14</b> Los agentes tienen derecho a la justificación con goce de haberes de las inasistencias en que incurran por las siguientes causas, y con las limitaciones que en cada caso se establecen:<br>
<b>c) Razones especiales.</b> Inasistencias motivadas por fenómenos meteorológicos y casos de fuerza mayor, debidamente comprobados. ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }


    #endregion

    #region LogicaDeEventos

    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        Licencia l = new Licencia();
        l.Desde = DateTime.Parse(this.TBDesde.Text);
        l.Hasta = DateTime.Parse(this.TBDesde.Text);
        l.Concepto = _Concepto;
        l.Persona = (Persona)Session["persona"];
        l.Persona.Area = (Area)Session["areaActual"];
        l.Auditoria = new Auditoria();
        l.Auditoria.UsuarioDeCarga = (Usuario)Session["usuario"];

        try
        {
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            string error = s.CargarLicencia(l);
            if (error == null)
            {
                Response.Redirect("~\\Principal.aspx");
            }
            else
            {
                ((Label)this.Master.FindControl("LError")).Text = error;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }
    }

    protected void BCalendarioDesde_Click(object sender, EventArgs e)
    {
        this.Calendar1.Visible = !this.Calendar1.Visible;
        if (this.Calendar1.Visible)
        {
            this.AceptarCancelar1.PuedeAceptar = false;
        }
        else
        {
            ValidarDatos();
        }
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.TBDesde.Text = Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;
        this.ValidarDatos();

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }


    private void ValidarDatos()
    {
        bool DatosValidos = true;

        if (this.TBDesde.Text == null)
            DatosValidos = false;

        if (this.TBRazones.Text == "" || this.TBDesde.Text == "")
            DatosValidos = false;

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }
    #endregion

}
