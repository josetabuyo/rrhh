using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SACC_FormDetalleDeAlumno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAsignarCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormAsignarCursos.aspx");

    }
}