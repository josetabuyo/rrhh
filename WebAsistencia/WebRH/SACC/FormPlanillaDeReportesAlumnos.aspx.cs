using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class SACC_FormPlanillaDeReportesAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();

        if (!IsPostBack)
        {
            //SetearLosTextBox();
           // this.personasJSON.Value = servicio.GetAlumnos((Usuario)Session[ConstantesDeSesion.USUARIO]);
        }

        string accion = ObtenerAccion();

        if (accion != "") 
        {
            CargarReporte(accion);
        }
       
    }

    private void CargarReporte(string accion)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        List<AlumnoDto> alumnos = new List<AlumnoDto>();
        List<CursoDto> cursos = new List<CursoDto>();

        if (accion == "modalidad")
        {
            CompletarComboDeModalidades();
            cursos = ws_viaticos.GetCursosDto((Usuario)Session[ConstantesDeSesion.USUARIO]).ToList();
            this.cursosJSON.Value = JsonConvert.SerializeObject(cursos);
            foreach (CursoDto curso in cursos)
            {
                //alumnos.AddRange(curso.Alumnos.ToList());
            }

            this.MostrarAlumnosEnLaGrilla(alumnos.Distinct().ToList());
        }
    }

    private string ObtenerAccion()
    {
        this.accion.Value = Request.QueryString["accion"];
        return this.accion.Value;
    }

    protected void btnBuscarPorModalidad_Click(object sender, EventArgs e)
    {
        //LimpiarPantalla();
        CompletarComboDeModalidades();
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        List<AlumnoDto> alumnos = new List<AlumnoDto>();
        Modalidad modalidad = ModalidadDesdeElForm();

        alumnos = ws_viaticos.ReporteAlumnosPorModalidad(modalidad).ToList();

        this.MostrarAlumnosEnLaGrilla(alumnos);
    }

    protected void btnBuscarPorCiclo_Click(object sender, EventArgs e)
    { }

    //estaría en el front
    protected void btnBuscarCampo_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        List<AlumnoDto> alumnos = new List<AlumnoDto>();

        if(this.tipo_busqueda.Value == "1")
        {
          Modalidad modalidad = ModalidadDesdeElForm();

          alumnos = ws_viaticos.ReporteAlumnosPorModalidad(modalidad).ToList();
        }

        this.MostrarAlumnosEnLaGrilla(alumnos);
    
    }

    

    protected void btnExportarAlumnos_Click(object sender, EventArgs e)
    { }

    

    protected void btnBuscarPorOrganismo_Click(object sender, EventArgs e)
    {

        //if (!DatosEstanCompletos())
        //{
        //    this.texto_mensaje_error.Value = "El Alumno no ha sido guardado. Seleccione el Alumno y la Modalidad";
        //    return;
        //}

        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var alumno = AlumnoDesdeElForm();

        alumno = ws_viaticos.GuardarAlumno(alumno, (Usuario)Session["usuario"]);

        LimpiarPantalla();

        //this.MostrarAlumnosEnLaGrilla(ws_viaticos);
    }

    //protected void btnModificarAlumno_Click(object sender, EventArgs e)
    //{

    //    if (!DatosEstanCompletos())
    //    {
    //        this.texto_mensaje_error.Value = "El Alumno no ha sido guardado. Seleccione el Alumno y la Modalidad";
    //        return;
    //    }

    //    WSViaticosSoapClient servicio = new WSViaticosSoapClient();
    //    var alumno = AlumnoDesdeElForm();

    //    servicio.ActualizarAlumno(alumno, new Usuario());

    //    LimpiarPantalla();

    //    this.MostrarAlumnosEnLaGrilla(servicio);
    //}

    protected void btnBuscarPorMateria_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var alumno = AlumnoDesdeElForm();

        //if (servicio.QuitarAlumno(alumno, (Usuario)Session["usuario"]))
        //{
        //    LimpiarPantalla();
        //   // MostrarAlumnosEnLaGrilla(servicio);

        //    this.texto_mensaje_exito.Value = "Todo bién";
        //}
        //else
        //{
        //    //this.texto_mensaje_error.Value = "No se puede eliminar el Alumno " + this.lblDatoNombre.Text + " " + this.lblDatoApellido.Text + " porque se encuentra asignado a un curso";
        //}
    }

    private Alumno AlumnoDesdeElForm()
    {

        var alumno = new Alumno();

        alumno.Modalidad = ModalidadDesdeElForm();
       // alumno.Baja = int.Parse(this.idBaja.Value);

        return alumno;
    }

    private Modalidad ModalidadDesdeElForm()
    {
        var modalidad = new Modalidad();
        modalidad.Id = int.Parse(this.cmbCampo.SelectedItem.Value);
        modalidad.Descripcion = this.cmbCampo.SelectedItem.Text;
        return modalidad;
    }

    private void CompletarComboDeModalidades()
    {
        this.cmbCampo.Items.Clear();
        ListItem todos = new ListItem();
        todos.Value = "-1";
        todos.Text = "Todos";
        this.cmbCampo.Items.Add(todos);
       // this.lblCampo.Visible = true;
        this.cmbCampo.Visible = true;
        this.btnBuscarCampo.Visible = true;

       // this.lblCampo.Text = "Cursos con Modalidad:";
        this.tipo_busqueda.Value = "1";

        var servicio = new WSViaticos.WSViaticosSoapClient();
        var modalidades = servicio.Modalidades().OrderBy(m => m.Descripcion);

        foreach (Modalidad m in modalidades)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = m.Id.ToString();
            unListItem.Text = m.Descripcion;
            this.cmbCampo.Items.Add(unListItem);
        }
    }

    //protected void btnVerAlumno_Click(object sender, EventArgs e)
    //{
    //   // Session[ConstantesDeSesion.ALUMNO] = int.Parse(this.DNIAlumnoFicha.Value);
    //    Response.Redirect("~/SACC/FormDetalleDeAlumno.aspx");
    //}

    private bool DatosEstanCompletos()
    {
        return !((this.cmbCampo.SelectedIndex < 1));
    }

    private void MostrarAlumnosEnLaGrilla(List<AlumnoDto> alumnos)
    {
        this.alumnosJSON.Value = JsonConvert.SerializeObject(alumnos);
        //var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos((Usuario)Session[ConstantesDeSesion.USUARIO]));
        //this.alumnosJSON.Value = alumnos.ToString();
    }

    private void LimpiarPantalla()
    {
        //this.lblDatoNombre.Text = "";
        //this.lblDatoApellido.Text = "";
        //this.lblDatoDocumento.Text = "";
        //this.lblDatoTelefono.Text = "";
        //this.lblDatoMail.Text = "";
        //this.lblDatoDireccion.Text = "";
        //this.texto_mensaje_error.Value = "";
        //this.texto_mensaje_exito.Value = "";
    }

    private void SetearLosTextBox()
    {
        //this.lblCampo.Visible = false;
        this.cmbCampo.Visible = false;
        this.btnBuscarCampo.Visible = false;
        this.tipo_busqueda.Value = "0";
    }

}