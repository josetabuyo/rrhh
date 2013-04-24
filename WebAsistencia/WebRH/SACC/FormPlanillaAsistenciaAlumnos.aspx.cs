using System;
using WSViaticos;

public partial class SACC_FormPlanillaAsistenciaAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarComboCursos();
        }
    }

    protected void CargarAsistencias(object sender, EventArgs e)
    {
        this.PlanillaAsistencia.CargarAsistencias();
    }

    private void CargarComboCursos()
    {
        var cursos = Servicio().GetCursosDto();
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