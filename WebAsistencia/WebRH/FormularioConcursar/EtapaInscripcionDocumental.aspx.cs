using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_EtapaInscripcionDocumental : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        if (!IsPostBack)
        {
           // var postul = Servicio().GetPostulacionById(usuario.Owner.Id, 86);

           // var postulacion = JsonConvert.SerializeObject(postul);

           // this.postulacion.Value = postulacion;
        }
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}