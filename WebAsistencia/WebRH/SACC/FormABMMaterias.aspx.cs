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
            CompletarCombosDeModalidades();
            CompletarCombosDeCiclos();
            this.materiasJSON.Value = servicio.GetMaterias();
        }

        this.btnModificarMateria.Enabled = false;
        this.btnQuitarMateria.Enabled = false;
        MostrarMateriasEnLaGrilla(servicio);
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

    private void MostrarMateriasEnLaGrilla(WSViaticosSoapClient servicio)
    {
        var materias = JsonConvert.DeserializeObject(servicio.GetMaterias());
        this.materiasJSON.Value = materias.ToString();
    }

    private void CompletarCombosDeModalidades()
    {
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



    protected void btnAgregarMateria_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
            this.texto_mensaje_error.Value = "Materia no guardada. Complete todos los campos.";
            //this.alerta_mensaje.Value = "1";
            //this.lblMensaje.Text =  "Materia no guardada. Escriba el nombre y elija la Modalidad";
            return;
        }

        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var materia = MateriaDelForm();
        materia.Id = 0;
        materia = ws_viaticos.GuardarMateria(materia, (Usuario)Session["usuario"]);

        LimpiarPantalla();
        
        this.MostrarMateriasEnLaGrilla(ws_viaticos);
    }

    protected Materia MateriaDelForm()
    {
        var materia = new Materia();
        if (this.idMateria.Value != "")
        {
            materia.Id = int.Parse(this.idMateria.Value);
        }

        materia.Nombre = this.txtNombre.Text;
        materia.Modalidad = ModalidadDeMateriaFromForm();
        materia.Ciclo = CicloDeMateriaFromForm();

        return materia;

    }

    protected void btnModificarMateria_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
            this.texto_mensaje_error.Value = "Materia no guardada. Complete todos los campos.";
            return;
        }
  
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        var materia = MateriaDelForm();

        servicio.ModificarMateria(materia, (Usuario)Session["usuario"]);
        LimpiarPantalla();
       
        this.MostrarMateriasEnLaGrilla(servicio);
    }

    protected void btnQuitarMateria_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient servicio = new WSViaticosSoapClient();
        
        var materia = MateriaDelForm();

        if (servicio.QuitarMateria(materia, (Usuario)Session["usuario"]))
        {
            LimpiarPantalla();
            MostrarMateriasEnLaGrilla(servicio);
            this.texto_mensaje_exito.Value = "Todo bién";
        }
        else
        {
            //mensaje de error
            this.texto_mensaje_error.Value = "No se puede eliminar la Materia " + this.txtNombre.Text + " porque se encuentra asignado a un curso";
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:alert('" + mensaje + "');</script>");
            //this.alerta_mensaje.Value = "3";
            //return;
        }

    }

    private Modalidad ModalidadDeMateriaFromForm()
    {
        var modalidad = new Modalidad();
        modalidad.Id = int.Parse(this.cmbPlanDeEstudio.SelectedItem.Value);
        modalidad.Descripcion = this.cmbPlanDeEstudio.SelectedItem.Text;
        return modalidad;
    }

    private Ciclo CicloDeMateriaFromForm()
    {
        var ciclo = new Ciclo();
        ciclo.Id = int.Parse(this.cmbCiclo.SelectedItem.Value);
        ciclo.Nombre = this.cmbCiclo.SelectedItem.Text;
        return ciclo;
    }

    private void LimpiarPantalla()
    {
        this.txtNombre.Text = "";
        this.idMateria.Value = "";
        this.cmbPlanDeEstudio.SelectedIndex = -1;
        this.texto_mensaje_error.Value = "";
        this.texto_mensaje_exito.Value = "";
       // this.alerta_mensaje.Value = "2";
        this.cmbCiclo.SelectedIndex = -1;
        
    }

    private bool DatosEstanCompletos()
    {
        return !((this.txtNombre.Text == "") || (this.cmbPlanDeEstudio.SelectedIndex < 1) || (this.cmbCiclo.SelectedIndex < 1) || (this.txtNombre.Text == "Nombre"));
    }
}