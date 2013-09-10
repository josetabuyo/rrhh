using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class SACC_FormPlanillaObservaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CargarObservaciones();
            var observaciones = JsonConvert.SerializeObject(Servicio().GetObservaciones());

             this.observaciones.Value = observaciones.ToString();
        }
    }

    //private ObservacionDTO[] CargarObservaciones()
    //{
    //    return Servicio().GetObservaciones();
    //}

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}