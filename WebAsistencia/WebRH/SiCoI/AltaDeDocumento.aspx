<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaDeDocumento.aspx.cs"
    Inherits="AltaDeDocumento" EnableEventValidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SICOI</title>
    <link id="link3" rel="stylesheet" href="../Estilos/EstilosSICOI.css" type="text/css" runat="server" />
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
            <div id="panelBusquedaBasica">
                <div class="titulo_filtro"> Buscar documentos:</div>
                <input type="text" id="inputFiltroGoogleano" runat="server"/>
            </div>
            <div id="panelBusquedaAvanzada">
                <div class="titulo_filtro">
                    Creado entre:</div>
                <input type="text" id="filtroFechaDesde" runat="server"/>
                <div class="agrupador_de_filtros_por_fecha">
                    y
                </div>
                <input type="text" id="filtroFechaHasta" runat="server"/>
                <div>
                </div>
                <input type="text" id="filtroTicket" runat="server" visible = "false"  />
                <div class="titulo_filtro"> Extracto:</div>
                <input type="text" id="FiltroExtracto" runat="server"/>
                <div>
                </div>
                <div class="titulo_filtro">
                    Número:</div>
                <input type="text" id="FiltroNumero" runat="server" maxlength="30"  />
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
                <input type="checkbox" id="chkFiltroSoloDocsEnMiArea" runat="server" />
                <div>
                </div>
                <div id="titulo_filtro_area_actual" class="titulo_filtro">
                    Área Actual:</div>
                <input id="selectorAreaActualEnfiltro" type="text" data-provide="typeahead" data-items="9" runat="server" />
                <div id="titulo_filtro_area_origen" class="titulo_filtro">
                    Área Origen:</div>
                <input id="selectorAreaOrigenEnfiltro" type="text" data-provide="typeahead" data-items="9" runat="server" />
                <div>
                </div>
                <div class="titulo_filtro">
                    Detenido más de:</div>
                <input type="text" id="txtFiltroPorTiempoEnAreaActual" runat="server" soloNumero ="soloNumero" maxlength="4"/>
                <span>días</span>        
            </div>
            <div class="botones_alta_documento">
                <input type="button" id="btnToggleBusquedaAvanzada" class=" btn btn-primary" value="+"/>
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
        </div>       
    </div>

    <div id="plantillas">
        <div id="lista_de_documentos">
        </div>
        <div id="plantilla_ficha_chica_de_documento" class="ficha_chica_de_documento ficha_chica_de_documento_par">
            <div id="ficha_chica_titulo_ticket">Ticket:</div>
            <div id="ficha_chica_contenido_ticket">AAA036</div>
            <div id="ficha_chica_titulo_tipo">Tipo:</div>
            <div id="ficha_chica_contenido_tipo">Expediente N° 97</div>
            <div id="ficha_chica_titulo_categoria">Categoría:</div>
            <div id="ficha_chica_contenido_categoria">Renuncia</div>
            <input type="button" id="link_enviar_documento" value="Enviar" class="btn"/><br />
            <div id="ficha_chica_titulo_area_actual">Área Actual:</div>
            <div id="ficha_chica_contenido_area_actual">Dirección General de Recursos Humanos y Organización</div><br />
            <div id="ficha_chica_titulo_extracto">Extracto:</div>
            <div id="ficha_chica_contenido_extracto">ddaaddaa</div>
            <div id="ficha_chica_boton_desplegar" class="icon-plus-sign"></div>
        </div>    

         <div id="plantilla_ficha_grande_de_documento">
            <div id='ficha_grande_titulo_area_creadora'> Area Creadora:</div>
            <div id="ficha_grande_contenido_area_creadora"> Mesa de Entradas </div><br />
            <div id='ficha_grande_titulo_tiempo_en_area_actual'> En Area Actual Desde:</div>
            <div id="ficha_grande_contenido_tiempo_en_area_actual"> 2 dias </div><br />
            <div id='ficha_grande_titulo_comentarios'> Comentarios:</div>
            <textarea id="ficha_grande_contenido_comentarios"></textarea>
            <div id='ficha_grande_titulo_transiciones'> Transiciones</div>
            <div id='ficha_grande_titulo_fecha_de_ingreso'> Fecha de ingreso</div>
            <div id='ficha_grande_titulo_area_destino'> Próximo area destino:</div>
            <input type="text" id='ficha_grande_contenido_area_destino' data-provide="typeahead" data-items="9"/>
        </div>
    </div>

    <asp:HiddenField ID="AreaDelUsuario" runat="server" />
    <asp:HiddenField ID="ListaAreas" runat="server" />
    <asp:HiddenField ID="CategoriasDeDocumento" runat="server" />
    <asp:HiddenField ID="TiposDeDocumento" runat="server" />

    <asp:HiddenField ID="AreaSeleccionadaOrigenEnFiltro" runat="server" />
    <asp:HiddenField ID="AreaSeleccionadaActualEnFiltro" runat="server" />

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
    <script type="text/javascript" src="InputAutocompletableDeAreas.js"></script>
    <script type="text/javascript" src="PanelDeDocumentos.js"></script>
    <script type="text/javascript" src="PanelAltaDeDocumento.js"></script>
    <script type="text/javascript" src="ListaDeFichas.js"></script>
    <script type="text/javascript" src="FichaChicaDeDocumento.js"></script>
    <script type="text/javascript" src="FichaGrandeDeDocumento.js"></script>
    <script type="text/javascript" src="FabricaDeFichasDeDocumento.js"></script>
    <script type="text/javascript" src="WebService.js"></script>
    <script type="text/javascript" src="BotonAlertas.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var listaAreas = JSON.parse($('#ListaAreas').val());
            var tiposDeDocumento = JSON.parse($('#TiposDeDocumento').val());
            var categoriasDeDocumento = JSON.parse($('#CategoriasDeDocumento').val());
            var areaDelUsuario = JSON.parse($('#AreaDelUsuario').val());

            var cfg_panel_documentos = {
                divPanelDocumentos: $("#panel_documentos"),
                plantillaFichaChica: $("#plantilla_ficha_chica_de_documento"),
                plantillaFichaGrande: $("#plantilla_ficha_grande_de_documento"),
                uiListaDeDocs: $("#lista_de_documentos"),
                listaAreas:listaAreas,
                areaDelUsuario: areaDelUsuario
            }
            var panel_documentos = new PanelDeDocumentos(cfg_panel_documentos);

