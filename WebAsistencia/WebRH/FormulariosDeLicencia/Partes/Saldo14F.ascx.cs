﻿#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;

#endregion

public partial class FormulariosDeLicencia_Partes_Saldo14F : System.Web.UI.UserControl
{
    //private int _DiasDisponibles;
    //public int DiasDisponibles
    //{
    //    get { return _DiasDisponibles; }
    //    set { _DiasDisponibles = value; }
    //}

    //private int _DiasSolicitados;
    //public int DiasSolicitados
    //{
    //    get { return _DiasSolicitados; }
    //    set { 
    //        _DiasSolicitados = value;
    //        this.LSolicitadas.Text = value.ToString() + " Días";
    //    }
    //}

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
            SaldoLicencia saldo;
            saldo = s.GetSaldoLicencia14F((Persona)Session["persona"], this.Concepto);
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
