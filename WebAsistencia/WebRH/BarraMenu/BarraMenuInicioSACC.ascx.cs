using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Configuration;

public partial class BarraMenuInicioSACC : System.Web.UI.UserControl
{

    public String UrlEstilos { get; set; }
    public String UrlImagenes { get; set; }
    public String Feature { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {        
        try
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            this.LabelUsuario.Text = usuario.NombreDeUsuario;
            this.LabelUsuario.Text = usuario.NombreDeUsuario;
            ConfigurarBarraDeNavegacion();
        }
        catch (Exception)
        {
            Response.Redirect("~\\Login.aspx");
        } 
    }

    protected void VolverAInicioLinkButton_Click(object sender, EventArgs e)
    {
        {
            Response.Redirect("~\\SeleccionDeArea.aspx");
        }
    }

    protected void CerrarSessionLinkButton_Click(object sender, EventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }
    }

    protected void SolicitarViaticoLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\FormularioDeViaticos\\FCargaComisionDeServicio.aspx");
    }

    protected void DetalleDeViaticoLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\FormularioDeViaticosAprobacion\\FControlDeAprobacion.aspx");
    }

    private void VisibilidadDeLosBotonesDeViaticos(bool son_visibles)
    {
        //SolicitarViaticoLinkButton.Visible = false;// son_visibles;
        //DetalleDeViaticoLinkButton.Visible = false;// son_visibles;
    }

    private void ConfigurarBarraDeNavegacion()
    {
        if (EstaEnModoDesarrollo())
            VisibilidadDeLosBotonesDeViaticos(true);
        else
            HabilitarBotonesSegunUsuario();
    }


    private void HabilitarBotonesSegunUsuario()
    {
        Usuario usuario = ((Usuario)Session["usuario"]);

        var el_usuario_puede_ver_los_botones = (usuario.NombreDeUsuario.Contains("fmiranda") || usuario.NombreDeUsuario.Contains("mnovoa") || usuario.NombreDeUsuario.Contains("UsuDir") || usuario.NombreDeUsuario.Contains("UsuDirGral") || usuario.NombreDeUsuario.Contains("UsuSecre") || usuario.NombreDeUsuario.Contains("UsuViat"));
        VisibilidadDeLosBotonesDeViaticos(el_usuario_puede_ver_los_botones);

    }

    private bool EstaEnModoDesarrollo()
    {
        string development_key = ConfigurationManager.AppSettings["developmentMode"];
        return development_key.Equals("afkr73p21");
    }
}