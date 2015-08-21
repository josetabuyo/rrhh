#region

using System;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Partes_Saldo14H : System.Web.UI.UserControl
{
    private ConceptoDeLicencia _Concepto;
    private DateTime _Fecha;

    public ConceptoDeLicencia Concepto
    {
        get { return _Concepto; }
        set { _Concepto = value; }
    }

    public DateTime Fecha
    {
        get { return _Fecha; }
        set { _Fecha = value; }
    }

    public void Page_Load(object sender, EventArgs e)
    {
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        SaldoLicencia saldo;
        saldo = s.GetSaldoLicencia14FoH((Persona)Session["persona"], this.Concepto, this.Fecha);
        Session["saldoLicencia"] = saldo;
        this.LDiasAnual.Text = saldo.SaldoAnual.ToString();
        this.LDiasMes.Text = saldo.SaldoMensual.ToString();   
        
        //if (!IsPostBack)
        //{
        //    WSViaticosSoapClient s = new WSViaticosSoapClient();
        //    SaldoLicencia saldo;
        //    saldo = s.GetSaldoLicencia((Persona)Session["persona"], this.Concepto);
        //    Session["saldoLicencia"] = saldo;
        //    this.LDiasAnual.Text = saldo.SaldoAnual.ToString();
        //    this.LDiasMes.Text = saldo.SaldoMensual.ToString();

        //}
        //else
        //{
        //    SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
        //    this.LDiasAnual.Text = saldo.SaldoAnual.ToString();
        //    this.LDiasMes.Text = saldo.SaldoMensual.ToString();
        //}
    }
}
