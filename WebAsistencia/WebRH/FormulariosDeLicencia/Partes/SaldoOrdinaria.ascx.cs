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
        set
        {
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
            SaldoLicencia saldo;

            //se hace el cálculo a partir de una lista de DNIs
            var persona0 = new Persona();
            var persona1 = new Persona();
            var persona2 = new Persona();
            var persona3 = new Persona();
            var persona4 = new Persona();
            var persona5 = new Persona();
            var persona6 = new Persona();
            var persona7 = new Persona();
            var persona8 = new Persona();
            var persona9 = new Persona();

            persona0.Documento = 24068918;
            persona1.Documento = 22302255;
            persona2.Documento = 27227139;
            persona3.Documento = 11361763;
            persona4.Documento = 28351923;
            persona5.Documento = 28991731;
            persona6.Documento = 17086768;
            persona7.Documento = 29646177;
            persona8.Documento = 25612213;
            persona9.Documento = 20007869;

            List<Persona> personas_list = new List<Persona>();
            personas_list.Add(persona0);
            personas_list.Add(persona1);
            personas_list.Add(persona2);
            personas_list.Add(persona3);
            personas_list.Add(persona4);
            personas_list.Add(persona5);
            personas_list.Add(persona6);
            personas_list.Add(persona7);
            personas_list.Add(persona8);
            personas_list.Add(persona9);
            List<SaldoLicencia> saldos = new List<SaldoLicencia>();
            personas_list.ForEach(p =>
            {
                saldos.Add(s.GetSaldoLicencia(p, this.Concepto));
      
            }
                );

            var hola = "hola";
            //saldo = s.GetSaldoLicencia((Persona)Session["persona"], this.Concepto);
           
            //foreach (SaldoLicenciaDetalle d in saldo.Detalle)
            //{
            //    InsertarDetalleDeSaldo(d);
            //}
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
}
