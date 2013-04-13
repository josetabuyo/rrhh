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
    //int anio = 2013;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void CargarAsistencias()
    {
        var id_curso = int.Parse(this.CursoId.Value);
        //var mes = int.Parse(this.Mes.Value);

        if (id_curso != 0 )
        {
        //    var dias = DateTime.DaysInMonth(anio, mes);
        //    var fecha_desde = new DateTime(2013, mes, 01);
        //    var fecha_hasta = new DateTime(2013, mes, dias);

            var planilla = Servicio().GetPlanillaEvaluacionesPorCurso(id_curso);
            var curso = JsonConvert.DeserializeObject<JObject>(Servicio().GetCursoById(id_curso));
        //    this.Curso.Value = curso.ToString();

        //    //this.planillaJSON.Value = planilla.ToString();
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
    protected void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarAsistencias();
    }
}