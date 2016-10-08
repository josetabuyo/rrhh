using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class FormulariosDeLicencia_CalculoDeLicenciaOrdinaria : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            RealizarAnalsis();
        }
    }

    public void RealizarAnalsis()
    {
        if (textbox_dni.Text.Trim().Equals(string.Empty)) return;

        WSViaticosSoapClient s = new WSViaticosSoapClient();
        var persona = (Persona)Session["persona"];
        persona = new Persona();

        persona.Documento = int.Parse(this.textbox_dni.Text);
        var analisis = s.GetAnalisisLicenciaOrdinaria(persona);

        var t = this.tabla_analsis;
        t.Rows.Add(Header());
        analisis.lineas.ToList().ForEach(linea =>
        {
            t.Rows.Add(RowFrom(linea));
        });
    }

    protected TableRow Header()
    {
        var row = new TableRow();

        var cell = new TableCell();
        cell.Text = "Periodo";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "Autorizados";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "Utilizados";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "Desde";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "Hasta";
        row.Cells.Add(cell);
        
        return row;
    }

    protected TableRow RowFrom(LogCalculoVacaciones log)
    {
        var row = new TableRow();

        AddInfoPeriodo(row, log);

        var css_class = ClassInfoLicenciaFor(log);

        var cell = new TableCell();
        cell.CssClass = css_class;
        cell.Text = log.CantidadDiasDescontados.ToString();
        row.Cells.Add(cell);

        if (log.PerdidaPorVencimiento)
        {
            cell = new TableCell();
            cell.CssClass = css_class;
            cell.ColumnSpan = 2;
            cell.Text = "Vencidas";
            row.Cells.Add(cell);
        }
        else if (log.PerdidaExplicitamente)
        {
            cell = new TableCell();
            cell.CssClass = css_class;
            cell.ColumnSpan = 2;
            cell.Text = "Perdida";
            row.Cells.Add(cell);
        } else
        {
            cell = new TableCell();
            cell.CssClass = css_class;
            AddFecha(cell, log.LicenciaDesde);
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.CssClass = css_class;
            AddFecha(cell, log.LicenciaHasta);
            row.Cells.Add(cell);
        }
        
        return row;
    }



    protected void AddInfoPeriodo(TableRow row, LogCalculoVacaciones log)
    {
        var cell = new TableCell();
        var css_class = ClassInfoPeriodoFor(log.PeriodoAutorizado);
        cell.CssClass = css_class;
        SetValue(cell, log.PeriodoAutorizado);
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.CssClass = css_class;
        SetValue(cell, log.CantidadDiasAutorizados);
        row.Cells.Add(cell);
    }
    
    public string LastLicenciaClass { get; set; }
    public string LastCabeceraClass { get; set; }
    
    public string ClassInfoLicenciaFor(LogCalculoVacaciones log)
    {
        var fecha = log.LicenciaDesde;
        if (log.PerdidaExplicitamente)
        {
            return "perdidas";
        }
        if (log.PerdidaPorVencimiento)
        {
            return "vencidas";
        }
        if (fecha != DateTime.MinValue)
        {
            var new_class = NextLicenciaClass();
            LastLicenciaClass = new_class;
        }
        return LastLicenciaClass;
    }

    protected string ClassInfoPeriodoFor(int periodo)
    {
        if (periodo != 0)
        {
            var new_class = NextCabeceraClass();
            LastCabeceraClass = new_class;
        }
        return LastCabeceraClass;
        
    }

    protected string NextCabeceraClass()
    {
        if (LastCabeceraClass== "autorizacion-b")
        {
            return "autorizacion-a";
        }
        else
        {
            return "autorizacion-b";
        }
    }
    
    protected string NextLicenciaClass()
    {
        if (LastLicenciaClass == "usufructo-b")
        {
            return "usufructo-a";
        }
        else
        {
            return "usufructo-b";
        }
    }

    protected void SetValue(TableCell cell, int value)
    {
        if (value != 0)
        {
            cell.Text = value.ToString();
        }
    }

    protected void AddFecha(TableCell cell, DateTime fecha)
    {
        if (!fecha.Equals(DateTime.MinValue))
        {
            cell.Text = fecha.ToShortDateString();
        }
    }
}