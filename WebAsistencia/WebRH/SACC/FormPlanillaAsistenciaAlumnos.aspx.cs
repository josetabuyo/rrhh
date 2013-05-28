using System;
using WSViaticos;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class SACC_FormPlanillaAsistenciaAlumnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarComboCursos();
        }
    }

    protected void CargarAsistencias(object sender, EventArgs e)
    {
        this.PlanillaAsistencia.CargarAsistencias();
      
    }

    private void CargarComboCursos()
    {
        var cursos = Servicio().GetCursosDto();
        var mesesJson = new List<Object>();

        foreach (var c in cursos)
        {
            this.CmbCurso.Items.Add(new System.Web.UI.WebControls.ListItem(c.Nombre + " " + c.Materia.Ciclo.Nombre.ToUpper(), c.Id.ToString()));
            
            for (var mes = DateTime.Parse(c.FechaInicio).Month; mes <= DateTime.Parse(c.FechaFin).Month; mes++)
            {
                mesesJson.Add(new{IdCurso = c.Id, Mes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes),  NroMes= mes.ToString() });
            } 
        }
        this.MesesCurso.Value += JsonConvert.SerializeObject(mesesJson);
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        this.PlanillaAsistencia.GuardarDetalleAsistencias();
        this.PlanillaAsistencia.CargarAsistencias();
    }

}