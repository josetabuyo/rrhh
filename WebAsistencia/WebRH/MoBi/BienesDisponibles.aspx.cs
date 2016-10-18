using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class MoBi_BienesDisponibles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            WSViaticosSoapClient ws = Servicio();
            Cargar_TiposDeBienes(ws);
            Cargar_AreasDelUsuario(ws, usuario.Id, Convert.ToInt32(DropDownListTipoDeBien.SelectedValue), true);
            Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
        }
    }

    private void Cargar_AreasDelUsuario(WSViaticosSoapClient ws, int IdUsuario, int IdTipoBien, bool MostrarMostrarSoloAreasConBienes)
    {
        WSViaticos.MoBi_Area[] AreasUsuario= ws.Mobi_GetAreasUsuarioCBO(IdUsuario,IdTipoBien, MostrarMostrarSoloAreasConBienes);
        DropDownAreasUsuario.DataSource = AreasUsuario.OfType<MoBi_Area>().ToList();
        DropDownAreasUsuario.DataTextField = "Nombre";
        DropDownAreasUsuario.DataValueField = "Id";
        DropDownAreasUsuario.DataBind();
    }

    private void Cargar_TiposDeBienes(WSViaticosSoapClient ws)
    {
        WSViaticos.MoBi_TipoBien[] TiposDeBienes = ws.Mobi_GetTipoBien();
        DropDownListTipoDeBien.DataSource = TiposDeBienes.OfType<MoBi_TipoBien>().ToList();
        DropDownListTipoDeBien.DataTextField = "Nombre";
        DropDownListTipoDeBien.DataValueField = "Id";
        DropDownListTipoDeBien.DataBind();
    }

    private void Cargar_Bienes(WSViaticosSoapClient ws, int IdArea, int IdTipoBien)
    {
        WSViaticos.MoBi_Bien[] Bienes = ws.Mobi_GetBienesDelArea(IdArea, IdTipoBien);
        GridViewBienes.DataSource = Bienes.OfType<MoBi_Bien>().ToList();
        GridViewBienes.DataBind();
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void GridViewBienes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session.Add("MOBI_IdBien", GridViewBienes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
        Session.Add("MOBI_AreaOrigen", Server.HtmlDecode(GridViewBienes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text));
        Session.Add("MOBI_TipoBien", Server.HtmlDecode(DropDownListTipoDeBien.SelectedItem.Text));
        Session.Add("MOBI_Item", Server.HtmlDecode(GridViewBienes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
        if (e.CommandName == "MOV")
            Server.Transfer("MovimentosBien.aspx");
        if (e.CommandName == "ASIG")
            Server.Transfer("AsignarBienes.aspx");
    }

    protected void DropDownAreasUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Bienes(Servicio(), Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    private void ActualizarAreasYBienes( )
    {
        WSViaticosSoapClient ws = Servicio();
        Usuario usuario = ((Usuario)Session["usuario"]);
        bool MostrarTodasLasAreas = (rbTodasLasAreas2.Checked ? true : false);
        Cargar_AreasDelUsuario(ws, usuario.Id, Convert.ToInt32(DropDownListTipoDeBien.SelectedValue), MostrarTodasLasAreas);
        Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    protected void DropDownListTipoDeBien_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActualizarAreasYBienes();
    }

    protected void rbAreasConBienes_CheckedChanged(object sender, EventArgs e)
    {
        ActualizarAreasYBienes();
    }

    protected void rbTodasLasAreas_CheckedChanged(object sender, EventArgs e)
    {
        ActualizarAreasYBienes();
    }
}