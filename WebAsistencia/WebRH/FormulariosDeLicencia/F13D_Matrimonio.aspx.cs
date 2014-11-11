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
        this.DesdeHasta1.CambioFecha += new EventHandler(DesdeHasta1_CambioFecha);
        this.DesdeHasta1.DesplegoCalendario += new EventHandler(DesdeHasta1_DesplegoCalendario);
        _Concepto = new ConceptoDeLicencia();

        if (this.rbMatrimonioPropio.Checked)
        {
            _Concepto.Id = 18;
        }

        if (this.rbMatrimonioDeHijo.Checked)
        {
            _Concepto.Id = 19;
        }

    }

    private string Titulo()
    {
        return @"Solicitud de Licencia Extraordinaria con goce de haberes por matrimonio del agente o de sus hijos (Decreto 3.413/79 - Anexo I - Cap. IV - Art. 13 - I -d ) (CCT - Art. 146) ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"Corresponderá licencia por 10 días laborables al agente que contraiga matrimonio. Se concederán 3 días laborables a los agentes con motivo del matrimonio de cada uno de sus hijos. En todos los casos deberá acreditarse este hecho ante la autoridad pertinente.";

    }

    #endregion

    #region LogicaDeEventos
    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        try
        {
            Licencia l = new Licencia();
            l.Desde = this.DesdeHasta1.Desde;
            l.Hasta = this.DesdeHasta1.Hasta;
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
        this.TBDesde.Text = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;
        ValidarDatos();
    }

    void DesdeHasta1_DesplegoCalendario(object sender, EventArgs e)
    {
        this.AceptarCancelar1.PuedeAceptar = false;
    }

    void DesdeHasta1_CambioFecha(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox1.Enabled = false;
        ValidarDatos();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
        this.TextBox1.Enabled = true;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }
    private void ValidarDatos()
    {
        bool DatosValidos = true;
        if (!this.DesdeHasta1.ValidarFechas())
        {
            DatosValidos = false;
        }
        if (this.TBDesde.Text == null)
        {
            DatosValidos = false;
        }
        else if (this.TBDesde.Text == "")
        {
                DatosValidos = false;
        }

        if (!this.rbMatrimonioPropio.Checked && !this.rbMatrimonioDeHijo.Checked)
        {
            DatosValidos = false;
        }



        if (this.rbMatrimonioDeHijo.Checked)
        {
            if (this.TextBox1.Text == null)
                DatosValidos = false;
            else
                if (this.TextBox1.Text == "")
                    DatosValidos = false;
        }

        if (this.rbMatrimonioPropio.Checked)
        {
            // 17 = id Matrimonio Agente en tabla Tabla_Conceptos_Licencias
            if (!this.DesdeHasta1.DiasHabilitadosEntreFechas(17))
            {
                DatosValidos = false;
            }
        }

        if (this.rbMatrimonioDeHijo.Checked)
        {
            if (this.TextBox1.Text == null || this.TextBox1.Text == "")
            {
                    DatosValidos = false;
            }
            // 27 = id Matrimonio Hijo en tabla Tabla_Conceptos_Licencias
            if (!this.DesdeHasta1.DiasHabilitadosEntreFechas(19) )
            {
                DatosValidos = false;
            }
        }

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }
    #endregion



}
