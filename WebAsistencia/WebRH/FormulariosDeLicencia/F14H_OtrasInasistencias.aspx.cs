#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    ConceptoDeLicencia _Concepto;

    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = Titulo();
        ((Label)this.Master.FindControl("LResumenNormativa")).Text = Normativa();
        ((Label)this.Master.FindControl("LProcedimiento")).Text = Procedimiento();
        this.AceptarCancelar1.PuedeAceptar = false;
        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);

        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 34;
        this.Saldo14H1.Concepto = _Concepto;

    }
    private string Titulo()
    {
        return @"Solicitud de Justificación de Inasistencia sin goce de sueldo (Decreto 3.413/79 - Anexo I - Cap. III - Art. 14 h)";
    }


    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"<b>Art. 14</b> Los agentes tienen derecho a la justificación con goce de haberes de las inasistencias en que incurran por las siguientes causas, y con las limitaciones que en cada caso se establecen:<br>
<b>h) Otras inasistencias.</b> Las inasistencias que no encuadren en ninguno de los incisos anteriores pero que obedezcan a razones atendibles, se podrán justificar <b>sin goce de sueldo</b> hasta un máximo de seis (6) días por año calendario y no más de dos (2) por mes.";

    }

    #endregion

    #region LogicaDeEventos

    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        Licencia l = new Licencia();
        l.Concepto = _Concepto;
        l.Persona = (Persona)Session["persona"];
        l.Persona.Area = (Area)Session["areaActual"];
        l.Desde = DateTime.Parse(this.TBDesde.Text);
        l.Hasta = DateTime.Parse(this.TBDesde.Text);
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
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();
    }

    protected void RBOtorgada_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

        this.TBDesde.Text = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = !this.Calendar1.Visible;
        if (this.Calendar1.Visible)
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();
    }

    protected void RBDenegada_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;

        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;

        if (!this.RBDenegada.Checked && !this.RBOtorgada.Checked)
            DatosValidos = false;

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }

    #endregion
    
}
