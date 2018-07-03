using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class EvaluacionDesempenio_ABMComites : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        if (!IsPostBack)
        {
            List<ComiteEvaluacionDesempenio> comites;

            try
            {
                comites = new List<ComiteEvaluacionDesempenio>(Servicio().GetAllComites());
            }
            catch (Exception excepcion)
            {

                throw new Exception("No se pudo traer los comites. Mensaje: " + excepcion.Message);
            }


            var comites_json = JsonConvert.SerializeObject(comites);

            this.ComitesHiddenField.Value = comites_json;
        }
    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}