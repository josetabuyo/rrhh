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

        string id_postulacion = Request.QueryString["id"];

        if (!IsPostBack)
        {
            
            var postulacion = Servicio().GetPostulacionById(usuario.Owner.Id, int.Parse(id_postulacion));

            this.postulacion.Value = JsonConvert.SerializeObject(postulacion.Numero);
        }
        
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }


}