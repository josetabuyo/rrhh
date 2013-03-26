<%@ WebService Language="C#" Class="AjaxWS" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

/// <summary>
/// Descripción breve de AjaxWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class AjaxWS : System.Web.Services.WebService {
    private WSViaticos.WSViaticosSoapClient backEndService;
    public AjaxWS () {
        this.backEndService = new WSViaticos.WSViaticosSoapClient();
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
    public string CrearDocumento(string documento_dto) {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        return backEndService.GuardarDocumento_Ajax(documento_dto, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
    public string GetDocumentosFiltrados(String filtros)
    {
        return backEndService.GetDocumentosFiltrados(filtros);
    }   
}

