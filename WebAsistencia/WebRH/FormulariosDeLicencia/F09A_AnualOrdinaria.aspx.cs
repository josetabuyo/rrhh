#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Text;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    //tener cuidado con los nombres de los pdf porque al poner \u00A0Anual\u00A0Ordinaria para escapear los espacios
    //el nombre no esta correctamente generado y se rompe la apertura del pdf si se requiere abrir con un firefox,
    //pero lo descarga bien si se descarga como pdf y luego se abre. Si se requiere que ande con ambos no se debe
    //usar este escape, poner un guion bajo en su lugar.
    private ConceptoDeLicencia _Concepto;
    private String pathPdfTemplate = "\\Licenciaspdf\\Licencia Anual Ordinaria.pdf";// path del pdf que se rellenara
    private String nombrePdf = "Licencia\u00A0Anual\u00A0Ordinaria.pdf";// nombre del pdf que se generara
    
    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = Titulo();
        ((Label)this.Master.FindControl("LResumenNormativa")).Text = Normativa();
        ((Label)this.Master.FindControl("LProcedimiento")).Text = Procedimiento();
        ((Label)this.Master.FindControl("LAclaracion")).Text = Aclaracion();
        this.AceptarCancelar1.PuedeAceptar = false;
        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);
        this.DesdeHasta1.CambioFecha += new EventHandler(DesdeHasta1_CambioFecha);
        this.DesdeHasta1.DesplegoCalendario += new EventHandler(DesdeHasta1_DesplegoCalendario);
        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 1;
        this.SaldoOrdinaria1.Concepto = _Concepto;
    }

    private string Titulo()
    {
        return @"Solicitud de Licencia Anual Ordinaria (Decreto 3.413/79 - Anexo I - Cap. II - Art 9)";
    }

    private string Aclaracion()
    {
        return @"* La cantidad de dias disponibles está sujeta a modificación ante licencias solicitadas anteriormente y que se encuentran pendientes de recepción ó procesamiento en la Dirección General de Recursos Humanos y Organización.";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"La <b>licencia anual ordinaria</b> se acordará por año vencido.<br>
El período de licencia se otorgará con goce íntegro de haberes.<br>
El término de esta licencia será fijado en relación con la antigüedad que registre el agente al 31 de diciembre del año al que corresponda el beneficio.<br>
A pedido del interesado y siempre que por razones de servicio lo permitan, esta licencia podrá fraccionarse en dos (2) períodos.<br>
Los períodos en que el agente no preste servicios por hallarse en uso de licencia por afecciones o lesiones de largo tratamiento, accidentes de trabajo o enfermedad profesional, y las sin goce de sueldo —excluida la licencia por maternidad— no generan derecho a licencia anual ordinaria.<br>
ESTA SOLICITUD DEBE SER RECIBIDA EN LA DIRECCION DE ADMINISTRACIÓN DE PERSONAL 15 DIAS ANTES DEL INICIO DEL PERIODO DE LICENCIA QUE SE AUTORICE. ";

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
                //ver redirect en el cliente
                //Response.Redirect("~\\Principal.aspx");
                //genero el pdf como respuesta
                this.GenerarPdf(this.pathPdfTemplate, this.nombrePdf, System.Web.HttpContext.Current.Response, l);
            }
            else
            {
                ((Label)this.Master.FindControl("LError")).Text = error;
            }
        }
        catch (Exception exception)
        {
            ((Label)this.Master.FindControl("LError")).Text = exception.ToString();
            //Response.Redirect("~\\Principal.aspx");
        }
    }

    void DesdeHasta1_DesplegoCalendario(object sender, EventArgs e)
    {
        this.AceptarCancelar1.PuedeAceptar = false;
    }

    void DesdeHasta1_CambioFecha(object sender, EventArgs e)
    {
        this.ValidarDatos();
        this.SaldoOrdinaria1.DiasSolicitados = this.DesdeHasta1.DiasEntreFechas();
    }

    protected void RBOtorgada_CheckedChanged(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    protected void RBDenegada_CheckedChanged(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;
        
        if (!this.DesdeHasta1.ValidarFechas())
            DatosValidos = false;

        if (this.DesdeHasta1.DiasEntreFechas() > this.SaldoOrdinaria1.DiasDisponibles)
            DatosValidos = false;

        if (!this.RBOtorgada.Checked && !this.RBDenegada.Checked)
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
        //para armar la lista de periodos disponibles
        StringBuilder sb = new StringBuilder();

        //lleno el diccionario  
      
        //obtengo la fecha actual del server, posteriormente tomo solo la parte de la fecha
        //tambien se puede usar "MM/dd/yyyy" para que me retorne exactamente esa cantidad de digitos
              
        dic.Add("nyap", l.Persona.Apellido+", "+l.Persona.Nombre);
        dic.Add("dni", Convert.ToString(l.Persona.Documento));
        dic.Add("area", l.Persona.Area.Nombre);
        dic.Add("d2", l.Desde.ToShortDateString());
        dic.Add("d3", l.Hasta.ToShortDateString());
        dic.Add("fechaSolicitud", (DateTime.Now.Date).ToString("d"));          
        if (this.RBOtorgada.Checked)
            dic.Add("grupo1", "op1");
        else
            dic.Add("grupo1", "op2");

        dic.Add("daño", Convert.ToString(this.DesdeHasta1.DiasEntreFechas()));//idContenido.Text
        //obtengo la lista de periodos disponibles
        //la cantidad maxima que se puede mostrar en el pdf es 8, si se agregan mas lineas se mostrara un slide para indicar eso
        SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
        foreach (SaldoLicenciaDetalle detalle in saldo.Detalle)
        {            
            //???en realidad los detalles deberian solo contener una lista de periodos que tengan dias disponibles >0
            //porque sino no seria un saldo de licencia, o capaz que tenga una lista completa de TODOS los periodos
            //posibles desde su incorporacion
            if (detalle.Disponible > 0)
            {     
                sb.AppendFormat("Periodo {0}: {1} Días\n", Convert.ToString(detalle.Periodo), Convert.ToString(detalle.Disponible));
             
            }
        }
        dic.Add("periodos", sb.ToString());
        //en caso de que sean mas de 8 lineas agregar un mensaje indicativo!!!!!

        rellenador.FillPDF(Server.MapPath("~") + pathPdfTemplate, nombrePdf, dic, respuestaHTTP);
           
    
    }


}
