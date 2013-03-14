using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SACC_Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCargarPlanilla_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/CreacionDePlanilla.aspx");
    }

    protected void btnImprimirPlanilla_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormPlanillaAsistenciaAlumnos.aspx");
    }
    protected void btnABMAlumnos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormABMAlumnos.aspx");
    }


    protected void btnABMCursos_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormABMCursos.aspx");

    }

    protected void btnUnAlumnoParticular_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormDetalleDeAlumno.aspx");

    }

    protected void btnUnCursoParticular_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormDetalleDeCurso.aspx");

    }
}