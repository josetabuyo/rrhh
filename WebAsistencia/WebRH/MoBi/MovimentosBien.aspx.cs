using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class MoBi_MovimentosBien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HiddenField_IdBien.Value = Convert.ToString(Session["MOBI_IdBien"]);
            txtTipoBien.Text = (string)(Session["MOBI_TipoBien"]);
            txtItem.Text = (string)(Session["MOBI_Item"]);
            WSViaticosSoapClient ws = new WSViaticosSoapClient();
            Cargar_Bienes(ws, Convert.ToInt32(HiddenField_IdBien.Value));
        }
    }

    private void Cargar_Bienes(WSViaticosSoapClient ws, int IdBien)
    {
        WSViaticos.MoBi_Evento[] Eventos = ws.Mobi_GetEventosBien(IdBien);
        GridViewMovimientos.DataSource = Eventos.OfType<MoBi_Evento>().ToList();
        GridViewMovimientos.DataBind();
    }

}