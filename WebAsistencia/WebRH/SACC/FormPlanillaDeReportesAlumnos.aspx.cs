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
        CargarReporte(ObtenerAccion());
    }

    private void CargarReporte(string accion)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        List<AlumnoDto> alumnos = new List<AlumnoDto>();

        CompletarCombo(accion);
        //La primer llamada es con las fechas máximas
        alumnos = ws_viaticos.ReporteAlumnos("01/01/1900", "31/12/9999", (Usuario)Session["usuario"]).ToList();
        this.MostrarAlumnosEnLaGrilla(alumnos.ToList());
    }

    private string ObtenerAccion()
    {
        this.accion.Value = Request.QueryString["accion"];
        return this.accion.Value;
    }

    private void CompletarComboDeModalidades()
    {
        AgregarOpcionTodos();

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

    private void CompletarComboDeOrganismos()
    {
        AgregarOpcionTodos();

        var servicio = new WSViaticos.WSViaticosSoapClient();
        var organismos = servicio.Organismos();

        foreach (Organismo o in organismos)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = o.Id.ToString();
            unListItem.Text = o.Descripcion;
            this.cmbCampo.Items.Add(unListItem);
        }
    }


    private void CompletarComboDeCiclos()
    {
        AgregarOpcionTodos();

        var servicio = new WSViaticos.WSViaticosSoapClient();
        var ciclos = servicio.Ciclos();

        foreach (Ciclo o in ciclos)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = o.Id.ToString();
            unListItem.Text = o.Nombre;
            this.cmbCampo.Items.Add(unListItem);
        }
    }


    private void MostrarAlumnosEnLaGrilla(List<AlumnoDto> alumnos)
    {
        this.alumnosJSON.Value = JsonConvert.SerializeObject(alumnos);
    }


    private void CompletarCombo(string accion)
    {

        if (accion == "modalidad")
        {   
            CompletarComboDeModalidades(); 
        }
        else if (accion == "organismo")
        {    
            CompletarComboDeOrganismos();
        }
        else if (accion == "ciclo")
        {    
            CompletarComboDeCiclos();
        }
        else
        {
            this.cmbCampo.Items.Clear();
            this.cmbCampo.Visible = false;
            return;
        }
    }

    private void AgregarOpcionTodos()
    {
        this.cmbCampo.Items.Clear();
        ListItem todos = new ListItem();
        todos.Value = "-1";
        todos.Text = "Todos";
        this.cmbCampo.Items.Add(todos);
        this.cmbCampo.Visible = true;
    }



}