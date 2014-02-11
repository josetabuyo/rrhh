using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WSViaticos;


public partial class SACC_BarraDeNavegacion : System.Web.UI.UserControl
{
    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
    protected void items_accesibles()
    {
        var usuario = (Usuario)Session["usuario"];

        var menu_izq = Servicio().GetMenuPara("MACC_IZQ", usuario);
        var menu_der = Servicio().GetMenuPara("MACC_DER", usuario);
        var menu_calif = Servicio().GetMenuPara("MACC_CALIFICACIONES", usuario);
        var menu_parametria = Servicio().GetMenuPara("MACC_PARAMETRIA", usuario);

        var elementos_de_menu_derecho = string.Empty;
        var elementos_de_menu_izquierdo = string.Empty;

        elementos_de_menu_izquierdo = ArmarMenu(menu_izq, menu_calif, "Calificaciones");
        elementos_de_menu_derecho = ArmarMenu(menu_der, menu_parametria, "Parametría");
        this.menu_izquierdo.InnerHtml = elementos_de_menu_izquierdo;
        this.menu_derecho.InnerHtml = elementos_de_menu_derecho;
    }

    private static string ArmarMenu(MenuDelSistema menu, MenuDelSistema sub_menu, string menu_fijo)
    {
        var elementos_de_menu = string.Empty;
        menu.Items.ToList().ForEach(item_p =>
        {
            elementos_de_menu += "<li class='dropdown'>" +
                                       "<a href=" + item_p.Acceso.Url + ">" + item_p.NombreItem + "</a></li>";
        });

        elementos_de_menu += "<li class='dropdown'>" +
                                       "<a href='#'  class='dropdown-toggle' data-toggle='dropdown'>" + menu_fijo + "</a>" +
                                       "<ul id='menu_calificaciones' class='dropdown-menu'>";

        sub_menu.Items.ToList().ForEach(m =>
        {
            elementos_de_menu += "<li><a href=" + m.Acceso.Url + ">" + m.NombreItem + "</a></li>";
        });

        elementos_de_menu += "</ul></li>";
        return elementos_de_menu;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        items_accesibles();
    }
}