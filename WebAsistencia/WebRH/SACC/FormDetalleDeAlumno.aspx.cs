using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class SACC_FormDetalleDeAlumno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var servicio = new WSViaticos.WSViaticosSoapClient();
        
        if (!IsPostBack)
        {
            this.CargarGrilla();
            this.alumnoJSON.Value = Servicio().GetAlumnoByDNI((int)Session[ConstantesDeSesion.ALUMNO]);
            this.alumnoPerfilJSON.Value = JsonConvert.SerializeObject(Servicio().GetAlumnoPerfilById((JsonConvert.DeserializeObject<AlumnoDto>(this.alumnoJSON.Value)).Id));
        }

    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    //protected void btnAsignarCursos_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/SACC/FormAsignarCursos.aspx");

    //}

    private void CargarGrilla()
    {
        var servicio = Servicio();
        var cursos = servicio.GetCursosDelAlumno((int)Session[ConstantesDeSesion.ALUMNO]);
        var asistencias_por_curso = servicio.GetAsistenciasDelAlumno((int)Session[ConstantesDeSesion.ALUMNO]);
        var evaluaciones_por_curso = servicio.GetEvaluacionesDeAlumno((int)Session[ConstantesDeSesion.ALUMNO]);
        this.cursosJSON.Value = ConvertirAJSON(cursos);
        this.asistenciasJSON.Value = JsonConvert.SerializeObject(asistencias_por_curso);
        this.evaluacionesJSON.Value = JsonConvert.SerializeObject(evaluaciones_por_curso);
    }

    private string ConvertirAJSON(CursoDto[] cursos)
    {
        return JsonConvert.SerializeObject(cursos);
    }

    //private string ConvertirAJSON(EvaluacionDto[] cursos)
    //{
    //    return JsonConvert.SerializeObject(cursos);
    //}
}