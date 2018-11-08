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
        //reemplazado por el requiere funcionalidad dentro del html

        /* WSViaticosSoapClient s = new WSViaticosSoapClient();
           var puede_cambiar_etapas = s.ElUsuarioTienePermisosParaFuncionalidadPorNombre(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, "etapas_postular");
           var puede_foliar_documentos = s.ElUsuarioTienePermisosParaFuncionalidadPorNombre(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id, "etapa_preinscripcion_documental");

           var menu = this.MenuNavegacion;
           var subMenu = this.subMenu_administracion;

            if (puede_cambiar_etapas)
          {
             // var menu = this.MenuNavegacion;
              var item_etapas = new HtmlGenericControl("li");
              item_etapas.Attributes["class"] = "dropdown";
              item_etapas.InnerHtml = "<a href='EtapasPostulacion.aspx' >Cambiar Etapas de Postulaciones</a>";
              subMenu.Controls.Add(item_etapas);
          }

          if (puede_foliar_documentos)
          {
             // var menu = this.MenuNavegacion;
              var item_etapas = new HtmlGenericControl("li");
              item_etapas.Attributes["class"] = "dropdown";
              item_etapas.InnerHtml = "<a href='EtapaInscripcionDocumental.aspx' >Foliar Postulacion</a>";
              subMenu.Controls.Add(item_etapas);
          }*/

    }
}