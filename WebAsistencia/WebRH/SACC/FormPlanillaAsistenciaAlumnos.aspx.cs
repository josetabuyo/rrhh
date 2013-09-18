using System;
using WSViaticos;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



public partial class SACC_FormPlanillaAsistenciaAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarComboCursos();
        }
    }

    private void CargarComboCursos()
    {
        var cursos = Servicio().GetCursosDto((Usuario)Session[ConstantesDeSesion.USUARIO]);
        var mesesJson = new List<Object>();

        foreach (var c in cursos)
        {
            this.CmbCurso.Items.Add(new System.Web.UI.WebControls.ListItem(c.Nombre + " " + c.Materia.Ciclo.Nombre.ToUpper(), c.Id.ToString()));
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}