using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WSViaticos;


public partial class Visitas_Acreditaciones : System.Web.UI.Page
{
    private void InitDetalles()
    {
        this.divConfirmar.Visible = false;
        this.divConfirmar.Style["height"] = "1000%";
        this.divConfirmar.Style["width"] = "100%";
        this.divConfirmar.Style["position"] = "absolute";

        this.divAddPersona.Visible = false;
        this.divAddPersona.Style["height"] = "1000%";
        this.divAddPersona.Style["width"] = "100%";
        this.divAddPersona.Style["position"] = "absolute";

        this.divPersonasBusq.Visible = false;
        this.divPersonasBusq.Style["height"] = "1000%";
        this.divPersonasBusq.Style["width"] = "100%";
        this.divPersonasBusq.Style["position"] = "absolute";

    }


    private void ShowMensaje( string Titulo, string Descrip)
    {
        this.lblTituloMsj.Text = Titulo;
        this.lblDescipMsj.Text = Descrip;
        this.lbCancelar.Visible = false;
        this.lbConfirmar.Visible = false;
        this.lbAceptar.Visible = true;
        this.lbAceptar.Focus();
        this.divConfirmar.Visible = true;
    }

    private void ShowMensajeConfirmarEliminar()
    {
        this.lblTituloMsj.Text = "Confirmar:";
        this.lblDescipMsj.Text = "¿Confirma eliminar a la persona de la autorización?";
        this.lbCancelar.Visible = true;
        this.lbCancelar.Focus();
        this.lbConfirmar.Visible = true;
        this.lbAceptar.Visible = false;
        this.divConfirmar.Visible = true;
    }


    private void HideMensaje()
    {
        this.divConfirmar.Visible = false;
        if (this.divAddPersona.Visible) this.SetFocusAddPersona();
    }

    private void SetFocusAddPersona()
    {
        if (txtDoc.Enabled) txtDoc.Focus();
        else if (txtApellido.Enabled) txtApellido.Focus();
        else if (txtNombre.Enabled) txtNombre.Focus();
        else if (txtCredencial.Enabled) txtCredencial.Focus();
    }

    private void ChargeAutorizaciones()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        AutorizacionVisitaExtracto[] AutExt = ws.GetAutorizaciones(DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
        GridView_Autorizaciones.DataSource = AutExt;
        GridView_Autorizaciones.DataBind();
    }

    private void ShowAcomp()
    {
        this.divAddPersona.Visible = true;
        if (txtDoc.Enabled) txtDoc.Focus();
        this.SetFocusAddPersona();
    }

    private void HideAcomp()
    {
        this.divAddPersona.Visible = false;
    }


