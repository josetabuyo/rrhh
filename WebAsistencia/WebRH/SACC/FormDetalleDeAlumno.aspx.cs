using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class SACC_FormDetalleDeAlumno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();

        if (!IsPostBack)
        {
            this.alumnoJSON.Value = servicio.GetAlumnoByDNI((int)Session[ConstantesDeSesion.ALUMNO]);
        }

    }

    protected void btnAsignarCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormAsignarCursos.aspx");

    }
}