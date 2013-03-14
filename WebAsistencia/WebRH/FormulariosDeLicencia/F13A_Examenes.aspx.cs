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
        this.DesdeHasta1.CambioFecha += new EventHandler(DesdeHasta1_CambioFecha);
        this.DesdeHasta1.DesplegoCalendario += new EventHandler(DesdeHasta1_DesplegoCalendario);
        _Concepto = new ConceptoDeLicencia();
        if (this.rbSecundario.Checked)
        {
            _Concepto.Id = 14;
        }
        if (this.rbTerciario.Checked)
        {
            _Concepto.Id = 15;
        }
        
    }


    private string Titulo()
    {
        return @"Solicitud de Licencia Extraordinaria con goce de haberes para rendir exámenes (Decreto 3.413/79 - Anexo I - Cap. IV - Art. 13 - I -a ) ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"Esta licencia se concederá por un lapso máximo anual de 12 días laborables para nivel Secundario y de 28 días para niveles Terciario o Postgrado. Dentro de los cinco (5) días hábiles de producido el reintegro al servicio, el agente deberá presentar el o los comprobantes de que ha rendido examen o en su defecto, constancia que acredite haber iniciado los trámites para su obtención, extendidos por el respectivo establecimiento educacional.";

    }

    #endregion

    #region LogicaDeEventos

    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        try
        {
            Licencia l = new Licencia();
            l.Desde = DesdeHasta1.Desde;
            l.Hasta = DesdeHasta1.Hasta;
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
        CalendarExamen.Visible = !this.CalendarExamen.Visible;

        if (this.CalendarExamen.Visible)
            this.AceptarCancelar1.PuedeAceptar = false;
        else
            ValidarDatos();
    }

    protected void CalendarExamen_SelectionChanged(object sender, EventArgs e)
    {
        this.TBFechaDeExamen.Text = CalendarExamen.SelectedDate.ToShortDateString();
        CalendarExamen.Visible = false;
        ValidarDatos();
    }

    void DesdeHasta1_CambioFecha(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    void DesdeHasta1_DesplegoCalendario(object sender, EventArgs e)
    {
        ValidarDatos();
    }
    protected void rbSecundario_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void rbTerciario_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;

        if (this.rbSecundario.Checked)
	    {
            if (DesdeHasta1.DiasEntreFechas() > 3)
            {
                DatosValidos = false;
            }
	    }

        if (this.rbTerciario.Checked)
        {
            if (DesdeHasta1.DiasEntreFechas() > 6)
            {
                DatosValidos = false;
            }
        }


        if (this.TBFechaDeExamen.Text == null)
            DatosValidos = false;
        else
            if (this.TBFechaDeExamen.Text == "")
                DatosValidos = false;
            else
            {
                if (DesdeHasta1.EstaCargado())
                {
                    //En el metodo EsAnteriorA se valida a si mismo las fechas desde, hasta.
                    if (!DesdeHasta1.EsAnteriorA(DateTime.Parse(this.TBFechaDeExamen.Text)))
                        DatosValidos = false;

                    if (!DesdeHasta1.EsPosteriorA(DateTime.Parse(this.TBFechaDeExamen.Text)))
                        DatosValidos = false;
                }
                else
                {
                    DatosValidos = false;
                }
            }

        if (rbSecundario.Checked == false && rbTerciario.Checked == false)
            DatosValidos = false;
            

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }

    #endregion



}
