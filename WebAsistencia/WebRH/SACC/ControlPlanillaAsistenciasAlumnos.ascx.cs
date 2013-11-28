using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSViaticos;

public partial class ControlPlanillaAsistenciasAlumnos : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
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
   
}
    


