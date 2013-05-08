using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class SACC_FormABMAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DivMensaje.Visible = true;
        var servicio = new WSViaticos.WSViaticosSoapClient();
        SetearLosTextBox();

        if (!IsPostBack)
        {
            CompletarCombosDeModalidades();
            this.personasJSON.Value = servicio.GetAlumnos();
        }

        
        this.btnModificarAlumno.Enabled = false;
        this.btnQuitarAlumno.Enabled = false;
        MostrarAlumnosEnLaGrilla(servicio);    
    }

    private void MostrarAlumnosEnLaGrilla(WSViaticosSoapClient servicio)
    {
        this.DivMensaje.Visible = true;
        var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos());
        this.alumnosJSON.Value = alumnos.ToString();
    }

    protected void btnBuscarPersona_Click(object sender, EventArgs e)
    {
        this.DivMensaje.Visible = true;
        int dni;

        try
        {
            dni = int.Parse(this.input_dni.Text);
        }
        catch (Exception)
        {
            this.alerta_mensaje.Value = "1";
            return;
        }
        

        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var persona = new JObject();

        try
        {
           persona = JsonConvert.DeserializeObject<JObject>(servicio.GetPersonaByDNI(dni));
        }
        catch (Exception)
        {
            this.DivMensaje.Visible = true;
            this.alerta_mensaje.Value = "4";
            return;
        }
        

        this.idAlumnoAVer.Value = ((int)persona["id"]).ToString();
        this.lblDatoNombre.Text = (string)persona["nombre"];
        this.lblDatoApellido.Text = (string)persona["apellido"];
        this.lblDatoDocumento.Text = ((int)persona["documento"]).ToString();
        this.lblDatoTelefono.Text = (string)persona["telefono"];
        this.lblDatoMail.Text = (string)persona["mail"];
        this.lblDatoDireccion.Text = (string)persona["direccion"];
        this.cmbPlanDeEstudio.SelectedIndex = (int)persona["modalidad"];
        this.idBaja.Value = ((int)persona["baja"]).ToString();

        //this.alumnosJSON.Value = alumnos.ToString();
    }

    protected void btnAgregarAlumno_Click(object sender, EventArgs e)
    {
        this.DivMensaje.Visible = true;
        if (!DatosEstanCompletos())
        {
            this.alerta_mensaje.Value = "1";
            //this.lblMensaje.Text = "Alumno no guardado. Seleccione el alumno y la Modalidad";
            return;
        }
        
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var alumno = AlumnoDesdeElForm();

        alumno = ws_viaticos.GuardarAlumno(alumno, (Usuario)Session["usuario"]);

        LimpiarPantalla();

        this.MostrarAlumnosEnLaGrilla(ws_viaticos);
    }

    protected void btnModificarAlumno_Click(object sender, EventArgs e)
    {
        this.DivMensaje.Visible = true;
        if (!DatosEstanCompletos())
        {
            this.alerta_mensaje.Value = "1";
            return;
        }

        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var alumno = AlumnoDesdeElForm();

        servicio.ActualizarAlumno(alumno, new Usuario());

        LimpiarPantalla();

        this.MostrarAlumnosEnLaGrilla(servicio);
    }

    protected void btnQuitarAlumno_Click(object sender, EventArgs e)
    {
        this.DivMensaje.Visible = true;
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var alumno = AlumnoDesdeElForm();

        if (servicio.QuitarAlumno(alumno, (Usuario)Session["usuario"]))
        {
            LimpiarPantalla();
            MostrarAlumnosEnLaGrilla(servicio);
        }
        else
        {
            //mensaje de error
            this.DivMensaje.Visible = false;
            string mensaje = "No se puede eliminar el Alumno " + this.lblDatoNombre.Text +" " + this.lblDatoApellido.Text + " porque se encuentra asignado a un curso";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:alert('" + mensaje + "');</script>");
            return;
        }

        LimpiarPantalla();
    }

    private Alumno AlumnoDesdeElForm()
    {
        this.DivMensaje.Visible = true;
        var area = new Area();
        area.Id = 1;
        area.Nombre = "Area De Faby";

        var alumno = new Alumno();
        alumno.Id = int.Parse(this.idAlumnoAVer.Value);
        alumno.Apellido = this.lblDatoApellido.Text;
        alumno.Nombre = this.lblDatoNombre.Text;
        alumno.Documento = int.Parse(this.lblDatoDocumento.Text);
        alumno.Telefono = this.lblDatoTelefono.Text;
        alumno.Mail = this.lblDatoMail.Text;
        alumno.Direccion = this.lblDatoDireccion.Text;
        //alumno.Area = area;
        alumno.Modalidad = ModalidadDeAlumnoFromForm();
        alumno.Baja = int.Parse(this.idBaja.Value);

        return alumno;
    }

    private Modalidad ModalidadDeAlumnoFromForm()
    {
        this.DivMensaje.Visible = true;
        var modalidad = new Modalidad();
        modalidad.Id = int.Parse(this.cmbPlanDeEstudio.SelectedItem.Value);
        modalidad.Descripcion = this.cmbPlanDeEstudio.SelectedItem.Text;
        return modalidad;
    }

    private void CompletarCombosDeModalidades()
    {
        this.DivMensaje.Visible = true;
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var modalidades = servicio.Modalidades().OrderBy(m => m.Descripcion);

        foreach (Modalidad m in modalidades)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = m.Id.ToString();
            unListItem.Text = m.Descripcion;
            this.cmbPlanDeEstudio.Items.Add(unListItem);
        }
    }

    protected void btnVerAlumno_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SACC/FormDetalleDeAlumno.aspx"); 
    }

    private bool DatosEstanCompletos()
    {
        return !((this.lblDatoNombre.Text == "") || (this.lblDatoApellido.Text == "") || (this.lblDatoDocumento.Text == "") || (this.cmbPlanDeEstudio.SelectedIndex < 1));
    }

    private void LimpiarPantalla()
    {
        this.DivMensaje.Visible = true;
        this.lblDatoNombre.Text = "";
        this.lblDatoApellido.Text = "";
        this.lblDatoDocumento.Text = "";
        this.lblDatoTelefono.Text = "";
        this.lblDatoMail.Text = "";
        this.lblDatoDireccion.Text = "";
        this.alerta_mensaje.Value = "2";
    }

    private void SetearLosTextBox()
    {
        this.DivMensaje.Visible = true;
        this.lblDatoApellido.Attributes.Add("readonly", "true");
        this.lblDatoDocumento.Attributes.Add("readonly", "true");
        this.lblDatoNombre.Attributes.Add("readonly", "true");
        this.lblDatoTelefono.Attributes.Add("readonly", "true");
        this.lblDatoMail.Attributes.Add("readonly", "true");
        this.lblDatoDireccion.Attributes.Add("readonly", "true");
        //this.lblMensaje.Text = "";
    }

}