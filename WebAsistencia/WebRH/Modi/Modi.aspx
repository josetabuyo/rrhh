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
           <div id="ui_vista_de_resultados_de_legajos">
                <label id="lbl_nombre"></label>
                <label id="lbl_apellido"></label>
                <div id="panel_documentos"> </div>
           </div>
        </div>

        <div id="plantillas">
            <div id="plantilla_ui_documento" class="documento">
                <label class="titulo">Descripción:</label>
                <label id="lbl_descripcion_en_RRHH"></label>
                <label class="titulo">Jurisdicción:</label>
                <label id="lbl_jurisdiccion"></label>
                <label class="titulo">Organismo:</label>
                <label id="lbl_organismo"></label>
                <label class="titulo">Folio:</label>
                <label id="lbl_folio"></label>
                <label class="titulo">Fecha Desde:</label>
                <label id="lbl_fechaDesde"></label>
                <label class="titulo">Tabla:</label>
                <label id="lbl_tabla"></label>
                <label class="titulo">Id:</label>
                <label id="lbl_id"></label>
            </div>
        </div>       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="BuscadorDeLegajos.js"></script>
    <script type="text/javascript" src="VistaDeResultadosDeLegajos.js"></script>
    <script type="text/javascript" src="ServicioDeLegajos.js"></script>
    <script type="text/javascript" src="VistaDocumentoModi.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var vista_del_legajo = new VistaDeResultadosDeLegajos({
                ui: $('#ui_vista_de_resultados_de_legajos'),
                plantilla_vista_documento: $('#plantilla_ui_documento')
            });
            var buscador = new BuscadorDeLegajos({
                ui: $('#ui_buscador_de_legajos'),
                servicioDeLegajos: ServicioDeLegajos,
                vistaDeResultados: vista_del_legajo
            });
        });
    </script>   
</html>