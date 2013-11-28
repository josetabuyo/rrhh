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

        var items = Servicio().ItemsDelMenu(usuario, usuario.FeaturesDescripcion.First()).ToList();
        
        var items_primarios = items.FindAll(i => i.Padre.Equals(0));

        var elementos_de_menu_derecho = string.Empty;
        var elementos_de_menu_izquierdo = string.Empty;

        items_primarios.FindAll(i => i.Posicion == "I").ForEach(item_p =>
        {
            elementos_de_menu_izquierdo += ArmarSeccionMenu(items, item_p);
        });

        items_primarios.FindAll(i => i.Posicion == "D").ForEach(item_p =>
        {
            elementos_de_menu_derecho += ArmarSeccionMenu(items, item_p);
        });

        this.menu_izquierdo.InnerHtml = elementos_de_menu_izquierdo;
        this.menu_derecho.InnerHtml = elementos_de_menu_derecho;
    }

    private static string ArmarSeccionMenu(List<ItemDeMenu> items, ItemDeMenu item_p)
    {
        var elementos_de_menu = string.Empty;
        var items_secundarios = items.FindAll(item => item.Padre == item_p.Id);
        var clase = string.Empty;
        if (items_secundarios.Count > 0)
            clase = " class='dropdown-toggle' data-toggle='dropdown' ";

        elementos_de_menu += "<li class='dropdown'>" +
                                       "<a href=" + item_p.Url + clase + ">" + item_p.NombreItem + "</a>" +
                                       "<ul id='" + item_p.Menu + "_" + item_p.NombreItem + "_" + item_p.Id + "' class='dropdown-menu'>";

        items_secundarios.ForEach(item => { elementos_de_menu += "<li><a href=" + item.Url + ">" + item.NombreItem + "</a></li>"; });

        elementos_de_menu += "</ul></li>";
        return elementos_de_menu;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        items_accesibles();
    }
}