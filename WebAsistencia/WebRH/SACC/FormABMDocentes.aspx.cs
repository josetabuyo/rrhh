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
       // this.DivMensaje.Visible = true;
        var servicio = new WSViaticos.WSViaticosSoapClient();
        SetearLosTextBox();

        if (!IsPostBack)
        {   
            this.docentesJSON.Value = servicio.GetDocentes();
        }

        this.btnQuitarDocente.Enabled = false;
        MostrarDocentesEnLaGrilla(servicio);
    }

    private void MostrarDocentesEnLaGrilla(WSViaticosSoapClient servicio)
    {
        //this.DivMensaje.Visible = true;
        var docentes = JsonConvert.DeserializeObject(servicio.GetDocentes());
        this.docentesJSON.Value = docentes.ToString();
    }

    protected void btnBuscarPersona_Click(object sender, EventArgs e)
    {
        //this.DivMensaje.Visible = true;
        LimpiarPantalla();
        int dni;

        try
        {
            dni = int.Parse(this.input_dni.Text);
        }
        catch (Exception)
        {
            this.texto_mensaje_error.Value = "El Docente no ha sido guardado. No ha seleccionado ningún Docente";
            //this.alerta_mensaje.Value = "1";
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
            this.texto_mensaje_error.Value = "No se encontro una persona con el D.N.I: " + dni;
            //this.alerta_mensaje.Value = "4";
            return;
        }

        this.idDocente.Value = ((int)persona["id"]).ToString();       
        this.lblDatoNombre.Text = (string)persona["nombre"];
        this.lblDatoApellido.Text = (string)persona["apellido"];
        this.lblDatoDocumento.Text = ((int)persona["documento"]).ToString();
        this.lblDatoTelefono.Text = (string)persona["telefono"];
        this.lblDatoMail.Text = (string)persona["mail"];
        this.lblDatoDireccion.Text = (string)persona["direccion"];
        this.idBaja.Value = ((int)persona["baja"]).ToString();    

        //this.alumnosJSON.Value = alumnos.ToString();
    }


    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
       // this.DivMensaje.Visible = true;
        if (!DatosEstanCompletos())
        {
            this.texto_mensaje_error.Value = "El Docente no ha sido guardado. No ha seleccionado ningún Docente";
            //this.lblMensaje.Text = "Docente no guardado. Complete todos los campos";
            //this.alerta_mensaje.Value = "1";
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
        docente.Baja = int.Parse(this.idBaja.Value);

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
        //this.DivMensaje.Visible = true;
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var docente = new Docente();
        docente.Id = int.Parse(this.idDocente.Value);
        docente.Dni = int.Parse(this.lblDatoDocumento.Text);
        docente.Nombre = this.lblDatoNombre.Text;
        docente.Apellido = this.lblDatoApellido.Text;

        if(servicio.QuitarDocente(docente, (Usuario)Session["usuario"]))
        {
            LimpiarPantalla();
            MostrarDocentesEnLaGrilla(servicio);
            this.texto_mensaje_exito.Value = "Todo bién";
        }else
        {
           // this.DivMensaje.Visible = false;
            this.texto_mensaje_error.Value = "No se puede eliminar el docente " + this.lblDatoNombre.Text + " " + this.lblDatoApellido.Text + " porque se encuentra asignado a un curso";
             //   ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:alert('" + mensaje + "');</script>");

            //mensaje de error
            //this.alerta_mensaje.Value = "3";
            //return;
        }
        
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
        this.texto_mensaje_error.Value = "";
        this.texto_mensaje_exito.Value = "";
        //this.alerta_mensaje.Value = "2";
    }

    private bool DatosEstanCompletos()
    {
        return !((this.lblDatoNombre.Text == "") || (this.lblDatoApellido.Text == "") || (this.lblDatoDocumento.Text == ""));
    }

    private void SetearLosTextBox()
    {
        this.lblDatoApellido.Attributes.Add("readonly", "true");
        this.lblDatoDocumento.Attributes.Add("readonly", "true");
        this.lblDatoNombre.Attributes.Add("readonly", "true");
        this.lblDatoTelefono.Attributes.Add("readonly", "true");
        this.lblDatoMail.Attributes.Add("readonly", "true");
        this.lblDatoDireccion.Attributes.Add("readonly", "true");
        //this.lblMensaje.Text = "";
    }
}