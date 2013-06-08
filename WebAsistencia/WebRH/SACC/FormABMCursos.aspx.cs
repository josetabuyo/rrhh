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
        this.CargarComboEspaciosFisicos();
        this.CargarComboDias();
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void btnVerCurso_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormDetalleDeCurso.aspx");
    }

    private void CargarGrilla()
    {
        var servicio = Servicio();
        var cursos = servicio.GetCursosDto((Usuario)Session[ConstantesDeSesion.USUARIO]);
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
        this.materiasJSON.Value = materias.ToString();
        this.cmbMateria.Items.Add(new ListItem("Materia", ""));
        foreach (var item in materias)
        {
            this.cmbMateria.Items.Add(new ListItem(item["nombre"].ToString() + " (" + item["ciclo"]["Nombre"] + ")", item["id"].ToString()));
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
            this.cmbDocente.Items.Add(new ListItem(item["nombre"].ToString() + " " + item["apellido"].ToString(), item["id"].ToString()));
        }
    }

    private void CargarComboEspaciosFisicos()
    {
        var servicio = Servicio();
        var espacios_fisicos = JsonConvert.DeserializeObject<JArray>(servicio.GetEspaciosFisicos((Usuario)Session[ConstantesDeSesion.USUARIO]));
        this.espacios_fisicosJSON.Value = espacios_fisicos.ToString();

        this.cmbEspacioFisico.Items.Add(new ListItem("Espacio Físico", ""));
        foreach (var item in espacios_fisicos)
        {
            this.cmbEspacioFisico.Items.Add(new ListItem(item["edificio"].ToString().Substring(27).Replace('"', ' ').Trim().Replace("}", "") + ", " + "Aula: " + item["aula"].ToString(), item["id"].ToString()));
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

        var curso = new CursoDto();
        
        curso.Id = int.Parse("0" + this.txtIdCurso.Value);
        curso.Materia = servicio.GetMateriaById(int.Parse("0" + this.txtIdMateria.Value));
        curso.Docente = servicio.GetDocenteById(int.Parse("0" + this.txtIdDocente.Value));
        curso.EspacioFisico = servicio.GetEspacioFisicoById(int.Parse("0" + this.txtIdEspacioFisico.Value));
        
        var horariosDto = new List<HorarioDto>();
        GetHorariosDto(horariosDto);
        curso.Horarios = horariosDto.ToArray();
        curso.FechaInicio = txtFechaInicio.Text;
        curso.FechaFin = txtFechaFin.Text;
      

        servicio.AgregarCurso(curso);

        LimpiarFormulario();
        this.CargarGrilla();
    }
    protected void btnModificarCurso_Click(object sender, EventArgs e)
    {
        var servicio = Servicio();

        var curso = new CursoDto();

        curso.Id = int.Parse(this.txtIdCurso.Value);
        curso.Materia = servicio.GetMateriaById(int.Parse("0" + this.txtIdMateria.Value));
        curso.Docente = servicio.GetDocenteById(int.Parse("0" + this.txtIdDocente.Value));
        curso.EspacioFisico = servicio.GetEspacioFisicoById(int.Parse("0" + this.txtIdEspacioFisico.Value));
       
        var horariosDto = new List<HorarioDto>();
        GetHorariosDto(horariosDto);
        curso.Horarios = horariosDto.ToArray();
        curso.FechaInicio = txtFechaInicio.Text;
        curso.FechaFin = txtFechaFin.Text;
        servicio.ModificarCurso(curso);

        LimpiarFormulario();
        this.CargarGrilla();

    }

    private void GetHorariosDto(List<HorarioDto> horariosDto)
    {
        var horarios = JsonConvert.DeserializeObject<JArray>(this.txtHorarios.Value);
        foreach (var h in horarios)
        {
            var horario = new HorarioDto() { NumeroDia = int.Parse(h["NumeroDia"].ToString()), Dia = h["Dia"].ToString(), HoraDeInicio = h["HoraDeInicio"].ToString(), HoraDeFin = h["HoraDeFin"].ToString(), HorasCatedra = int.Parse(h["HorasCatedra"].ToString()) };
            horariosDto.Add(horario);
        }
    }
    protected void btnQuitarCurso_Click(object sender, EventArgs e)
    {
        var servicio = Servicio();
        
        var curso = new CursoDto();
        var horarios = JsonConvert.DeserializeObject<JArray>(this.txtHorarios.Value);

        curso.Id = int.Parse(this.txtIdCurso.Value);
        curso.Materia = servicio.GetMateriaById(int.Parse("0" + this.txtIdMateria.Value));
        curso.Docente = servicio.GetDocenteById(int.Parse("0" + this.txtIdDocente.Value));
        curso.EspacioFisico = servicio.GetEspacioFisicoById(int.Parse("0" + this.txtIdEspacioFisico.Value));
        
        var horariosDto = new List<HorarioDto>();
        foreach (var h in horarios)
        {
            var horario = new HorarioDto() { NumeroDia = int.Parse(h["NumeroDia"].ToString()), Dia = h["Dia"].ToString(), HoraDeInicio = h["HoraDeInicio"].ToString(), HoraDeFin = h["HoraDeFin"].ToString() };
            horariosDto.Add(horario);
        }
        curso.Horarios = horariosDto.ToArray();

        if (servicio.QuitarCurso(curso, (Usuario)Session["usuario"]))
        {
            this.LimpiarFormulario();
            this.CargarGrilla();
        }
    }

    private void LimpiarFormulario()
    {
        this.txtIdCurso.Value = string.Empty;
        this.txtIdDocente.Value = string.Empty;
        this.txtIdEspacioFisico.Value = string.Empty;
        this.txtIdMateria.Value = string.Empty;
        this.cmbDocente.SelectedValue = "";
        this.cmbMateria.SelectedValue = "";
        this.cmbEspacioFisico.SelectedValue = "";
    }
}