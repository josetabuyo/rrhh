using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WSViaticos;
using System.Web.UI.WebControls;
using System.Data;

public partial class Visitas_Acreditacion : System.Web.UI.Page
{
    // Acreditar autorizaciones de visitas
    private static string strEtiquetaFecha = "@Fecha";
    private static string strNombreIDAutorizacion = "ID";
    private static string strTitulo = "Acreditaciones " + strEtiquetaFecha;

    private static string[] aColAutorizacion = 
    {   "*"+strNombreIDAutorizacion,
        "*Acreditado",
        "Fecha",
        "Autorizado por",
        "*Apellido",
        "*Nombre",
        "*Documento",
        "Telefono",
        "Motivo",
        "*Funcionario",
        "*Lugar",
        "Representa a",
        "Acompañantes"
    };


    /***********************************/

    private void setAutorizacionesBusqueda()
    {
        GridView_Personas.DataKeyNames = new string[] { strNombreIDAutorizacion };
        GridView_Personas.DataSource = CreateDataTableAutorizacion(false);
        GridView_Personas.DataBind();
    }


    private DataTable CreateDataTableAutorizacion(bool FullRow)
    {
        Usuario user = (Usuario)Session[ConstantesDeSesion.USUARIO];
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        AutorizacionVisita[] aAut = ws.GetAutorizaciones(user.Id, txtApellido.Text, txtNombre.Text, Convert.ToInt32(txtDoc.Text.CompareTo(string.Empty) == 0 ? "0" : txtDoc.Text));

        DataTable dt = new DataTable();
        foreach (string Col in aColAutorizacion)
            if (FullRow || Col.Contains("*")) dt.Columns.Add(Col.Replace("*", string.Empty));

        foreach (AutorizacionVisita a in aAut)
        {
            DataRow dr = dt.NewRow();

            if (dt.Columns.Contains(strNombreIDAutorizacion))
                dr[strNombreIDAutorizacion] = a.Id;

            if (dt.Columns.Contains("Acreditado"))
                dr["Acreditado"] = a.Acreditado ? "SI" : "NO";

            if (dt.Columns.Contains("Autorizado por"))
                dr["Autorizado por"] = string.Empty;

            if (dt.Columns.Contains("Fecha"))
                dr["Fecha"] = a.FechaAut.ToString("dd/MM/yyyy");

            if (dt.Columns.Contains("Apellido"))
                dr["Apellido"] = a.PersonaAutorizada.Apellido;

            if (dt.Columns.Contains("Nombre"))
                dr["Nombre"] = a.PersonaAutorizada.Nombre;

            if (dt.Columns.Contains("Documento"))
                dr["Documento"] = a.PersonaAutorizada.Documento;

            if (dt.Columns.Contains("Telefono"))
                dr["Telefono"] = a.PersonaAutorizada.Telefono;

            if (dt.Columns.Contains("Motivo"))
                dr["Motivo"] = a.Motivo.Motivo;

            if (dt.Columns.Contains("Funcionario"))
                dr["Funcionario"] = a.Funcionario.Apellido + ", " + a.Funcionario.Nombre;

            if (dt.Columns.Contains("Lugar"))
                dr["Lugar"] = a.Lugar;

            if (dt.Columns.Contains("Representa a"))
                dr["Representa a"] = a.Representa;

            if (dt.Columns.Contains("Acompañantes"))
                dr["Acompañantes"] = a.Acompanantes.ToString();

            dt.Rows.Add(dr);
        }
        return dt;
    }

    private void InitDetalleAutorizacion()
    {
        this.divAutorizacion.Visible = false;
        this.divAutorizacion.Style["height"] = "auto";
        this.divAutorizacion.Style["width"] = "100%";
        this.divAutorizacion.Style["position"] = "absolute";

        this.divGridViewAutorizaciones.Style["position"] = "absolute";
        this.divGridViewAutorizaciones.Style["width"] = "600px";
        this.divGridViewAutorizaciones.Style["height"] = "600px";
        this.divGridViewAutorizaciones.Style["top"] = "50%";
        this.divGridViewAutorizaciones.Style["left"] = "50%";
        this.divGridViewAutorizaciones.Style["margin"] = "-300px 0 0 -300px";
    }


    private void ShowPersonasBusqueda()
    {
        this.DetailsView_Autorizacion.DataSource = CreateDataTableAutorizacion(true);
        this.DetailsView_Autorizacion.DataKeyNames = new string[] { strNombreIDAutorizacion };
        this.DetailsView_Autorizacion.DataBind();
        this.DetailsView_Autorizacion.Rows[0].Visible = false;
        this.divAutorizacion.Visible = true;
    }

    private void HideAutorizacionesBusqueda()
    {
        this.divAutorizacion.Visible = false;
    }


    /*****************/


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTitulo.Text = strTitulo.Replace(strEtiquetaFecha, DateTime.Now.ToString("D").ToUpper());
            InitDetalleAutorizacion();
            GridView_Personas.DataBind();
        }
        txtDoc.Focus();
    }

    protected void Button_Buscar_Click(object sender, EventArgs e)
    {
        setAutorizacionesBusqueda();
    }

    protected void GridView_Personas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1) e.Row.Cells[1].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.Cells[2].Text.Contains("SI") && e.Row.RowIndex != GridView_Personas.SelectedIndex)
                e.Row.BackColor = System.Drawing.Color.FromArgb(0xEC, 0xF8, 0xE0);
    }


    protected void GridView_Personas_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowPersonasBusqueda();
    }

    protected void Button_Aceptar_Click(object sender, EventArgs e)
    {
        HideAutorizacionesBusqueda();
    }

    protected void Button_Cancelar_Click(object sender, EventArgs e)
    {
        HideAutorizacionesBusqueda();
    }
}