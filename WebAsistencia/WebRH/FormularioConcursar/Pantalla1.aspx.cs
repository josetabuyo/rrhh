using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Pantalla1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnAgregarAntecedenteAcademico_Click(object sender, EventArgs e)
    //{
             
    //    WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
    //    var antecedente = AntecedenteAcademicoDesdeElForm();

    //    //antecedente = ws_viaticos.GuardarAlumno(alumno, (Usuario)Session["usuario"]);

    //    //LimpiarPantalla();

    //    this.MostrarAntecedenteAcademicoEnLaGrilla(ws_viaticos);
    //}

    //private object AntecedenteAcademicoDesdeElForm()
    //{
    //    var antecedentes = new List<string>() {"Secundario", "","","Mater","Bachiller","Orientado a programacion","SI"  };

    //    return antecedentes;
    //}

    //private void MostrarAntecedenteAcademicoEnLaGrilla(WSViaticosSoapClient servicio)
    //{

    //    //var alumnos = JsonConvert.DeserializeObject(servicio.GetAlumnos((Usuario)Session[ConstantesDeSesion.USUARIO]));
    //    this.alumnosJSON.Value = alumnos.ToString();
    //}

}

