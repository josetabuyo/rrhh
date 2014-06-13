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
<<<<<<< HEAD
            var estudios = JsonConvert.SerializeObject(Servicio().GetCvEstudios(documento));

            var cv = Servicio().GetCurriculum(documento);

            var curriculum = JsonConvert.SerializeObject(cv);
=======
            //var estudios = JsonConvert.SerializeObject(Servicio().GetCvEstudios(documento));
            //var actividades_docentes = JsonConvert.SerializeObject(Servicio().GetCvDocencia(documento));
            var curriculum = JsonConvert.SerializeObject(Servicio().GetCurriculum(documento));
>>>>>>> 0c7730678400af9e2074f693616d04cf79e5f770

            //this.cvEstudios.Value = estudios;
            //this.cvActividadesDocentes.Value = actividades_docentes;
            this.curriculum.Value = curriculum;
        }

    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}

