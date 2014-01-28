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
    private WSViaticos.Usuario usuarioLogueado;
    
    public AjaxWS () {
        this.backEndService = new WSViaticos.WSViaticosSoapClient();
        this.usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
    public string CrearDocumento(string documento_dto) {        
        return backEndService.GuardarDocumento_Ajax(documento_dto, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
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
        return backEndService.GuardarCambiosEnDocumento(id_documento, id_area_destino, comentario, usuarioLogueado);
    }
    
    ////////////////////////////////////////MODI

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string BuscarLegajosParaDigitalizacion(string criterio)
    {
        var respuesta = backEndService.BuscarLegajosParaDigitalizacion(criterio);
        var respuestaSerializada =  Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetImagenPorId(int id_imagen)
    {
        var respuesta = backEndService.GetImagenPorId(id_imagen);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetThumbnailPorId(int id_imagen, int alto, int ancho)
    {
        var respuesta = backEndService.GetThumbnailPorId(id_imagen, alto, ancho);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AsignarImagenAFolioDeLegajo(int id_imagen, int nro_folio)
    {
        backEndService.AsignarImagenAFolioDeLegajo(id_imagen, nro_folio, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AsignarCategoriaADocumento(int id_categoria, string tabla, int id_documento)
    {
        backEndService.AsignarCategoriaADocumento(id_categoria, tabla, id_documento, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DesAsignarImagen(int id_imagen)
    {
        backEndService.DesAsignarImagen(id_imagen, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CategoriasDocumentosSICOI()
    {
        var respuesta = backEndService.CategoriasDocumentosSICOI();
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }
    ////////////////////////////////////////FIN MODI  
    
    /////////////////////MAU

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FuncionalidadesPara(int id_usuario)
    {
        var respuesta = backEndService.FuncionalidadesPara(id_usuario);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad)
    {
        backEndService.ConcederFuncionalidadA(id_usuario, id_funcionalidad);
    }

    [WebMethod(EnableSession = true)]
    public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad)
    {
        backEndService.DenegarFuncionalidadA(id_usuario, id_funcionalidad);
    }    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string TodasLasFuncionalidades()
    {
        var respuesta = backEndService.TodasLasFuncionalidades();
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetMenu(string nombre_menu)
    {
        var respuesta = backEndService.GetMenuPara(nombre_menu, usuarioLogueado);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string BuscarPersonas(string criterio)
    {
        var respuesta = backEndService.BuscarPersonas(criterio);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string BuscarPersonasConLegajo(string criterio)
    {
        var respuesta = backEndService.BuscarPersonasConLegajo(criterio);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;        
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetUsuarioPorIdPersona(int id_persona)
    {
        var respuesta = backEndService.GetUsuarioPorIdPersona(id_persona);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CrearUsuarioPara(int id_persona)
    {
        var respuesta = backEndService.CrearUsuarioPara(id_persona);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AreasAdministradasPor(int id_usuario)
    {
        var respuesta = backEndService.AreasAdministradasPorIdUsuario(id_usuario);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }
    /////////////////////FIN MAU

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InscribirAlumnos(string alumnos, int id_curso)
    {
        var lista_alumnos_para_inscribir = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WSViaticos.Alumno>>(alumnos);
        return backEndService.InscribirAlumnosACurso(lista_alumnos_para_inscribir.ToArray(), id_curso, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CambiarPassword(string pass_actual, string pass_nueva)
    {
        return backEndService.CambiarPassword(this.usuarioLogueado, pass_actual, pass_nueva);
        
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
        backEndService.IniciarServicioDeAlertas(PlantillaHtmlHead(), PlantillaHtmlBody());
    }



    private string PlantillaHtml()
    {
       // string plantillaHtml = System.Configuration.ConfigurationManager.AppSettings["PlantillaHtml"];

        string plantillaHtml = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "SiCOI\\EmailTemplate.htm"); 
       
        return plantillaHtml;
    }


    private string PlantillaHtmlHead()
    {
       // string plantillaHtmlhead1 = System.Configuration.ConfigurationManager.AppSettings["PlantillaHtmlHead"];
         
        string plantillaHtmlhead = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "SiCOI\\EmailTemplateHead.htm"); 
 
        return plantillaHtmlhead;
    }
    
    private string PlantillaHtmlBody()
    {
        //string plantillaHtmlbody = System.Configuration.ConfigurationManager.AppSettings["PlantillaHtmlBody"];

        string plantillaHtmlbody = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "SiCOI\\EmailTemplateBody.htm"); 
        
        return plantillaHtmlbody;
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

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetPlanillaEvaluaciones(int id_curso, int id_instancia)
    {
        var Planilla = backEndService.GetPlanillaEvaluaciones(id_curso, id_instancia);
        return Newtonsoft.Json.JsonConvert.SerializeObject(Planilla);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetInstanciasDeEvaluacion(int id_curso)
    {
        var instancias = backEndService.GetInstanciasDeEvaluacion(id_curso);
        return Newtonsoft.Json.JsonConvert.SerializeObject(instancias);
    }
    [WebMethod(EnableSession = true)]
    public string GuardarEvaluaciones(string evaluaciones_nuevas, string evaluaciones_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        var evaluaciones_nuevas_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.EvaluacionDto[]>(evaluaciones_nuevas);
        var evaluaciones_originales_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.EvaluacionDto[]>(evaluaciones_originales);
        
        var res =backEndService.GuardarEvaluaciones(evaluaciones_nuevas_dto, evaluaciones_originales_dto, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }
    
    //GENERAL

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SetAreaActualEnSesion(int id_area)
    {
        HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = backEndService.AreasAdministradasPor(usuarioLogueado).ToList().Find(a => a.Id == id_area);
    }
}

