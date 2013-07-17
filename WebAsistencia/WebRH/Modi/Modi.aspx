<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modi.aspx.cs"
    Inherits="AltaDeDocumento" EnableEventValidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SICOI</title>
    <link id="link3" rel="stylesheet" href="EstilosModi.css" type="text/css" runat="server" />
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
</head>
<body class="body-detalle">
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="MODI" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div id="contenedor_principal_modi">
           <div id="ui_buscador_de_legajos">
                <input id="input_numero" type="text" class="span2"/>
                <button id="boton_buscar" type="button" class="btn btn-primary">Buscar</button>
                <div id="aviso_legajo_no_encontrado" class="alert alert-danger">
                </div>
           </div>
           <div id="ui_vista_de_resultados_de_legajos" class="vista_de_legajo">
                <label id="lbl_nombre"></label>
                <label id="lbl_apellido"></label>
                <div id="panel_imagenes_no_asignadas" class="panel_de_imagenes"> </div>
                <div id="visualizador_de_imagenes" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="FILTER: chroma(color=#CCCCCC)" allowTransparency>
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 id="tituloImagen"></h3>
                    </div>
                    <div class="modal-body">
                        <img alt="" src="" id="imagen" />
                    </div>
                </div>
                <div id="panel_documentos"> </div>
           </div>
        </div>

        <div id="plantillas">
            <div id="plantilla_ui_documento" class="documento">
                <div id="panel_datos_documento">
                    <label class="titulo">Descripción:</label>
                    <label id="lbl_descripcion_en_RRHH"></label>               
                    <label class="titulo">Folio:</label>
                    <label id="lbl_folio"></label>      
                </div>        
                <div id="panel_imagenes" class="panel_de_imagenes">
                    
                </div>
            </div>
            <div id="plantilla_ui_imagen" class="imagen_miniatura">
                <img alt="" src="" id="img_thumbnail" />
                <%--<label id="lbl_nombre"></label>      --%>
            </div>
        </div>       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="BuscadorDeLegajos.js"></script>
    <script type="text/javascript" src="VistaDeResultadosDeLegajos.js"></script>
    <script type="text/javascript" src="ServicioDeLegajos.js"></script>
    <script type="text/javascript" src="VistaDeDocumentoModi.js"></script>
    <script type="text/javascript" src="VistaDeImagenModi.js"></script>
    <script type="text/javascript" src="ServicioDeDragAndDrop.js"></script>
    <script type="text/javascript" src="ServicioDeImagenes.js"></script>
    <script type="text/javascript" src="VisualizadorDeImagenes.js"></script>
    <script type="text/javascript" src="ProveedorAjax.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var servicio_de_imagenes = new ServicioDeImagenes(new ProveedorAjax());
            var vista_del_legajo = new VistaDeResultadosDeLegajos({
                ui: $('#ui_vista_de_resultados_de_legajos'),
                plantilla_vista_documento: $('#plantilla_ui_documento'),
                plantilla_vista_imagen: $('#plantilla_ui_imagen'),
                servicioDeImagenes: servicio_de_imagenes
            });

            var servicio_de_legajos = new ServicioDeLegajos(new ProveedorAjax());
            var buscador = new BuscadorDeLegajos({
                ui: $('#ui_buscador_de_legajos'),
                servicioDeLegajos: servicio_de_legajos,
                vistaDeResultados: vista_del_legajo
            });
        });
    </script>   
</html>