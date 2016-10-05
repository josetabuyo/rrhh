using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MoBi_MenuBienes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bienes.aspx");
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        Response.Redirect("BienesDisponibles.aspx");
    }
}