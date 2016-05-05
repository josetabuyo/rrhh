using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;


public partial class MoBi_RecepcionarBienes : System.Web.UI.Page
{
    /*******************************************/
    /*******************************************/
    /*******************************************/
    private int IdUsuario = 0;
    /*******************************************/
    /*******************************************/
    /*******************************************/
    /*******************************************/

    private int ParamEmpty = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WSViaticosSoapClient ws = Servicio();
            Cargar_AreasDelUsuario(ws, IdUsuario);
            Cargar_TiposDeBienes(ws);
            Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
        }
    }

    private void Cargar_AreasDelUsuario(WSViaticosSoapClient ws, int IdUsuario)
    {
        WSViaticos.MoBi_Area[] AreasUsuario = ws.Mobi_GetAreasUsuario(IdUsuario);
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
        WSViaticos.MoBi_Bien[] Bienes = ws.Mobi_GetBienesDelAreaRecepcion(IdArea, IdTipoBien);
        GridViewBienes.DataSource = Bienes.OfType<MoBi_Bien>().ToList();
        GridViewBienes.DataBind();
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void DropDownListTipoDeBien_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Bienes(Servicio(), Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    protected void DropDownAreasUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargar_Bienes(Servicio(), Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }


    protected void btnRecepcionar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = Servicio();
        ws.Mobi_GuardarEventoBien(enumTipoEvento.ASIGNACION_OPERATIVA_RECEPCION, Convert.ToInt32(GridViewBienes.DataKeys[Convert.ToInt32(hfIndexGrid.Value)].Value), ParamEmpty, ParamEmpty, hfObservaciones.Value, IdUsuario);
        Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));
    }

    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = Servicio();
        Servicio().Mobi_GuardarEventoBien(enumTipoEvento.ASIGNACION_OPERATIVA_RECHAZO, Convert.ToInt32(GridViewBienes.DataKeys[Convert.ToInt32(hfIndexGrid.Value)].Value), ParamEmpty, ParamEmpty, string.Empty, IdUsuario);
        Cargar_Bienes(ws, Convert.ToInt32(DropDownAreasUsuario.SelectedValue), Convert.ToInt32(DropDownListTipoDeBien.SelectedValue));        
    }
}