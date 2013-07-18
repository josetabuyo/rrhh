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

    [WebMethod(EnableSession = false)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
    public string GetDocumentosFiltrados(String filtros)
    {
        var docs = backEndService.GetDocumentosFiltrados(filtros);
        var docs_serializados = Newtonsoft.Json.JsonConvert.SerializeObject(docs);
        return docs_serializados;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetDocumentosEnAlerta()
    {
        var docs = backEndService.GetDocumentosEnAlerta();
        return docs;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool HayDocumentosEnAlerta()
    {
        return backEndService.HayDocumentosEnAlerta();
    }
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string TransicionarDocumento(int id_documento, int id_area_origen, int id_area_destino)
    {
        return backEndService.TransicionarDocumento(id_documento, id_area_origen, id_area_destino);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string TransicionarDocumentoConAreaIntermedia(int id_documento, int id_area_origen, int id_area_intermedia, int id_area_destino)
    {
        return backEndService.TransicionarDocumentoConAreaIntermedia(id_documento, id_area_origen, id_area_intermedia, id_area_destino);
    }   
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GuardarCambiosEnDocumento(int id_documento, int id_area_destino, string comentario)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        return backEndService.GuardarCambiosEnDocumento(id_documento, id_area_destino, comentario, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetLegajoParaDigitalizacion(int numero_documento)
    {
        var respuesta = backEndService.GetLegajoParaDigitalizacion(numero_documento);
        var respuestaSerializada =  Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetImagenSinAsignar(int legajo, string nombre_imagen)
    {
        var respuesta = backEndService.GetImagenSinAsignar(legajo, nombre_imagen);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetThumbnailsDeImagenesAsignadasAlDocumento(string tabla, int id)
    {
        var respuesta = backEndService.getThumbnailsDeImagenesAsignadasAlDocumento(tabla, id);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }
    
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AsignarImagenADocumento(string nombre_imagen, int legajo, string tabla, int id_documento)
    {
        backEndService.asignarImagenADocumento(nombre_imagen, legajo, tabla, id_documento);
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InscribirAlumnos(string alumnos, int id_curso)
    {
        var lista_alumnos_para_inscribir = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WSViaticos.Alumno>>(alumnos);
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        return backEndService.InscribirAlumnosACurso(lista_alumnos_para_inscribir.ToArray(), id_curso, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetCursosDTO()
    {
        var curso = Newtonsoft.Json.JsonConvert.SerializeObject(backEndService.GetCursosDto((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]));
        return curso.ToString();
    } 
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void IniciarServicioDeAlertas()
    {
        backEndService.IniciarServicioDeAlertas();
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DetenerServicioDeAlertas()
    {
        backEndService.DetenerServicioDeAlertas();
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string EstadoServicioDeAlertas()
    {
        return backEndService.EstadoServicioDeAlertas();
    }       
}

