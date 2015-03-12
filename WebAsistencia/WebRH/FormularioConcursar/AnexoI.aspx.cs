using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        //var postulacion = ((WSViaticos.Usuario)Session[ConstantesDeSesion.POSTULACION]);
        string id_postulacion = Request.QueryString["id"];  
        string fh_postulacion_ansi = Request.QueryString["fh"];
        var fh_postulacion = DateTime.Parse(fh_postulacion_ansi);

        if (!IsPostBack)
        {
            var cv = Servicio().GetCurriculumVersion(usuario.Owner.Id, fh_postulacion);
            var postulacion = Servicio().GetPostulacionById(usuario.Owner.Id, int.Parse(id_postulacion));
            var curriculum = JsonConvert.SerializeObject(cv);

            this.curriculum.Value = curriculum;
            this.postulacion.Value = JsonConvert.SerializeObject(postulacion);
        }
      
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}