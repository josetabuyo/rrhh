using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using WSViaticos;



public partial class CtrlAcc_service : System.Web.UI.Page
{
    private enum eMethod
    {
        mUnknown,
        mDotacion,
        mInformarLote,
        mLoginWeb
    }

    private string _User = string.Empty;
    private string _Pass = string.Empty;
    private string _Method = string.Empty;
    private string _Param = string.Empty;
    private string _JsonResp = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        string error_message = string.Empty;

        if (!Save_Params(ref error_message))
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eErrorParams, error_message, Response);
            return;
        }
        if (!Process_Event(ref error_message))
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eErrorProcess, error_message, Response);
            return;
        }
        else
        {
            ServiceResponse.Write(ServiceResponse.eStatus.eResponseOK, _JsonResp, Response);
            return;            
        }
    }

    private bool Save_Params(ref string error_message)
    {
        try {
            _User = Request["user"].ToString();
            _Pass = Request["pass"].ToString();
            _Method = Request["metodo"].ToString();
            _Param = Request["json"].ToString();
            return true;
        }
        catch( Exception ex )
        {
            error_message = ex.Message;
            return false;
        }
    }


    private bool Process_Event(ref string error_message)
    {
        try
        {
            if (!Validar_Credenciales_Usuario())
            {
                error_message = "Las credenciales del usuario son inválidas. Verifique los permisos asignados.";
                return false;
            }
            var method = this.Get_Method(_Method);
            switch (method)
            {
                case eMethod.mDotacion:
                    _JsonResp = mDotacion(_Param);
                    break;

                case eMethod.mInformarLote:
                    _JsonResp = mInformarLote(_Param);
                    break;

                case eMethod.mLoginWeb:
                    _JsonResp = true.ToString(); //mLoginWeb(); La funcion fue ejecutada anteriormente en Validar_Credenciales_Usuario()
                    break;

                default:
                    throw new Exception("Error: La petición solicitada no pudo ser identíficada.");
            }
            if (_JsonResp == string.Empty)
                throw new Exception("Error: La respuesta no pudo ser procesada correctamente.");
            return true;
        }
        catch (Exception ex)
        {
            error_message = ex.Message;
            return false;
        }
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

    private bool Validar_Credenciales_Usuario()
    {
        if (mLoginWeb().ToUpper() == "TRUE")
            return true;
        else
            return false;
    }


    private string mDotacion(string sParam)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        var json = ws.CTL_ACC_Get_Dotacion();
        return json;
    }


    private string mInformarLote(string sParam)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        return ws.CTL_ACC_Grabar_Lote(sParam);
    }


    private string mLoginWeb()
    {
        var json = "false";
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        if (ws.Login(_User, _Pass))
        {
            var usu = ws.GetUsuarioPorAlias(_User);
            var array_fun = ws.FuncionalidadesPara(usu.Id);
            if (Array.Exists( array_fun, fun => fun.Nombre == "reg_info_aplicativo" ))
                json = "true";
        } 
        return json;
    }



    public class CCryptorEngine
    {
        private string key;
        //constructor
        public CCryptorEngine()
        {
            /* Establecer una clave. La misma clave
               debe ser utilizada para descifrar
               los datos guardados en la BD. */
            key = "_RRHHyOrg_MDS_2017_";
        }

        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
                   0, ArrayResultado.Length);
        }


        public string Desencriptar(string textoEncriptado)
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar =
            Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos
            //de encriptación se le aplica hashing
            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform =
             tdes.CreateDecryptor();

            byte[] resultArray =
            cTransform.TransformFinalBlock(Array_a_Descifrar,
            0, Array_a_Descifrar.Length);

            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public string EncodeMD5(string texto)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original 
            // password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(texto);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
        }

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
            Response.Write(JsonConvert.SerializeObject(sResp));
        }

    }

}