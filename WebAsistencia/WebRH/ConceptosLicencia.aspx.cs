#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Linq;

#endregion

public partial class ConceptosLicencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        WSViaticosSoapClient s = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
        GrupoConceptosDeLicencia[] grupos = s.GetGruposConceptosLicencia();
        
        bool puede_solicitar_viaticos = s.ElUsuarioTienePermisosPara(((Usuario)Session[ConstantesDeSesion.USUARIO]).Id,12);

        if (!puede_solicitar_viaticos)
        {
            grupos = grupos.Where(g=>g.Id !=5).ToArray();
        }


        TableCell tc; TableRow tr;

        foreach (GrupoConceptosDeLicencia grupo in grupos)
        {
            tc = new TableCell();
            tr = new TableRow();
            ControlGrupoConceptosLicencia wc = new ControlGrupoConceptosLicencia();
            wc = (ControlGrupoConceptosLicencia)LoadControl("~\\ControlGrupoConceptosLicencia.ascx");
            wc.Grupo = grupo;
            tc.Controls.Add(wc);
            tr.Cells.Add(tc);
            this.TablaGrupos.Rows.Add(tr);
        }



    }

    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~\\Login.aspx");
        }
    }

    protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }
}
