#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class Planillas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            TableCell tc; TableRow tr;
            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            Persona[] personas = s.GetPersonas((Area)Session["areaActual"], 1);
            foreach (Persona unaPersona in personas)
            {
                if (!unaPersona.Es1184)
                {

                    Table table = new Table();

                    tc = new TableCell();
                    tr = new TableRow();
                    ControlPlanillaDeFirma wc = new ControlPlanillaDeFirma();
                    wc = (ControlPlanillaDeFirma)LoadControl("~\\FormulariosOtros\\ControlPlanillaDeFirma.ascx");
                    wc.Agente = unaPersona;
                    tc.Controls.Add(wc);
                    tr.Cells.Add(tc);
                    table.Rows.Add(tr);
                    table.CssClass = "salto_de_pagina";
                    Panel.Controls.Add(table);
                }
            }
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }
    }
    protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }
}

