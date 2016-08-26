using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class MoBi_AsignarBienes : System.Web.UI.Page
{
    private int ParamEmpty = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HiddenField_IdBien.Value = Convert.ToString(Session["MOBI_IdBien"]);
            txtTipoBien.Text = (string)(Session["MOBI_TipoBien"]);
            txtItem.Text = (string)(Session["MOBI_Item"]);
            Usuario usuario = ((Usuario)Session["usuario"]);
            WSViaticosSoapClient ws = new WSViaticosSoapClient();
            Cargar_AreasDelUsuario(ws, usuario.Id);
            Cargar_InfoAdicBien(ws, Convert.ToInt32(HiddenField_IdBien.Value) );
        }
    }


    private void Cargar_AreasDelUsuario(WSViaticosSoapClient ws, int IdUsuario)
    {
        WSViaticos.MoBi_Area[] AreasUsuario = ws.Mobi_GetAreasDelUsuario( IdUsuario);
        DropDownAreasDestino.DataSource = AreasUsuario.OfType<MoBi_Area>().ToList();
        DropDownAreasDestino.DataTextField = "Nombre";
        DropDownAreasDestino.DataValueField = "Id";
        DropDownAreasDestino.DataBind();
        DropDownAreasDestino.SelectedIndex = -1;
    }

    private void Cargar_AgentesDelArea(WSViaticosSoapClient ws, int IdArea)
    {        
        WSViaticos.MoBi_Agente[] AgentesDelArea = ws.Mobi_GetAgentesArea(IdArea);
        DropDownAgenteDestino.DataSource = AgentesDelArea.OfType<MoBi_Agente>().ToList();
        DropDownAgenteDestino.DataTextField = "Descripcion";
        DropDownAgenteDestino.DataValueField = "Id";
        DropDownAgenteDestino.DataBind();
        DropDownAgenteDestino.SelectedIndex = -1;
        DropDownAgenteDestino.Enabled = true;

        if (DropDownAgenteDestino.Items.Count < 1)
        {
            DropDownAgenteDestino.Items.Clear();
            DropDownAgenteDestino.Items.Add(new ListItem("<< NO HAY AGENTES EN EL ÁREA >>", "-1"));
            DropDownAgenteDestino.SelectedIndex = 0;
            DropDownAgenteDestino.Enabled = false;
        }
    }

    private void Cargar_InfoAdicBien(WSViaticosSoapClient ws, int IdBien)
    {
        MoBi_Bien bien = ws.Mobi_GetBien(IdBien);
        txtArea.Text =  bien.AreaActual;
    }


    protected void DropDownAreasDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (checkAgenteDestino.Checked && DropDownAreasDestino.SelectedIndex > -1) {
            Cargar_AgentesDelArea((new WSViaticosSoapClient()), Convert.ToInt32(DropDownAreasDestino.SelectedItem.Value));
        }
    }

    protected void btnCancekar_Click(object sender, EventArgs e)
    {
        Response.Redirect("BienesDisponibles.aspx");
    }

    protected void checkAgenteDestino_CheckedChanged(object sender, EventArgs e)
    {
        if (checkAgenteDestino.Checked) {
            DropDownAgenteDestino.Visible = true;
            Cargar_AgentesDelArea((new WSViaticosSoapClient()), Convert.ToInt32(DropDownAreasDestino.SelectedItem.Value));
        }
        else {
            DropDownAgenteDestino.Items.Clear();
            DropDownAgenteDestino.Visible = false;
        }
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        Usuario usuario = ((Usuario)Session["usuario"]);
        if(
        ws.Mobi_GuardarEventoBien(
            enumTipoEvento.ASIGNACION_OPERATIVA_TRANSITO,
            Convert.ToInt32(HiddenField_IdBien.Value),
            Convert.ToInt32(DropDownAreasDestino.SelectedItem.Value),
            (checkAgenteDestino.Checked ? Convert.ToInt32(DropDownAgenteDestino.SelectedItem.Value) : ParamEmpty),
            txtObservaciones.Text, usuario.Id))
            Response.Redirect("BienesDisponibles.aspx");
    }

}