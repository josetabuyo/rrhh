<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modi.aspx.cs"
    Inherits="AltaDeDocumento" EnableEventValidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MODI</title>
    <link rel="stylesheet" href="EstilosModi.css" type="text/css"/>
    <%= Referencias.Css("../")%>
</head>
<body class="body-detalle">
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" 
            Feature="<div style='margin-top: 6px;'> <span style='font-size:20px; font-weight: bold;'>MODI</span> <br/> <span style='font-size:12px;'> Módulo de Digitalización </span> </div>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div id="contenedor_principal_modi">
           <div id="ui_vista_de_resultados_de_legajos" class="vista_de_legajo">
                <label id="lbl_resumen_datos_personales"></label>
                <input id="btn_nueva_busqueda" type="button" value = "Buscar" class="btn btn-primary"/>
                <div id="lbl_titulo_imagenes_no_asignadas"> Imágenes no asiginadas a ningún documento </div>
                <div id="panel_imagenes_no_asignadas"></div>
                <div id="lbl_titulo_panel_documentos"> Documentos </div>
                <div id="lbl_titulo_imagenes_documentos"> Folios </div>
                <div id="panel_documentos"> </div>
           </div>
        </div>

        <div id="plantillas">
            <div id="ui_buscador_de_legajos">
                <input id="input_numero" type="text" class="span2"/>
                <div id="aviso_legajo_no_encontrado" class="alert alert-danger">
                </div>
                <div id="progress_bar">
                </div>
            </div>

            <div id="plantilla_ui_documento" class="documento">
                <div id="panel_datos_documento">
                    <div id="cmb_categoria" class="styled-select">
                        <select>
                            <option id="-1"> Seleccione una categoría</option>
                        </select>
                    </div>
                    <div class="panel_datos_sin_categoria">
                        <label class="titulo">Descripción:</label>
                        <label id="lbl_descripcion_en_RRHH"></label>               
                    </div>  
                </div>        
                <div id="panel_folios">
                    
                </div>
            </div>

            <div id="plantilla_ui_folio" class="folio">
                <div class="contenedor_lbl_folio">
                    <div id="overlay_lbl_folio">
                    </div>
                    <div id="lbl_folio">
                        Folio 1
                    </div>
                </div>
            </div>

            <div id="plantilla_ui_imagen" class="imagen_miniatura">
                <img alt="" src="Imagenes/static.gif" id="img_estatica" />
                <img alt="" src="" id="img_thumbnail" />
            </div>
            
            <div id="plantilla_alerta" class="alerta">
                <div id="lbl_mensaje"></div>
            </div>

            <div id="plantilla_ui_visualizador_imagen" class="visualizador_imagen"> 
                <div id="contenedor_imagen">     
                    <div id="panel_folio">
                        <label> Folio:</label>
                        <input id="txt_folio" type="text" />
                    </div>                  
                    <img alt="" src="" id="imagen" />
                </div>
            </div>

            <div id="plantilla_ui_panel_imagenes" class="panel_de_imagenes">
                <li id="aviso_no_hay_imagenes">
                    
                </li>
            </div>

            <div id="plantilla_ui_selector_legajos" class="selector_legajos">
                <div id="panel_legajos">
                    
                </div>
            </div>

            <div id="plantilla_ui_vista_legajo_fila" class="vista_legajo_fila">
                <label id="lbl_nombre"></label>
                <label id="lbl_apellido"></label>
                <label id="lbl_cuil"></label>
                <label id="lbl_id_interna"></label>
            </div>
        </div>       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="Alerta.js"></script>
    <script type="text/javascript" src="BuscadorDeLegajos.js"></script>
    <script type="text/javascript" src="VistaDeLegajoModi.js"></script>
    <script type="text/javascript" src="VistaDeDocumentoModi.js"></script>
    <script type="text/javascript" src="VistaDeFolioModi.js"></script>
    <script type="text/javascript" src="VistaDeImagen.js"></script>
    <script type="text/javascript" src="ServicioDeDragAndDrop.js"></script>
    <script type="text/javascript" src="ServicioDeDigitalizacionDeLegajos.js"></script>
    <script type="text/javascript" src="ServicioDeCategoriasDeDocumentos.js"></script>
    <script type="text/javascript" src="VisualizadorDeImagenes.js"></script>
    <script type="text/javascript" src="PanelDeImagenes.js"></script>
    <script type="text/javascript" src="SelectorDeLegajos.js"></script>
    <script type="text/javascript" src="VistaLegajoFila.js"></script>
    <script type="text/javascript" src="ProveedorAjax.js"></script>



    <script type="text/javascript">
        $(document).ready(function () {
            var proveedor_ajax = new ProveedorAjax();
            var servicio_de_legajos = new ServicioDeDigitalizacionDeLegajos(proveedor_ajax);
            var servicio_de_categorias = new ServicioDeCategoriasDeDocumentos(proveedor_ajax);

            var vista_del_legajo = new VistaDeLegajoModi({
                ui: $('#ui_vista_de_resultados_de_legajos'),
                plantilla_vista_documento: $('#plantilla_ui_documento'),
                servicioDeCategorias: servicio_de_categorias,
                servicioDeLegajos: servicio_de_legajos
            });

            var buscador = new BuscadorDeLegajos({
                ui: $('#ui_buscador_de_legajos'),
                servicioDeLegajos: servicio_de_legajos,
                onLegajoEncontrado: function (legajo) {
                    vista_del_legajo.mostrarLegajo(legajo);
                }
            });
            vista_del_legajo.buscadorDeLegajos = buscador;
            buscador.mostrarModal();
        });
    </script>   
</html>