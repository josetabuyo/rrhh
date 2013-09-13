<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaProtocolo.aspx.cs" Inherits="FormularioProtocolo_ConsultaProtocolo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Áreas</title>
        <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
        <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
        <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" /> 
        <link id="link3" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
        <link id="link4" rel="stylesheet" href="ConsultaProtocolo.css" type="text/css" runat="server" />
        <link id="link5" rel="stylesheet" href="VistaDeArea.css" type="text/css" runat="server" />
        <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
            <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/" />
            <div id="ContenedorPrincipal" class="contenedor_principal contenedor_principal_consulta_protocolo">            
                <legend>
                    Listado de Áreas del Ministerio de Desarrollo Social de Nación                     
                    <input type="text" id="search" class="search" placeholder="Buscar"/>     
                </legend>  
                <div id="ContenedorPlanilla" runat="server">
 
                </div>
                <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
                <asp:HiddenField ID="texto_mensaje_error" runat="server" />
                <asp:HiddenField ID="areasJSON" runat="server" EnableViewState="true"/>
                <asp:HiddenField ID="txtIdArea" runat="server" />
                <asp:HiddenField ID="idArea" runat="server" />
            </div>
            <div id="plantillas">
                <div id="plantilla_vista_area" class="vista_area">
                    <div class="contenido">
                        <div><div class="titulo">Responsable:</div> <div id="responsable" class="valor"></div></div>
                        <div><div class="titulo">Dirección:</div> <div id="direccion" class="valor"></div></div>
                        <div><div class="titulo">Teléfono:</div> <div id="telefono" class="valor"></div></div>
                        <div><div class="titulo">Fax:</div> <div id="fax" class="valor"></div></div>
                        <div><div class="titulo">Mail:</div> <div id="mail" class="valor"></div></div>
                        <div id="asistentes"></div>
                    </div>
                </div>
                <div id="plantilla_vista_asistente" class="vista_asistente">
                    <div><div id="cargo" class="titulo"></div> <div id="resumen" class="valor"></div></div>                 
                </div>
            </div>
        </form>
    </body>

    <script type="text/javascript" src="AdministradorDeAreas.js"></script>
    <script type="text/javascript" src="Area.js"></script>
    <script type="text/javascript" src="VistaDeArea.js"></script>
    <script type="text/javascript" src="VistaDeAsistente.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/list.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var admin = new AdministradorDeAreas();
        });
    </script>
</html>
