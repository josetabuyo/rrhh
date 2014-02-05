using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Web.UI.HtmlControls;


public partial class Visitas_Autorizaciones : System.Web.UI.Page
{
    private static string KeyListFun = "listFuncionarios";
    private static int iDiasDispMax = 20;
    private static string DateFormat = "yyyMMdd";


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) Init_Controls();
    }

    private void Init_Controls()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        this.SetFuncionarios(DropDownList_Funcionarios, ws.GetFuncionarios());
        this.SetMotivos(DropDownListMotivo, ws.GetMotivoVista());
        this.InitPersonasBusqueda();
        this.InitInfoPagina();
        this.SetDiasDisponibles();
        this.DropDownList_Funcionarios.Focus();
        this.Form.DefaultButton = this.Button_Ingresar.UniqueID;
    }

    private void SetDiasDisponibles()
    {
        lblContadorDias.Text = "Días disponibles: " + (iDiasDispMax - ListBox_DiasSeleccionados.Items.Count).ToString();
    }

    private void SetLugarSegunFuncionario()
    {
        FuncionarioVisita[] lFun = (FuncionarioVisita[])Session[KeyListFun];
        FuncionarioVisita F = lFun.Single(Fun => Fun.Id == Convert.ToInt32(DropDownList_Funcionarios.SelectedValue));
        txtLugar.Text = F.LugarTrabajo;
    }

    private void SetFuncionarios( DropDownList ddlFun, FuncionarioVisita[] lFun )
    {
        ddlFun.Items.Clear();
        foreach (FuncionarioVisita f in lFun)
        {
            ListItem liFun = new ListItem(f.Tratamiento + " " + f.Apellido + ", " + f.Nombre, f.Id.ToString());
            ddlFun.Items.Add(liFun);
        }
        Session[KeyListFun] = lFun;
        SetLugarSegunFuncionario();
    }

    private void SetMotivos(DropDownList ddlMot, MotivoVisita[] lMot)
    {
        ddlMot.Items.Clear();
        foreach (MotivoVisita m in lMot)
        {
            ListItem liMot = new ListItem(m.Motivo, m.Id.ToString());
            ddlMot.Items.Add(liMot);
        }
    }

    private void AgregarDia()
    {
        DateTime day = Calendar_SelDias.SelectedDate;
        lblMsj.Text = string.Empty;
        string dayKey = day.ToString(DateFormat);
        string dayValue = day.ToString("D").ToUpper();

        if (dayKey.CompareTo(DateTime.Now.ToString(DateFormat)) < 0)
        {
            lblMsj.Text = "La fecha seleccionada no es válida.<br/>Seleccione a partir de hoy en adelante.";
            return;
        }
        Dictionary<string, string> dDias = new Dictionary<string, string>();
        foreach (ListItem d in ListBox_DiasSeleccionados.Items)
        {
            dDias.Add(d.Value, d.Text);
        }
        if (dDias.ContainsKey(dayKey))
        {
            lblMsj.Text = "La fecha elegida ya fue seleccionada.";
            return;
        }
        if (dDias.Count >= iDiasDispMax)
        {
            lblMsj.Text = "La fecha no fue agregada: Alcanzó la cantidad máxima posible de 20 días autorizados.";
            return;
        }
        dDias.Add(dayKey, dayValue);
        ListBox_DiasSeleccionados.Items.Clear();
        foreach (KeyValuePair<string, string> kvp in dDias.OrderBy(k => k.Key))
        {
            ListBox_DiasSeleccionados.Items.Add(new ListItem(kvp.Value, kvp.Key));
        }
        SetDiasDisponibles();
    }

    private void QuitarDia()
    {

        ListBox_DiasSeleccionados.Items.Remove(ListBox_DiasSeleccionados.SelectedItem);
        lblMsj.Text = string.Empty;
        SetDiasDisponibles();
    }

    private void InitPersonasBusqueda()
    {
        this.divPersonas.Visible = false;
        this.divPersonas.Style["height"] = "auto";
        this.divPersonas.Style["width"] = "100%";
        this.divPersonas.Style["position"] = "absolute";

        this.divGridViewPersonas.Style["position"] = "absolute";
        this.divGridViewPersonas.Style["width"] = "600px";
        this.divGridViewPersonas.Style["height"] = "600px";
        this.divGridViewPersonas.Style["top"] = "50%";
        this.divGridViewPersonas.Style["left"] = "50%";
        this.divGridViewPersonas.Style["margin"] = "-300px 0 0 -300px";
    }

    private void InitInfoPagina()
    {
        this.divInfoPagina.Visible = false;
        this.divInfoPagina.Style["height"] = "auto";
        this.divInfoPagina.Style["width"] = "100%";
        this.divInfoPagina.Style["position"] = "absolute";

        this.tableInfoPagina.Style["position"] = "absolute";
        this.tableInfoPagina.Style["width"] = "600px";
        this.tableInfoPagina.Style["height"] = "150px";
        this.tableInfoPagina.Style["top"] = "50%";
        this.tableInfoPagina.Style["left"] = "50%";
        this.tableInfoPagina.Style["margin"] = "-75px 0 0 -300px";

        this.tableInfoPagina.Style["background-color"] = "White";
    }

    private void ShowPersonasBusqueda()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        PersonaVisita[] aPV = ws.GetPersonasVisitas(txtApellido.Text, txtNombre.Text, (txtDoc.Text.CompareTo(string.Empty) == 0 ? 0 : Convert.ToInt32(txtDoc.Text)));
        GridView_Personas.DataSource = aPV;
        string[] dkn = new string[] { "Id" };
        GridView_Personas.DataKeyNames = dkn;        
        GridView_Personas.DataBind();
        GridView_Personas.SelectedIndex = -1;
        this.divPersonas.Visible = true;
        Button_CancelarBusqueda.Focus();
    }

    private void ShowInfoPagina(string Mensaje, System.Drawing.Color textColor)
    {
        lblInfoPagina.Text = Mensaje;
        lblInfoPagina.ForeColor = textColor;
        this.divInfoPagina.Visible = true;
        Button_Aceptar.Focus();
    }

    private void HidePersonasBusqueda()
    {
        this.divPersonas.Visible = false;
    }

    private void HideInfoPagina()
    {
        this.divInfoPagina.Visible = false;
    }

    private void SetPersonaBusqueda()
    {
        txtNombre.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[2].Text);
        txtNombre.Enabled = false;
        txtApellido.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[3].Text);
        txtApellido.Enabled = false;
        txtDoc.Text = Server.HtmlDecode(GridView_Personas.SelectedRow.Cells[4].Text);
        txtDoc.Enabled = false;
        HiddenField_IdPersona.Value = GridView_Personas.SelectedDataKey.Value.ToString();
        HidePersonasBusqueda();
    }

    private void ClearPersonaSeleccionada()
    {
        txtNombre.Text = string.Empty;
        txtNombre.Enabled = true;
        txtApellido.Text = string.Empty;
        txtApellido.Enabled = true;
        txtDoc.Text = string.Empty;
        txtDoc.Enabled = true;
    }

    private bool ValIngresoAutorizacion()
    {
        if (ListBox_DiasSeleccionados.Items.Count < 1)
        {
            lblMsj.Text = "Debe agregar al menos un dia a la lista.";
            return false;
        }
        return true;
    }

    private PersonaVisita CrearPersona()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        PersonaVisita unaPersona = new PersonaVisita() { Apellido = txtApellido.Text, Nombre = txtNombre.Text, Documento = Convert.ToInt32(txtDoc.Text) };
        string IP = HttpContext.Current.Request.UserHostAddress.ToString();
        unaPersona = ws.savePersonaVisita(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, IP, unaPersona);
        return unaPersona;
    }

    private MotivoVisita CrearMotivo()
    {
        return new MotivoVisita() { Id = Convert.ToInt32(DropDownList_Funcionarios.SelectedValue), Motivo = DropDownList_Funcionarios.SelectedItem.Text };
    }

    private FuncionarioVisita CrearFuncionario()
    {
        FuncionarioVisita[] lFun = (FuncionarioVisita[])Session[KeyListFun];
        return lFun.Single(Fun => Fun.Id == Convert.ToInt32(DropDownList_Funcionarios.SelectedValue));
    }


    private DateTime[] GetFechasSeleccionadas()
    {
        DateTime[] aFechas = new DateTime[ListBox_DiasSeleccionados.Items.Count];
        for (int i = 0; i < ListBox_DiasSeleccionados.Items.Count; i++)
            aFechas[i] = DateTime.ParseExact(ListBox_DiasSeleccionados.Items[i].Value, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        return aFechas;     
    }

    private AutorizacionVisita GuardarAutorizacion(AutorizacionVisita autVisita)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        string IP = HttpContext.Current.Request.UserHostAddress.ToString();
        return ws.saveAutorizacionVisita(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, IP, autVisita);
    }

    private void ClearForm()
    {
        this.DropDownList_Funcionarios.SelectedIndex = 0;
        this.ClearPersonaSeleccionada();
        this.DropDownListMotivo.SelectedIndex = 0;
        this.txtLugar.Text = string.Empty;
        this.txtRepresenta.Text = string.Empty;
        this.ListBox_DiasSeleccionados.Items.Clear();
        this.SetDiasDisponibles();
    }
    

    /*******************************************************/

    protected void ImageButton_BusDoc_Click(object sender, ImageClickEventArgs e)
    {
        ShowPersonasBusqueda();
    }
    protected void ImageButton_BusApe_Click(object sender, ImageClickEventArgs e)
    {
        ShowPersonasBusqueda();
    }
    protected void ImageButton_BusNom_Click(object sender, ImageClickEventArgs e)
    {
        ShowPersonasBusqueda();
    }

    protected void ImageButton_DelDoc_Click(object sender, ImageClickEventArgs e)
    {
        ClearPersonaSeleccionada();
    }
    protected void ImageButton_DelApe_Click(object sender, ImageClickEventArgs e)
    {
        ClearPersonaSeleccionada();
    }
    protected void ImageButton_DelNom_Click(object sender, ImageClickEventArgs e)
    {
        ClearPersonaSeleccionada();
    }

    protected void Button_CancelarBusqueda_Click(object sender, EventArgs e)
    {
        HidePersonasBusqueda();
        this.DropDownList_Funcionarios.Focus();
    }

    protected void Calendar_SelDias_SelectionChanged(object sender, EventArgs e)
    {
        AgregarDia();
    }

    protected void Button_QuitarDiaSel_Click(object sender, EventArgs e)
    {
        QuitarDia();
    }

    protected void GridView_Personas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.Cells.Count>1) e.Row.Cells[1].Visible = false;
    }

    protected void GridView_Personas_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPersonaBusqueda();
        this.DropDownList_Funcionarios.Focus();
    }

    protected void DropDownList_Funcionarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetLugarSegunFuncionario();
    }

    protected void Calendar_SelDias_DayRender(object sender, DayRenderEventArgs e)
    {
        if( ListBox_DiasSeleccionados.Items.FindByValue(e.Day.Date.ToString(DateFormat)) != null )
            e.Cell.BackColor = System.Drawing.Color.FromArgb(0xBC, 0xF5, 0xA9);
    }

    protected void Button_Aceptar_Click(object sender, EventArgs e)
    {
        this.HideInfoPagina();
        this.DropDownList_Funcionarios.Focus();
    }

    protected void Button_Ingresar_Click(object sender, EventArgs e)
    {
        if (!ValIngresoAutorizacion()) return;
        string strMensaje = string.Empty;
        System.Drawing.Color colorText = System.Drawing.Color.Green;
        try
        {
            AutorizacionVisita av = new AutorizacionVisita();
            av.PersonaAutorizada = this.CrearPersona(); 
            av.Funcionario = this.CrearFuncionario();
            av.Motivo = this.CrearMotivo();
            av.FechasAut = this.GetFechasSeleccionadas();
            av.Lugar = txtLugar.Text;
            av.Representa = txtRepresenta.Text;
            av = GuardarAutorizacion(av);
            if (av == null) throw new Exception();
            this.ClearForm();
            strMensaje = "La autorización fue ingresada exitosamente.";
        }
        catch
        {
            strMensaje = "No fue posible agregar la autorización. Vuelva a intentar.";
            colorText = System.Drawing.Color.Red;
        }
        finally
        {
            this.ShowInfoPagina(strMensaje, colorText);
        }
    }

}