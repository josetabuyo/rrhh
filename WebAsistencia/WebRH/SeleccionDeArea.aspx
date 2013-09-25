<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleccionDeArea.aspx.cs"
    Inherits="SeleccionDeArea" %>
<%@ Register Src="ControlArea.ascx" TagName="ControlArea" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Documento sin título</title>
    <link id="link1" rel="stylesheet" href="Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <script type="text/javascript" src="Scripts/FuncionesDreamWeaver.js"></script>
    <link id="link4" rel="stylesheet" href="Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link2" rel="stylesheet" href="bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="Estilos/alertify.default.css"  />
    <script type="text/javascript" src="Scripts/alertify.js"></script>
    <script type="text/javascript" src="bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="Scripts/jquery.leanModal.min.js"></script>
</head>

<body onload="MM_preloadImages('Imagenes/Botones/gestiontramites_s2.png','Imagenes/Botones/administrar_s2.png','Imagenes/Botones/solicitar_modificacion_s2.png','Imagenes/Botones/Botones Nuevos/ayuda_s2.png','Imagenes/Botones/Botones Nuevos/inicio_s2.png','Imagenes/Botones/cerrarsesion_s2.png','Imagenes/Botones/consprotocolo_s2.png')">

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="Imagenes/" UrlPassword="" UrlEstilos="Estilos/" />
    <div class="botones">


        <div class="botones_main_sicoi">
            <asp:Button ID="btnNuevoDocumento" Text="Nuevo Documento" runat="server" 
                onclick="btnNuevoDocumento_Click" class=" btn btn-primary boton_main_documentos" 
                Visible="False"/> 
        </div>

         <div class="botones_main_sicoi">
            <asp:Button ID="btnNuevaPlanilla" Text="Nueva Planilla" runat="server" 
                onclick="btnNuevaPlanilla_Click" class=" btn btn-primary boton_main_documentos" 
                Visible="False"/> 
        </div>
        <br /><br />
        <legend style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">Áreas a Administrar </legend>
        <%--<img src="Imagenes/area.png" alt="area" width="315" height="54" class="areaadminis" />--%>
        <a href="FormularioProtocolo/ConsultaProtocolo.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image14','','Imagenes/Botones/consprotocolo_s2.png',1)">
            <img src="Imagenes/Botones/consprotocolo.png" width="161" height="20" class="lalala"
                id="Image14" /></a>
                <%--<a href="FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('gestionar','','Imagenes/Botones/gestiontramites_s2.png',1)">
                    <img src="Imagenes/Botones/gestiontramites.png" width="175" height="16" class="gestionar"
                        id="gestionar" /></a>--%>
       <%-- <div class="edificio">
            <img src="Imagenes/eva_contenta.jpg" alt="edificio" width="200" height="306" />
        </div>--%>

        <div style="clear: both;">
            <%--<uc1:ControlArea runat="server"></uc1:ControlArea>--%>
            <%--<asp:Table ID="TablaAreas" runat="server"></asp:Table>--%>
            <asp:Panel ID="Panel" runat="server"></asp:Panel>

        </div>
        <p>&nbsp;</p>
    </div>   
</form>


<script type="text/javascript">
    function EditarElArea(id) {
        PageMethods.EditarElArea(id, onSuccess, onFailure);
    }

    function IrAlArea(id) {
        PageMethods.IrAlArea(id, onSuccess, onFailure);
    }

    function onSuccess(result) {
        window.location = result;
    }

    function onFailure(error) {
        alert(error);
    }


    </script>

     

</body>

</html>
