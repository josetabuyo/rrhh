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
            return "Domingo";
        if (dia == "Monday")
            return "Lunes";
        if (dia == "Tuesday")
            return "Martes";
        if (dia == "Wednesday")
            return "Miercoles";
        if (dia == "Thursday")
            return "Jueves";
        if (dia == "Friday")
            return "Viernes";
        if (dia == "Saturday")
            return "Sabado";

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


            tc.Text = DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) + " " + PrimerDia.AddDays(i).Day.ToString();
            tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            tr.Cells.Add(tc);

            tc = new TableCell();
            if (DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) == "Sabado" || DiaDeLaSemana(PrimerDia.AddDays(i).DayOfWeek.ToString()) == "Domingo")
            {
                tc.Text = "No laborable";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "No laborable";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
            }
            else
            {
                tc.Text = "&nbsp;";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = "&nbsp;";
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
            }

            tc = new TableCell();
            if (PrimerDia.AddDays(i + Filas).Month == PrimerDia.Month)
            {
                tc.Text = DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) + " " + PrimerDia.AddDays(i + Filas).Day.ToString();
                tc.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
                tc.BorderWidth = 1;
                tr.Cells.Add(tc);
                if (DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) == "Sabado" || DiaDeLaSemana(PrimerDia.AddDays(i + Filas).DayOfWeek.ToString()) == "Domingo")
                {
                    tc = new TableCell();
                    tc.Text = "No laborable";
                    tc.BorderWidth = 1;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "No laborable";
                    tc.BorderWidth = 1;
                    tr.Cells.Add(tc);
                }
                else
                {
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = "&nbsp;";
                    tc.BorderWidth = 1;
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
            }
            this.Table1.Rows.Add(tr);
        }
    }


   
   
    
}