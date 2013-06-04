using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;


public partial class SACC_BarraDeNavegacion : System.Web.UI.UserControl
{
    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
    protected void items_accesibles()
    {
        
        var items = Servicio().ItemsDelMenu("MenuSACC", (Usuario)Session["usuario"]);

        items.ToList().ForEach(item =>
        {
            var nuevo_elemento = new Literal() { Text="<li><a href=" + item.Url + ">" + item.NombreItem + "</a></li>"};
            this.sub_menu_parametria.Controls.Add(nuevo_elemento);

        });
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        items_accesibles();
    }
}