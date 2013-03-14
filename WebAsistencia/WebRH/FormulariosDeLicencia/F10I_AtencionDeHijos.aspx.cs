#region

using System;
using System.Threading;
using System.Web.UI.WebControls;
using WSViaticos;

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
        _Concepto.Id = 11;


        //this.TextBox1.Attributes.Add("onkeyup", "javascript:activarSubmit(" + this.TextBox1.ClientID + "," + this.TBDesde.ClientID + "," + this.TextBox2.ClientID + "," + this.AceptarCancelar1.BotonAceptar.ClientID + ");");
        //this.TextBox2.Attributes.Add("onkeyup", "javascript:activarSubmit(" + this.TextBox1.ClientID + "," + this.TBDesde.ClientID + "," + this.TextBox2.ClientID + "," + this.AceptarCancelar1.BotonAceptar.ClientID + ");");

    }

    private string Titulo()
    {
        return @"Solicitud de Licencia Especial por Atención de hijos menores (Decreto 3.413/79 - Anexo I - Cap. III - Art. 10 i ) (CCT - Art. 142) ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"De acuerdo a lo especificado por el <b>Art. 10, inciso i) del Decreto 3.413/79 (Anexo I - Cap. III) y por el Convenio Colectivo de Trabajo en su Art. 142:</b><br>
El agente (varón o mujer) que tenga hijos menores de edad, en caso de fallecer la madre, madrastra, padre o tutor de los menores, tendrá derecho a <b>treinta (30)</b> días corridos de licencia, sin perjuicio de la que le pueda corresponder por fallecimiento. ";

    }

    #endregion

    #region LogicaDeEventos

    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        Licencia l = new Licencia();
        l.Desde = DateTime.Parse(this.TBDesde.Text);
        l.Hasta = l.Desde;
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
                Response.Redirect("~\\Principal.aspx", false);
            }
            else
            {
                ((Label)this.Master.FindControl("LError")).Text = error;
            }
        }
        catch (ThreadAbortException)
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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

        this.TBDesde.Text = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = !this.Calendar1.Visible;
        if (this.Calendar1.Visible)
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();

    }

    protected void TBApellido_TextChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }
    protected void TBDocumento_TextChanged(object sender, EventArgs e)
    {
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

        switch (this.TBApellido.Text)
        {
            case null:
                DatosValidos = false;
                break;
            case "":
                DatosValidos = false;
                break;
        }

        switch (this.TBDocumento.Text)
        {
            case null:
                DatosValidos = false;
                break;
            case "":
                DatosValidos = false;
                break;
        }

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }

    #endregion




}
