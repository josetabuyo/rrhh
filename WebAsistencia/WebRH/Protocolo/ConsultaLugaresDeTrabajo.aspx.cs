using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ConsultaLugaresDeTrabajo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        MostrarAreasEnLaGrilla(servicio);
    }

    private void MostrarAreasEnLaGrilla(WSViaticosSoapClient servicio)
    {
        var areas = servicio.GetAreasParaLugaresDeTrabajo();
        this.areasJSON.Value = JsonConvert.SerializeObject(areas);
    }
}