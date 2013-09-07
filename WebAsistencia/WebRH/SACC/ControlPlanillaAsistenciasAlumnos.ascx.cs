using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSViaticos;

public partial class ControlPlanillaAsistenciasAlumnos : System.Web.UI.UserControl
{
    int anio = 2013;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            this.CursoId.Value = Request["idCurso"];
            this.Mes.Value = Request["mes"];
        }
        CargarAsistencias();

    }

    public void CargarAsistencias()
    {
        var id_curso = int.Parse(this.CursoId.Value);
        var mes = int.Parse("0" + this.Mes.Value);
        
        if (id_curso != 0 && mes != 0)
        {
            var dias = DateTime.DaysInMonth(anio, mes);
            var fecha_desde = new DateTime(2013, mes, 01);
            var fecha_hasta = new DateTime(2013, mes, dias);

            var planilla = Servicio().GetPlanillaInasistenciaAlumnoPorMes(id_curso, fecha_desde, fecha_hasta);
            var curso = JsonConvert.DeserializeObject<JObject>(Servicio().GetCursoById(id_curso));
            this.Curso.Value = curso.ToString();

            this.planillaJSON.Value = planilla.ToString();
        }
        else
            this.planillaJSON.Value = "";
    }



    public void GuardarDetalleAsistencias()
    {
        var detalle_asistencias_JSON = JsonConvert.DeserializeObject<JArray>(this.DetalleAsistencias.Value);
        if (detalle_asistencias_JSON != null)
        {
            var servicio = Servicio();
            
            var detalle_asistencias = new List<AcumuladorDto>();
            foreach (var item in detalle_asistencias_JSON)
            {
                AcumuladorDto asistencia = new AcumuladorDto();
                asistencia.IdAlumno = int.Parse(item["id_alumno"].ToString());
                asistencia.IdCurso = int.Parse(this.CursoId.Value);
                asistencia.Fecha = DateTime.Parse(item["fecha"].ToString());
                asistencia.Valor = item["valor"].ToString();
                detalle_asistencias.Add(asistencia);
            }
            var res = servicio.GuardarDetalleAsistencias(detalle_asistencias.ToArray(), detalle_asistencias.ToArray(), (Usuario)Session["usuario"]);

            var curso = this.Curso.Value;
        }
    }


    public void ActualizarCurso(CursoDto detalle_curso_JSON)
    {
        if (detalle_curso_JSON != null)
        {
            var servicio = Servicio();
            detalle_curso_JSON.Horarios = servicio.GetCursoDtoById(detalle_curso_JSON.Id, (Usuario)Session["usuario"]).Horarios;

            servicio.ModificarCurso(detalle_curso_JSON); //, (Usuario)Session["usuario"]); Ver si hay que agregar usuario o no

        }
    }



    private WSViaticosSoapClient Servicio(){
        return new WSViaticosSoapClient();
    }
    protected void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarAsistencias();
    }
}
    


