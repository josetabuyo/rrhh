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
        var servicio = new WSViaticos.WSViaticosSoapClient();

        if (!IsPostBack)
        {
            CompletarCombosDeEdificios();
           // CompletarCombosDeCiclos();
            this.espacios_fisicosJSON.Value = servicio.GetEspaciosFisicos();
        }

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
            unListItem.Value = edificio.Id.ToString();
            unListItem.Text = edificio.Nombre;
            this.cmbEdificio.Items.Add(unListItem);
        }
    }


     //protected void cbMostarDireccion_Click(object sender, EventArgs e)
     //{
     //    this.txtDireccion.Text = "aaa";
     //}

    protected void btnAgregarEspacioFisico_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
            this.alerta_mensaje.Value = "1";
            //this.lblMensaje.Text =  "Materia no guardada. Escriba el nombre y elija la Modalidad";
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
            //espacio_fisico.Id = int.Parse(this.idMateria.Value);
        }

        espacio_fisico.Aula = this.txtAula.Text;
       // espacio_fisico.Edificio = EdificioDeEspacioFisicoFromForm();

        return espacio_fisico;

    }

    protected void btnModificarEspacioFisico_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
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
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        
        var espacio_fisico = EspacioFisicoDelForm();

        if (servicio.QuitarEspacioFisico(espacio_fisico, (Usuario)Session["usuario"]))
        {
            LimpiarPantalla();
            MostrarEspacioFisicoEnLaGrilla(servicio);
        }
        else
        {
            //mensaje de error
            this.alerta_mensaje.Value = "3";
            return;
        }

    }

    private Edificio EdificioDeEspacioFisicoFromForm()
    {
        var edificio = new Edificio();
        edificio.Id = int.Parse(this.cmbEdificio.SelectedItem.Value);
        edificio.Nombre = this.cmbEdificio.SelectedItem.Text;
        return edificio;
    }

    //private Ciclo CicloDeMateriaFromForm()
    //{
    //    var ciclo = new Ciclo();
    //    ciclo.Id = int.Parse(this.cmbCiclo.SelectedItem.Value);
    //    ciclo.Nombre = this.cmbCiclo.SelectedItem.Text;
    //    return ciclo;
    //}

    private void LimpiarPantalla()
    {
        this.txtAula.Text = "";
        //this.id.Value = "";
        this.cmbEdificio.SelectedIndex = -1;
        this.alerta_mensaje.Value = "2";
        //this.cmbCiclo.SelectedIndex = -1;
        
    }

    private bool DatosEstanCompletos()
    {
        return !((this.txtAula.Text == "") || (this.cmbEdificio.SelectedIndex < 1));
    }
}