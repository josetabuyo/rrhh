#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;

#endregion

public partial class FormulariosDeLicencia_Partes_SaldoOrdinaria : System.Web.UI.UserControl
{
    private int _DiasDisponibles;
    public int DiasDisponibles
    {
        get { return _DiasDisponibles; }
        set { _DiasDisponibles = value; }
    }

    private int _DiasSolicitados;
    public int DiasSolicitados
    {
        get { return _DiasSolicitados; }
        set { 
            _DiasSolicitados = value;
            this.LSolicitadas.Text = value.ToString() + " Días";
        }
    }

    private ConceptoDeLicencia _Concepto;

    public ConceptoDeLicencia Concepto
    {
        get { return _Concepto; }
        set { _Concepto = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();

            //WSAsistencia s = new WSAsistencia();  
            //SaldoLicencia saldo;
            //saldo = s.GetSaldoLicencia((Persona)Session["persona"], this.Concepto);
            //Session["saldoLicencia"] = saldo;
            //foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            //{
            //    InsertarDetalleDeSaldo(d);
            //}


            Persona[] personas_list = GetEmpleadosExcelFaby(); //GetSerra(); //

            for (int i = 0; i < personas_list.Length; i++)
            {
                SaldoLicencia licencia = s.GetSaldoLicencia(personas_list[i], this.Concepto);
            }
           


        }
        else
        {
            SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
            foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            {
                InsertarDetalleDeSaldo(d);
            }
        }
    }

    private void InsertarDetalleDeSaldo(SaldoLicenciaDetalle detalle)
    {
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        string[] fuentes = { "Tahoma" };
        tc.Text = "&nbsp;&nbsp;&nbsp;&nbsp;Periodo " + detalle.Periodo.ToString() + ": ";
        tc.Font.Size = FontUnit.Small;
        tc.Font.Names = fuentes;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.Text = detalle.Disponible.ToString() + " Días";
        this.DiasDisponibles += detalle.Disponible;
        tc.Font.Size = FontUnit.Small;
        tc.Font.Names = fuentes;
        tr.Cells.Add(tc);
        this.TDiasDisponibles.Rows.Add(tr);
    }

    private List<Persona> GetCasoRaro()
    {
        List<Persona> personas_list = new List<Persona>();
        var persona0 = new Persona(); persona0.Documento = 3895266; personas_list.Add(persona0);
        return personas_list;
    }


    private List<Persona> GetSerra()
    {
        List<Persona> personas_list = new List<Persona>();
        var persona0 = new Persona(); persona0.Documento = 11488589; personas_list.Add(persona0);
        return personas_list;
    }

    private Persona[] GetEmpleadosExcelFaby()
    {
        Persona[] personas_list;
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        personas_list = s.GetDNIDotacion();
        return personas_list;
    }
}
