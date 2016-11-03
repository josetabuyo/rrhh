#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;
using System.Web;
using System.Text;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    ConceptoDeLicencia _Concepto;
    private String pathPdfTemplate = "\\Licenciaspdf\\Inasistencia por Integracion de mesa examinadora.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Inasistencia\u00A0por\u00A0Integracion\u00A0de\u00A0mesa\u00A0examinadora.pdf";// nombre del pdf que se generara

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
        _Concepto.Id = 33;

    }

    private string Titulo()
    {
        return @"Solicitud de Justificación de Inasistencia por Integración de mesa examinadora (Decreto 3.413/79 - Anexo I - Cap. V - Art. 14 g) ";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"Cuando el agente deba integrar mesas examinadoras en establecimientos educacionales oficiales o incorporados, o en universidades privadas reconocidas por el Gobierno Nacional, y con tal motivo se creara conflicto de horarios, se le justificarán hasta doce (12) días laborables en el año calendario. ";
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
    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
        this.TBDesde.Text = Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;
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

    private void ValidarDatos()
    {
        bool DatosValidos = true;
        if (this.TBDesde.Text == null)
            DatosValidos = false;
        else
            if (this.TBDesde.Text == "")
                DatosValidos = false;

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
        dic.Add("d1", l.Desde.ToShortDateString());
        dic.Add("fechaSolicitud", (DateTime.Now.Date).ToString("d"));

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);


    }

}
