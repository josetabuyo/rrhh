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
        var documento = 29753914;

        if (!IsPostBack)
        {
            //CargarCvEstudios();

            var estudios = JsonConvert.SerializeObject(Servicio().GetCvEstudios(documento));

            var cv = Servicio().GetCurriculum(documento);

            var curriculum = JsonConvert.SerializeObject(cv);

            this.curriculum.Value = curriculum;
        }

    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}

