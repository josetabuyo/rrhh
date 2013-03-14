#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class ParteDiario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Area area = (Area)Session["areaActual"];
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
        Persona[] personas = s.GetPersonas(area);
        this.LArea.Text = area.Nombre;
        this.LFecha.Text = DateTime.Now.ToShortDateString();

        foreach (Persona unaPersona in personas)
        {
            if (unaPersona.InasistenciaActual != null)
            {
                InsertarFila(unaPersona);
            }
        }
        this.ImageButton1.ImageUrl = "~/FormulariosOtros/GetBarCodes.aspx?codigo=FRH0202," + ((Area)Session["areaActual"]).Id + "," + DateTime.Today.ToShortDateString() + ",1,1";
    }

    private void InsertarFila(Persona unaPersona)
    {
        TableRow tr = new TableRow();
        
        TableCell tc = new TableCell();
        tc.Text = unaPersona.Documento.ToString();
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.Text = unaPersona.Apellido + ", " + unaPersona.Nombre;
        tr.Cells.Add(tc);

        tc = new TableCell();
        if (!unaPersona.InasistenciaActual.Aprobada)
        {
            tc.Text = "*";
        }
        tc.Text = tc.Text + unaPersona.InasistenciaActual.Descripcion;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.Text = unaPersona.InasistenciaActual.Desde.ToShortDateString();
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.Text = unaPersona.InasistenciaActual.Hasta.ToShortDateString();
        tr.Cells.Add(tc);

        this.TablaAsentes.Rows.Add(tr);
    }
    protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Redirect("~\\Principal.aspx");
    }
}
