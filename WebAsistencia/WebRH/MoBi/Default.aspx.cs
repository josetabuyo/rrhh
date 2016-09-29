using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var usuario = ((Usuario)Session["usuario"]);
        var ws = new WSViaticosSoapClient();
        var lstFunciones = ws.FuncionalidadesPara(usuario.Id);
        if (lstFunciones.Any(x => x.Nombre == "1.alta_baja_asoc_bien"))
            #if DEBUG
                Response.Redirect("BienesABA.aspx");
            #else
                Response.Redirect("BienesDisponibles.aspx");
            #endif
        else if (lstFunciones.Any(x => x.Nombre == "2.consulta_bien"))
            Response.Redirect("Bienes.aspx");
        else
            Response.Redirect("../MenuPrincipal/Menu.aspx");            
    }


}