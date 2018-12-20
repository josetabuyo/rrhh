using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Impresiones_ImpresionComisionesDeServicios : System.Web.UI.Page
{    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Impresiones_PlantillaComisionDeServicios cs = new Impresiones_PlantillaComisionDeServicios();
        cs = (Impresiones_PlantillaComisionDeServicios)LoadControl("~\\Impresiones\\PlantillaComisionDeServicios.ascx");
        this.PanelComisiones.Controls.Add(cs);
    }

    protected void Imprimir(object sender, EventArgs e)
    {
        this.BtnImprimir.Visible = false;
        Response.Write("<script language=javascript>{window.print()}</script>");
    }

}