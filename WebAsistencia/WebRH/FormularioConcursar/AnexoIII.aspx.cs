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
        var postulacion = HttpContext.Current.Session[ConstantesDeSesion.POSTULACION];

        if (!IsPostBack)
        {
            var cv = Servicio().GetCurriculum(usuario.Owner.Id);

            var curriculum = JsonConvert.SerializeObject(cv);

            this.curriculum.Value = curriculum;
            this.postulacion.Value = postulacion.ToString();
        }

      
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}