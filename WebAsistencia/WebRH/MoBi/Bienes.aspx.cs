using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;


public partial class MoBi_Bienes : System.Web.UI.Page
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

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void GridViewBienes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Session.Add("MOBI_IdBien", GridViewBienes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
        Session.Add("MOBI_TipoBien", Server.HtmlDecode(DropDownListTipoDeBien.SelectedItem.Text));
        Session.Add("MOBI_Item", Server.HtmlDecode(GridViewBienes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
        if (e.CommandName == "MOV")
            Server.Transfer("MovimentosBien.aspx");
        if (e.CommandName == "ASIG")
            Server.Transfer("AsignarBienes.aspx");
    }


    private void Cargar_AreasDelUsuario(WSViaticosSoapClient ws, int IdUsuario, int IdTipoBien, bool IncluirDependencias)
    {
        //WSViaticos.MoBi_Area[] AreasUsuario = ws.Mobi_GetAreasDelUsuarioBienesDisponibles( IdUsuario, IdTipoBien, IncluirDependencias, BienEsVehiculoYTienePermServGrales());
        //DropDownAreasUsuario.DataSource = AreasUsuario.OfType<MoBi_Area>().ToList();
        //DropDownAreasUsuario.DataTextField = "Nombre";
        //DropDownAreasUsuario.DataValueField = "Id";
        //DropDownAreasUsuario.DataBind();

        WSViaticos.MoBi_Area[] AreasUsuario = ws.Mobi_GetAreasUsuarioCBO(IdUsuario, IdTipoBien, true );
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

    protected void DropDownAreasUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Bienes(Servicio(), Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    protected void DropDownListTipoDeBien_SelectedIndexChanged(object sender, EventArgs e)
    {
        ActualizarAreasYBienes();
    }

    protected void chkIncluirDependencias_CheckedChanged(object sender, EventArgs e)
    {
        ActualizarAreasYBienes();
    }

    private void ActualizarAreasYBienes()
    {
        WSViaticosSoapClient ws = Servicio();
        Usuario usuario = ((Usuario)Session["usuario"]);
        bool IncluirDependencias = (chkIncluirDependencias.Checked ? true : false);
        Cargar_AreasDelUsuario(ws, usuario.Id, Convert.ToInt32(DropDownListTipoDeBien.SelectedValue), IncluirDependencias);
        Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    private bool TienePermisosVehiculosServGrales()
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        Usuario usuario = ((Usuario)Session["usuario"]);
        var lstFunciones = ws.FuncionalidadesPara(usuario.Id);
        return lstFunciones.Any(x => x.Nombre == "gestion_serv_gral_vehiculos");
    }


    private bool BienEsVehiculoYTienePermServGrales()
    {
        return (DropDownListTipoDeBien.SelectedValue == "1") && this.TienePermisosVehiculosServGrales();
    }


    protected void GridViewBienes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if (row.RowType == DataControlRowType.DataRow)
        {
            row.Attributes["id"] = "row_" + row.RowIndex.ToString();
            row.Attributes.Add("onclick", "Seleccionar_Row(this);");
            //row.Cells[2].Attributes.Add("class", "Detalle");
            row.Cells[2].Text = "<a><img class=\"Detalle\" alt=\"Detalle\" src=\"../Imagenes/detalle.png\" /></a>";
        }
    }
}