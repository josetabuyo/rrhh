using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Web.UI.HtmlControls;

public partial class FormularioConcursar_MenuConcursar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        var puede_cambiar_etapas = s.ElUsuarioTienePermisosPara(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, 14);
        if (puede_cambiar_etapas)
        {
            var menu = this.MenuNavegacion;
            var item_etapas = new HtmlGenericControl("li");
            item_etapas.InnerHtml = "<a href='EtapasPostulacion.aspx' >Cambiar Etapas de Postulaciones</a>";
            menu.Controls.Add(item_etapas);
        }
    }
}