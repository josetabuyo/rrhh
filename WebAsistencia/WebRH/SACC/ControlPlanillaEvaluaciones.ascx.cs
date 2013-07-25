using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using WSViaticos;
using Newtonsoft.Json;

public partial class SACC_ControlPlanillaEvaluaciones : System.Web.UI.UserControl
{
    public void CargarEvaluaciones()
    {
        var id_curso = int.Parse(this.CursoId.Value);

        if (id_curso != 0 )
        {
            var planilla = Servicio().GetPlanillaEvaluacionesPorCurso(id_curso);
            var curso = JsonConvert.DeserializeObject<JObject>(Servicio().GetCursoById(id_curso));
            this.Curso.Value = curso.ToString();

            this.planillaJSON.Value = planilla.ToString();
        }
    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
    protected void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarEvaluaciones();
    }
}