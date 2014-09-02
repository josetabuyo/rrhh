using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Postulaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
            var postulaciones = Servicio().GetPostulaciones(usuarioLogueado);
            var puestos = Servicio().GetCvPuestos();
             
             var puestoSerialize = JsonConvert.SerializeObject(puestos);
             var postulacionSerialize = JsonConvert.SerializeObject(postulaciones);
            this.puestos.Value = puestoSerialize;
            this.postulaciones.Value = postulacionSerialize;
        }
        
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}