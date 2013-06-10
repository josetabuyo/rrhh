using System;

public partial class SACC_PrintPlanillaAsistenciaAlumnos : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
            CompletarEtiquetas();
    }
    public void CompletarEtiquetas()
    {
        this.Mes.InnerText = Request.QueryString["nombre_mes"];
        this.Docente.InnerText = Request.QueryString["docente"];
        this.Curso.InnerText = Request.QueryString["nombre_curso"];

    }
}