using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MoBi_BienesDetalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnMovimientos_Click(object sender, EventArgs e)
    {
        Response.Redirect("HistorialBienes.aspx?idBien=" + hidden_idBien.Value);
     
    }



    protected void btnMovimientos_Click1(object sender, EventArgs e)
    {
        //Response.Redirect("HistorialBienes.aspx?idBien=" + hid.Value + "&MOBI_Item="+ed_descripcion_bien.InnerText);
        Response.Redirect("HistorialBienes.aspx?idBien=" + hid.Value + "&MOBI_Item=" + hdescripBien.Value);
   
    }
}