    private void ShowPersonasBusq()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        PersonaVisita[] aPV = ws.GetPersonasVisitas(txtApellido.Text, txtNombre.Text, (txtDoc.Text.CompareTo(string.Empty) == 0 ? 0 : Convert.ToInt32(txtDoc.Text)));
        GridView_Personas.DataSource = aPV;
        string[] dkn = new string[] { "Id" };
        GridView_Personas.DataKeyNames = dkn;
        GridView_Personas.DataBind();
        GridView_Personas.SelectedIndex = -1;
        this.divPersonasBusq.Visible = true;
        this.Button_CancelarBusqueda.Focus();
    }

    private void HidePersonasBusq()
    {
        this.divPersonasBusq.Visible = false;
        this.SetFocusAddPersona();
    }

    private void SetPersonaBusqueda()
    {
        txtNombre.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[2].Text);
        txtNombre.Enabled = false;
        txtApellido.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[3].Text);
        txtApellido.Enabled = false;
        txtDoc.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[4].Text);
        txtDoc.Enabled = false;
    }

    private void ClearPersonaSeleccionada()
    {
        txtNombre.Text = string.Empty;
        txtNombre.Enabled = true;
        txtApellido.Text = string.Empty;
        txtApellido.Enabled = true;
        txtDoc.Text = string.Empty;
        txtDoc.Enabled = true;
        this.SetFocusAddPersona();
    }

    private AcreditacionVisita CrearAcreditacionSeleccionada()
    {
        AcreditacionVisita acred = new AcreditacionVisita();
        acred.Autorizacion = new AutorizacionVisita() { Id = Convert.ToInt32(GridView_Autorizaciones.Rows[GridView_Autorizaciones.SelectedIndex].Cells[1].Text) };
        acred.Fecha = DateTime.ParseExact(DateTime.Now.ToString("yyyyMMdd"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        return acred;
    }


    private void SetPersonasAcreditacion()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        this.GridView_Acomp.DataSource = ws.getPersonasAcreditacion(this.CrearAcreditacionSeleccionada());
        this.GridView_Acomp.DataBind();
    }


    private PersonaVisita GetPersonaDefault()
    {
        int Index = GridView_Autorizaciones.SelectedIndex;
        string Apellido = Server.HtmlDecode(GridView_Autorizaciones.Rows[Index].Cells[2].Text.ToString());
        string Nombre = Server.HtmlDecode(GridView_Autorizaciones.Rows[Index].Cells[3].Text.ToString());
        int Documento = Convert.ToInt32(GridView_Autorizaciones.Rows[Index].Cells[4].Text.ToString());
        PersonaVisita perDef = new PersonaVisita() { Apellido = Apellido, Nombre = Nombre, Documento = Documento };
        return perDef;
    }

    private bool PersonaDefaultYaEstaAgregada(PersonaVisita perDef)
    {       
        foreach (GridViewRow gvr in GridView_Acomp.Rows)
            if (Server.HtmlDecode(gvr.Cells[3].Text.ToString()).CompareTo(perDef.Nombre) == 0 && Server.HtmlDecode(gvr.Cells[4].Text.ToString()).CompareTo(perDef.Apellido) == 0 && gvr.Cells[5].Text.ToString().CompareTo(perDef.Documento.ToString()) == 0)
            {
                this.ClearControlesAcomp();
                return true;
            }
        return false;
    }


    private void SetPersonaDefault()
    {
        PersonaVisita perDef = this.GetPersonaDefault();
        if (PersonaDefaultYaEstaAgregada(perDef)) return;
        this.txtApellido.Text = perDef.Apellido;
        this.txtNombre.Text = perDef.Nombre;
        this.txtDoc.Text = perDef.Documento.ToString();
        this.txtNombre.Enabled = false;
        this.txtApellido.Enabled = false;
        this.txtDoc.Enabled = false;
    }

    private bool EsPersonaValida()
    {
        if (txtApellido.Text.CompareTo(string.Empty) == 0 && txtNombre.Text.CompareTo(string.Empty) == 0 && txtDoc.Text.CompareTo(string.Empty) == 0)
        {
            this.ShowMensaje("Atención", "Es necesario agregar alguna información de la persona autorizada para el ingreso.");
            return false;
        }
        return true;
    }

    private bool AgregarPersonaAutorizacion()
    {
        if (!this.EsPersonaValida()) return false;
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        string IP = HttpContext.Current.Request.UserHostAddress.ToString();
        AcreditacionVisita acred = this.CrearAcreditacionSeleccionada();
        int Doc = (txtDoc.Text.CompareTo(string.Empty) == 0 ? 0 : Convert.ToInt32(txtDoc.Text));
        PersonaVisitaAcreditada perAcred = new PersonaVisitaAcreditada() { Apellido = txtApellido.Text, Nombre = txtNombre.Text, Documento = Doc, NroCredencial = txtCredencial.Text };
        if (!ws.savePersonaAcreditacion(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, IP, acred, perAcred))
        {
            this.ShowMensaje("Atención:", "La persona no fue agregada, compruebe que no haya sido ingresada anteriormente.");
            return false;
        }
        return true;
    }

    private void ClearControlesAcomp()
    {
        this.ClearPersonaSeleccionada();
        this.txtCredencial.Text = string.Empty;
    }

    private bool EliminarPersonaAutorizacion()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        //string IP = HttpContext.Current.Request.UserHostAddress.ToString();
        //int IdUser =  ((Usuario)Session[ConstantesDeSesion.USUARIO]).Id;
        AcreditacionVisita acred = this.CrearAcreditacionSeleccionada();
        PersonaVisitaAcreditada perAcred = new PersonaVisitaAcreditada() { Id = Convert.ToInt32(GridView_Acomp.DataKeys[GridView_Acomp.SelectedIndex].Value) };
        return ws.eliminarPersonaAcreditacion(acred, perAcred);
    }

    private bool AcreditacionOk()
    {
        PersonaVisita perDef = this.GetPersonaDefault();
        if (this.PersonaDefaultYaEstaAgregada(perDef))
            return true;
        return false;
    }

    private void IngresarAcreditacion()
    {

    }

    /***********************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTitulo.Text = "Autorizaciones de acceso " + DateTime.Now.ToString("dd/MM/yyyy") + ":";
            InitDetalles();
            ChargeAutorizaciones();
        }
    }

    protected void GridView_Autorizaciones_PreRender(object sender, EventArgs e)
    {
        if (GridView_Autorizaciones.Rows.Count > 0)
        {
            GridView_Autorizaciones.UseAccessibleHeader = true;
            GridView_Autorizaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void GridView_Autorizaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPersonasAcreditacion();
        this.SetPersonaDefault();
        this.ShowAcomp();
    }

    protected void lbCancelar_Click(object sender, EventArgs e)
    {
        this.HideMensaje();
    }

    protected void lbConfirmar_Click(object sender, EventArgs e)
    {
        this.HideMensaje();
    }

    protected void GridView_Autorizaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void Button_CancelarAcomp_Click(object sender, EventArgs e)
    {
        this.HideAcomp();
    }

    protected void ImageButton_BusAcomp_Click(object sender, ImageClickEventArgs e)
    {       
        this.ShowPersonasBusq();
    }

    protected void ImageButton_DelAcomp_Click(object sender, ImageClickEventArgs e)
    {
        this.ClearPersonaSeleccionada();
    }

    protected void Button_CancelarBusqueda_Click(object sender, EventArgs e)
    {
        this.HidePersonasBusq();
    }

    protected void GridView_Personas_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPersonaBusqueda();
        this.HidePersonasBusq();
    }

    protected void GridView_Personas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1) e.Row.Cells[1].Visible = false;
    }

    protected void Button_AgregarAcomp_Click(object sender, EventArgs e)
    {
        if (!this.AgregarPersonaAutorizacion()) return;
        this.ClearControlesAcomp();
        this.SetPersonasAcreditacion();
    }

    protected void GridView_Acomp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1) e.Row.Cells[2].Visible = false;
    }

    protected void GridView_Acomp_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ShowMensajeConfirmarEliminar();
    }

    protected void Button_Acreditar_Click(object sender, EventArgs e)
    {
        if (!this.AcreditacionOk())
        {
            this.ShowMensaje("Atención:", "Es obligarorio ingresar la persona autorizada");
            return;
        }
        this.IngresarAcreditacion();
    }

    protected void lbConfirmarEliminar_Click(object sender, EventArgs e)
    {
        this.EliminarPersonaAutorizacion();
        this.SetPersonasAcreditacion();
        this.HideMensaje();
    }
}