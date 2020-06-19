using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SimpleServlet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/x-java-jnlp-file";      

        		
		Response.Write("<?xml version='1.0' encoding='utf-8'?>");
		//TRABAJO: modificar a https://127.0.0.1:8443 para evitar la busqueda por dns para que funcione
        Response.Write("<jnlp spec='1.0+' codebase='" + Request["host"] + "'> "); //request host es https://127.0.0.1:43414

		//facu sea http o https:   out.println("<jnlp spec='1.0+' codebase='http://www.milocal.com:8080/AutofirmaJWS/' > ");
		//server:    out.println("<jnlp spec='1.0+' codebase='https://clientefirma-pc16.rhcloud.com/AutofirmaJWS/' > ");
		Response.Write("<information>");
		Response.Write("<title>Firma Digital MDS</title> ");
		Response.Write("<vendor>MDS</vendor> ");
        Response.Write("<homepage href='Login.aspx'/> ");
		Response.Write("<description>Proyecto basado en AutoFirma</description>");
		Response.Write("<description kind='short'>Firma Digital MDS</description> ");
        //modificar a Response.Write("<icon href='" + Request["host"] + "Imagenes/recibos/images.jpg' width='64' height='64'/> ");
        //porque por no encuentra el recurso en desarrollo porque se ejecuta en http y no https
        Response.Write("<icon href='" + Request["host"] + "Imagenes/recibos/images.jpg' width='64' height='64'/> ");
		Response.Write("<offline-allowed/> ");
		Response.Write("</information>");		
		Response.Write("<security>");
		Response.Write("<all-permissions/>");
		Response.Write("</security>");
		Response.Write("<update check='timeout' policy='always'/>");
		Response.Write("<resources> ");
		Response.Write("<j2se version='1.6+' />");
		Response.Write("<jar href='FirmaDigital/simple_afirma_3_4s2.jar' size='28616000 '/> ");/*nota:actualizar el tamaÃ±o en bytes cuando este todo bien*/
		Response.Write("<property name='jnlp.packEnabled' value='true'/>");
		Response.Write("</resources>");
		Response.Write("<application-desc main-class='es.gob.afirma.standalone.SimpleAfirma'>");
		Response.Write("<argument>");
		//Response.Write(request.getParameter("cadenaFirma"));
        Response.Write(Request["cadenaFirma"]);
		Response.Write("</argument>");
		Response.Write("</application-desc> ");
		Response.Write("</jnlp> ");		


    }
}