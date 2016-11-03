#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;
using System.Collections.Generic;
using System.Web;
using System.Text;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{

    ConceptoDeLicencia _Concepto;
    private String pathPdfTemplate = "\\Licenciaspdf\\Inasistencia por Fallecimiento de Familiar.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Inasistencia\u00A0por\u00A0Fallecimiento\u00A0de\u00A0Familiar.pdf";// nombre del pdf que se generara

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


        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);
        _Concepto = new ConceptoDeLicencia();
        
        if (this.rbConyugue.Checked || 
            this.rbHijo.Checked || 
            this.rbPadreMadre.Checked)
        {
            _Concepto.Id = 28;
        }

        if (this.rbHermano.Checked || 
            this.rbNieto.Checked || 
            this.rbAbuelo.Checked || 
            this.rbSuegro.Checked || 
            this.rbYerno.Checked)
        {
            _Concepto.Id = 29;
        }

    }

    private string Titulo()
    {
        return @"Solicitud de Justificación de Inasistencia por Fallecimiento de Familiar (Decreto 3.413/79 - Anexo I - Cap. V - Art. 14 b) ";
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
<b>b) Fallecimiento.</b> Por fallecimiento de un familiar, ocurrido en el país o en el extranjero, con arreglo a la siguiente escala:<br/>
1) Del cónyuge o parientes consanguíneos en primer grado: cinco (5) días laborables.<br/>
2) De parientes consanguíneos de segundo grado y afines de primero y segundo grado: tres (3) días laborables.<br/>
Los términos previstos en este inciso comenzarán a contarse a partir del día de producido el fallecimiento, del de la toma de conocimiento del mismo, o del de las exequias, a opción del agente.";
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
                //genero el pdf como respuesta
                this.GenerarPdf(this.pathPdfTemplate, this.nombrePdf, System.Web.HttpContext.Current.Response, l);
         
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

    void DesdeHasta1_DesplegoCalendario(object sender, EventArgs e)
    {
        this.AceptarCancelar1.PuedeAceptar = false;
    }

    void DesdeHasta1_CambioFecha(object sender, EventArgs e)
    {
        this.ValidarDatos();
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

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton7_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    protected void RadioButton8_CheckedChanged(object sender, EventArgs e)
    {
        ValidarDatos();
    }

    public void ValidarDatos()
    {
        bool DatosValidos = true;
        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;

        if (_Concepto.Id == 28)
        {
            if (!DesdeHasta1.DiasHabilitadosEntreFechas(_Concepto.Id))
            {
               DatosValidos = false;
            }
        }

        if (_Concepto.Id == 29)
        {
            if (!DesdeHasta1.DiasHabilitadosEntreFechas(_Concepto .Id))
            {
                DatosValidos = false;
            }
        }

        if (!this.DesdeHasta1.ValidarFechas())
        {
            DatosValidos = false;
        }

        if (!this.rbConyugue.Checked && !this.rbHijo.Checked && !this.rbPadreMadre.Checked && !this.rbAbuelo.Checked && !this.rbHermano.Checked && !this.rbNieto.Checked && !this.rbSuegro.Checked && !this.rbYerno.Checked)
        {
            DatosValidos = false;
        }

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }

    #endregion

    private void GenerarPdf(string pathPdfTemplate, string nombrePdf, System.Web.HttpResponse respuestaHTTP, Licencia l)
    {
        //diccionario donde guardar los keys y valores a llenar en los pdf
        Dictionary<string, string> dic = new Dictionary<string, string>();
        //clase que realiza el relleno del pdf
        RellenadorPdf rellenador = new RellenadorPdf();

        //lleno el diccionario  

        //obtengo la fecha actual del server, posteriormente tomo solo la parte de la fecha
        //tambien se puede usar "MM/dd/yyyy" para que me retorne exactamente esa cantidad de digitos

        dic.Add("nyap", l.Persona.Apellido + ", " + l.Persona.Nombre);
        dic.Add("dni", Convert.ToString(l.Persona.Documento));
        dic.Add("area", l.Persona.Area.Nombre);
        dic.Add("d1", this.TBDesde.Text);
        dic.Add("fechaSolicitud", (DateTime.Now.Date).ToString("d"));

        if (this.rbConyugue.Checked)
            dic.Add("grupo1", "op1");
        else
            if (this.rbHijo.Checked)
               dic.Add("grupo1", "op2");
            else
                if (this.rbPadreMadre.Checked)
                    dic.Add("grupo1", "op3");
                else
                    if (this.rbAbuelo.Checked)
                        dic.Add("grupo1", "op4");
                    else
                        if (this.rbNieto.Checked)
                            dic.Add("grupo1", "op5");
                        else
                            if (this.rbSuegro.Checked)
                                dic.Add("grupo1", "op6");
                            else
                                if (this.rbYerno.Checked)
                                    dic.Add("grupo1", "op7");
                                else //entonces esta seteado this.rbHermano.Checked
                                    dic.Add("grupo1", "op8");
                  

        dic.Add("d2", l.Desde.ToShortDateString());
        dic.Add("d3", l.Hasta.ToShortDateString());

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);


    }



}
