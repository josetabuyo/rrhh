using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class SACC_FormABMDocentes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();

        if (!IsPostBack)
        {   
            this.docentesJSON.Value = servicio.GetDocentes();
        }

        MostrarDocentesEnLaGrilla(servicio);
    }

    private void MostrarDocentesEnLaGrilla(WSViaticosSoapClient servicio)
    {
        var docentes = JsonConvert.DeserializeObject(servicio.GetDocentes());
        this.docentesJSON.Value = docentes.ToString();
    }

    protected void btnBuscarPersona_Click(object sender, EventArgs e)
    {

        int dni = int.Parse(this.input_dni.Text);

        WSViaticosSoapClient servicio = new WSViaticosSoapClient();

        var persona = JsonConvert.DeserializeObject<JObject>(servicio.GetPersonaByDNI(dni));

        this.idDocente.Value = ((int)persona["id"]).ToString();       
        this.lblDatoNombre.Text = (string)persona["nombre"];
        this.lblDatoApellido.Text = (string)persona["apellido"];
        this.lblDatoDocumento.Text = ((int)persona["documento"]).ToString();
        this.lblDatoTelefono.Text = (string)persona["telefono"];
        this.lblDatoMail.Text = (string)persona["mail"];
        this.lblDatoDireccion.Text = (string)persona["direccion"];    

        //this.alumnosJSON.Value = alumnos.ToString();
    }


    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
            this.lblMensaje.Text = "Docente no guardado. Complete todos los campos";
            return;
        }

        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var docente = new Docente();

        if (this.idDocente.Value != "")
        {
            docente.Id = int.Parse(this.idDocente.Value);
        }

        docente.Dni = int.Parse(this.lblDatoDocumento.Text);
        docente.Nombre = this.lblDatoNombre.Text;
        docente.Apellido = this.lblDatoApellido.Text;

        docente = ws_viaticos.GuardarDocente(docente, (Usuario)Session["usuario"]);

        LimpiarPantalla();

        this.MostrarDocentesEnLaGrilla(ws_viaticos);
    }

    //protected void btnModificarDocente_Click(object sender, EventArgs e)
    //{
    //    if (!DatosEstanCompletos())
    //    {
    //        return;
    //    }

    //    WSViaticosSoapClient servicio = new WSViaticosSoapClient();
    //    var docente = new Docente();
    //    docente.Id = int.Parse(this.idDocente.Value);
    //    docente.Nombre = this.txtNombre.Text;
    //    docente.Apellido = this.txtApellido.Text;

    //    servicio.ModificarDocente(docente, new Usuario());
    //    LimpiarPantalla();
    //    this.MostrarDocentesEnLaGrilla(servicio);
    //}

    protected void btnQuitarDocente_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var docente = new Docente();
        docente.Id = int.Parse(this.idDocente.Value);
        docente.Dni = int.Parse(this.lblDatoDocumento.Text);
        docente.Nombre = this.lblDatoNombre.Text;
        docente.Apellido = this.lblDatoApellido.Text;

        servicio.QuitarDocente(docente, (Usuario)Session["usuario"]);
        LimpiarPantalla();
        MostrarDocentesEnLaGrilla(servicio); 
    }

    private void LimpiarPantalla()
    {
        this.idDocente.Value = "";
        this.lblDatoNombre.Text = "";
        this.lblDatoApellido.Text = "";
        this.lblDatoDocumento.Text = "";
        this.lblDatoTelefono.Text = "";
        this.lblDatoMail.Text = "";
        this.lblDatoDireccion.Text = "";    
    }

    private bool DatosEstanCompletos()
    {
        return !((this.lblDatoNombre.Text == "") || (this.lblDatoApellido.Text == "") || (this.lblDatoDocumento.Text == ""));
    }
}