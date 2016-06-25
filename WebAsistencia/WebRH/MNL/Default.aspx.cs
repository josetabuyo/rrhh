using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;

public partial class MNL_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var servicio = new WSViaticosSoapClient();
            var novedades = servicio.CambiosDeObraSocialDe(1940);

            this.novedades.Value = JsonConvert.SerializeObject(novedades); ;
        }

    }
}