using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Pantalla1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var documento = 21345678;

        if (!IsPostBack)
        {
            //CargarCvEstudios();
            var estudios = JsonConvert.SerializeObject(Servicio().GetCvEstudios(documento));

            this.cvEstudios.Value = estudios.ToString();
        }

    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}

