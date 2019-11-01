#region

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WebRhUI;
using WSViaticos;
using System.Collections;
using Newtonsoft.Json;


#endregion

public partial class SeleccionDeArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario usuario = ((Usuario)Session["usuario"]);
        var ws = new WSViaticosSoapClient();
        //this.areasDelUsuarioJSON.Value = JsonConvert.SerializeObject(ws.AreasAdministradasPor(usuario));
        //FC: nueva funcion que busca las areas administradas por el usuario y para una funcionalidad, en este caso la 4 es ingreso_a_administracion_areas
        var areas = JsonConvert.SerializeObject(ws.AreasAdministradasPorUsuarioYFuncionalidad(usuario, 4));
        this.areasDelUsuarioJSON.Value = areas;
        
    }
}