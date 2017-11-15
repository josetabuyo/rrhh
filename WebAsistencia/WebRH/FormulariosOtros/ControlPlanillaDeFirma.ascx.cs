#region

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using GenCode128;


#endregion

public partial class ControlPlanillaDeFirma : System.Web.UI.UserControl
{

    public Persona Agente
    {
        set
        {
            this.LNombreAgente.Text = value.Apellido + ", " + value.Nombre;
            this.LDocumento.Text = value.Documento.ToString();
            //value.Area.Nombre.ToString();//sacar
        }
    }

    private string DiaDeLaSemana(string dia)
    {
        if (dia == "Sunday")
            return "D";
        if (dia == "Monday")
            return "L";
        if (dia == "Tuesday")
            return "M";
        if (dia == "Wednesday")
            return "M";
        if (dia == "Thursday")
            return "J";
        if (dia == "Friday")
            return "V";
        if (dia == "Saturday")
            return "S";

        return dia;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label4.Text = ((Area)Session["areaActual"]).Nombre;
        int Filas = (DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + 1) / 2;
        this.Table1.Style.Add(HtmlTextWriterStyle.Width, "100%");
        this.LPeriodo.Text = DateTime.Today.Month + "/" + DateTime.Today.Year;
        this.Table1.BorderWidth = 1;

        int idArea = ((Area) Session["areaActual"]).Id;
        this.ImbBarcode.ImageUrl = "~/FormulariosOtros/GetBarCodes.aspx?codigo=FRH0201," + this.LDocumento.Text + "," + idArea + "," + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

        TableRow tr;
        TableCell tc;
        
        DateTime PrimerDia = DateTime.Now.Subtract(TimeSpan.FromDays(DateTime.Now.Day - 1));
        for (int i = 0; i < Filas; i++)
        {
            tr = new TableRow();
            tc = new TableCell();
            tc.BorderWidth = 1;
            tc.Height = 35;
            tc.Style.Add("width", "6%");

            tc.Text = DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) + " " + PrimerDia.AddDays(i).Day.ToString();
            tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            tr.Cells.Add(tc);

            tc = new TableCell();
            if (DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) == "S" || DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) == "D")
            {
                tc.Text = "No laborable";
                tc.BorderWidth = 1;
                tc.ColumnSpan = 2;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "No laborable";
                tc.ColumnSpan = 2;
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
            }
            else
            {
                tc.Text = "&nbsp;";
                tc.BorderWidth = 1;
                tc.Style.Add("width", "7%");
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "&nbsp;";
                tc.Style.Add("width", "14.5%");
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "&nbsp;";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc.Style.Add("width", "8%");
                tc = new TableCell();
                tc.Text = "&nbsp;";
                tc.BorderWidth = 1;
                tc.Style.Add("width", "14.5%");
                tr.Cells.Add(tc);
            }

            /*2 tanda*/
            tc = new TableCell();
            if (PrimerDia.AddDays(i + Filas).Month == PrimerDia.Month)
            {
                tc.Text = DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) + " " + PrimerDia.AddDays(i + Filas).Day.ToString();
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
                tc.BorderWidth = 1;
                tc.Style.Add("width", "6%");
                tr.Cells.Add(tc);
                if (DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) == "S" || DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) == "D")
                {
                    tc = new TableCell();
                    tc.Text = "No laborable";
                    tc.BorderWidth = 1;
                    tc.ColumnSpan = 2;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "No laborable";
                    tc.BorderWidth = 1;
                    tc.ColumnSpan = 2;
                    tr.Cells.Add(tc);
                }
                else
                {
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
                    tc.Style.Add("width", "7%");
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
                    tc.Style.Add("width", "14.5%");
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
                    tr.Cells.Add(tc);
                    tc.Style.Add("width", "8%");
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
                    tc.Style.Add("width", "14.5%");
                    tr.Cells.Add(tc);
                }
            }
            else
            {
                tc.Text = "####";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "####";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "####";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "####";
                tc.BorderWidth = 1;

                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "####";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
            }
            this.Table1.Rows.Add(tr);
            this.Table1.Style.Add("border-collapse", "collapse");
        }
    }


   
   
    
}