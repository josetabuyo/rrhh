#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
using System.Collections.Generic;
using System.Linq;

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
            List<Persona> personas_list = s.GetTodosLosEmpleados().ToList();

            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();

            //WSAsistencia s = new WSAsistencia();  
            //SaldoLicencia saldo;

            //se hace el cálculo a partir de una lista de DNIs
            //var persona0 = new Persona();
            //var persona1 = new Persona();
            //var persona2 = new Persona();
            //var persona3 = new Persona();
            //var persona4 = new Persona();
            //var persona5 = new Persona();
            //var persona6 = new Persona();
            //var persona7 = new Persona();
            //var persona8 = new Persona();
            //var persona9 = new Persona();
            //var persona10 = new Persona();
            //var persona11 = new Persona();
            //var persona12 = new Persona();
            //var persona13 = new Persona();
            //var persona14 = new Persona();
            //var persona15 = new Persona();
            //var persona16 = new Persona();
            //var persona17 = new Persona();
            //var persona18 = new Persona();
            //var persona19 = new Persona();
            //var persona20 = new Persona();
            //var persona21 = new Persona();
            //var persona22 = new Persona();
            //var persona23 = new Persona();
            //var persona24 = new Persona();
            //var persona25 = new Persona();
            //var persona26 = new Persona();
            //var persona27 = new Persona();
            //var persona28 = new Persona();
            //var persona29 = new Persona();
            //var persona30 = new Persona();
            //var persona31 = new Persona();
            //var persona32 = new Persona();
            //var persona33 = new Persona();
            //var persona34 = new Persona();
            //var persona35 = new Persona();
            //var persona36 = new Persona();
            //var persona37 = new Persona();
            //var persona38 = new Persona();
            //var persona39 = new Persona();
            //var persona40 = new Persona();
            //var persona41 = new Persona();
            //var persona42 = new Persona();
            //var persona43 = new Persona();
            //var persona44 = new Persona();
            //var persona45 = new Persona();
            //var persona46 = new Persona();
            //var persona47 = new Persona();
            //var persona48 = new Persona();
            //var persona49 = new Persona();

            //persona0.Documento = 27820956;
            //persona1.Documento = 14101330;
            //persona2.Documento = 12888410;
            //persona3.Documento = 33004079;





           
            //personas_list.Add(persona0);
            //personas_list.Add(persona1);
            //personas_list.Add(persona2);
            //personas_list.Add(persona3);
            //personas_list.Add(persona4);
            //personas_list.Add(persona5);
            //personas_list.Add(persona6);
            //personas_list.Add(persona7);
            //personas_list.Add(persona8);
            //personas_list.Add(persona9);
            //personas_list.Add(persona10);
            //personas_list.Add(persona11);
            //personas_list.Add(persona12);
            //personas_list.Add(persona13);
            //personas_list.Add(persona14);
            //personas_list.Add(persona15);
            //personas_list.Add(persona16);
            //personas_list.Add(persona17);
            //personas_list.Add(persona18);
            //personas_list.Add(persona19);
            // personas_list.Add(persona20);
            //personas_list.Add(persona21);
            //personas_list.Add(persona22);
            //personas_list.Add(persona23);
            //personas_list.Add(persona24);
            //personas_list.Add(persona25);
            //personas_list.Add(persona26);
            //personas_list.Add(persona27);
            //personas_list.Add(persona28);
            //personas_list.Add(persona29);
            // personas_list.Add(persona30);
            //personas_list.Add(persona31);
            //personas_list.Add(persona32);
            //personas_list.Add(persona33);
            //personas_list.Add(persona34);
            //personas_list.Add(persona35);
            //personas_list.Add(persona36);
            //personas_list.Add(persona37);
            //personas_list.Add(persona38);
            //personas_list.Add(persona39);
            // personas_list.Add(persona40);
            //personas_list.Add(persona41);
            //personas_list.Add(persona42);
            //personas_list.Add(persona43);
            //personas_list.Add(persona44);
            //personas_list.Add(persona45);
            //personas_list.Add(persona46);
            //personas_list.Add(persona47);
            //personas_list.Add(persona48);
            //personas_list.Add(persona49);
            //List<SaldoLicencia> saldos = new List<SaldoLicencia>();
            personas_list.ForEach(p =>
            {
                SaldoLicencia licencia = s.GetSaldoLicencia(p, this.Concepto);
                s.GuardarLicenciaPasePermanente(p, licencia, this.Concepto);
                //saldos.Add(licencia);
            }
                );

            //var hola = "hola";
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
