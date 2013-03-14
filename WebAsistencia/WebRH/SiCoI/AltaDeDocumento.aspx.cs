using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebRhUI;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class AltaDeDocumento : System.Web.UI.Page
{
    private Usuario usuarioLogueado;
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        usuarioLogueado = ((Usuario)Session[ConstantesDeSesion.USUARIO]);

        var servicio = new WSViaticos.WSViaticosSoapClient();


        if (!IsPostBack)
        {
            string areas_origen_destino;

            areas_origen_destino = servicio.AreasFormalesConInformales_JSON();

            this.ListaAreas.Value = areas_origen_destino;
            this.TiposDeDocumento.Value = JsonConvert.SerializeObject(servicio.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion));
            CompletarCombosDeTipoDeDocumentos();
            CompletarCombosDeCategoria();
            this.RefrescarListaDeDocumentos();
            var areaDelUsuarioDTO = new {   id = usuarioLogueado.Areas[0].Id, 
                                            descripcion =  usuarioLogueado.Areas[0].Nombre};
            divAreaDelUsuario.Value = JsonConvert.SerializeObject(areaDelUsuarioDTO);
            //CompletarCombosDeTipoDeDocumentos();
        }
    }

    private void RefrescarListaDeDocumentos()
    {
        this.ListaDocumentos.Value = DocumentosFromWS();

        var servicio = new WSViaticos.WSViaticosSoapClient();
        this.boton_alertas.Visible = servicio.HayDocumentosEnAlerta();
    }

    private void CompletarCombosDeTipoDeDocumentos()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var tiposDeDocumento = servicio.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion);

        foreach (TipoDeDocumentoSICOI td in tiposDeDocumento)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = td.Id.ToString();
            unListItem.Text = td.descripcion;
            //this.cmbTipoDeDocumento.Items.Add(unListItem);
            this.cmbFiltroPorTipoDeDocumento.Items.Add(unListItem);
        }
    }

    private void CompletarCombosDeCategoria()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var categoriasDeDocumento = servicio.CategoriasDocumentosSICOI().OrderBy(cd => cd.descripcion);

        foreach (CategoriaDeDocumentoSICOI cd in categoriasDeDocumento)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = cd.Id.ToString();
            unListItem.Text = cd.descripcion;
            this.cmbCategoria.Items.Add(unListItem);
            this.cmbFiltroPorCategoria.Items.Add(unListItem);
        }
    }

    //private void MostrarGrillaDeDocumentos()
    //{
    //    var lista_de_documentos = DocumentosFromWS();
    //    string[] columnasTablaDocumentos = new string[] { "Tipo", "Nro", "Ticket", "Extracto", "Fecha", "Area origen", "Estado", "Area Actual", "Area Destino", "Obs", "Acciones" };
    //    this.ListaDocumentos.Value = JsonConvert.SerializeObject(lista_de_documentos);
    //    MostrarTablaDeDocumentos(lista_de_documentos, this.grillaDocumentos, new DocumentoSICOIToRowSerializer(), columnasTablaDocumentos);
    //}

    private string DocumentosFromWS()
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        Usuario usuario = (Usuario)Session["usuario"];
              
        var filtros = new List<String>();

        if (chkFiltroSoloDocsEnMiArea.Checked){
            var filtroPorArea = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorAreaActual",
                idArea = usuarioLogueado.Areas[0].Id.ToString()
            }); 
            filtros.Add(filtroPorArea);
        }
        if(filtroFechaDesde.Value != ""){
            var filtroPorFechaDesde = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorFechaDesde",
                fechaDesde = filtroFechaDesde.Value
            }); 
            filtros.Add(filtroPorFechaDesde);
        }
        if (filtroFechaHasta.Value != ""){
            var filtroPorFechaHasta = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorFechaHasta",
                fechaHasta = filtroFechaHasta.Value
            }); 
            filtros.Add(filtroPorFechaHasta);
        }
        if (FiltroExtracto.Value != ""){
            var filtroPorExtracto = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorExtracto",
                extracto = FiltroExtracto.Value
            });            
            filtros.Add(filtroPorExtracto);
        }
        if (FiltroNumero.Value != ""){
            var filtroPorNumero = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorNumero",
                numero = FiltroNumero.Value
            });             
            filtros.Add(filtroPorNumero);
        }

        if (txtFiltroPorTiempoEnAreaActual.Value != "")
        {
            var filtroPorTiempoEnAreaActualDto = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA",
                dias = txtFiltroPorTiempoEnAreaActual.Value
            });
            filtros.Add(filtroPorTiempoEnAreaActualDto);
        }
        
        var tipoDeDocumento = TipoDeDocumentoAFiltrarFromForm();
        if (tipoDeDocumento.Id >= 0){
            var filtroPorTipo = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorTipoDocumento",
                idTipo = tipoDeDocumento.Id.ToString()
            });              
            filtros.Add(filtroPorTipo);
        }
        var categoriaDeDocumento = CategoriaDeDocumentoAFiltrarFromForm();
        if (categoriaDeDocumento.Id >= 0){
            var filtroPorCategoria = JsonConvert.SerializeObject(new
            {
                tipoDeFiltro = "FiltroDeDocumentosPorCategoria",
                idCategoria = categoriaDeDocumento.Id.ToString()
            });    
            filtros.Add(filtroPorCategoria);
        }
        if (!chkFiltroSoloDocsEnMiArea.Checked)
        {
            int idAreaActualAFiltrar;
            if (int.TryParse(AreaSeleccionadaActualEnFiltro.Value, out idAreaActualAFiltrar))
            {
                if (idAreaActualAFiltrar >= 0)
                {
                    var filtroPorAreaActual = JsonConvert.SerializeObject(new
                    {
                        tipoDeFiltro = "FiltroDeDocumentosPorAreaActual",
                        idArea = idAreaActualAFiltrar.ToString()
                    });
                    filtros.Add(filtroPorAreaActual);
                }
            }
        }
        int idAreaOrigenAFiltrar;
        if (int.TryParse(AreaSeleccionadaOrigenEnFiltro.Value, out idAreaOrigenAFiltrar)){
            if (idAreaOrigenAFiltrar >= 0){
                var filtroPorTransicion = JsonConvert.SerializeObject(new
                {
                    tipoDeFiltro = "FiltroDeDocumentosPorTransicion",
                    idAreaOrigen = idAreaOrigenAFiltrar.ToString(),
                    idAreaDestino = usuarioLogueado.Areas.First().Id.ToString()
                });                  
                filtros.Add(filtroPorTransicion);
            }
        }
        var documentos = ws_viaticos.GetDocumentosFiltrados(filtros.ToArray());

        return documentos;
    }

    private TipoDeDocumentoSICOI TipoDeDocumentoFromForm()
    {
        var tipoDeDocumento = new TipoDeDocumentoSICOI();
        tipoDeDocumento.Id = int.Parse(this.idTipoDeDocumentoSeleccionadoEnAlta.Value);
        tipoDeDocumento.descripcion = "";
        return tipoDeDocumento;
    }

    private TipoDeDocumentoSICOI TipoDeDocumentoAFiltrarFromForm()
    {
        var tipoDeDocumento = new TipoDeDocumentoSICOI();
        tipoDeDocumento.Id = int.Parse(this.cmbFiltroPorTipoDeDocumento.SelectedItem.Value);
        tipoDeDocumento.descripcion = this.cmbFiltroPorTipoDeDocumento.SelectedItem.Text;
        return tipoDeDocumento;
    }


    private TipoDeDocumentoSICOI CategoriaDeDocumentoAFiltrarFromForm()
    {
        var categoria = new TipoDeDocumentoSICOI();
        categoria.Id = int.Parse(this.cmbFiltroPorCategoria.SelectedItem.Value);
        categoria.descripcion = this.cmbFiltroPorCategoria.SelectedItem.Text;
        return categoria;
    }

    private CategoriaDeDocumentoSICOI CategoriaDeDocumentoFromForm()
    {
        var categoria = new CategoriaDeDocumentoSICOI();
        categoria.Id = int.Parse(this.cmbCategoria.SelectedItem.Value);
        categoria.descripcion = this.cmbCategoria.SelectedItem.Text;
        return categoria;
    }

    private Area AreaOrigenFromForm()
    {
        Area area_origen = new Area();
        Int32 id_area_origen = Int32.Parse(this.AreaSeleccionadaOrigen.Value);
        area_origen.Id = id_area_origen;
        return area_origen;
    }

    private Documento DocumentoDesdeElForm()
    {
        var documento = new Documento();
        documento.numero = this.txtNumero.Text;
        documento.extracto = this.txtExtracto.Text;
        
        documento.comentarios = this.txtComentarios.Text; //lo tiene que tener la transicion //por ahora lo dejamos en documento

        documento.tipoDeDocumento = TipoDeDocumentoFromForm();
        documento.categoriaDeDocumento = CategoriaDeDocumentoFromForm();
        //CrearTransicionesPara(documento);
        //documento.areaOrigen = AreaOrigenFromForm();

        var areaDestino = new Area();
        /*if (!EstaVacio(AreaDestino()))
        {
            documento.areaDestino = areaDestino;
            Int32 id_area_destino = Int32.Parse(this.AreaSeleccionadaDestino.Value);
            areaDestino.Id = id_area_destino;
        }*/

        return documento;
    }

    protected void btnCrearDocumento_Click(object sender, EventArgs e)
    {
        if (!DatosEstanCompletos())
        {
            return;
        }
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var documento = DocumentoDesdeElForm();
        documento = ws_viaticos.GuardarDocumento(documento, IdAreaOrigenDesdeElForm(), usuarioLogueado.Areas[0].Id, usuarioLogueado);
        var idAreaDestino = IdAreaDestinoDesdeElForm();
        if(idAreaDestino != -1) ws_viaticos.CrearTransicionFuturaParaDocumento(documento.Id, idAreaDestino, usuarioLogueado);

        LimpiarPantalla();
        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + " Número de Ticket generado: " + documento.ticket + "');</script>");
        this.RefrescarListaDeDocumentos();
    }

    protected void btnGuardarCambiosDetalle_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var idDocumentoEnDetalle = IdDocumentoEnDetalleDesdeElForm();
        var idAreaDestino = IdAreaDestinoEnDetalleDesdeElForm();
        ws_viaticos.GuardarCambiosEnDocumento(idDocumentoEnDetalle, idAreaDestino, this.txtComentariosEnDetalle.Text, usuarioLogueado);
        this.RefrescarListaDeDocumentos();
    }

    private int IdDocumentoEnDetalleDesdeElForm()
    {
        return int.Parse(this.idDocumentoEnDetalle.Value);
    }

    private int IdAreaDestinoEnDetalleDesdeElForm()
    {
        return int.Parse(this.AreaSeleccionadaDestinoEnDetalle.Value);
    }

    private int IdAreaActual()
    {
        return usuarioLogueado.Areas[0].Id;
    }

    private int IdAreaDestinoDesdeElForm()
    {
        if (this.AreaSeleccionadaDestino.Value != "")
            return int.Parse(this.AreaSeleccionadaDestino.Value);

        return -1;
    }

    private int IdAreaOrigenDesdeElForm()
    {
        if (this.AreaSeleccionadaOrigen.Value != "")
            return int.Parse(this.AreaSeleccionadaOrigen.Value);

        return -1;
    }

    protected void btnAplicarFiltros_Click(object sender, EventArgs e)
    {
        this.RefrescarListaDeDocumentos();
    }

    protected void btnAlertas_Click(object sender, EventArgs e)
    {
        this.ListaDocumentos.Value = DocumentosEnAlertaFromWS();
    }

    private string DocumentosEnAlertaFromWS()
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        Usuario usuario = (Usuario)Session["usuario"];

        var documentos = ws_viaticos.GetDocumentosEnAlerta();

        return documentos;
    }

    protected void btnEnviarDocumento_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var doc = documentoAEnviar();
        ws_viaticos.TransicionarDocumento((Int32)doc["id"], usuarioLogueado.Areas[0].Id, (Int32)doc["areaDestino"]["id"]);
        this.RefrescarListaDeDocumentos();
    }

    protected void btnEnviarDocumentoConAreaintermedia_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws_viaticos = new WSViaticosSoapClient();
        var doc = documentoAEnviar();
        ws_viaticos.TransicionarDocumentoConAreaIntermedia((Int32)doc["id"], (Int32)doc["areaActual"]["id"], usuarioLogueado.Areas[0].Id, (Int32)doc["areaDestino"]["id"]);
        this.RefrescarListaDeDocumentos();
    }

    private JObject documentoAEnviar()
    {
        return JsonConvert.DeserializeObject<JObject>(divDocumentoAEnviar.Value);
    }

    private void MostrarTablaDeDocumentos(List<Documento> lista_de_documentos, Table tablaDocumentos, EntityToRowConverter<Documento> rowSerializer, string[] nombresColumnas)
    {
        tablaDocumentos.CssClass = "table table-striped table-bordered table-condensed";
        RenderizadorDeTablas<Documento> renderizador = new RenderizadorDeTablas<Documento>(rowSerializer);
        renderizador.EstiloCeldaCabecera = "detalle_viatico_titulo_tabla_detalle";
        renderizador.AgregarCabeceras(nombresColumnas, tablaDocumentos);
        renderizador.RenderTo(new List<Documento>(lista_de_documentos), tablaDocumentos);
    }

    private bool DatosEstanCompletos()
    {
        return !((TipoDeDocumentoFromForm().Id==0) || /*EstaVacio(Numero()) ||*/ EstaVacio(Categoria()) || EstaVacio(Extracto()) || EstaVacio(AreaOrigen()));
    }

    private string TipoDeDocumento()
    {
        return this.cmbTipoDeDocumento.SelectedItem.Text;
    }

    private string AreaDestino()
    {
        return this.AreaSeleccionadaDestino.Value;
    }

    private string AreaOrigen()
    {
        return this.AreaSeleccionadaOrigen.Value;
    }

    private string Numero()
    {
        return this.txtNumero.Text;
    }

    private string Categoria()
    {
        return this.cmbCategoria.SelectedItem.Text;
    }

    private string Extracto()
    {
        return this.txtExtracto.Text;
    }

    private bool EstaVacio(string texto)
    {
        return texto.Trim().Length == 0;
    }

    private void LimpiarPantalla()
    {
        this.txtComentarios.Text = "";
        this.txtExtracto.Text = "";
        this.txtNumero.Text = "";
        this.AreaSeleccionadaDestino.Value = null;
        this.selectorDeAreaOrigen.Value = null;
        this.selectorDeAreaDestino.Value = null;
        this.AreaSeleccionadaOrigen.Value = null;
        this.cmbCategoria.SelectedValue = null;
        this.cmbTipoDeDocumento.SelectedValue = null;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SeleccionDeArea.aspx");
    }
}
