<%@ page language="C#" autoeventwireup="true" inherits="AltaDeDocumento, App_Web_opm0ft0a" enableeventvalidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SICOI</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />

     <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
      <script type="text/javascript" src="utilesSICOI.js"></script>
       <script type="text/javascript" src="../Scripts/InputSoloNumeros.js"></script>


</head>
<body class="body-detalle" onload="MM_preloadImages('Imagenes/Botones/gestiontramites_s2.png','Imagenes/Botones/administrar_s2.png','Imagenes/Botones/solicitar_modificacion_s2.png','Imagenes/Botones/Botones Nuevos/ayuda_s2.png','Imagenes/Botones/Botones Nuevos/inicio_s2.png','Imagenes/Botones/cerrarsesion_s2.png','Imagenes/Botones/consprotocolo_s2.png')">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_principal_sicoi">
        <div id="botonera_paneles_desplegables">
            <asp:Button ID="boton_alertas" Text="!" runat="server" OnClick="btnAlertas_Click"
                    class=" btn btn-danger" />
            <div id="boton_desplegar_panel_filtros" class="boton_que_abre_panel_desplegable"
                title="Filtros">
                Filtros
            </div>
            <div id="boton_desplegar_panel_alta_documento" class="boton_que_abre_panel_desplegable"
                title="Agregar documento">
                Alta de documento
            </div>
        </div>
        <div id="panel_filtros" class="panel_desplegable">
            <div class="titulo_filtro">
                Creado entre:</div>
            <input type="text" id="filtroFechaDesde" runat="server" enableviewstate="true"  />
            <div class="agrupador_de_filtros_por_fecha">
                y
            </div>
            <input type="text" id="filtroFechaHasta" runat="server" enableviewstate="true"  />
            <div>
            </div>
            <input type="text" id="filtroTicket" runat="server" enableviewstate="true" visible = "false"  />
            <div class="titulo_filtro">
                Extracto:</div>
            <input type="text" id="FiltroExtracto" runat="server" enableviewstate="true"/>
            <div>
            </div>
            <div class="titulo_filtro">
                Número:</div>
            <input type="text" id="FiltroNumero" runat="server" enableviewstate="true"  />
            <div class="titulo_filtro_tipo">
                Tipo:</div>
            <asp:DropDownList ID="cmbFiltroPorTipoDeDocumento" runat="server" EnableViewState="true" type = "text" >
                <asp:ListItem Value="-1" class="placeholder" Selected="true">Todos</asp:ListItem>
            </asp:DropDownList>
            <div class="titulo_filtro_categoria">
                Categoría:</div>
            <asp:DropDownList ID="cmbFiltroPorCategoria" runat="server" EnableViewState="true" type = "text" >
                <asp:ListItem Value="-1" class="placeholder" Selected="true">Todas</asp:ListItem>
            </asp:DropDownList>
            <div>
            </div>
            <div class="titulo_filtro_solo_docs_en_mi_area" id = "titulo_filtro_solo_docs_en_mi_area">
                Solo documentos en mi área:</div>
            <input type="checkbox" id="chkFiltroSoloDocsEnMiArea" runat="server" enableviewstate="true"   />
            <div>
            </div>
            <div id="titulo_filtro_area_actual" class="titulo_filtro">
                Área Actual:</div>
            <input id="selectorAreaActualEnfiltro" type="text" data-provide="typeahead" enableviewstate="true" 
                data-items="9" runat="server" />

            <div id="titulo_filtro_area_origen" class="titulo_filtro">
                Área Origen:</div>
            <input id="selectorAreaOrigenEnfiltro" type="text" data-provide="typeahead" 
                data-items="9" runat="server" />
            <div>
            </div>
            <div class="titulo_filtro">
                Detenido más de:</div>
            <input type="text" id="txtFiltroPorTiempoEnAreaActual" runat="server" soloNumero ="soloNumero"
                enableviewstate="true" maxlength="4"  />
            <span>días</span>
           

            <div class="botones_alta_documento">
                <asp:Button ID="btn_aplicar_filtros" Text="Aplicar filtro" runat="server" OnClick="btnAplicarFiltros_Click"
                    class=" btn btn-primary" />
                <asp:Button ID="btn_cancelar_filtro" Text="Quitar filtros" runat="server" OnClick="btnCancelar_Click"
                    class=" btn btn-primary" />
            </div>
        </div>
        <div id="panel_alta_documento" class="panel_desplegable">
            <asp:DropDownList ID="cmbTipoDeDocumento" nullValue="Tipo de documento" runat="server" EnableViewState="true" onBlur = "javascript:feedback_vacios()" >
                <asp:ListItem Value="" Selected="true"></asp:ListItem>
            </asp:DropDownList>
            <div id="letrasDelTipoDeDocumento">
            </div>
            <asp:TextBox ID="txtNumero" nullValue="Número" runat="server" MaxLength="50"></asp:TextBox>
            <asp:DropDownList ID="cmbCategoria" nullValue="Categoría de documento" runat="server" EnableViewState="true" onBlur = "javascript:feedback_vacios()">
                <asp:ListItem Value="" Selected="true"></asp:ListItem>
            </asp:DropDownList>
            <input id="selectorDeAreaOrigen" nullValue="Área de Origen" type="text" data-provide="typeahead" onBlur = "feedback_vacios()" data-items="9" runat="server" />
            <asp:TextBox ID="txtExtracto" nullValue="Ingrese el extracto del documento" TextMode="MultiLine" type = "text" onkeyup = "valida_envia()" Height="112px" runat="server"></asp:TextBox>
            <input id="selectorDeAreaDestino" nullValue="Área de Destino (opcional)" type="text" data-provide="typeahead" data-items="9" runat="server" />
            <asp:TextBox ID="txtComentarios" nullValue="Ingrese sus comentarios (opcional)" runat="server" TextMode="MultiLine" Height="32px" class="detalle_alta_documento" ></asp:TextBox>
            <div class="botones_alta_documento">
                <asp:Button ID="btnCrearDocumento" Text="Agregar Documento" runat="server" type = "submit" OnClick="btnCrearDocumento_Click" onMouseEnter = "feedback_vacios()"
                    class=" btn btn-primary" />
                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" OnClick="btnCancelar_Click"
                    class=" btn btn-primary" />
            </div>
        </div>
        <div id="panel_documentos">
            <asp:Table ID="grillaDocumentos" runat="server">
            </asp:Table>
        </div>
        <div id="detalle_documento">
            <asp:HiddenField ID="idDocumentoEnDetalle" runat="server" />
            <img id="cerrarDetalle" src="../Imagenes/Botones/Botones Sicoi/cerrar_s1.png" width="20" height="20" alt='X' />
            <div id='titulo_tipo_documento_detalle'>
                Tipo de Documento:</div>
            <div id="TipoDocumentoDetalle">
            </div>
            <div id='titulo_numero_documento_detalle'>
                N&uacute;mero:</div>
            <div id="NumeroDocumentoDetalle">
            </div>
            <div id='titulo_fecha_documento_detalle'>
                Creado el:</div>
            <div id="FechaDocumentoDetalle">
            </div>
            <div id='titulo_area_origen_documento_detalle'>
                Área origen:</div>
            <div id="AreaOrigenDocumentoDetalle">
            </div>
            <div id='titulo_extracto_documento_detalle'>
                Extracto:</div>
            <div id="ExtractoDocumentoDetalle">
            </div>
            <div id='titulo_comentarios_detalle'>
                Comentarios:</div>
            <asp:TextBox ID="txtComentariosEnDetalle" placeholder="Ingrese sus comentarios (opcional)"
                runat="server" TextMode="MultiLine" Height="32px"></asp:TextBox>
            <div id='titulo_historial_transiciones'>
                Transiciones:</div>
            <div id="contenedor_historial_documento_detalle">
            </div>
            <div id="proto_transicion_de_documento_historial" class="transicion_de_documento_historial">
                <div class="fecha_transicion">
                </div>
                <div class="titulo_area_origen_transicion">
                    Área Origen:</div>
                <div class="area_origen_transicion">
                </div>
                <div class="titulo_area_destino_transicion">
                    Área Destino:</div>
                <div class="area_destino_transicion">
                </div>
            </div>
            <div id='titulo_area_destino_detalle'>
                Próximo área destino:</div>
            <input id="selectorAreaDestinoEnDetalle"  type="text"
                data-provide="typeahead" data-items="9" runat="server" />
            <asp:Button ID="btnGuardarCambiosDetalle" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambiosDetalle_Click"
                class=" btn btn-primary" />
        </div>
    </div>

    <asp:HiddenField ID="divAreaDelUsuario" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaOrigen" runat="server" />
    <asp:HiddenField ID="ListaAreas" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaOrigenEnFiltro" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaActualEnFiltro" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaDestino" runat="server" />
    <asp:HiddenField ID="divFiltrosActivos" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaDestinoEnDetalle" runat="server" />
    <asp:HiddenField ID="ListaDocumentos" runat="server" />
    <asp:HiddenField ID="TiposDeDocumento" runat="server" />
    <asp:HiddenField ID="idTipoDeDocumentoSeleccionadoEnAlta" runat="server" />
    <asp:HiddenField ID="divDocumentoAEnviar" runat="server" />
    <asp:Button ID="btnEnviarDocumento" Text="" runat="server" OnClick="btnEnviarDocumento_Click"
        Style="display: none" />
    <asp:Button ID="btnEnviarDocumentoConAreaIntermedia" Text="" runat="server" OnClick="btnEnviarDocumentoConAreaintermedia_Click"
        Style="display: none" />
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
   
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-transition.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/InputAutocompletable.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>
    <script type="text/javascript" src="AdministradorDeDocumentos.js"></script>
    <script type="text/javascript" src="PanelDeFiltrosDeDocumentos.js"></script>
    <script type="text/javascript" src="GrillaDeDocumentos.js"></script>
    <script type="text/javascript" src="InputAutocompletableDeAreas.js"></script>
    <script type="text/javascript" src="PanelDetalleDeDocumento.js"></script>
  
       <script type="text/javascript" src="../Scripts/InputSoloNumeros.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var selectorDeAreaOrigenEnAlta = $('#selectorDeAreaOrigen');
            var selectorDeAreaDestinoEnAlta = $('#selectorDeAreaDestino');
            var selectorDeAreaDestinoEnDetalle = $('#selectorAreaDestinoEnDetalle');
            var selectorDeAreaActualEnfiltro = $('#selectorAreaActualEnfiltro');
            var selectorDeAreaOrigenEnfiltro = $('#selectorAreaOrigenEnfiltro');

            var areaOrigenSeleccionadaEnAlta = $('#AreaSeleccionadaOrigen');
            var areaDestinoSeleccionadaEnAlta = $('#AreaSeleccionadaDestino');
            var areaDestinoSeleccionadaEnDetalle = $('#AreaSeleccionadaDestinoEnDetalle');
            var areaActualSeleccionadaEnFiltro = $('#AreaSeleccionadaActualEnFiltro');
            var areaOrigenSeleccionadaEnFiltro = $('#AreaSeleccionadaOrigenEnFiltro');

            var listaAreas = $('#ListaAreas');
            var listaDocumentos = JSON.parse($('#ListaDocumentos').val());
            var botonCerrarDetalle = $('#cerrarDetalle');
            var botonDesplegarPanelAlta = $("#boton_desplegar_panel_alta_documento");
            var botonDesplegarPanelFiltros = $("#boton_desplegar_panel_filtros");
            var panelFiltros = $("#panel_filtros");
            var panelAlta = $("#panel_alta_documento");
            var panelDocumentos = $("#panel_documentos");
            var panelDetalle = $("#detalle_documento");
            var filtroFechaDesde = $("#filtroFechaDesde");
            var filtroFechaHasta = $("#filtroFechaHasta");
            var botonAplicarFiltros = $("#btn_aplicar_filtros");
            var divDocumentoAEnviar = $("#divDocumentoAEnviar");
            var btnEnviarDocumento = $("#btnEnviarDocumento");
            var btnEnviarDocumentoConAreaIntermedia = $("#btnEnviarDocumentoConAreaIntermedia");
            var idDocumentoEnDetalle = $("#idDocumentoEnDetalle");
            var ExtractoDocumentoDetalle = $("#ExtractoDocumentoDetalle");
            var TipoDocumentoDetalle = $("#TipoDocumentoDetalle");
            var NumeroDocumentoDetalle = $("#NumeroDocumentoDetalle");
            var FechaDocumentoDetalle = $("#FechaDocumentoDetalle");
            var txtComentariosEnDetalle = $("#txtComentariosEnDetalle");
            var AreaOrigenDocumentoDetalle = $("#AreaOrigenDocumentoDetalle");
            var tiposDeDocumento = JSON.parse($('#TiposDeDocumento').val());
            var cmbTipoDeDocumento = $('#cmbTipoDeDocumento');
            var cmbFiltroPorTipoDeDocumento = $('#cmbFiltroPorTipoDeDocumento');
            var idTipoDeDocumentoSeleccionadoEnAlta = $('#idTipoDeDocumentoSeleccionadoEnAlta');
            var lblLetrasDelTipoDeDocumento = $("#letrasDelTipoDeDocumento");
            var txtNumero = $('#txtNumero');
            var areaDelUsuario = JSON.parse($('#divAreaDelUsuario').val());
            var chkFiltroSoloDocsEnMiArea = $('#chkFiltroSoloDocsEnMiArea');
            var titulo_filtro_area_actual = $('#titulo_filtro_area_actual');


            var cfg_grilla = {
                areaDelUsuario: areaDelUsuario,
                divDocumentoAEnviar: divDocumentoAEnviar,
                btnEnviarDocumento: btnEnviarDocumento,
                btnEnviarDocumentoConAreaIntermedia: btnEnviarDocumentoConAreaIntermedia,
                panelDetalle: panelDetalle,
                listaDocumentos: listaDocumentos//,
                //panelDocumentos: panelDocumentos
            }

            var grillaDocumentos = new GrillaDeDocumentos(cfg_grilla);

            var cfg_panel_detalle = {
                grillaDocumentos: grillaDocumentos,
                panelDetalle: panelDetalle,
                panelDocumentos: panelDocumentos,
                panelFiltros: panelFiltros,
                panelAlta: panelAlta,
                botonDesplegarPanelAlta: botonDesplegarPanelAlta,
                botonDesplegarPanelFiltros: botonDesplegarPanelFiltros,
                idDocumentoEnDetalle: idDocumentoEnDetalle,
                ExtractoDocumentoDetalle: ExtractoDocumentoDetalle,
                TipoDocumentoDetalle: TipoDocumentoDetalle,
                NumeroDocumentoDetalle: NumeroDocumentoDetalle,
                FechaDocumentoDetalle: FechaDocumentoDetalle,
                txtComentariosEnDetalle: txtComentariosEnDetalle,
                AreaOrigenDocumentoDetalle: AreaOrigenDocumentoDetalle,
                selectorDeAreaDestinoEnDetalle: selectorDeAreaDestinoEnDetalle,
                areaDestinoSeleccionadaEnDetalle: areaDestinoSeleccionadaEnDetalle
            };
            var panel_detalle = new PanelDetalle(cfg_panel_detalle);

            var panel_filtros = new PanelDeFiltrosDeDocumentos( $('#FiltroExtracto'),
                                                                $('#FiltroNumero'),
                                                                $('#filtroFechaDesde'),
                                                                $('#filtroFechaHasta'),
                                                                $('#selectorAreaActualEnfiltro'),
                                                                $('#AreaSeleccionadaActualEnFiltro'),
                                                                $('#selectorAreaOrigenEnfiltro'),
                                                                $('#AreaSeleccionadaOrigenEnFiltro'),
                                                                $('#txtFiltroPorTiempoEnAreaActual'),
                                                                $('#cmbFiltroPorTipoDeDocumento'),
                                                                $('#cmbFiltroPorCategoria'),
                                                                $('#chkFiltroSoloDocsEnMiArea'),
                                                                $('#titulo_filtro_solo_docs_en_mi_area'),
                                                                $('#divFiltrosActivos'),
                                                                areaDelUsuario,
                                                                $("#boton_desplegar_panel_filtros"),
                                                                $('#titulo_filtro_area_actual')
                                                                );


            var cfg_administrador_docs = {
                titulo_filtro_area_actual: titulo_filtro_area_actual,
                chkFiltroSoloDocsEnMiArea: chkFiltroSoloDocsEnMiArea,
                areaDelUsuario: areaDelUsuario,
                grillaDocumentos: grillaDocumentos,
                selectorDeAreaOrigenEnAlta: selectorDeAreaOrigenEnAlta,
                selectorDeAreaDestinoEnAlta: selectorDeAreaDestinoEnAlta,
                selectorDeAreaDestinoEnDetalle: selectorDeAreaDestinoEnDetalle,
                selectorDeAreaActualEnfiltro: selectorDeAreaActualEnfiltro,
                selectorDeAreaOrigenEnfiltro: selectorDeAreaOrigenEnfiltro,

                areaOrigenSeleccionadaEnAlta: areaOrigenSeleccionadaEnAlta,
                areaDestinoSeleccionadaEnAlta: areaDestinoSeleccionadaEnAlta,
                areaDestinoSeleccionadaEnDetalle: areaDestinoSeleccionadaEnDetalle,
                areaActualSeleccionadaEnFiltro: areaActualSeleccionadaEnFiltro,
                areaOrigenSeleccionadaEnFiltro: areaOrigenSeleccionadaEnFiltro,

                listaAreas: listaAreas,
                listaDocumentos: listaDocumentos,
                botonCerrarDetalle: botonCerrarDetalle,
                botonDesplegarPanelAlta: botonDesplegarPanelAlta,
                botonDesplegarPanelFiltros: botonDesplegarPanelFiltros,
                panelFiltros: panelFiltros,
                panelAlta: panelAlta,
                panelDocumentos: panelDocumentos,
                panelDetalle: panelDetalle,
                filtroFechaDesde: filtroFechaDesde,
                filtroFechaHasta: filtroFechaHasta,
                botonAplicarFiltros: botonAplicarFiltros,
                idDocumentoEnDetalle: idDocumentoEnDetalle,
                ExtractoDocumentoDetalle: ExtractoDocumentoDetalle,
                TipoDocumentoDetalle: TipoDocumentoDetalle,
                NumeroDocumentoDetalle: NumeroDocumentoDetalle,
                FechaDocumentoDetalle: FechaDocumentoDetalle,
                txtComentariosEnDetalle: txtComentariosEnDetalle,
                AreaOrigenDocumentoDetalle: AreaOrigenDocumentoDetalle,
                tiposDeDocumento: tiposDeDocumento,
                cmbTipoDeDocumento: cmbTipoDeDocumento,
                cmbFiltroPorTipoDeDocumento: cmbFiltroPorTipoDeDocumento,
                idTipoDeDocumentoSeleccionadoEnAlta: idTipoDeDocumentoSeleccionadoEnAlta,
                lblLetrasDelTipoDeDocumento: lblLetrasDelTipoDeDocumento,
                txtNumero: txtNumero
            };
            var admin = new AdministradorDeDocumentos(cfg_administrador_docs);

        });
    </script>   

   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</body>
</html>