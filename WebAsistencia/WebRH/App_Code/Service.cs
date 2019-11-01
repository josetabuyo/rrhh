
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Configuration;

/// <summary>
/// Descripción breve de AjaxWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class AjaxWS : System.Web.Services.WebService
{
    private WSViaticos.WSViaticosSoapClient backEndService;
    private WSViaticos.Usuario usuarioLogueado;

    public AjaxWS()
    {
        this.backEndService = new WSViaticos.WSViaticosSoapClient();
        this.usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }


    [WebMethod(EnableSession = true)]
    public string GetUsuario()
    {
        var usuario = usuarioLogueado.Owner.Nombre + " " + usuarioLogueado.Owner.Apellido;
        return usuario;
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CrearDocumento(string documento_dto)
    {
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
        var respuesta = backEndService.BuscarLegajosParaDigitalizacion(criterio, usuarioLogueado);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetImagenPorId(int id_imagen)
    {
        var respuesta = backEndService.GetImagenPorId(id_imagen, usuarioLogueado);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetThumbnailPorId(int id_imagen, int alto, int ancho)
    {
        var respuesta = backEndService.GetThumbnailPorId(id_imagen, alto, ancho, usuarioLogueado);
        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        return respuestaSerializada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int AgregarImagenSinAsignarAUnLegajo(int id_interna, string nombre_imagen, string bytes_imagen)
    {
        return backEndService.AgregarImagenSinAsignarAUnLegajo(id_interna, nombre_imagen, bytes_imagen, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int AgregarImagenAUnFolioDeUnLegajo(int id_interna, int numero_folio, string nombre_imagen, string bytes_imagen)
    {
        return backEndService.AgregarImagenAUnFolioDeUnLegajo(id_interna, numero_folio, nombre_imagen, bytes_imagen, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AsignarImagenAFolioDeLegajo(int id_imagen, int nro_folio)
    {
        backEndService.AsignarImagenAFolioDeLegajo(id_imagen, nro_folio, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AsignarImagenAFolioDeLegajoPasandoPagina(int id_imagen, int nro_folio, int pagina)
    {
        backEndService.AsignarImagenAFolioDeLegajoPasandoPagina(id_imagen, nro_folio, pagina, usuarioLogueado);
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
    public bool ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre(string nombre_funcionalidad)
    {
        return backEndService.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre(nombre_funcionalidad, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool ElUsuarioLogueadoTienePermisosParaFuncionalidadPorId(int id_funcionalidad)
    {
        return backEndService.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorId(id_funcionalidad, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad)
    {
        backEndService.ConcederFuncionalidadA(id_usuario, id_funcionalidad, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad)
    {
        backEndService.DenegarFuncionalidadA(id_usuario, id_funcionalidad, usuarioLogueado);
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

        //     respuesta = AplicarConfiguracionDeEntorno(respuesta);

        var respuestaSerializada = Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);

        return respuestaSerializada;
    }

    protected WSViaticos.MenuDelSistema AplicarConfiguracionDeEntorno(WSViaticos.MenuDelSistema respuesta)
    {
        if (EstoyEnEntornoDeDesarrollo())
        {
            AgregarWebRHAUrls(respuesta);
        }
        return respuesta;
    }

    protected void AgregarWebRHAUrls(WSViaticos.MenuDelSistema respuesta)
    {
        respuesta.Items.ToList().ForEach(item =>
        {
            item.Acceso.Url = "/WebRH" + item.Acceso.Url;
        });
    }

    protected bool EstoyEnEntornoDeDesarrollo()
    {
        return ConfigurationManager.AppSettings["developmentMode"].Equals("afkr73p21");
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
    public bool RecuperarUsuario(string criterio)
    {
        var respuesta = backEndService.RecuperarUsuario(criterio);
        return respuesta;
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
        var respuesta = backEndService.CrearUsuarioPara(id_persona, usuarioLogueado);
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
        backEndService.AsignarAreaAUnUsuario(id_usuario, id_area, usuarioLogueado);
    }

    [WebMethod(EnableSession = true)]
    public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area)
    {
        backEndService.DesAsignarAreaAUnUsuario(id_usuario, id_area, usuarioLogueado);
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
    public void EliminarLicenciaPendienteAprobacion(int id)
    {
        backEndService.EliminarLicenciaPendienteAprobacion(id);
    }


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void EliminarPasePendienteAprobacion(int id_pase)
    {
        backEndService.EliminarPasePendienteAprobacion(id_pase);
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
        return backEndService.CambiarPassword( pass_actual, pass_nueva, this.usuarioLogueado);

    }

    [WebMethod(EnableSession = true)]
    public string ResetearPassword(int id_usuario)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(new { nueva_clave = backEndService.ResetearPassword(id_usuario, usuarioLogueado) });
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
        //HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = backEndService.AreasAdministradasPor(usuarioLogueado).ToList().Find(a => a.Id == id_area);
        List<WSViaticos.Area> areas = backEndService.AreasAdministradasPorUsuarioYFuncionalidad(usuarioLogueado, 4).ToList();
        WSViaticos.Area areaEncontrada = areas.Find(a => a.Id == id_area);
        HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = areaEncontrada;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SetAreaActualEnSesionNuevo(string areaJSON)
    {
        //HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = backEndService.AreasAdministradasPor(usuarioLogueado).ToList().Find(a => a.Id == id_area);
        //List<WSViaticos.Area> areas = backEndService.AreasAdministradasPorUsuarioYFuncionalidad(usuarioLogueado, 4).ToList();
        //WSViaticos.Area areaEncontrada = areas.Find(a => a.Id == id_area);
        WSViaticos.Area area = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.Area>(areaJSON);
        HttpContext.Current.Session[ConstantesDeSesion.AREA_ACTUAL] = area;
    }

    [WebMethod(EnableSession = true)]
    public string GuardarObservaciones(string observaciones_nuevas, string observaciones_originales)
    {
        var observaciones_nuevas_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.ObservacionDTO[]>(observaciones_nuevas);
        var observaciones_originales_dto = Newtonsoft.Json.JsonConvert.DeserializeObject<WSViaticos.ObservacionDTO[]>(observaciones_originales);

        var res = backEndService.GuardarObservaciones(observaciones_nuevas_dto, observaciones_originales_dto, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(res);
    }

    #region POSTULAR

    //#region CvAntecedentesAcademicos

    //[WebMethod(EnableSession = true)]
    //public string EliminarCVAntecedenteAcademico(int antecedentesAcademicos_borrar)
    //{
    //    var antecedentesAcademicos = backEndService.EliminarCvAntecedenteAcademico(antecedentesAcademicos_borrar, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(antecedentesAcademicos);
    //}

    //#endregion

    //#region CvActividadesDocentes


    //[WebMethod(EnableSession = true)]
    //public string GuardarCVActividadDocente(WSViaticos.CvDocencia actividad_docente)
    //{

    //    var actividadDocente_guardada = backEndService.GuardarCvActividadDocente(actividad_docente, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(actividadDocente_guardada);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvActividadDocente(WSViaticos.CvDocencia actividad_docente)
    //{
    //    var un_estudio = backEndService.ActualizarCvActividadDocente(actividad_docente, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(un_estudio);
    //}

    //[WebMethod(EnableSession = true)]
    //public string EliminarCVActividadDocente(int id_actividad_docente)
    //{
    //    var antecedentesAcademicos = backEndService.EliminarCvActividadDocente(id_actividad_docente, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(antecedentesAcademicos);
    //}

    //#endregion

    //#region CvEventosAcademicos

    //[WebMethod(EnableSession = true)]
    //public string GuardarCVEventoAcademico(WSViaticos.CvEventoAcademico eventoAcademico)
    //{
    //    var eventoAcademicoGuardado = backEndService.GuardarCvEventoAcademico(eventoAcademico, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(eventoAcademicoGuardado);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCVEventoAcademico(WSViaticos.CvEventoAcademico eventoAcademico)
    //{
    //    var eventoAcademicoActualizado = backEndService.ActualizarCvEventoAcademico(eventoAcademico, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(eventoAcademicoActualizado);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvEventosAcademicos(int id_evento_academico)
    //{
    //    return backEndService.EliminarCvEventosAcademicos(id_evento_academico, usuarioLogueado);
    //}
    //#endregion

    //#region CvPublicaciones

    //[WebMethod(EnableSession = true)]
    //public string GuardarCvPublicacionesTrabajos(WSViaticos.CvPublicaciones publicacion)
    //{
    //    var publicacionGuardada = backEndService.GuardarCvPublicacionesTrabajos(publicacion, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(publicacionGuardada);
    //}
    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvPublicacionesTrabajos(WSViaticos.CvPublicaciones publicacion)
    //{
    //    var publicacionActualizada = backEndService.ActualizarCvPublicaciones(publicacion, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(publicacionActualizada);
    //}

    //[WebMethod(EnableSession = true)]
    //public string EliminarCvPublicacionesTrabajos(WSViaticos.CvPublicaciones publicacionesTrabajos_borrar)
    //{
    //    var publicacionesTrabajos = backEndService.EliminarCvPublicacionesTrabajos(publicacionesTrabajos_borrar, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(publicacionesTrabajos);
    //}

    //#endregion


    //#region CvMatriculas

    //[WebMethod(EnableSession = true)]
    //public string GuardarCVMatricula(WSViaticos.CvMatricula matricula)
    //{
    //    var matriculaGuardada = backEndService.GuardarCvMatricula(matricula, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(matriculaGuardada);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvMatricula(WSViaticos.CvMatricula una_matricula)
    //{
    //    una_matricula = backEndService.ActualizarCvMatricula(una_matricula, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(una_matricula);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvMatricula(int id_matricula)
    //{
    //    return backEndService.EliminarCvMatricula(id_matricula, usuarioLogueado);

    //}

    //#endregion

    //#region CvInstituciones
    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvInstitucionAcademica(WSViaticos.CvInstitucionesAcademicas institucion_academica)
    //{
    //    var institucion = backEndService.ActualizarCvInstitucionAcademica(institucion_academica, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(institucion);
    //}



    //[WebMethod(EnableSession = true)]
    //public string GuardarCvInstitucionAcademica(WSViaticos.CvInstitucionesAcademicas institucion_academica)
    //{
    //    var institucion = backEndService.GuardarCvInstitucionAcademica(institucion_academica, usuarioLogueado);

    //    return Newtonsoft.Json.JsonConvert.SerializeObject(institucion);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvInstitucionAcademica(int id_institucion_academica)
    //{
    //    return backEndService.EliminarCvInstitucionAcademica(id_institucion_academica, usuarioLogueado);
    //}

    //#endregion

    //#region CvExperienciasLaborales

    //[WebMethod(EnableSession = true)]
    //public string GuardarCvExperienciaLaboral(WSViaticos.CvExperienciaLaboral experiencia_laboral)
    //{
    //    var experiencia = backEndService.GuardarCvExperienciaLaboral(experiencia_laboral, usuarioLogueado);

    //    return Newtonsoft.Json.JsonConvert.SerializeObject(experiencia);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvExperienciaLaboral(WSViaticos.CvExperienciaLaboral experiencia_laboral)
    //{
    //    experiencia_laboral = backEndService.ActualizarCvExperienciaLaboral(experiencia_laboral, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(experiencia_laboral);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvExperienciaLaboral(int id_experiencia_laboral)
    //{
    //    return backEndService.EliminarCvExperienciaLaboral(id_experiencia_laboral, usuarioLogueado);
    //}

    //#endregion

    //#region CvIdiomas

    //[WebMethod(EnableSession = true)]
    //public string GuardarCvIdiomaExtranjero(WSViaticos.CvIdiomas idioma_extranjero)
    //{
    //    var idioma = backEndService.GuardarCvIdiomaExtranjero(idioma_extranjero, usuarioLogueado);

    //    return Newtonsoft.Json.JsonConvert.SerializeObject(idioma);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvIdiomaExtranjero(WSViaticos.CvIdiomas idioma_extranjero)
    //{
    //    idioma_extranjero = backEndService.ActualizarCvIdiomaExtranjero(idioma_extranjero, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(idioma_extranjero);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvIdiomaExtranjero(int id_idioma_extranjero)
    //{
    //    return backEndService.EliminarCvIdiomaExtranjero(id_idioma_extranjero, usuarioLogueado);
    //}


    //#endregion

    //#region CvCompetenciasInformaticas

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvCompetenciaInformatica(WSViaticos.CvCompetenciasInformaticas competencia_informatica)
    //{
    //    competencia_informatica = backEndService.ActualizarCvCompetenciaInformatica(competencia_informatica, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(competencia_informatica);
    //}


    //[WebMethod(EnableSession = true)]
    //public string GuardarCvCompetenciaInformatica(WSViaticos.CvCompetenciasInformaticas competencia_informatica)
    //{
    //    var competencia = backEndService.GuardarCvCompetenciaInformatica(competencia_informatica, usuarioLogueado);

    //    return Newtonsoft.Json.JsonConvert.SerializeObject(competencia);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvCompetenciaInformatica(int id_competencia_informatica)
    //{
    //    return backEndService.EliminarCvCompetenciaInformatica(id_competencia_informatica, usuarioLogueado);
    //}



    //#endregion

    //#region CvOtrasCapacidades

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvOtraCapacidad(WSViaticos.CvCapacidadPersonal otra_capacidad)
    //{
    //    otra_capacidad = backEndService.ActualizarCvOtraCapacidad(otra_capacidad, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(otra_capacidad);
    //}

    //[WebMethod(EnableSession = true)]
    //public string GuardarCvOtraCapacidad(WSViaticos.CvCapacidadPersonal otra_capacidad)
    //{
    //    backEndService.GuardarCvOtraCapacidad(otra_capacidad, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(otra_capacidad);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvOtraCapacidad(int id_capacidad)
    //{
    //    return backEndService.EliminarCvOtraCapacidad(id_capacidad, usuarioLogueado);
    //}

    //#endregion

    //#region CvActividadesCapacitacion

    //[WebMethod(EnableSession = true)]
    //public string GuardarCvActividadCapacitacion(WSViaticos.CvCertificadoDeCapacitacion actividad_capacitacion)
    //{
    //    var actividad = backEndService.GuardarCvActividadCapacitacion(actividad_capacitacion, usuarioLogueado);

    //    return Newtonsoft.Json.JsonConvert.SerializeObject(actividad);
    //}

    //[WebMethod(EnableSession = true)]
    //public string ActualizarCvActividadCapacitacion(WSViaticos.CvCertificadoDeCapacitacion actividad_capacitacion)
    //{
    //    var actividad = backEndService.ActualizarCvActividadCapacitacion(actividad_capacitacion, usuarioLogueado);
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(actividad);
    //}

    //[WebMethod(EnableSession = true)]
    //public bool EliminarCvActividadCapacitacion(int id_actividad_capacitacion)
    //{
    //    return backEndService.EliminarCvActividadCapacitacion(id_actividad_capacitacion, usuarioLogueado);
    //}

    //#endregion

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void SetPuestoEnSesion(WSViaticos.Puesto puesto)
    //{
    //    HttpContext.Current.Session[ConstantesDeSesion.PUESTO] = puesto;
    //}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SetPerfilEnSesion(WSViaticos.Perfil perfil)
    {
        HttpContext.Current.Session[ConstantesDeSesion.PERFIL] = perfil;
    }

    //public void SetPuestoEnSesion(WSViaticos.Perfil perfil)
    //{
    //    HttpContext.Current.Session[ConstantesDeSesion.PERFIL] = perfil;
    //}




    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void SetObjetoEnSesion(string nombre, string objeto)
    {
        HttpContext.Current.Session[nombre] = objeto;
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetObjetoEnSesion(string nombre)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(HttpContext.Current.Session[nombre]);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetPerfilEnSesion(WSViaticos.Perfil perfil)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(HttpContext.Current.Session[ConstantesDeSesion.PERFIL]);
    }



    //public string GetPuestoEnSesion(WSViaticos.Puesto puesto)
    //{
    //    return Newtonsoft.Json.JsonConvert.SerializeObject(HttpContext.Current.Session[ConstantesDeSesion.PUESTO]);
    //}

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetPostulacionById(int idpostulacion)
    {
        var postulacion = backEndService.GetPostulacionById(usuarioLogueado.Owner.Id, idpostulacion);
        return Newtonsoft.Json.JsonConvert.SerializeObject(postulacion);
    }

    [WebMethod(EnableSession = true)]
    public string PostularseA(WSViaticos.Postulacion una_postulacion)
    {
        var postulacion = backEndService.PostularseA(una_postulacion, usuarioLogueado);
        return Newtonsoft.Json.JsonConvert.SerializeObject(postulacion);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetComite(int idComite)
    {
        var comite = backEndService.GetComite(idComite);
        return JsonConvert.SerializeObject(comite);
    }

    #endregion



    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetObservaciones()
    {
        var observaciones = backEndService.GetObservaciones();
        return Newtonsoft.Json.JsonConvert.SerializeObject(observaciones);
    }

    //Registro Usuarios Postular
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void RegistrarNuevoUsuario(WSViaticos.AspiranteAUsuario aspirante)
    {
        backEndService.RegistrarNuevoUsuario(aspirante);
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AgregarAntecedenteAcademico()
    {
        return "ok";
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string EjecutarEnBackend(string nombre_metodo, String[] argumentos_json)
    {
        System.Reflection.MethodInfo metodo = backEndService.GetType().GetMethods().ToList().Find(m => m.Name == nombre_metodo);
        if (metodo == null) throw new Exception("Error: No se encontró el método " + nombre_metodo + " en el WEB SERVICE");

        var argumentos_esperados = metodo.GetParameters();

        var argumentos_a_enviar = new List<Object>();

        for (int i = 0; i < argumentos_json.Count(); i++)
        {
            var arg_esperado = argumentos_esperados[i];
            var arg_json = argumentos_json[i];
            if (arg_esperado.ParameterType == typeof(String)) argumentos_a_enviar.Add(arg_json);
            else argumentos_a_enviar.Add(Newtonsoft.Json.JsonConvert.DeserializeObject(arg_json, arg_esperado.ParameterType));
        }

        if (argumentos_esperados.Any(a => a.Name == "usuario"))
        {
            try
            {
                if (usuarioLogueado.GetType().Name == "UsuarioNulo") throw new Exception("Error: Debe estar logueado para acceder a esta funcionalidad");
                argumentos_a_enviar.Add(usuarioLogueado);

            }
            catch (Exception)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject("");
            }
        }
        try
        {
            var respuesta = metodo.Invoke(backEndService, argumentos_a_enviar.ToArray());

            if ((nombre_metodo == "ModificarMiMail") || (nombre_metodo == "ModificarMailRegistro"))
            {
                this.usuarioLogueado = backEndService.GetUsuarioPorId(this.usuarioLogueado.Id);
                Session[ConstantesDeSesion.USUARIO] = this.usuarioLogueado;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta);
        }
        catch (Exception e)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(e);
        }

    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string MetodosDelBackend()
    {
        var metodos = backEndService.GetType().GetMethods().ToList().Select(m => new { nombre = m.Name });
        return Newtonsoft.Json.JsonConvert.SerializeObject(metodos);
    }

    ////INICIO: DDJJ//
    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string AreasConDDJJAdministradasPor()
    //{
    //    var areas = backEndService.AreasConDDJJAdministradasPor(usuarioLogueado);
    //    var areas_serializados = Newtonsoft.Json.JsonConvert.SerializeObject(areas);
    //    return areas_serializados;
    //}

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string GetAreasParaDDJJDelMes(string valorCombo)
    //{
    //    var areas = backEndService.GetAreasParaDDJJDelMes(valorCombo, usuarioLogueado);
    //    var areas_serializados = Newtonsoft.Json.JsonConvert.SerializeObject(areas);
    //    return areas_serializados;
    //}

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string GenerarDDJJ104(List<WSViaticos.DDJJ104> lista)
    //{
    //    var resp = backEndService.GenerarDDJJ104(lista.ToArray(), usuarioLogueado);

    //    if (resp)
    //    {
    //        return "OK";
    //    }
    //    else
    //    {
    //        return "ERROR";
    //    }
    //}

    //[WebMethod(EnableSession = true)]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string ImprimirDDJJ104(List<WSViaticos.DDJJ104> lista)
    //{
    //    var ddjj = backEndService.ImprimirDDJJ104(lista.ToArray());
    //    var ddjj_serializados = Newtonsoft.Json.JsonConvert.SerializeObject(ddjj);
    //    return ddjj_serializados;
    //}

    ////FIN: DDJJ//
}

