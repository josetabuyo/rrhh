using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using Newtonsoft.Json;

public partial class CtrlAcc_service : System.Web.UI.Page
{
    private string _User = string.Empty;
    private string _Pass = string.Empty;
    private string _Method = string.Empty;
    private string _Param = string.Empty;
    private string _JsonResp = string.Empty;

    private enum eMethod
    {
        mUnknown,
        mDotacion,
        mInformarLote
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Save_Params())
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eErrorParams, string.Empty, Response);
            return;
        }
        if (!Process_Event())
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eErrorProcess, string.Empty, Response);
            return;
        }
        else
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eResponseOK, _JsonResp, Response);
            return;            
        }
    }

    private bool Save_Params()
    {
        try {
            _User = Request["user"].ToString();;
            _Pass = Request["pass"].ToString();;
            _Method = Request["metodo"].ToString();
            _Param = Request["json"].ToString();
            return true;
        }
        catch
        {
            return false;
        }
    }


    private bool Process_Event()
    {
        var method = this.Get_Method(_Method);
        switch (method)
        {
            case eMethod.mDotacion:
                _JsonResp = mDotacion(_Param);
                break;

            case eMethod.mInformarLote:
                _JsonResp = mInformarLote(_Param);
                break;                

            case eMethod.mUnknown: default:
                return false;
        }
        if (_JsonResp == string.Empty) return false;

        return true;
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


    private class ServiceResponse
    {
        public enum eStatus
        { 
            eResponseOK = 0,
            eErrorUnknow = 1,
            eErrorParams = 2,
            eErrorAuthentication = 3,
            eErrorProcess = 4
        }

        public eStatus _Status = eStatus.eErrorUnknow;
        public string _StatusDesc = string.Empty;
        public string _Json = string.Empty;

        private ServiceResponse() {}

        public static void Write(eStatus status, string json, HttpResponse Response)
        {
            var sResp = new ServiceResponse();
            sResp._Status = status;
            
            switch (sResp._Status)
            {
                case eStatus.eResponseOK:
                    sResp._StatusDesc = "Ok";
                    break;
                case eStatus.eErrorUnknow:
                    sResp._StatusDesc = "Error desconocido.";
                    break;
                case eStatus.eErrorParams:
                    sResp._StatusDesc = "Error al procesar los parametros enviados.";
                    break;
                case eStatus.eErrorAuthentication:
                    sResp._StatusDesc = "Error al autenticar las credenciales del usuario.";
                    break;
                case eStatus.eErrorProcess:
                    sResp._StatusDesc = "Error al procesar la solicitud.";
                    break;
            }
            CCryptorEngine cryp = new CCryptorEngine();
            sResp._Json = cryp.Encriptar(json);
            var output = JsonConvert.SerializeObject(sResp);
            Response.Write(output);
        }

    }

}