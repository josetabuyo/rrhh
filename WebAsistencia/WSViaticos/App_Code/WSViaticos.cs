using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.Services;
using General;
using General.Calendario;
using General.Repositorios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[WebService(Namespace = "http://wsviaticos.gov.ar/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSViaticos : System.Web.Services.WebService
{
    public WSViaticos()
    {

    }

    [WebMethod]
    public Usuario[] GetUsuarios()
    {
        RepositorioUsuarios repoUsuarios = new RepositorioUsuarios(Conexion());
        List<Usuario> usuarios = repoUsuarios.GetTodosLosUsuarios();
        Usuario[] retuUsuarios = new Usuario[usuarios.Count];
        for (int i = 0; i < usuarios.Count; i++)
        {
            retuUsuarios[i] = usuarios[i];
        }
        return retuUsuarios;

    }

    [WebMethod]
    public void EliminarInasistenciaActual(Persona unaPersona)
    {
        RepositorioPersonas repoPersonas = new RepositorioPersonas();
        repoPersonas.EliminarInasistenciaActual(unaPersona);
    }

    [WebMethod]
    public void EliminarPase(PaseDeArea unPase)
    {
        RepositorioPasesDeArea repositorio = new RepositorioPasesDeArea();
        repositorio.EliminarSolicitudDePase(unPase);
    }

    [WebMethod]
    public bool CargarPase(PaseDeArea unPase)
    {
        RepositorioPasesDeArea repositorio = new RepositorioPasesDeArea();
        return repositorio.CargarSolicitudDePase(unPase);

    }

    [WebMethod]
    public bool CargarPasePlano(int documento, int idAreaOrigen, int idAreaDestino, int idUsuarioCarga)
    {
        RepositorioPasesDeArea repositorio = new RepositorioPasesDeArea();

        Persona nuevaPersona = new Persona();
        nuevaPersona.Documento = documento;

        Area areaOrigen = new Area(idAreaOrigen, "");
        Area areaDestino = new Area(idAreaDestino, "");

        Usuario usuario = new Usuario();
        usuario.Id = idUsuarioCarga;

        Auditoria auditoria = new Auditoria();
        auditoria.UsuarioDeCarga = usuario;

        PaseDeArea nuevoPase = new PaseDeArea();
        nuevoPase.AreaDestino = areaDestino;
        nuevoPase.AreaOrigen = areaOrigen;
        nuevoPase.Auditoria = auditoria;
        nuevoPase.Persona = nuevaPersona;

        return repositorio.CargarSolicitudDePase(nuevoPase);
    }

    [WebMethod]
    public Area[] GetAreas()
    {
        //var repositorio = new RepositorioDeAreas(Conexion());

        var repositorio = new RepositorioDeOrganigrama(Conexion());
        List<Area> areas = repositorio.GetOrganigrama().ObtenerAreas(true);

        Area[] returnAreas = new Area[areas.Count];

        for (int i = 0; i < areas.Count; i++)
        {
            returnAreas[i] = areas[i];
        }
        return returnAreas;
    }

    [WebMethod]
    public Area GetAreaSuperiorA(Area unArea)
    {
        RepositorioDeOrganigrama repo = new RepositorioDeOrganigrama(Conexion());

        var organigrama = repo.GetOrganigrama();

        var area = organigrama.AreaSuperiorDe(unArea);
        while (!area.PresentaDDJJ)
            area = organigrama.AreaSuperiorDe(area);

        return area;
    }

    [WebMethod]
    public Area GetAreaPreviaDe(ComisionDeServicio una_comision)
    {
        var repositorio = new RepositorioDeComisionesDeServicio(Conexion());
        return repositorio.GetAreaPreviaDe(una_comision);
    }

    [WebMethod]
    public Area RecargarArea(Area unArea)
    {
        var repositorio = new RepositorioDeAreas(Conexion());
        repositorio.ReloadArea(unArea);
        return unArea;
    }

    [WebMethod]
    public SaldoLicencia GetSaldoLicencia(Persona unaPersona, ConceptoDeLicencia concepto)
    {
        RepositorioPersonas repoPersonas = new RepositorioPersonas();
        unaPersona.TipoDePlanta = repoPersonas.GetTipoDePlantaActualDe(unaPersona);

        RepositorioLicencias repoLicencias = new RepositorioLicencias();
        SaldoLicencia unSaldo;
        ProrrogaLicenciaOrdinaria prorroga = new ProrrogaLicenciaOrdinaria();
        if (prorroga.SeAplicaAlTipoDePlanta(unaPersona.TipoDePlanta))
        {
            RepositorioProrrogasDeLicenciaOrdinaria repoProrrogas = new RepositorioProrrogasDeLicenciaOrdinaria();
            prorroga = repoProrrogas.CargarDatos(new ProrrogaLicenciaOrdinaria());
        }
        else
        {
            prorroga = null;
        }

        if (concepto.Id == 1)
        {
            unSaldo = repoLicencias.CargarSaldoLicenciaOrdinariaDe(concepto, prorroga, unaPersona);
        }
        else
        {
            unSaldo = repoLicencias.CargarSaldoLicenciaGeneralDe(concepto, unaPersona);
        }
        return unSaldo;
    }

    [WebMethod]
    public SaldoLicencia GetSaldoLicenciaPlano(int documento, int idConcepto)
    {
        Persona persona = new Persona();
        SaldoLicencia saldo;
        persona.Documento = documento;
        ConceptoDeLicencia concepto = new ConceptoDeLicencia();
        concepto.Id = idConcepto;
        saldo = this.GetSaldoLicencia(persona, concepto);
        return saldo;
    }

    [WebMethod]
    public string CargarLicencia(Licencia unaLicencia)
    {
        RepositorioLicencias repositorio = new RepositorioLicencias();
        if (repositorio.GetLicenciasQueSePisanCon(unaLicencia))
            return "Ya existe una licencia en el periodo especificado";
        if (repositorio.GetSolicitudesQueSePisanCon(unaLicencia))
            return "Ya existe una solicitud de licencia en el periodo especificado";

        return repositorio.Guardar(unaLicencia);
    }

    [WebMethod]
    public GrupoConceptosDeLicencia[] GetGruposConceptosLicencia()
    {
        GrupoConceptosDeLicencia grupo = new GrupoConceptosDeLicencia();
        RepositorioConceptosDeLicencia repositorio = new RepositorioConceptosDeLicencia();
        List<GrupoConceptosDeLicencia> grupos = repositorio.GetGruposConceptosLicencia();
        GrupoConceptosDeLicencia[] returnGrupos = new GrupoConceptosDeLicencia[grupos.Count];

        for (int i = 0; i < grupos.Count; i++)
        {
            returnGrupos[i] = grupos[i];
        }
        return returnGrupos;
    }

    [WebMethod]
    public Persona[] GetPersonas(Area unArea)
    {

        RepositorioPersonas repositorio = new RepositorioPersonas();
        List<Persona> personas = repositorio.GetPersonasDelArea(unArea);
        Persona[] returnPersonas = new Persona[personas.Count];

        for (int i = 0; i < personas.Count; i++)
        {
            returnPersonas[i] = personas[i];
        }
        return returnPersonas;
    }

    [WebMethod]
    public Usuario Login(string NombreUsuario, string Password)
    {
        Usuario usuario = new Usuario();
        usuario.NombreDeUsuario = NombreUsuario;

        RepositorioUsuarios repoUsuarios = new RepositorioUsuarios(Conexion());
        if (repoUsuarios.LoginUsuario(usuario, Password))
        {
            return usuario;
        }
            return null;
        
    }

    [WebMethod]
    public void AltaDeComisionesDeServicio(ComisionDeServicio unaComision)
    {
        var repositorio = new RepositorioDeComisionesDeServicio(Conexion());
        List<ComisionDeServicio> comisiones = new List<ComisionDeServicio>();

        comisiones.Add(unaComision);
        repositorio.GuardarComisionesDeServicio(comisiones);
    }


    [WebMethod]
    public void AltaDeComisionDeServicio(ComisionDeServicio unaComision)
    {
        var repositorio = new RepositorioDeComisionesDeServicio(Conexion());

        repositorio.GuardarComisionDeServicio(unaComision);
    }

    [WebMethod]
    public Zona[] ZonasDeViaticos()
    {
        var repositorio = new RepositorioZonas(Conexion());

        List<Zona> zonas = repositorio.GetTodasLasZonas();
        Zona[] dtos = new Zona[zonas.Count];

        for (int i = 0; i < zonas.Count; i++)
        {
            dtos[i] = zonas[i];
        }
        return dtos;
    }

    [WebMethod]
    public Zona GetZonaDe(Provincia provincia)
    {
        var repositorio = new RepositorioZonas(Conexion());
        Zona zona = repositorio.GetZonaFromProvincia(provincia);

        return zona;
    }


    [WebMethod]
    public MedioDeTransporte[] MediosDeTransporte()
    {
        RepositorioMediosDeTransporte repositorio = new RepositorioMediosDeTransporte();
        List<MedioDeTransporte> medios = repositorio.GetTodosLosMediosDeTransporte();
        MedioDeTransporte[] dtos = new MedioDeTransporte[medios.Count];

        for (int i = 0; i < medios.Count; i++)
        {
            dtos[i] = medios[i];
        }
        return dtos;
    }

    [WebMethod]
    public MedioDePago[] MediosDePago()
    {
        RepositorioMediosDePago repositorio = new RepositorioMediosDePago();
        List<MedioDePago> medios = repositorio.GetTodosLosMediosDePago();
        MedioDePago[] dtos = new MedioDePago[medios.Count];

        for (int i = 0; i < medios.Count; i++)
        {
            dtos[i] = medios[i];
        }
        return dtos;
    }

    [WebMethod]
    public string CargarLicenciaPlana(int documentoAgente, int idConcepto, string LicenciaDesde, string LicenciaHasta, int idArea, int idUsuarioAuditoria)
    {
        Licencia licencia = new Licencia();
        licencia.Persona = new Persona();
        licencia.Persona.Documento = documentoAgente;
        licencia.Concepto = new ConceptoDeLicencia();
        licencia.Concepto.Id = idConcepto;
        licencia.Desde = DateTime.Parse(LicenciaDesde);
        licencia.Hasta = DateTime.Parse(LicenciaHasta);
        licencia.Auditoria = new Auditoria();
        licencia.Auditoria.UsuarioDeCarga = new Usuario();
        licencia.Auditoria.UsuarioDeCarga.Id = idUsuarioAuditoria;
        licencia.Persona.Area = new Area();
        licencia.Persona.Area.Id = idArea;

        return this.CargarLicencia(licencia);
    }

    //FC: implementar para traer las listas de solicitudes
    [WebMethod]
    public ComisionDeServicio[] GetTodasLasComisionesDeServicios()
    {

        var repositorio = new RepositorioDeComisionesDeServicio(Conexion());

        return repositorio.ObtenerTodosLosViaticos().ToArray();
    }

    [WebMethod]
    public ComisionDeServicio[] GetComisionesDeServicioPorUsuario(Usuario usuario)
    {
        var repositorio = new RepositorioDeComisionesDeServicio(Conexion());
        //Se puede mejorar
        var lista_de_todos_los_viaticos = repositorio.ObtenerTodosLosViaticos();
        var lista_viaticos_usuario = new List<ComisionDeServicio>();
        usuario.Areas.ForEach(a => lista_viaticos_usuario.AddRange(lista_de_todos_los_viaticos.FindAll(v => v.TransicionesRealizadas.Select(t => t.AreaOrigen.Id).Contains(a.Id) ||
                                                                                                            v.TransicionesRealizadas.Select(t => t.AreaDestino.Id).Contains(a.Id))));

        return lista_viaticos_usuario.Distinct().ToArray();
    }

    [WebMethod]
    public void ReasignarComision(ComisionDeServicio una_comision, Int32 id_area, Int32 id_accion, String comentarios)
    {
        var repo_viaticos = new RepositorioDeComisionesDeServicio(Conexion());
        var repo_areas = new RepositorioDeOrganigrama(Conexion());
        //Se cambio el Repositorio de Áreas por el Repositorio de Organigrama para refactorizar
        var area = repo_areas.GetAreaById(id_area);
        //Se puede mejorar
        repo_viaticos.ReasignarComision(una_comision, area, id_accion, comentarios);
    }

    [WebMethod]
    public List<AccionDeTransicion> GetAccionesDeTransicion()
    {
        var repositorio = new RepositorioDeAccionesDeTransicion();

        var acciones = repositorio.GetAccionesDeTransicion();
        return acciones;
    }

    [WebMethod]
    public List<AccionDeTransicion> GetAccionesDeTransicionParaUnViaticoEnCirculacion()
    {
        var repositorio = new RepositorioDeAccionesDeTransicion();

        var acciones = repositorio.GetAccionesDeTransicionParaUnViaticoEnCirculacion();
        return acciones;
    }

    [WebMethod]
    public Decimal CalcularViaticoPara(Estadia estadia, Persona persona)
    {
        RepositorioCalculadorDeViatico repo = new RepositorioCalculadorDeViatico();
        RepositorioTipoDeViatico repo_tipoViatico = new RepositorioTipoDeViatico();

        //si no encuentra un tipo de viatico rompe...o.O
        persona.TipoDeViatico = repo_tipoViatico.GetTipoDeViaticoDe(persona);

        return repo.GetValorDeViatico(estadia, persona);

    }

    [WebMethod]
    public float CalcularDiasPara(Estadia estadia)
    {
        CalculadorDeDias calculadorDeDias = new CalculadorDeDias();

        return calculadorDeDias.CalcularDiasDe(estadia);

    }

    [WebMethod]
    public Persona CompletarDatosDeContratacion(Persona persona)
    {
        RepositorioTipoDeViatico repo_tipoViatico = new RepositorioTipoDeViatico();
        return repo_tipoViatico.GetNivelGradoDeContratacionDe(persona);
    }

    [WebMethod]
    public Area SiguientePasoDelCircuitoDelArea(Area area_actual)
    {
        RepositorioDeOrganigrama repo = new RepositorioDeOrganigrama(Conexion());
        var organigrama = repo.GetOrganigrama();
        var excepciones = repo.ExcepcionesDeCircuitoViaticos();
        var area_de_viaticos = new Area(1073, "Área de Viáticos y Pasajes", "010100100300100000001073", true);
        var circuito = new CircuitoDeAprobacionDeViatico(organigrama, excepciones, area_de_viaticos);
        return circuito.SiguienteAreaDe(area_actual);
    }

    [WebMethod]
    public bool PuedeGuardarseComision(ComisionDeServicio comision)
    {
        return comision.PuedeGuardarse();
    }

    [WebMethod]
    public Documento GuardarDocumento(Documento un_documento, int id_area_creadora, int id_area_actual, Usuario usuario)
    {
        var conexion = Conexion();
        var repo_documentos = new RepositorioDeDocumentos(conexion);
        var repo_organigrama = RepositorioDeOrganigrama.NuevoRepositorioOrganigrama(conexion);
        var repo_transiciones = new RepositorioMensajeria(conexion, repo_documentos, repo_organigrama);
        var repo_usuarios = new RepositorioUsuarios(conexion);
        var mensajeria = repo_transiciones.GetMensajeria();
        
        repo_documentos.GuardarDocumento(un_documento, usuario);

        mensajeria.SeEnvioDirectamente(un_documento, repo_organigrama.GetAreaById(id_area_creadora), repo_organigrama.GetAreaById(id_area_actual), DateTime.Now);

        repo_transiciones.GuardarTransicionesDe(mensajeria);
        return un_documento;
    }

    [WebMethod]
    public Documento GuardarCambiosEnDocumento(int id_documento, int id_area_destino, string comentario, Usuario usuario)
    {
        var conexion = Conexion();
        var repo_documentos = new RepositorioDeDocumentos(conexion);
        var repo_organigrama = new RepositorioDeOrganigrama(conexion);
        var repo_transiciones = new RepositorioMensajeria(conexion, repo_documentos, repo_organigrama);
        var mensajeria = repo_transiciones.GetMensajeria();

        var un_documento = repo_documentos.GetDocumentoPorId(id_documento);
        un_documento.comentarios = comentario;
        repo_documentos.UpdateDocumento(un_documento, usuario);

        var area_destino = new Area();

        if (id_area_destino != -1)
        {
            area_destino = repo_organigrama.GetAreaById(id_area_destino);

            mensajeria.SeEnviaAFuturo(un_documento, usuario.Areas[0], area_destino);

            repo_transiciones.GuardarTransicionesDe(mensajeria);
        }
        
        return un_documento;
    }

    [WebMethod]
    public Documento CrearTransicionFuturaParaDocumento(int id_documento, int id_area_destino, Usuario usuario)
    {
        var conexion = Conexion();
        var repo_documentos = new RepositorioDeDocumentos(conexion);
        var repo_organigrama = new RepositorioDeOrganigrama(conexion);
        var repo_transiciones = new RepositorioMensajeria(conexion, repo_documentos, repo_organigrama);
        var mensajeria = repo_transiciones.GetMensajeria();

        var un_documento = repo_documentos.GetDocumentoPorId(id_documento);
        var area_destino = repo_organigrama.GetAreaById(id_area_destino);

        mensajeria.SeEnviaAFuturo(un_documento, usuario.Areas[0], area_destino);

        repo_transiciones.GuardarTransicionesDe(mensajeria);
        return un_documento;
    }

    
    [WebMethod]
    public List<List<string>> GetComisionesPorFiltro(List<Area> lista_areas, List<Provincia> lista_provincias, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        var generadorDeReporte = new GeneradorDeReportes();

        var filtro_area = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuAreaCreadoraEstaEn(lista_areas)));
        var filtro_provincia = new FiltroDeComisiones(lista => lista.FindAll(c => c.Estadias.Any(e => lista_provincias.Any(p => p.Id == e.Provincia.Id))));
        var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
        List<FiltroDeComisiones> filtros = new List<FiltroDeComisiones>() { filtro_area, filtro_provincia, filtro_periodo };

        return generadorDeReporte.ViaticoPorAreasPorProvincia(filtros, comisiones, lista_provincias);

    }

    //El web service acepta metodos sobrecargados??
    [WebMethod]
    public List<List<string>> GetComisionesPorProvincia(List<Provincia> lista_provincias, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        var generadorDeReporte = new GeneradorDeReportes();


        var filtro_provincia = new FiltroDeComisiones(lista => lista.FindAll(c => c.Estadias.Any(e => lista_provincias.Any(p => p.Id == e.Provincia.Id))));
        var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
        List<FiltroDeComisiones> filtros = new List<FiltroDeComisiones>() { filtro_provincia, filtro_periodo };

        return generadorDeReporte.ViaticosPorProvincia(filtros, comisiones, lista_provincias);

    }

    [WebMethod]
    public List<List<string>> GetComisionesPorAgente(List<Area> areas_autorizadas, Persona persona, DateTime fechaDesde, DateTime fechaHasta, List<ComisionDeServicio> comisiones)
    {
        var generadorDeReporte = new GeneradorDeReportes();

        var filtro_area = new FiltroDeComisiones(lista => lista.FindAll(c => c.TuAreaCreadoraEstaEn(areas_autorizadas)));
        var filtro_persona = new FiltroDeComisiones(lista => lista.FindAll(c => c.Persona.Documento == persona.Documento));
        var filtro_periodo = new FiltroDeComisiones(lista => lista.FindAll(c => c.TenesAlgunaEstadiaEnElPeriodo(fechaDesde, fechaHasta)));
        List<FiltroDeComisiones> filtros = new List<FiltroDeComisiones>() { filtro_area, filtro_persona, filtro_periodo };

        return generadorDeReporte.ViaticosDePersonaPorAreas(filtros, comisiones);

    }

    [WebMethod]
    public List<Area> AreasCompletas()
    {

        List<Area> areas = new List<Area>();
        var repositorio = new RepositorioDeAreas(Conexion());

        return areas = repositorio.GetTodasLasAreasCompletas();
    }     

    [WebMethod]
    public string AreasFormalesConInformales_JSON()
    {
        var repositorio = new RepositorioDeOrganigrama(Conexion());
        var areasFormales = repositorio.GetOrganigrama().ObtenerAreas(true);
        var areasFormales_dto = new List<Object>();
        areasFormales.ForEach(delegate(Area a)
        {            
            areasFormales_dto.Add(AreaDtoPara(a));
        });
        return JsonConvert.SerializeObject(areasFormales_dto);
    }
    
    [WebMethod]
    public List<Area> AreasInferioresDe(Area area)
    {
        List<Area> areas = new List<Area>();
        var repositorio = new RepositorioDeOrganigrama(Conexion());
        return areas = repositorio.GetOrganigrama().GetAreasInferioresDelArea(area);
    }
    
    [WebMethod]
    public Documento[] GetTodosLosDocumentos()
    {
        var repositorio = new RepositorioDeDocumentos(Conexion());
        return repositorio.GetTodosLosDocumentos().ToArray();
    }

    [WebMethod]
    public TipoDeDocumentoSICOI[] TiposDeDocumentosSICOI()
    {
        var repositorio = new RepositorioDeDocumentos(Conexion());
        return repositorio.GetTiposDeDocumentos().ToArray();
    }

    [WebMethod]
    public CategoriaDeDocumentoSICOI[] CategoriasDocumentosSICOI()
    {
        var repositorio = new RepositorioDeDocumentos(Conexion());
        return repositorio.GetCategoriasDeDocumentos().ToArray();
    }

    //[WebMethod]
    //public string GetDocumentosFiltrados(List<String> filtros)
    //{
    //    var filtrosDesSerializados = desSerializadorDeFiltros().DesSerializarFiltros(filtros);
    //    var documentos = RepositorioDocumentos().GetDocumentosFiltrados(filtrosDesSerializados);
    //    var documentos_dto = new List<Object>();

    //    documentos.ForEach(delegate(Documento doc)
    //    {
    //        documentos_dto.Add(DocumentoDtoPara(doc));
    //    });
    //    return JsonConvert.SerializeObject(documentos_dto);
    //}

    [WebMethod]
    public string GetDocumentosFiltrados(String filtros)
    {
        var filtrosDesSerializados = desSerializadorDeFiltros().DesSerializarFiltros(filtros);
        var documentos = RepositorioDocumentos().GetDocumentosFiltrados(filtrosDesSerializados);
        var documentos_dto = new List<Object>();

        documentos.ForEach(delegate(Documento doc)
        {
            documentos_dto.Add(DocumentoDtoPara(doc));
        });
        return JsonConvert.SerializeObject(documentos_dto);
    }

    [WebMethod]
    public string GetDocumentosEnAlerta()
    {
        var documentos = DocumentosEnAlerta();
        var documentos_dto = new List<Object>();

        documentos.ForEach(delegate(Documento doc)
        {
            documentos_dto.Add(DocumentoDtoPara(doc));
        });
        return JsonConvert.SerializeObject(documentos_dto);
    }

    private List<Documento> DocumentosEnAlerta()
    {
        // var filtrosDesSerializados = desSerializadorDeFiltros().DesSerializarFiltros(filtros);
        var alertas = new RepositorioDeAlertas(Mensajeria()).GetAlertas();
        var documentos = new List<Documento>();

        alertas.ForEach(a => documentos = RepositorioDocumentos().GetDocumentosFiltrados(a));

        documentos = documentos.Distinct().ToList();
        return documentos;
    }

    [WebMethod]
    public Boolean HayDocumentosEnAlerta()
    {
        return DocumentosEnAlerta().Any();
    }


    private DesSerializadorDeFiltros desSerializadorDeFiltros()
    {
        return new DesSerializadorDeFiltros(Mensajeria());
    }

    private Object DocumentoDtoPara(Documento doc){
        return new
                {
                    id = doc.Id,
                    numero = doc.numero,
                    tipo = TipoDocumentoDtoPara(doc.tipoDeDocumento),
                    ticket = doc.ticket,
                    extracto = doc.extracto,
                    fechaDeAlta = doc.fecha.ToString("dd/MM/yyyy"),
                    areaCreadora = AreaDtoPara(Mensajeria().SeOriginoEnArea(doc)),
                    areaActual = AreaDtoPara(Mensajeria().EstaEnElArea(doc)),
                    areaDestino = AreaDtoPara(Mensajeria().AreaDestinoPara(doc)),
                    enAreaActualHace = TiempoEnElAreaActualDTOPara(doc),
                    estado = EstadoDtoPara(doc),
                    historial = HistorialDeTransicionesDtoPara(doc),
                    comentarios = doc.comentarios,
                    categoria = CategoriaDtoPara(doc.categoriaDeDocumento)
                };
    }

    private object TiempoEnElAreaActualDTOPara(Documento doc)
    {
        var tiempo = Mensajeria().TiempoEnElAreaActualPara(doc);
        return new {    dias = tiempo.Days,
                        horas = tiempo.Hours,
                        minutos = tiempo.Minutes};
    }


    private Object CategoriaDtoPara(CategoriaDeDocumentoSICOI cat)
    {
        return new
        {
            id = cat.Id,
            descripcion = cat.descripcion
        };

    }
    private Object TipoDocumentoDtoPara(TipoDeDocumentoSICOI tipoDoc)
    {
        return new
                {
                    id = tipoDoc.Id,
                    descripcion = tipoDoc.descripcion
                };
    }

    private Object AreaDtoPara(Area area){
        return new
                {
                    id = area.Id,
                    descripcion = area.Alias
                };
    }

    private String EstadoDtoPara(Documento doc)
    {
        var areaDestino = Mensajeria().AreaDestinoPara(doc);
        string estado;
        estado = "Recibido";
        if (areaDestino.Id > -1) estado = "A remitir";
        return estado;
    }

    private Array HistorialDeTransicionesDtoPara(Documento doc)
    {
        var historial = new List<Object>(); 
        Mensajeria().HistorialDetransicionesPara(doc).ForEach(t => historial.Add(new {  areaOrigen = t.AreaOrigen.NombreConAlias(),
                                                                                areaDestino = t.AreaDestino.NombreConAlias(),
                                                                                fecha = t.Fecha.ToString("dd/MM/yyyy")
                                                                                }));
        return historial.ToArray();
    }


    public RepositorioDeDocumentos RepositorioDocumentos()
    {
        return new RepositorioDeDocumentos(Conexion());
    }

    public ConexionBDSQL Conexion()
    {
        return new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
    }

    public RepositorioMensajeria RepoMensajeria()
    {
        var conexion = Conexion();
        var repo_documentos = new RepositorioDeDocumentos(conexion);
        var repo_organigrama = RepositorioDeOrganigrama.NuevoRepositorioOrganigrama(conexion);//new RepositorioDeOrganigrama(conexion);
        return new RepositorioMensajeria(conexion, repo_documentos, repo_organigrama);
    }


    public Mensajeria Mensajeria()
    {
        var repo_transiciones = RepoMensajeria();
        return repo_transiciones.GetMensajeria();
    }

    [WebMethod]
    public void TransicionarDocumento(int id_documento, int id_area_origen, int id_area_destino)
    {
        var documento = RepositorioDocumentos().GetTodosLosDocumentos().Find(d => d.Id == id_documento);
        var area_origen = new RepositorioDeOrganigrama(Conexion()).GetAreaById(id_area_origen);
        var area_destino = new RepositorioDeOrganigrama(Conexion()).GetAreaById(id_area_destino);
        var mensajeria = Mensajeria();
        mensajeria.SeEnvioDirectamente(documento, area_origen, area_destino, DateTime.Now);
        RepoMensajeria().GuardarTransicionesDe(mensajeria);
    }

    [WebMethod]
    public void TransicionarDocumentoConAreaIntermedia(int id_documento, int id_area_origen, int id_area_intermedia, int id_area_destino)
    {
        var documento = RepositorioDocumentos().GetTodosLosDocumentos().Find(d => d.Id == id_documento);
        var area_origen = new RepositorioDeOrganigrama(Conexion()).GetAreaById(id_area_origen);
        var area_intermedia = new RepositorioDeOrganigrama(Conexion()).GetAreaById(id_area_intermedia);
        var area_destino = new RepositorioDeOrganigrama(Conexion()).GetAreaById(id_area_destino);
        var mensajeria = Mensajeria();
        mensajeria.TransicionarConAreaIntermedia(documento, area_origen, area_intermedia, area_destino, DateTime.Now);
        RepoMensajeria().GuardarTransicionesDe(mensajeria);
    }

    [WebMethod]
    public Area EstaEnElArea(Documento documento)
    {
        var mensajeria = Mensajeria();
        return mensajeria.EstaEnElArea(documento);
    }

    
    //////////////////////////
    [WebMethod]
    public CalendarioDeCurso GetCalendarioDeCurso(Curso un_curso)
    {
        var manager_de_calendarios = new ManagerDeCalendarios(new CalendarioDeFeriados());
        manager_de_calendarios.AgregarCalendarioPara(un_curso);
        return manager_de_calendarios.CalendarioPara(un_curso);

    }
    [WebMethod]
    public PlanillaMensualDto GetPlanillaMensualDto(Curso un_curso, DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso calendario)
    {
        var planilla_mensual = new GeneradorDePlanillas().GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, calendario);
        return new PlanillaMensualDto();
    }
    

    public PlanillaMensual GetPlanillaMensual(Curso un_curso, DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso calendario)
    {
        return new GeneradorDePlanillas().GenerarPlanillaMensualPara(un_curso, fecha_desde, fecha_hasta, calendario);
    }


    [WebMethod]
    public List<AsistenciaDto> GetAsistenciasPorCursoYAlumno(int id_curso, int id_alumno)
    {
        List<AsistenciaDto> asistencias_dto = new List<AsistenciaDto>();
        var asistencias = RepoAsistencias().GetAsistenciasPorCursoYAlumno(id_curso, id_alumno);
        asistencias.ForEach(a => asistencias_dto.Add(new AsistenciaDto(a.IdAlumno, a.IdCurso, a.Fecha, a.Valor)));

        return asistencias_dto;
    }


    [WebMethod]
    public string GetPlanillaInasistenciaAlumnoPorMes(int id_curso, DateTime fecha_desde, DateTime fecha_hasta)
    {
        var un_curso = RepositorioDeCursos().GetCursoById(id_curso);


        var calendario = GetCalendarioDeCurso(un_curso);
        var planilla_mensual = GetPlanillaMensual(un_curso, fecha_desde, fecha_hasta, calendario);
        var dias_de_cursada = planilla_mensual.GetDiasDeCursadaEntre(fecha_desde, fecha_hasta);

        var planilla_mensual_dto = new object();
        var planilla_mensual_alumnos_dto = new List<Object>();
        

        if (planilla_mensual.Curso.Alumnos().Count > 0)
        {
            List<object> dias_con_formato = new List<object>();

            dias_de_cursada.ForEach(d => dias_con_formato.Add(new
            {
                dia = d.ToString("dd"),
                nombre_dia = d.ToString("ddd"),
                fecha = d.ToShortDateString(),
                horas = planilla_mensual.Curso.HorasCatedra
            }));
            
            planilla_mensual.Curso.Alumnos().ForEach(delegate(Alumno alumno)
            {
                var detalle_asistencias = RepoAsistencias().GetAsistenciasPorCursoYAlumno(planilla_mensual.Curso.Id ,alumno.Id);
                detalle_asistencias = detalle_asistencias.FindAll(a => a.Fecha.Ticks >= fecha_desde.Ticks && a.Fecha.Ticks <= fecha_hasta.Ticks);
                List<object> detalle_asistencia = new List<object>();
                
                detalle_asistencias.ForEach(d=>{
                    if(d.Fecha >= fecha_desde && d.Fecha <= fecha_hasta)
                        detalle_asistencia.Add(new{
                            valor = d.Valor,
                            fecha = d.Fecha.ToShortDateString()
                        });
                });

                int cant_asistencias_aux = 0;
                int cant_inasistencias_aux = 0;
                string cant_asistencias = string.Empty;
                string cant_inasistencias = string.Empty;
                detalle_asistencias.ForEach(a =>
                {
                    if (a.Valor < 4)
                        cant_asistencias_aux += a.Valor;
                }); 
                detalle_asistencias.ForEach(a =>
                {
                    if (a.Valor > 0 && a.Valor < 4)
                        cant_inasistencias_aux += planilla_mensual.Curso.HorasCatedra - a.Valor;
                    if (a.Valor == 4)
                        cant_inasistencias_aux += planilla_mensual.Curso.HorasCatedra;
                });

                if (cant_asistencias_aux == 0 && cant_inasistencias_aux == 0)
                {
                    cant_asistencias = string.Empty;
                    cant_inasistencias = string.Empty;
                }
                else
                {
                    cant_asistencias = cant_asistencias_aux.ToString();
                    cant_inasistencias = cant_inasistencias_aux.ToString();
                }
                planilla_mensual_alumnos_dto.Add(new
                {
                    id = alumno.Id,
                    nombrealumno = alumno.Nombre + " " + alumno.Apellido,
                    pertenece_a = "MDS",
                    detalle_asistencia = detalle_asistencia.ToArray(),
                    asistencias = cant_asistencias,
                    inasistencias = cant_inasistencias,
                    justificadas = "",
                    max_horas_cursadas = planilla_mensual.Curso.HorasCatedra
                });
            });

            planilla_mensual_dto = new
            {
                diascursados = dias_con_formato,
                asistenciasalumnos = planilla_mensual_alumnos_dto
            };
        }
        return JsonConvert.SerializeObject(planilla_mensual_dto);
    }

    [WebMethod]
    public AsistenciaDto unaasistencia()
    {
        return new AsistenciaDto(1, 1, DateTime.Now, 1);
    }
    [WebMethod]
    public void GuardarDetalleAsistencias(List<AsistenciaDto> asistencias_dto, Usuario usuario)
    {
        List<Asistencia> asistencias = new List<Asistencia>();
        Asistencia asistencia = null;
        foreach (var item in asistencias_dto)
        {
            switch (item.Valor)
            {
                case 0:
                    asistencia = new AsistenciaIndeterminada(item.Fecha, item.IdCurso, item.IdAlumno);
                    break;
                case 1:
                    asistencia = new AsistenciaHoraUno(item.Fecha,item.IdCurso, item.IdAlumno);
                    break;
                case 2:
                    asistencia = new AsistenciaHoraDos(item.Fecha, item.IdCurso, item.IdAlumno);
                    break;
                case 3:
                    asistencia = new AsistenciaHoraTres(item.Fecha, item.IdCurso, item.IdAlumno);
                    break;
                case 4:
                    asistencia = new InasistenciaNormal(item.Fecha, item.IdCurso, item.IdAlumno);
                    break;
                case 5:
                    asistencia = new AsistenciaClaseSuspendida(item.Fecha, item.IdCurso, item.IdAlumno);
                    break;
                default:
                    break;
            }
            asistencias.Add(asistencia);

        }
        RepoAsistencias().GuardarAsistencias(asistencias, usuario);
    }

    [WebMethod]
    public string Personas()
    {
        var personas = RepoPersonas().GetPersonas();

        var persoas_dto = new List<Object>();

        if (personas.Count() > 0)
        {
            personas.ForEach(delegate(Persona persona)
            {
                persoas_dto.Add(new
                {
                    label = persona.Apellido + ", " + persona.Nombre + " (DNI: " + persona.Documento + ")",
                    value = persona.Documento.ToString(),
                    nombre = persona.Apellido + ", " + persona.Nombre,
                    apellido = persona.Apellido,
                    documento = persona.Documento,
                    area = AreaDtoPara(persona.Area), 
                    
                });
            });
        }

        return JsonConvert.SerializeObject(persoas_dto);

    }

    [WebMethod]
    public string GetAlumnos()
    {
        var alumnos = RepoAlumnos().GetAlumnos();

        var alumnos_dto = new List<Object>();

        if (alumnos.Count() > 0)
        {
            alumnos.ForEach(delegate(Alumno alumno)
            {
                alumnos_dto.Add(new
                {
                    Id = alumno.Id,
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Documento = alumno.Documento,
                    Telefono = alumno.Telefono,
                    Mail = alumno.Mail,
                    Direccion = alumno.Direccion,
                 //   Area = AreaDtoPara(alumno.Area),
                    Modalidad = ModalidadPara(alumno.Modalidad),
                });
            });
        }

        return JsonConvert.SerializeObject(alumnos_dto);
 
    }


    [WebMethod]
    public List<Alumno> GetTodosLosAlumnos()
    {
        var alumnos = RepoAlumnos().GetAlumnos();
        return alumnos;

    }

    private object EdificioPara(Edificio edificio)
    {
        return new
        {
            id = edificio.Id,
            nombre = edificio.Nombre,
            direccion = edificio.Direccion
        };
    }

    private object ModalidadPara(Modalidad modalidad)
    {
        return new
        {
            Id = modalidad.Id,
            Descripcion = modalidad.Descripcion
        };
    }

    [WebMethod]
    public Alumno GuardarAlumno(Alumno un_alumno, Usuario usuario)
    {
        var conexion = Conexion();
        var repo_alumnos = RepoAlumnos();

        repo_alumnos.GuardarAlumno(un_alumno, usuario);

        return un_alumno;
    }

    [WebMethod]
    public Materia GuardarMateria(Materia una_materia, Usuario usuario)
    {
        var conexion = Conexion();
        una_materia = RepositorioDeMaterias().GuardarMaterias(una_materia, usuario);

        return una_materia;
    }

    [WebMethod]
    public void ModificarMateria(Materia una_materia, Usuario usuario)
    {
        var conexion = Conexion();
        RepositorioDeMaterias().ActualizarMaterias(una_materia, usuario);
    }

    [WebMethod]
    public bool QuitarMateria(Materia materia, Usuario usuario)
    {
        if (RepositorioDeMaterias().MateriaAsignadaACurso(materia))
        {
            return false;
        }
        RepositorioDeMaterias().QuitarMateria(materia, usuario);
        return true;
    }

    [WebMethod]
    public Docente GuardarDocente(Docente un_docente, Usuario usuario)
    {
        var conexion = Conexion();
        RepositorioDeDocentes().GuardarDocente(un_docente, usuario);

        return un_docente;
    }

    //[WebMethod]
    //public void ModificarDocente(Docente un_docente, Usuario usuario)
    //{
    //    var conexion = Conexion();
    //    RepositorioDeDocentes().ModificarDocente(un_docente, usuario);
    //}

    [WebMethod]
    public bool QuitarDocente(Docente docente, Usuario usuario)
    {
        if(RepositorioDeDocentes().DocenteAsignadoACurso(docente))
        { 
            return false;
        }
           RepositorioDeDocentes().QuitarDocente(docente, usuario);
            return true;
    }

    [WebMethod]
    public void ActualizarAlumno(Alumno un_alumno, Usuario usuario)
    {
        var conexion = Conexion();
        var repo_alumnos = RepoAlumnos();

        repo_alumnos.ActualizarAlumno(un_alumno, usuario);
    }

    [WebMethod]
    public void InscribirAlumnosACurso(List<Alumno> alumnos, int idCurso,  Usuario usuario)
    {
        var conexion = Conexion();
        Curso curso = RepositorioDeCursos().GetCursoById(idCurso);

        //curso.ActualizarAlumnosDelCurso(alumnos);

        RepositorioDeCursos().ActualizarInscripcionesACurso(alumnos, curso, usuario);

    }

    [WebMethod]
    public bool QuitarAlumno(Alumno alumno, Usuario usuario)
    {
        if (RepoAlumnos().AlumnoAsignadoACurso(alumno))
        {
            return false;
        }
        RepoAlumnos().QuitarAlumno(alumno, usuario);
        return true;

    }

    [WebMethod]
    public string GetCursoById(int id)
    {
        var curso = RepositorioDeCursos().GetCursoById(id);
        return JsonConvert.SerializeObject(curso);
    }

    [WebMethod]
    public EspacioFisico GetEspacioFisicoById(int id)
    {
        //var espacio_fisico = 
        return RepoEspaciosFisicos().GetEspacioFisicoById(id); //JsonConvert.SerializeObject(espacio_fisico);
    }

    [WebMethod]
    [System.Xml.Serialization.XmlInclude(typeof(DocenteNull))]
    public List<CursoDto> GetCursosDto()
    {
        var cursos = new RepositorioDeCursos(Conexion()).GetCursos();
        var cursos_dto = new List<CursoDto>();

        if (cursos.Count() > 0)
        {
            cursos.ForEach(delegate(Curso curso)
            {
                var un_curso = new CursoDto();
                un_curso.Id = curso.Id;
                un_curso.Nombre = curso.Nombre;
                un_curso.Materia = curso.Materia;
                un_curso.Docente = curso.Docente;
                un_curso.Alumnos = curso.Alumnos();
                un_curso.HorasCatedra = curso.HorasCatedra;
                un_curso.EspacioFisico = curso.EspacioFisico;
                var horarios = new List<HorarioDto>();
                foreach (var h in curso.GetHorariosDeCursada())
                {
                    horarios.Add(new HorarioDto() { NumeroDia = (int)h.Dia, Dia = DateTimeFormatInfo.CurrentInfo.GetDayName(h.Dia), HoraDeInicio = h.HoraDeInicio.ToString().Substring(0, 5), HoraDeFin = h.HoraDeFin.ToString().Substring(0, 5) });
                }
                un_curso.Horarios = horarios;
                cursos_dto.Add(un_curso);
            });
        }
        return cursos_dto;
    }

    [WebMethod]
    [System.Xml.Serialization.XmlInclude(typeof(DocenteNull))]
    public List<Curso> GetCursos()
    {
        return new RepositorioDeCursos(Conexion()).GetCursos();
        
    }

    [WebMethod]
    public string GetMaterias()
    {
        var materias = new RepositorioDeMaterias(Conexion()).GetMaterias();
        var materias_dto = new List<object>();

        if (materias.Count > 0)
        {
            materias.ForEach(delegate(Materia materia)
            {
                materias_dto.Add(new
                {
                    id = materia.Id,
                    nombre = materia.Nombre,
                    modalidad = ModalidadPara(materia.Modalidad),
                    ciclo = materia.Ciclo,
                });
            });
        };
        return JsonConvert.SerializeObject(materias_dto);
    }

    [WebMethod]
    public Docente GetDocenteById(int id)
    {
        var docente = RepositorioDeDocentes().GetDocenteById(id);
        return docente;
    }

    [WebMethod]
    public string GetDocentes()
    {
        var docentes = RepositorioDeDocentes().GetDocentes();
        var docentes_dto = new List<object>();
        
        if (docentes.Count > 0)
        {
            docentes.ForEach(delegate(Docente docente)
            {
                docentes_dto.Add(new
                {
                    id = docente.Id,
                    dni = docente.Dni,
                    nombre = docente.Nombre,
                    apellido = docente.Apellido,
                    telefono = docente.Telefono,
                    mail = docente.Mail,
                    domicilio = docente.Direccion
                });
            });
        };
        return JsonConvert.SerializeObject(docentes_dto);
    }

    [WebMethod]
    public Modalidad[] Modalidades()
    {
        return RepoAlumnos().GetModalidades().ToArray();
    }

    [WebMethod]
    public Ciclo[] Ciclos()
    {
        return RepositorioDeMaterias().GetCiclos().ToArray();
    }

    [WebMethod]
    public Materia GetMateriaById(int id)
    {
        return RepositorioDeMaterias().GetMateriaById(id);
        
    }

    [WebMethod]
    public bool QuitarCurso(CursoDto curso, Usuario usuario)
    {
        var un_curso = new Curso() { Docente = curso.Docente, Materia = curso.Materia, Id = curso.Id, EspacioFisico = curso.EspacioFisico};
        var horarios = curso.Horarios;
        horarios.ForEach(h =>
        {
            un_curso.AgregarHorarioDeCursada(new HorarioDeCursada((DayOfWeek)h.NumeroDia, h.HoraDeInicio, h.HoraDeFin, h.HorasCatedra));
        });

        return RepositorioDeCursos().QuitarCurso(un_curso, usuario);
    }

    [WebMethod]
    public bool AgregarCurso(CursoDto curso)
    {
        var un_curso = new Curso() { Docente = curso.Docente, Materia = curso.Materia, HorasCatedra = curso.HorasCatedra, EspacioFisico = curso.EspacioFisico};
        var horarios = curso.Horarios;
        horarios.ForEach(h =>
        {
            un_curso.AgregarHorarioDeCursada(new HorarioDeCursada((DayOfWeek)h.NumeroDia, h.HoraDeInicio, h.HoraDeFin, h.HorasCatedra));
        });

        return RepositorioDeCursos().AgregarCurso(un_curso);
    }

    [WebMethod]
    public bool ModificarCurso(CursoDto curso)
    {
        var un_curso = new Curso() { Id = curso.Id, Docente = curso.Docente, Materia = curso.Materia, HorasCatedra = curso.HorasCatedra, EspacioFisico = curso.EspacioFisico};
        var horarios = curso.Horarios;
        horarios.ForEach(h =>{
            un_curso.AgregarHorarioDeCursada(new HorarioDeCursada((DayOfWeek)h.NumeroDia, h.HoraDeInicio, h.HoraDeFin, h.HorasCatedra));
        });
        
        return RepositorioDeCursos().ModificarCurso(un_curso);
    }

    [WebMethod]
    public string GetPersonaByDNI(int dni)
    {
        RepositorioDeAlumnos repo = new RepositorioDeAlumnos(Conexion());
        Alumno persona = repo.GetAlumnoByDNI(dni);
        var persona_dto = new Object();

        if (persona == null)
        {
            persona_dto =
                       new
                       {
                           id = 0,
                           nombre = "No existe",
                           apellido = "No existe",
                           documento = "No existe",
                           modalidad = "-1",
                       };
        }
        else
        {
            persona_dto =
                       new
                       {
                           id = persona.Id,
                           nombre = persona.Nombre,
                           apellido = persona.Apellido,
                           documento = persona.Documento,
                           telefono = persona.Telefono,
                           direccion = persona.Direccion,
                           mail = persona.Mail,
                    //       area = persona.Area,
                           modalidad = 1,
                       };
        }
        return JsonConvert.SerializeObject(persona_dto);
    }


    [WebMethod]
    public Edificio[] Edificios()
    {
        return RepoEspaciosFisicos().GetEdificios().ToArray();
    }

    //[WebMethod]
    //public void EspacioFisico(EspacioFisico espacio_fisico)
    //{

    //}

    [WebMethod]
    public bool QuitarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
    {
        if (RepoEspaciosFisicos().EspacioFisicoAsignadoACurso(espacio_fisico))
        {
            return false;
        }
        RepoEspaciosFisicos().QuitarEspacioFisico(espacio_fisico, usuario);
        return true;
    }

    [WebMethod]
    public void ModificarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
    {
        var conexion = Conexion();
        RepoEspaciosFisicos().ModificarEspacioFisico(espacio_fisico, usuario);
    }

    [WebMethod]
    public void GuardarEspacioFisico(EspacioFisico un_espacio_fisico, Usuario usuario)
    {
         var conexion = Conexion();
        RepoEspaciosFisicos().ActualizarEspacioFisico(un_espacio_fisico, usuario);
    }

     [WebMethod]
    public string GetEspaciosFisicos()
     {

         var espacios_fisicos = new RepositorioDeEspaciosFisicos(Conexion()).GetEspaciosFisicos();
         var espacios_fisicos_dto = new List<object>();

         if (espacios_fisicos.Count > 0)
         {
             espacios_fisicos.ForEach(delegate(EspacioFisico espacio_fisico)
             {
                 espacios_fisicos_dto.Add(new
                 {
                     id = espacio_fisico.Id,
                     aula = espacio_fisico.Aula,
                     edificio = EdificioPara(espacio_fisico.Edificio),
                     capacidad = espacio_fisico.Capacidad
                 });
             });
         };
         return JsonConvert.SerializeObject(espacios_fisicos_dto);

     }

    private RepositorioDeAlumnos RepoAlumnos()
    {
        return new RepositorioDeAlumnos(Conexion());
    }

    private RepositorioPersonas RepoPersonas()
    {
        return new RepositorioPersonas();
    }

    private RepositorioDeMaterias RepositorioDeMaterias()
    {
        return new RepositorioDeMaterias(Conexion());
    }

    private RepositorioDeCursos RepositorioDeCursos()
    {
        return new RepositorioDeCursos(Conexion());
    }

    private RepositorioDeDocentes RepositorioDeDocentes()
    {
        return new RepositorioDeDocentes(Conexion());
    }

    private RepositorioDeAsistencias RepoAsistencias()
    {
        return new RepositorioDeAsistencias(Conexion());
    }

    private RepositorioDeEspaciosFisicos RepoEspaciosFisicos()
    {
        return new RepositorioDeEspaciosFisicos(Conexion());
    }

}