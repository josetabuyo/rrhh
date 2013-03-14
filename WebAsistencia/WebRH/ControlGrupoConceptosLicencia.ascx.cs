#region

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class ControlGrupoConceptosLicencia : System.Web.UI.UserControl
{
    private GrupoConceptosDeLicencia _Grupo;

    public GrupoConceptosDeLicencia Grupo
    {
        set 
        { 
            _Grupo = value;
            this.LNombreGrupo.Text = value.Descripcion;
            this.LDetalleGrupo.Text = value.Detalle.Replace("2.", "<br/>2.").Replace("3.", "<br/>3.");
            foreach (ConceptoDeLicencia concepto in value.Conceptos)
            {
                AgregarConcepto(concepto);
            }
        }
    }

    private void AgregarConcepto(ConceptoDeLicencia concepto)
    {
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        HyperLink hl = new HyperLink();
        hl.Text = "Art. " + concepto.Articulo + " " + concepto.Inciso + " - " + concepto.Descripcion;
        hl.Target = "_blank";

        hl.NavigateUrl = concepto.PathFormularioWeb;
        string[] fuentes = { "Tahoma" };
        hl.Font.Names = fuentes;
        hl.Font.Size = FontUnit.Small;
        
        tc.Controls.Add(hl);
        tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        tr.Cells.Add(tc);
        this.TConceptos.Rows.Add(tr);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
}
