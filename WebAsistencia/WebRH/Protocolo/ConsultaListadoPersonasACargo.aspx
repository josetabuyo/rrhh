<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaListadoPersonasACargo.aspx.cs" Inherits="FormularioProtocolo_ConsultaListadoPersonasACargo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Áreas</title>
        <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
        <%= Referencias.Css("../")%>
        <link id="link1" rel="stylesheet" href="ConsultaProtocolo.css" type="text/css" runat="server" />
        <link id="link5" rel="stylesheet" href="VistaDeArea.css" type="text/css" runat="server" />
        <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
            <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/" />
            <div id="ContenedorPrincipal" class="contenedor_principal contenedor_principal_consulta_protocolo">            
                <legend>
                    Listado de Personas de mis Áreas a cargo                     
                    <input type="text" id="search" class="search" placeholder="Buscar"/>     
                </legend> 
                <div id="botonera_paneles_desplegables"> 
                    <div id="boton_desplegar_panel_alta_documento" class="boton_que_abre_panel_desplegable"
                        title="Ver licencias">
                        Visor de Licencias
                    </div>
                </div>
                <div id="panel_alta_documento" class="panel_desplegable">
                 <h1>lalalal</h1>
                </div>

                <div id="ContenedorPlanilla" runat="server">
 
                </div>
                <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
                <asp:HiddenField ID="texto_mensaje_error" runat="server" />
                <asp:HiddenField ID="personasJSON" runat="server" EnableViewState="true"/>
                <asp:HiddenField ID="txtIdArea" runat="server" />
                <asp:HiddenField ID="idArea" runat="server" />
                <asp:HiddenField ID="DNIPersona" runat="server" />
                <asp:HiddenField ID="areaPersona" runat="server" />
                <asp:Button ID="btnAsistencia" runat="server" OnClick="btnAsistencia_Click" style="display:none;" />
                <asp:Button ID="btnEliminarAsistencia" runat="server" OnClick="btnEliminarAsistencia_Click" style="display:none;" />
                <asp:Button ID="btnPasePersona" runat="server" OnClick="btnPasePersona_Click" style="display:none;" />
                <asp:Button ID="btnEliminarPasePersona" runat="server" OnClick="btnEliminarPasePersona_Click" style="display:none;" />
            </div>
           
        </form>
    </body>

    <script type="text/javascript" src="AdministradorDePersonas.js"></script>
    <script type="text/javascript" src="Persona.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>

    <%= Referencias.Javascript("../")%>

    <script type="text/javascript">
        $(document).ready(function () {
            var admin = new AdministradorDePersonas();

            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
        });
    </script>
</html>
