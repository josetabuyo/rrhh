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
            this.materiasJSON.Value = servicio.GetMaterias();
        }

        MostrarMateriasEnLaGrilla(servicio);
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
            this.lblMensaje.Text = "Materia no guardada. Escriba el nombre y elija la Modalidad";
            return;
        }

        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var materia = MateriaDelForm(); 
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

        return materia;

    }

    protected void btnModificarMateria_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
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
        servicio.QuitarMateria(materia, (Usuario)Session["usuario"]);
        LimpiarPantalla();
        MostrarMateriasEnLaGrilla(servicio);  
    }

    private Modalidad ModalidadDeMateriaFromForm()
    {
        var modalidad = new Modalidad();
        modalidad.Id = int.Parse(this.cmbPlanDeEstudio.SelectedItem.Value);
        modalidad.Descripcion = this.cmbPlanDeEstudio.SelectedItem.Text;
        return modalidad;
    }

    private void LimpiarPantalla()
    {
        this.txtNombre.Text = "";
        this.idMateria.Value = "";
        this.cmbPlanDeEstudio.SelectedIndex = -1;
    }

    private bool DatosEstanCompletos()
    {
        return !((this.txtNombre.Text == "") || (this.cmbPlanDeEstudio.SelectedIndex == -1));
    }
}