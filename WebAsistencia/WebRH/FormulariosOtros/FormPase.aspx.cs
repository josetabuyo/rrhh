#region

using System;
using WSViaticos;

#endregion

public partial class FormPase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.LPeriodo.Text = DateTime.Now.Year.ToString();
            this.LFecha.Text = DateTime.Now.ToShortDateString();
            this.LNombre.Text = ((Persona)Session["personaPase"]).Apellido + ", " + ((Persona)Session["personaPase"]).Nombre;
            this.LDocumento.Text = ((Persona)Session["personaPase"]).Documento.ToString("###,###,##0");
            this.LArea.Text = ((Area)Session["areaPase"]).Nombre;
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }
        try
        {
            this.LAreaEmisora.Text = ((Area)Session["areaActual"]).Nombre;
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
        Response.Redirect("..\\SeleccionDeArea.aspx");//("..\\Principal.aspx");
    }
    protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("..\\Principal.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\Principal.aspx");
    }
}
