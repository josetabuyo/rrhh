using System;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSViaticos;
using System.Collections.Generic;

public partial class SACC_FormABMCursos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CargarGrilla();
        this.CargarComboMaterias();
        this.CargarComboDocentes();
        this.CargarComboDias();
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void btnVerCurso_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormDetalleDeAlumno.aspx");
    }

    private void CargarGrilla()
    {
        var servicio = Servicio();
        var cursos = servicio.GetCursosDto();
        this.cursosJSON.Value = ConvertirAJSON(cursos);
    }

    private string ConvertirAJSON(CursoDto[] cursos)
    {
        return JsonConvert.SerializeObject(cursos);
    }

    private void CargarComboMaterias()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var materias = JsonConvert.DeserializeObject<JArray>(servicio.GetMaterias());

        this.cmbMateria.DataValueField = "Id";
        this.cmbMateria.DataTextField = "Nombre";
        this.cmbMateria.Items.Add(new ListItem("Materia", ""));
        foreach (var item in materias)
        {
            this.cmbMateria.Items.Add(new ListItem(item["nombre"].ToString(), item["id"].ToString()));
        }
    }
    private void CargarComboDocentes()
    {
        var servicio = Servicio();
        var docentes = JsonConvert.DeserializeObject<JArray>(servicio.GetDocentes());
        this.cmbDocente.DataValueField = "Id";
        this.cmbDocente.DataTextField = "Nombre";

        this.cmbDocente.Items.Add(new ListItem("Docente", ""));
        foreach (var item in docentes)
        {
            this.cmbDocente.Items.Add(new ListItem(item["nombre"].ToString() + " " + item["apellido"].ToString(),item["id"].ToString()));
        }
    }

    private void CargarComboDias()
    {
        this.cmbDia.Items.Clear();
        this.cmbDia.Items.Add(new ListItem("Día", ""));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Monday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Tuesday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Wednesday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Thursday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Friday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Saturday));
        this.cmbDia.Items.Add(NuevoDia(DayOfWeek.Sunday));
    }

    private static ListItem NuevoDia(DayOfWeek dia)
    {
        return new ListItem(DateTimeFormatInfo.CurrentInfo.GetDayName(dia), ((int)dia).ToString());
    }


    protected void btnAgregarCurso_Click(object sender, EventArgs e)
    {
        var servicio = Servicio();

        var horarios_dto = JsonConvert.DeserializeObject<JArray>(this.txtHorarios.Value);

        var curso_dto = new
        {
            nombre = this.txtNombre.Text,
            materia_id = int.Parse("0" + this.txtIdMateria.Value),
            docente_id =  int.Parse("0" + this.txtIdDocente.Value),
            horarios = horarios_dto
        };
    
        servicio.AgregarCurso(JsonConvert.SerializeObject(curso_dto));

        LimpiarFormulario();
        this.CargarGrilla();
    }
    protected void btnModificarCurso_Click(object sender, EventArgs e)
    {
        var servicio = Servicio();
        
        var curso = new Curso();
        var horario = JsonConvert.DeserializeObject(this.txtHorarios.Value);

        curso.Id = int.Parse(this.txtIdCurso.Value);
        curso.Materia = servicio.GetMateriaById(int.Parse("0" + this.txtIdMateria.Value));
        curso.Docente = servicio.GetDocenteById(int.Parse("0" + this.txtIdDocente.Value));
        
        servicio.ModificarCurso(curso);

        LimpiarFormulario();
        this.CargarGrilla();
        
    }
    protected void btnQuitarCurso_Click(object sender, EventArgs e)
    {
        var servicio = Servicio();

        var id = this.txtIdCurso.Value;

        servicio.QuitarCurso(int.Parse(id));
        this.LimpiarFormulario();
        this.CargarGrilla();
    }

    private void LimpiarFormulario()
    {
        this.txtNombre.Text = string.Empty;
        this.txtIdCurso.Value = string.Empty;
        this.txtIdDocente.Value = string.Empty;
        this.txtIdMateria.Value = string.Empty;
        this.cmbDocente.SelectedValue = "";
        this.cmbMateria.SelectedValue = "";
    }
}