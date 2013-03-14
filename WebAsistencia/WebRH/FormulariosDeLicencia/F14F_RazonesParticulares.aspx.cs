#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    private ConceptoDeLicencia _Concepto;

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
        _Concepto.Id = 32;
    }

    private string Titulo()
    {
        return @"Solicitud de Justificación de Inasistencia por Razones Particulares (Decreto 3.413/79 - Anexo I - Cap. III - Art. 14 f) Solicitud FUERA DE TERMINO (menos de 48 hs. hábiles de anticipación)";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"<b>Art. 14</b> — Los agentes tienen derecho a la justificación con goce de haberes de las inasistencias en que incurran por las siguientes causas, y con las limitaciones que en cada caso se establecen:<br>
<b>f) Razones Particulares.</b> Hasta seis (6) en días laborables por año calendario y no más de dos (2) por mes.<br>
Si el agente inasistiera sin formular previamente el pedido de justificación o si lo formulare fuera de término, la autoridad competente, previa ponderación de las razones que invoque el interesado, podrá:<br>
— Justificar las inasistencias con goce de haberes.<br>
— Justificarlas sin goce de haberes.<br>
— No justificarlas.<br>
La resolución deberá ser comunicada al agente y al servicio de personal dentro de los tres (3) días hábiles posteriores a aquél en que se hubiera producido la inasistencia. Las inasistencias justificadas sin goce de haberes se encuadrarán hasta su agotamiento en las prescripciones del inciso h) del presente artículo. (Art 14 h = Otras Inasistencias: Hasta 6 al año y no más de 2 al mes) Las que no se justifiquen darán lugar a las sanciones previstas por las disposiciones legales y reglamentarias en vigor.";
    }

    #endregion

    #region LogicaDeEventos
    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        Licencia l = new Licencia();
        l.Desde = DateTime.Parse(this.TBDesde.Text.ToString());
        l.Hasta = DateTime.Parse(this.TBDesde.Text.ToString());
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

    protected void TBDesde_TextChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.TBDesde.Text = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;
        ValidarDatos();
    }

    protected void RBJustificada_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RBSinGoce_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RBNoJustificada_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }


    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
        this.TBDesde.Text = Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;
        this.ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;
        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;

        if (!this.RBJustificada.Checked && !this.RBNoJustificada.Checked && !this.RBSinGoce.Checked)
            DatosValidos = false;

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }


    #endregion

}
