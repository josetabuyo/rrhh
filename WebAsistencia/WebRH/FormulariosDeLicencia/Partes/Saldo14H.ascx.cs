#region

using System;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Partes_Saldo14H : System.Web.UI.UserControl
{
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
            SaldoLicencia saldo;
            saldo = s.GetSaldoLicencia((Persona)Session["persona"], this.Concepto);
            Session["saldoLicencia"] = saldo;
            this.LDiasAnual.Text = saldo.SaldoAnual.ToString();
            this.LDiasMes.Text = saldo.SaldoMensual.ToString();

        }
        else
        {
            SaldoLicencia saldo = (SaldoLicencia)Session["saldoLicencia"];
            this.LDiasAnual.Text = saldo.SaldoAnual.ToString();
            this.LDiasMes.Text = saldo.SaldoMensual.ToString();
        }
    }
}
