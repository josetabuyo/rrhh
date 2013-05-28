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
        CompletarCombosDeCiclos();
        var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos());
        this.alumnosJSON.Value = alumnos.ToString();
    }

    //protected void btnGrabarAsignacion_Click(object sender, EventArgs e)
    //{

    //    var id = this.idCursoSeleccionado.Value;

    //    if (id == "")
    //    {
    //        return; //poner un mensaje de error de curso no seleccionado
    //    }

    //    var servicio = new WSViaticosSoapClient();
    //    var alumnos_para_inscribir = alumnosAEnviar();
    //    var curso = new Curso();
    //    var idcurso = int.Parse(id);
    //    var lista_alumno = alumnos_para_inscribir.ToObject<List<Alumno>>();

    //    //servicio.InscribirAlumnosACurso(lista_alumno.ToArray(), idcurso, (Usuario)Session["usuario"]);

    //    CompletarCombosDeCursos();
    //    var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos());
    //    this.alumnosJSON.Value = alumnos.ToString();

    //}

    private JArray alumnosAEnviar()
    {
        return JArray.Parse(this.alumnosEnGrillaParaGuardar.Value);
    }

    private void CompletarCombosDeCursos()
    {
        var servicio = new WSViaticosSoapClient();
        var cursos = JsonConvert.SerializeObject(servicio.GetCursosDto());
        this.cursosJSON.Value = cursos.ToString();
    }

    private void CompletarCombosDeCiclos()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var ciclos = servicio.Ciclos().OrderBy(c => c.Id);

        foreach (Ciclo c in ciclos)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = c.Id.ToString();
            unListItem.Text = c.Nombre;
            this.cmbCiclo.Items.Add(unListItem);
        }
    }


}