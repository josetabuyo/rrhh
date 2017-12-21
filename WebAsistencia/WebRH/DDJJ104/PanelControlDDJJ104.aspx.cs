using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DDJJ104_PanelControlDDJJ104 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCertificarArea_Click(object sender, EventArgs e)
    {
        Response.Redirect("FAreasConDDJJ.aspx");
    }
    protected void btnConsultaDDJJ_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultaIndividualDDJJ.aspx");
    }
    protected void btnPersonasNoCertificadas_Click(object sender, EventArgs e)
    {
        Response.Redirect("PersonasNoCertificadas.aspx");
    }
    protected void btnCertificarPersonasNoCertificadas_Click(object sender, EventArgs e)
    {
        Response.Redirect("PersonasNoCertificadasAsigArea.aspx");
    }
    
}