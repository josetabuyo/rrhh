using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;

public partial class CtrlAcc_service : System.Web.UI.Page
{
    private enum eMethod
    {
        mUnknown,
        mDotacion,
        mInformarLote
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Process_Event();
    }


    private void Process_Event()
    {
        var sMethod = Request["metodo"].ToString();
        var sParam = Request["json"].ToString();
        var sResp = string.Empty;
        var method = Get_Method(sMethod);

        switch (method)
        {
            case eMethod.mDotacion:
                sResp = mDotacion(sParam);
                break;

            case eMethod.mInformarLote:
                sResp = mInformarLote(sParam);
                break;                

            case eMethod.mUnknown: default:
                sResp = "";
                break;
        }
        CCryptorEngine cryp = new CCryptorEngine();
        Response.Write(cryp.Encriptar(sResp));
    }

    private eMethod Get_Method(string sMethod)
    {
        try
        {
            return (eMethod)Enum.Parse(typeof(eMethod), sMethod, true);
        }
        catch
        {
            return eMethod.mUnknown;
        }
    }


    private string mDotacion(string sParam)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        var areas = ws.GetAreas(); var personas = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            personas += "{ 'Id': '" + areas[i].Id.ToString() + "', 'Ape': 'Area', 'Nom': '" + areas[i].Nombre + "', 'Doc': 0, 'Tar': '0' },";
        }
        string resp = "{ 'Personas': [ " + personas + " ] }";
        return resp;
    }


    private string mInformarLote(string sParam)
    {
        return string.Empty;
    }

}