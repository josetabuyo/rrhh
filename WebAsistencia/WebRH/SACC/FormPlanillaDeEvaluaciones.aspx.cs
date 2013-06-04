using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class SACC_FormPlanillaDeEvaluaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarComboCursos();
        }
    }

    protected void CargarEvaluaciones(object sender, EventArgs e)
    {
        this.PlanillaEvaluaciones.CargarEvaluaciones();
    }

    private void CargarComboCursos()
    {
        var cursos = Servicio().GetCursosDto((Usuario)Session[ConstantesDeSesion.USUARIO]);
        foreach (var c in cursos)
        {
            this.CmbCurso.Items.Add(new System.Web.UI.WebControls.ListItem(c.Nombre, c.Id.ToString()));
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}