using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class SACC_FormABMMaterias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.DivMensaje.Visible = true;
        var servicio = new WSViaticos.WSViaticosSoapClient();

        if (!IsPostBack)
        {
            CompletarCombosDeEdificios();
            // CompletarCombosDeCiclos();
        }

        this.btnModificarEspacioFisico.Enabled = false;
        this.btnQuitarEspacioFisico.Enabled = false;
        MostrarEspacioFisicoEnLaGrilla(servicio);
    }

    //private void CompletarCombosDeCiclos()
    //{
    //    var servicio = new WSViaticos.WSViaticosSoapClient();
    //    var ciclos = servicio.Ciclos().OrderBy(c => c.Id);

    //    foreach (Ciclo c in ciclos)
    //    {
    //        ListItem unListItem = new ListItem();
    //        unListItem.Value = c.Id.ToString();
    //        unListItem.Text = c.Nombre;
    //        this.cmbCiclo.Items.Add(unListItem);
    //    }
    //}

    private void MostrarEspacioFisicoEnLaGrilla(WSViaticosSoapClient servicio)
    {
        var espacio_fisico = JsonConvert.DeserializeObject(servicio.GetEspaciosFisicos());
        this.espacios_fisicosJSON.Value = espacio_fisico.ToString();
    }

    private void CompletarCombosDeEdificios()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var edificios = servicio.Edificios().OrderBy(e => e.Nombre);

        foreach (Edificio edificio in edificios)
        {
            ListItem unListItem = new ListItem();
            ListItem unListItem2 = new ListItem();
            unListItem.Value = edificio.Id.ToString();
            unListItem.Text = edificio.Nombre;
            unListItem2.Value = edificio.Id.ToString();
            unListItem2.Text = edificio.Direccion;
            this.cmbEdificio.Items.Add(unListItem);
            this.cmbDireccion.Items.Add(unListItem2);
        }
    }


    protected void cbMostarDireccion_Click(object sender, EventArgs e)
    {
        this.txtDireccion.Text = this.cmbDireccion.Items.FindByValue(this.cmbEdificio.SelectedValue.ToString()).Text;
    }

    protected void btnAgregarEspacioFisico_Click(object sender, EventArgs e)
    {
        //this.DivMensaje.Visible = true;
        if (!DatosEstanCompletos())
        {
            this.texto_mensaje_error.Value = "El Espacio Físico no ha sido guardado. Complete todos los campos";
            //this.alerta_mensaje.Value = "1";
            return;
        }

        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var espacio_fisico = EspacioFisicoDelForm();

        ws_viaticos.GuardarEspacioFisico(espacio_fisico, (Usuario)Session["usuario"]);

        LimpiarPantalla();

        this.MostrarEspacioFisicoEnLaGrilla(ws_viaticos);

    }

    protected EspacioFisico EspacioFisicoDelForm()
    {
        var espacio_fisico = new EspacioFisico();
        if (this.idEspacioFisico.Value != "")
        {
            espacio_fisico.Id = int.Parse(this.idEspacioFisico.Value);
        }

        espacio_fisico.Aula = this.txtAula.Text;
        espacio_fisico.Capacidad = int.Parse(this.txtCapacidad.Text);
        espacio_fisico.Edificio = EdificioDeEspacioFisicoFromForm();

        return espacio_fisico;
    }

    protected void btnModificarEspacioFisico_Click(object sender, EventArgs e)
    {
        //this.DivMensaje.Visible = true;
        if (!DatosEstanCompletos())
        {
            this.texto_mensaje_error.Value = "El Espacio Físico no ha sido guardado. Complete todos los campos";
            //this.alerta_mensaje.Value = "1";
            return;
        }

        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var espacio_fisico = EspacioFisicoDelForm();

        servicio.ModificarEspacioFisico(espacio_fisico, (Usuario)Session["usuario"]);
        LimpiarPantalla();

        this.MostrarEspacioFisicoEnLaGrilla(servicio);
    }

    protected void btnQuitarEspacioFisico_Click(object sender, EventArgs e)
    {
        //this.DivMensaje.Visible = true;
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();

        var espacio_fisico = EspacioFisicoDelForm();

        if (servicio.QuitarEspacioFisico(espacio_fisico, (Usuario)Session["usuario"]))
        {
            LimpiarPantalla();
            MostrarEspacioFisicoEnLaGrilla(servicio);
            this.texto_mensaje_exito.Value = "Todo bién";
        }
        else
        {
            //mensaje de error
            //this.DivMensaje.Visible =false;
            this.texto_mensaje_error.Value = "No se puede eliminar el Espacio Físico " + this.cmbEdificio.SelectedItem.Text + " porque se encuentra asignado a un curso";
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:alert('" + mensaje + "');</script>");
            //this.alerta_mensaje.Value = "3";
            //return;
        }

    }

    private Edificio EdificioDeEspacioFisicoFromForm()
    {
        var edificio = new Edificio();
        edificio.Id = int.Parse(this.cmbEdificio.SelectedItem.Value);
        edificio.Nombre = this.cmbEdificio.SelectedItem.Text;
        edificio.Direccion = this.txtDireccion.Text;
        return edificio;
    }


    private void LimpiarPantalla()
    {
        this.txtAula.Text = "";
        this.idEspacioFisico.Value = "";
        //this.id.Value = "";
        this.cmbEdificio.SelectedIndex = -1;
        this.texto_mensaje_error.Value = "";
        this.texto_mensaje_exito.Value = "";
        //this.alerta_mensaje.Value = "2";
        //this.cmbCiclo.SelectedIndex = -1;

    }

    private bool DatosEstanCompletos()
    {
        return !((this.txtAula.Text == "") || (this.cmbEdificio.SelectedIndex < 1) || (this.txtCapacidad.Text ==  ""));
    }
}