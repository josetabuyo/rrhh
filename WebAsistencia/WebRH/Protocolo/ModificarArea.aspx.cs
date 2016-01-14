using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioProtocolo_ModificarArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Area area = (Area)Session["areaActual"];
        var ws = new WSViaticosSoapClient();
        this.AreaSeleccionada.Value = JsonConvert.SerializeObject(ws.AreaCompleta(area.Id));
    }


    private Area ArmarArea(Area area)
    {
        var mi_area = new Area();
        mi_area.Id = area.Id;
        mi_area.Alias = area.Alias;

        return mi_area;
    }

}
