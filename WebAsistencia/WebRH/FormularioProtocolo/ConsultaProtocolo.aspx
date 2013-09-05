<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaProtocolo.aspx.cs" Inherits="FormularioProtocolo_ConsultaProtocolo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioProtocolo/GrillaProtocolo.ascx" TagName="GrillaProtocolo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Formulario Protocolo</title>
        <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
        <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
        <link id="link5" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" /> 
        <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
        <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
        <link rel="stylesheet" href="../Estilos/alertify.default.css"  /> 
        <link rel="stylesheet" href="../Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css" />
    </head>

    <body onload="MM_preloadImages('Imagenes/Botones/gestiontramites_s2.png','Imagenes/Botones/administrar_s2.png','Imagenes/Botones/solicitar_modificacion_s2.png','Imagenes/Botones/Botones Nuevos/ayuda_s2.png','Imagenes/Botones/Botones Nuevos/inicio_s2.png','Imagenes/Botones/cerrarsesion_s2.png','Imagenes/Botones/consprotocolo_s2.png')">

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
        <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/" />
            <div class= "contenedor_principal">
    		    <div class= "contenedor_separador"> 
        	        <div class= "imagen_separador"> 
                    <img src="../Imagenes/separador_protocolo.png" width="340" height="54" alt="separador_protocolo" />
		            </div>
                </div>

    <%--NO BORRAR--%>
    <%--    Se comenta el Filtro y la Búsqueda porque la misma se encuentra incompleto 
        y por el momento se decidió mostrar toda la tabla completa sin posibilidad de filtrado--%>


                <div class= "contenedor_buscador">
                </div>

                <div >
                    <fieldset>                  
                        <legend>Listado de Áreas del Ministerio de Desarrollo Social de Nación</legend>  
                        <div id="ContenedorPlanilla" runat="server">
                            <div class="input-append" style="clear:both;">                       
                                <input type="text" id="search" class="search" style="float:right; margin:5px;" placeholder="Buscar"/>    
                            </div>  
                        </div>
                    </fieldset>

                    <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
                    <asp:HiddenField ID="texto_mensaje_error" runat="server" />
                    <asp:HiddenField ID="areasJSON" runat="server" EnableViewState="true"/>
                    <asp:HiddenField ID="txtIdArea" runat="server" />
                    <asp:HiddenField ID="idArea" runat="server" />
                </div>
            </div>
            <div id="plantillas">
                <div id="plantilla_vista_area">
                    <div id="datos_area">
                    
                    </div>
                </div>
            </div>
        </form>
    </body>

    <script type="text/javascript" src="AdministradorDeAreas.js"></script>
    <script type="text/javascript" src="VistaDeArea.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/list.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>

    <script type="text/javascript">
    $(document).ready(function () {
        var admin = new AdministradorDeAreas();
        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
