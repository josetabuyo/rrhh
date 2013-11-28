using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ConsultaListadoPersonasACargo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //var servicio = new WSViaticos.WSViaticosSoapClient();
        MostrarPersonasEnLaGrilla();
    }

    private void MostrarPersonasEnLaGrilla()
    {
        this.personasJSON.Value = JsonConvert.SerializeObject((Persona[])Session["personas"]);
        //this.areasJSON.Value = JsonConvert.SerializeObject(servicio.GetAreasParaProtocolo());
    }
}