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
        //var usuario = ((Usuario)Session["usuario"]);
        //var ws = new WSViaticosSoapClient();
        //var lstFunciones = ws.FuncionalidadesPara(usuario.Id);
        //var bPerfil1 = lstFunciones.Any(x => x.Nombre == "1.alta_baja_asoc_bien");
        //var bPerfil2 = lstFunciones.Any(x => x.Nombre == "2.consulta_bien");
        //if (bPerfil1 && bPerfil2) Response.Redirect("MenuBienes.aspx");
        //if (bPerfil1) Response.Redirect("BienesDisponibles.aspx");
        //if (bPerfil2) Response.Redirect("Bienes.aspx");
        //Response.Redirect("../MenuPrincipal/Menu.aspx");  

        Response.Redirect("../MoBi/ReportesBienes.aspx");
    }

    //#if DEBUG
    //    Response.Redirect("BienesABA.aspx");
    //#else
    //    Response.Redirect("BienesDisponibles.aspx");
    //#endif

}