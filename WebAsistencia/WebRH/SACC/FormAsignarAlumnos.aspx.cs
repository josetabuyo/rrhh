using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSViaticos;

public partial class SACC_FormAsignarAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticosSoapClient();

        CompletarCombosDeCursos();
        var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos());
        this.alumnosJSON.Value = alumnos.ToString();
    }

    protected void btnGrabarAsignacion_Click(object sender, EventArgs e)
    {
        var servicio = new WSViaticosSoapClient();

        var alumnos_para_inscribir = alumnosAEnviar();
        var curso = new Curso();
        var idcurso = int.Parse(this.idCursoSeleccionado.Value);

        var lista_alumno = alumnos_para_inscribir.ToObject<List<Alumno>>();

        servicio.InscribirAlumnosACurso(lista_alumno.ToArray(), idcurso, new Usuario());

    }

    private JArray alumnosAEnviar()
    {
        return JArray.Parse(this.alumnosEnGrillaParaGuardar.Value);
    }

    private void CompletarCombosDeCursos()
    {
        var servicio = new WSViaticosSoapClient();
        var cursos = JsonConvert.DeserializeObject(servicio.GetCursos());
        this.cursosJSON.Value = cursos.ToString();

    }
}