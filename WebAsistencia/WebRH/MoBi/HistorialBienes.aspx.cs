using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
public partial class MoBi_HistorialBienes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
         //   var id_bien = Convert.ToString(Session["MOBI_IdBien"]);
          //  txtTipoBien.Text = (string)(Session["MOBI_TipoBien"]);
            txtItem.Text = (string)(Session["MOBI_Item"]);
            var id =  Request.QueryString["idBien"];
            WSViaticosSoapClient ws = new WSViaticosSoapClient();
            Cargar_Bienes(ws, Convert.ToInt32(id));
        }
        
    }

    private void Cargar_Bienes(WSViaticosSoapClient ws, int IdBien)
    {
        WSViaticos.MoBi_Evento[] Eventos = ws.Mobi_GetEventosBien(IdBien);
        GridViewMovimientos.DataSource = Eventos.OfType<MoBi_Evento>().ToList();
        GridViewMovimientos.DataBind();
    }

    
   

    protected void lkBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("BienesDisponibles.aspx");
    }

}