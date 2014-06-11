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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ElUsuarioLogueadoTieneLaFuncionalidad(int id_funcionalidad)
    {
        return backEndService.ElUsuarioTienePermisosPara(usuarioLogueado.Id, id_funcionalidad);;
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
    public string BuscarAreas(string criterio)
    {
        var respuesta = backEndService.BuscarAreas(criterio);
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

    [WebMethod(EnableSession = true)]
    public void AsignarAreaAUnUsuario(int id_usuario, int id_area)
    {
        backEndService.AsignarAreaAUnUsuario(id_usuario, id_area);
    }

    [WebMethod(EnableSession = true)]
    public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area)
    {
        backEndService.DesAsignarAreaAUnUsuario(id_usuario, id_area);
    }
    /////////////////////FIN MAU

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InscribirAlumnos(string alumnos, int id_curso)
    {
        var lista_alumnos_para_inscribir = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WSViaticos.Alumno>>(alumnos);
        return backEndService.InscribirAlumnosACurso(lista_alumnos_para_inscribir.ToArray(), id_curso, usuarioLogueado);
    }

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string ReporteAlumnosDeCursosConFecha(string fecha_desde, string fecha_hasta)
    //{
        
    //    var aaa = backEndService.ReporteAlumnosDeCursosConFecha(fecha_desde, fecha_hasta); //ver si cambiar por List<AlumnoDto>
    //    var  bbb =  Newtonsoft.Json.JsonConvert.SerializeObject(aaa);
    //    return bbb;
    //}


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string ReporteAlumnos(string fecha_desde, string fecha_hasta)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(backEndService.ReporteAlumnos(fecha_desde, fecha_hasta, usuarioLogueado));
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CambiarPassword(string pass_actual, string pass_nueva)
    {
        return backEndService.CambiarPassword(this.usuarioLogueado, pass_actual, pass_nueva);
        
    }

    [WebMethod(EnableSession = true)]
    public string ResetearPassword(int id_usuario)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(new{nueva_clave = backEndService.ResetearPassword(id_usuario)});
    }

    [WebMethod(EnableSession = true)]
    public string GetMaxHorasCatedraCurso()
    {
        var horas = Newtonsoft.Json.JsonConvert.SerializeObject(backEndService.GetMaxHorasCatedraCurso((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]));
        return horas;
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
        var Planilla = backEndService.GetPlanillaEvaluaciones(id_curso, id_instancia, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(Planilla);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetPlanillaAsistencias(int id_curso, string fecha_desde, string fecha_hasta)
    {
        DateTime v_fecha_desde = DateTime.Parse(fecha_desde);
        DateTime v_fecha_hasta = new DateTime();
        if (fecha_hasta != "")
            v_fecha_hasta = DateTime.Parse(fecha_hasta);
        var planilla = backEndService.GetPlanillaAsistencias(id_curso, v_fecha_desde, v_fecha_hasta, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(planilla);
    }


    [WebMethod(EnableSession = true)]
    public string GuardarAsistencias(string asistencias_nuevas, string asistencias_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        var evaluaciones_nuevas_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.AcumuladorDto[]>(asistencias_nuevas);
        var evaluaciones_originales_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.AcumuladorDto[]>(asistencias_originales);

        var res = backEndService.GuardarAsistencias(evaluaciones_nuevas_dto, evaluaciones_originales_dto, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }

    [WebMethod(EnableSession = true)]
    public string GuardarObservacionesCurso(int id_curso, string observaciones)
    {
        var res = backEndService.GuardarObservacionesCurso(id_curso, observaciones, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }
    
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetMesesCursoDto(int id_curso)
    {
        var meses = backEndService.GetMesesCursoDto(id_curso, (WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        return Newtonsoft.Json.JsonConvert.SerializeObject(meses);
    }
    
    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetCursosDto()
    {
        var cursos = backEndService.GetCursosDto((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        return Newtonsoft.Json.JsonConvert.SerializeObject(cursos);
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
        
        var res = backEndService.GuardarEvaluaciones(evaluaciones_nuevas_dto, evaluaciones_originales_dto, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }
    
    //GENERAL

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SetAreaActualEnSesion(int id_area)
    {
        HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = backEndService.AreasAdministradasPor(usuarioLogueado).ToList().Find(a => a.Id == id_area);
    }

    [WebMethod(EnableSession = true)]
    public string GuardarObservaciones(string observaciones_nuevas, string observaciones_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        var observaciones_nuevas_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.ObservacionDTO[]>(observaciones_nuevas);
        var observaciones_originales_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.ObservacionDTO[]>(observaciones_originales);

        var res = backEndService.GuardarObservaciones(observaciones_nuevas_dto, observaciones_originales_dto, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }

    [WebMethod(EnableSession = true)]
    public string GuardarCVDatosPersonales(WSViaticos.CvDatosPersonales datosPersonales_nuevos, WSViaticos.CvDatosPersonales datosPersonales_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        //var datosPersonales_nuevos_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.CvDatosPersonales>(datosPersonales_nuevos);
        //var datosPersonales_originales_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.CvDatosPersonales>(datosPersonales_originales);

        backEndService.GuardarCvDatosPersonales(datosPersonales_nuevos, datosPersonales_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }
    
    [WebMethod(EnableSession = true)]
    public string GuardarCVAntecedentesAcademicos(WSViaticos.CvEstudios antecedentesAcademicos_nuevos, WSViaticos.CvEstudios antecedentesAcademicos_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        var antecedentesAcademicos = backEndService.GuardarCvAntecedentesAcademicos(antecedentesAcademicos_nuevos, antecedentesAcademicos_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(antecedentesAcademicos );
    }
    
    [WebMethod(EnableSession = true)]
    public string EliminarCVAntecedentesAcademicos(WSViaticos.CvEstudios antecedentesAcademicos_borrar)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        var antecedentesAcademicos = backEndService.EliminarCvAntecedentesAcademicos(antecedentesAcademicos_borrar, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(antecedentesAcademicos );
    }

    
    [WebMethod(EnableSession = true)]
    public string GuardarCVCapacitaciones(WSViaticos.CvCertificadoDeCapacitacion capacitaciones_nuevas, WSViaticos.CvCertificadoDeCapacitacion capacitaciones_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvCapacidades(capacitaciones_nuevas, capacitaciones_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }
    
    [WebMethod(EnableSession = true)]
    public string GuardarCVDocencia(WSViaticos.CvDocencia docencias_nuevas, WSViaticos.CvDocencia docencias_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvDocencia(docencias_nuevas, docencias_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }
    
    [WebMethod(EnableSession = true)]
    public string GuardarCVEventoAcademico(WSViaticos.CvEventoAcademico eventosAcademicos_nuevos, WSViaticos.CvEventoAcademico eventosAcademicos_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvEventoAcademico(eventosAcademicos_nuevos, eventosAcademicos_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }

    [WebMethod(EnableSession = true)]
    public string GuardarCVPublicaciones(WSViaticos.CvPublicaciones publicaciones_nuevas, WSViaticos.CvPublicaciones publicaciones_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvPublicaciones(publicaciones_nuevas, publicaciones_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }

    [WebMethod(EnableSession = true)]
    public string GuardarCVMatriculas(WSViaticos.CvMatricula matriculas_nuevas, WSViaticos.CvMatricula matriculas_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvMatriculas(matriculas_nuevas, matriculas_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }


    [WebMethod(EnableSession = true)]
    public string GuardarCVInstituciones(WSViaticos.CvInstitucionesAcademicas instituciones_nuevas, WSViaticos.CvInstitucionesAcademicas instituciones_originales)
    {
        var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        backEndService.GuardarCvInstituciones(instituciones_nuevas, instituciones_originales, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject("");
    }
    
    
    
    
    

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetObservaciones()
    {
        var observaciones = backEndService.GetObservaciones();
        return Newtonsoft.Json.JsonConvert.SerializeObject(observaciones);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AgregarAntecedenteAcademico()
    {
        return "ok";
        //return backEndService.CambiarPassword(this.usuarioLogueado, pass_actual, pass_nueva);

    }
}

