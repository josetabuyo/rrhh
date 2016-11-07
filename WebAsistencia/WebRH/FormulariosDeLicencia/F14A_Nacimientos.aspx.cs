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
    private String pathPdfTemplate = "\\Licenciaspdf\\Inasistencia por Nacimiento.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Inasistencia\u00A0por\u00A0Nacimiento.pdf";// nombre del pdf que se generara

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
        _Concepto.Id = 27;
    }



    private string Titulo()
    {
        return @"Solicitud de Justificación de Inasistencia por Nacimiento (Decreto 3.413/79 - Anexo I - Cap. V - Art. 14 a ) (CCT - Art. 140)";
    }



    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"Art. 14 - Los agentes tienen derecho a la justificación con goce de haberes de las inasistencias en que incurran por las siguientes causas, y con las limitaciones que en cada caso se establecen <br>
<br>
a) Nacimientos.<br>
Al agente varón, por nacimiento de hijo, tres (3) días laborables.";

    }

    #endregion

    #region LogicaDeEventos

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

    private void ValidarDatos()
    {
        bool DatosValidos = true;
        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;


        if (!this.DesdeHasta1.ValidarFechas())
        {
            DatosValidos = false;
        }
        // 27 = id Nacimiento en tabla Tabla_Conceptos_Licencias
        if (!this.DesdeHasta1.DiasHabilitadosEntreFechas(27))
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
        dic.Add("categoria", l.Persona.Categoria + " " + l.Persona.Grado + " " + l.Persona.Nivel);
        dic.Add("d1", this.TBDesde.Text);
        dic.Add("fechaSolicitud", (DateTime.Now.Date).ToString("d"));
        dic.Add("d2", l.Desde.ToShortDateString());
        dic.Add("d3", l.Hasta.ToShortDateString());

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);


    }

}
