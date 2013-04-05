<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaDeDocumento.aspx.cs"
    Inherits="AltaDeDocumento" EnableEventValidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SICOI</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
</head>
<body class="body-detalle" onload="MM_preloadImages('Imagenes/Botones/gestiontramites_s2.png','Imagenes/Botones/administrar_s2.png','Imagenes/Botones/solicitar_modificacion_s2.png','Imagenes/Botones/Botones Nuevos/ayuda_s2.png','Imagenes/Botones/Botones Nuevos/inicio_s2.png','Imagenes/Botones/cerrarsesion_s2.png','Imagenes/Botones/consprotocolo_s2.png')">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_principal_sicoi">
        <div id="botonera_paneles_desplegables">
            <input type="button" id="boton_alertas" class=" btn btn-danger" value="!"/>
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
            <input type="text" id="FiltroNumero" runat="server" enableviewstate="true" 
                maxlength="30"  />
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
                <input type="button" id="btn_aplicar_filtros" class=" btn btn-primary" value="Aplicar filtros"/>
                <input type="button" id="btn_cancelar_filtro" class=" btn btn-primary" value="Quitar filtros"/>
            </div>
        </div>
        <div id="panel_alta_documento" class="panel_desplegable">
            <asp:DropDownList ID="cmbTipoDeDocumento" nullValue="Tipo de documento" runat="server" EnableViewState="true" >
                <asp:ListItem Value="" Selected="true"></asp:ListItem>
            </asp:DropDownList>
            <div id="letrasDelTipoDeDocumento">
            </div>
            <asp:TextBox ID="txtNumero" nullValue="Número" runat="server" MaxLength="50"></asp:TextBox>
            <asp:DropDownList ID="cmbCategoria" nullValue="Categoría de documento" runat="server" EnableViewState="true">
                <asp:ListItem Value="" Selected="true"></asp:ListItem>
            </asp:DropDownList>
            <input id="selectorDeAreaOrigen" nullValue="Área de Origen" type="text" data-provide="typeahead" data-items="9" runat="server" />
            <asp:TextBox ID="txtExtracto" nullValue="Ingrese el extracto del documento" TextMode="MultiLine" type = "text" Height="112px" runat="server"></asp:TextBox>
            <input id="selectorDeAreaDestino" nullValue="Área de Destino (opcional)" type="text" data-provide="typeahead" data-items="9" runat="server" />
            <asp:TextBox ID="txtComentarios" nullValue="Ingrese sus comentarios (opcional)" runat="server" TextMode="MultiLine" Height="32px" class="detalle_alta_documento" ></asp:TextBox>
            <div class="botones_alta_documento">
                <input type="button" id="btnCrearDocumento" class=" btn btn-primary" value="Agregar Documento"/>
                <input type="button" id="btnCancelar" class=" btn btn-primary" value="Cancelar"/>
            </div>
        </div>
        <div id="panel_documentos">
            <asp:Table ID="grillaDocumentos" runat="server">
            </asp:Table>
        </div>
        <div id="detalle_documento">
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
            <input id="selectorAreaDestinoEnDetalle"  type="text" data-provide="typeahead" data-items="9" runat="server" />
            <input type="button" id="btnGuardarCambiosDetalle" class=" btn btn-primary" value="Guardar Cambios"/>
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

    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>   
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
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
    <script type="text/javascript" src="../Scripts/InputSoloNumeros.js"></script>
    <script type="text/javascript" src="PanelDeFiltrosDeDocumentos.js"></script>
    <script type="text/javascript" src="GrillaDeDocumentos.js"></script>
    <script type="text/javascript" src="InputAutocompletableDeAreas.js"></script>
    <script type="text/javascript" src="PanelDetalleDeDocumento.js"></script>
    <script type="text/javascript" src="PanelDeDocumentos.js"></script>
    <script type="text/javascript" src="PanelAltaDeDocumento.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var listaAreas = JSON.parse($('#ListaAreas').val());
            //var listaDocumentos = JSON.parse($('#ListaDocumentos').val());
            var tiposDeDocumento = JSON.parse($('#TiposDeDocumento').val());
            var areaDelUsuario = JSON.parse($('#divAreaDelUsuario').val());

            var cfg_panel_documentos = {
                divPanelDocumentos: $("#panel_documentos"),
                areaDelUsuario: areaDelUsuario
            }
            var panel_documentos = new PanelDeDocumentos(cfg_panel_documentos);

            var cfg_panel_detalle = {
                divPanelDetalle: $("#detalle_documento"),
                ExtractoDocumentoDetalle: $("#ExtractoDocumentoDetalle"),
                TipoDocumentoDetalle: $("#TipoDocumentoDetalle"),
                NumeroDocumentoDetalle: $("#NumeroDocumentoDetalle"),
                FechaDocumentoDetalle: $("#FechaDocumentoDetalle"),
                txtComentariosEnDetalle: $("#txtComentariosEnDetalle"),
                AreaOrigenDocumentoDetalle: $("#AreaOrigenDocumentoDetalle"),
                selectorDeAreaDestinoEnDetalle: $('#selectorAreaDestinoEnDetalle'),
                areaDestinoSeleccionadaEnDetalle: $('#AreaSeleccionadaDestinoEnDetalle'),
                contenedor_historial_transiciones: $("#contenedor_historial_documento_detalle"),
                plantilla_transicion_documento: $('#proto_transicion_de_documento_historial'),
                botonCerrarDetalle: $('#cerrarDetalle'),
                btnGuardarCambios: $('#btnGuardarCambiosDetalle'),
                listaAreas: listaAreas
            };
            var panel_detalle = new PanelDetalleDeDocumento(cfg_panel_detalle);

            var cfg_panel_alta = {
                selectorDeAreaOrigenEnAlta: $('#selectorDeAreaOrigen'),
                selectorDeAreaDestinoEnAlta: $('#selectorDeAreaDestino'),
                areaOrigenSeleccionadaEnAlta: $('#AreaSeleccionadaOrigen'),
                areaDestinoSeleccionadaEnAlta: $('#AreaSeleccionadaDestino'),
                cmbTipoDeDocumento: $('#cmbTipoDeDocumento'),
                idTipoDeDocumentoSeleccionadoEnAlta: $('#idTipoDeDocumentoSeleccionadoEnAlta'),
                lblLetrasDelTipoDeDocumento: $("#letrasDelTipoDeDocumento"),
                txtNumero: $('#txtNumero'),
                txtExtracto: $('#txtExtracto'),
                txtComentarios: $('#txtComentarios'),
                btnCrearDocumento: $('#btnCrearDocumento'),
                btnCancelar: $('#btnCancelar'),
                cmbCategoriaDocumento: $('#cmbCategoria'),
                botonDesplegarPanelAlta: $("#boton_desplegar_panel_alta_documento"),
                divPanelAlta: $("#panel_alta_documento"),
                listaAreas: listaAreas,
                tiposDeDocumento: tiposDeDocumento,
                areaDelUsuario: areaDelUsuario
            }
            var panel_alta = new PanelAltaDeDocumento(cfg_panel_alta);

            var cfg_panel_filtros = {
                inputFiltroExtractoDocumento: $('#FiltroExtracto'),
                inputFiltroNumeroDocumento: $('#FiltroNumero'),
                inputFiltroFechaDesde: $('#filtroFechaDesde'),
                inputFiltroFechaHasta: $('#filtroFechaHasta'),
                inputFiltroAreaActual: $('#selectorAreaActualEnfiltro'),
                areaActualSeleccionadaEnFiltro: $('#AreaSeleccionadaActualEnFiltro'),
                inputFiltroAreaOrigen: $('#selectorAreaOrigenEnfiltro'),
                areaOrigenSeleccionadaEnFiltro: $('#AreaSeleccionadaOrigenEnFiltro'),
                inputFiltroDetenidoMasDeTantosDias: $('#txtFiltroPorTiempoEnAreaActual'),
                inputFiltroTipoDeDocumento: $('#cmbFiltroPorTipoDeDocumento'),
                inputFiltroCategoriaDocumentoFiltro: $('#cmbFiltroPorCategoria'),
                inputFiltroCheckDocumentosEnMiArea: $('#chkFiltroSoloDocsEnMiArea'),
                tituloFiltroCheckDocumentosEnMiArea: $('#titulo_filtro_solo_docs_en_mi_area'),
                divFiltrosActivos: $('#divFiltrosActivos'),
                botonDesplegarPanelFiltros: $("#boton_desplegar_panel_filtros"),
                tituloFiltroAreaActual: $('#titulo_filtro_area_actual'),
                divPanelFiltros: $("#panel_filtros"),
                btnAplicarFiltros: $('#btn_aplicar_filtros'),
                btnQuitarFiltros: $('#btn_cancelar_filtro'),
                areaDelUsuario: areaDelUsuario,
                listaAreas: listaAreas,
                tiposDeDocumento: tiposDeDocumento
            }
            var panel_filtros = new PanelDeFiltrosDeDocumentos(cfg_panel_filtros);

            panel_documentos.setPanelDetalle(panel_detalle);
            panel_documentos.setPanelFiltros(panel_filtros);

            panel_detalle.setPanelAlta(panel_alta);
            panel_detalle.setPanelFiltros(panel_filtros);
            panel_detalle.setPanelDocumentos(panel_documentos);

            panel_alta.setPanelFiltros(panel_filtros);
            panel_alta.setPanelDocumentos(panel_documentos);
            panel_alta.setPanelDetalle(panel_detalle);

            panel_filtros.setPanelAlta(panel_alta);
            panel_filtros.setPanelDetalle(panel_detalle);
            panel_filtros.setPanelDocumentos(panel_documentos);

            var boton_alertas = $("#boton_alertas");
            boton_alertas.click(function () {
                $.ajax({
                    url: "../AjaxWS.asmx/GetDocumentosEnAlerta",
                    type: "POST",
                    data: JSON.stringify({}),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var documentos = JSON.parse(respuestaJson.d);
                        panel_documentos._grilla_de_documentos.BorrarContenido();
                        panel_documentos._grilla_de_documentos.CargarObjetos(documentos);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            });

            setInterval(function () {
                $.ajax({
                    url: "../AjaxWS.asmx/HayDocumentosEnAlerta",
                    type: "POST",
                    data: JSON.stringify({}),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        if (JSON.parse(respuestaJson.d)) boton_alertas.show();
                        else boton_alertas.hide();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            },
            10000);  //cada 10 segundos pregunta si hay

        });
    </script>   

   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</body>
</html>