//            var cfg_panel_detalle = {
//                divPanelDetalle: $("#detalle_documento"),
//                ExtractoDocumentoDetalle: $("#ExtractoDocumentoDetalle"),
//                TipoDocumentoDetalle: $("#TipoDocumentoDetalle"),
//                NumeroDocumentoDetalle: $("#NumeroDocumentoDetalle"),
//                FechaDocumentoDetalle: $("#FechaDocumentoDetalle"),
//                txtComentariosEnDetalle: $("#txtComentariosEnDetalle"),
//                AreaOrigenDocumentoDetalle: $("#AreaOrigenDocumentoDetalle"),
//                selectorDeAreaDestinoEnDetalle: $('#selectorAreaDestinoEnDetalle'),
//                contenedor_historial_transiciones: $("#contenedor_historial_documento_detalle"),
//                plantilla_transicion_documento: $('#proto_transicion_de_documento_historial'),
//                botonCerrarDetalle: $('#cerrarDetalle'),
//                btnGuardarCambios: $('#btnGuardarCambiosDetalle'),
//                listaAreas: listaAreas
//            };
//            var panel_detalle = new PanelDetalleDeDocumento(cfg_panel_detalle);

//            var cfg_ficha_grande = {
//                divPanelDetalle: $("#detalle_documento"),
//                ExtractoDocumentoDetalle: $("#ExtractoDocumentoDetalle"),
//                TipoDocumentoDetalle: $("#TipoDocumentoDetalle"),
//                NumeroDocumentoDetalle: $("#NumeroDocumentoDetalle"),
//                FechaDocumentoDetalle: $("#FechaDocumentoDetalle"),
//                txtComentariosEnDetalle: $("#txtComentariosEnDetalle"),
//                AreaOrigenDocumentoDetalle: $("#AreaOrigenDocumentoDetalle"),
//                selectorDeAreaDestinoEnDetalle: $('#selectorAreaDestinoEnDetalle'),
//                contenedor_historial_transiciones: $("#contenedor_historial_documento_detalle"),
//                plantilla_transicion_documento: $('#proto_transicion_de_documento_historial'),
//                botonCerrarDetalle: $('#cerrarDetalle'),
//                btnGuardarCambios: $('#btnGuardarCambiosDetalle'),
//                listaAreas: listaAreas
//            };
//            var ficha_grande = new PanelDetalleDeDocumento(cfg_panel_detalle);

            var cfg_panel_alta = {
                selectorDeAreaOrigenEnAlta: $('#selectorDeAreaOrigen'),
                selectorDeAreaDestinoEnAlta: $('#selectorDeAreaDestino'),
                cmbTipoDeDocumento: $('#cmbTipoDeDocumento'),
                cmbCategoriaDocumento: $('#cmbCategoria'),
                lblLetrasDelTipoDeDocumento: $("#letrasDelTipoDeDocumento"),
                txtNumero: $('#txtNumero'),
                txtExtracto: $('#txtExtracto'),
                txtComentarios: $('#txtComentarios'),
                btnCrearDocumento: $('#btnCrearDocumento'),
                btnCancelar: $('#btnCancelar'),
                botonDesplegarPanelAlta: $("#boton_desplegar_panel_alta_documento"),
                divPanelAlta: $("#panel_alta_documento"),
                listaAreas: listaAreas,
                tiposDeDocumento: tiposDeDocumento,
                categoriasDeDocumento: categoriasDeDocumento,
                areaDelUsuario: areaDelUsuario
            }
            var panel_alta = new PanelAltaDeDocumento(cfg_panel_alta);

            var cfg_panel_filtros = {
                inputFiltroExtractoDocumento: $('#FiltroExtracto'),
                inputFiltroGoogleano: $('#inputFiltroGoogleano'),
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
                botonDesplegarPanelFiltros: $("#boton_desplegar_panel_filtros"),
                tituloFiltroAreaActual: $('#titulo_filtro_area_actual'),
                divPanelFiltros: $("#panel_filtros"),
                btnAplicarFiltros: $('#btn_aplicar_filtros'),
                btnQuitarFiltros: $('#btn_cancelar_filtro'),
                panelBusquedaBasica: $('#panelBusquedaBasica'),
                panelBusquedaAvanzada: $('#panelBusquedaAvanzada'),
                btnToggleBusquedaAvanzada: $('#btnToggleBusquedaAvanzada'),
                areaDelUsuario: areaDelUsuario,
                listaAreas: listaAreas,
                tiposDeDocumento: tiposDeDocumento,
                categoriasDeDocumento: categoriasDeDocumento
            }
            var panel_filtros = new PanelDeFiltrosDeDocumentos(cfg_panel_filtros);

            panel_documentos.setPanelFiltros(panel_filtros);

//            panel_detalle.setPanelAlta(panel_alta);
//            panel_detalle.setPanelFiltros(panel_filtros);
//            panel_detalle.setPanelDocumentos(panel_documentos);

            panel_alta.setPanelFiltros(panel_filtros);
            panel_alta.setPanelDocumentos(panel_documentos);

            panel_filtros.setPanelAlta(panel_alta);
            panel_filtros.setPanelDocumentos(panel_documentos);

            var botonAlertas = new BotonAlertas({   
                boton_alertas : $("#boton_alertas"),
                panel_documentos: panel_documentos
            });
            

        });
    </script>   

   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </form>
</body>
</html>