#region

using System;
using WSViaticos;
using System.Collections.Generic;
using System.Web;
using System.Text;

#endregion

public partial class FormPase : System.Web.UI.Page
{
    private String pathPdfTemplate = "\\Licenciaspdf\\Pase.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Pase.pdf";// nombre del pdf que se generara
    //como se requiere que se ubique el texto rellenado como un parrafo, entonces hay que armarlo por lo que se usa un texto con formato
    String texto1 = "A: DIRECCIÓN GENERAL DE RECURSOS HUMANOS Y ORGANIZACIÓN\rDe: {0}";
    String texto2 = "Se solicita a esa Dirección General efectuar el cambio de lugar de trabajo de {0}, Documento Nº {1}, quien pasa a desempeñarse en {2} a partir del dia: {3}";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {/////utilizado para pruebas harcodeadas
     /*       Area area = new Area();
            area.Nombre = "Area de Prueba general para el pase";
            area.Id = 1327;
            Session["areaPase"] = area;

            Persona agente2 = new Persona();
            agente2.Nombre = "Juan Carlos2";
            agente2.Apellido = "Testeando2";
            agente2.Documento = 297539142;
            Session["personaPase"] = agente2;*/
            /////
            this.LPeriodo.Text = DateTime.Now.Year.ToString();
            this.LFecha.Text = DateTime.Now.ToShortDateString();
            this.LNombre.Text = ((Persona)Session["personaPase"]).Apellido + ", " + ((Persona)Session["personaPase"]).Nombre;
            this.LDocumento.Text = ((Persona)Session["personaPase"]).Documento.ToString("###,###,##0");
            this.LArea.Text = ((Area)Session["areaPase"]).Nombre.ToUpper();
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }
        try
        {
            this.LAreaEmisora.Text = ((Area)Session["areaActual"]).Nombre.ToUpper();
        }
        catch (Exception)
        {
            Response.Redirect("~\\SeleccionDeArea.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();

        PaseDeArea pase = new PaseDeArea();
        pase.Persona = (Persona)Session["personaPase"];
        pase.Persona.Area = (Area)Session["areaActual"];
        pase.AreaOrigen = (Area)Session["areaActual"];
        pase.AreaDestino = (Area)Session["areaPase"];
        pase.Auditoria = new Auditoria();
        pase.Auditoria.UsuarioDeCarga = (Usuario) Session["usuario"];
        pase.Fecha = DateTime.Now;
        pase.Auditoria = new Auditoria();
        pase.Auditoria.UsuarioDeCarga = (Usuario)Session["usuario"];
        s.CargarPase(pase);
        //revizando el codigo, se ve que la carga de pase siempre retorna true por lo que directamente se genera el pdf
        //genero el pdf como respuesta
        this.GenerarPdf(this.pathPdfTemplate, this.nombrePdf, System.Web.HttpContext.Current.Response, pase);

       
    }
    protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("..\\Principal.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\Principal.aspx");
    }

    private void GenerarPdf(string pathPdfTemplate, string nombrePdf, System.Web.HttpResponse respuestaHTTP, PaseDeArea pase)
    {
        //diccionario donde guardar los keys y valores a llenar en los pdf
        Dictionary<string, string> dic = new Dictionary<string, string>();
        //clase que realiza el relleno del pdf
        RellenadorPdf rellenador = new RellenadorPdf();
        //para armar la lista de periodos disponibles
        StringBuilder cabecera = new StringBuilder();
        StringBuilder cuerpo = new StringBuilder();       

        //lleno el diccionario  

        //obtengo la fecha actual del server, posteriormente tomo solo la parte de la fecha
        //tambien se puede usar "MM/dd/yyyy" para que me retorne exactamente esa cantidad de digitos

        dic.Add("periodo", this.LPeriodo.Text); //es el año actual
        dic.Add("d1", this.LFecha.Text); // esla fecha actual
        cabecera.AppendFormat(texto1, pase.AreaOrigen);
        //la fecha es la de hoy
        cuerpo.AppendFormat(texto2, this.LNombre.Text, this.LDocumento.Text, this.LArea.Text, (DateTime.Now.Date).ToString("d"));
        dic.Add("cabecera", cabecera.ToString());
        dic.Add("cuerpo", cuerpo.ToString());

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);


    }

}
