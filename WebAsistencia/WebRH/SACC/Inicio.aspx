<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="SACC_Inicio" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu"
    TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Sistema de Apoyo de Creación de Capacidades</title>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css" />
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>
</head>

<body>

    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"> </asp:ScriptManager>--%>
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    </form>
    
    <div style="background-color: #122b48; margin-top: -17px; text-align: center;">
        <img alt="fondo" src="../Imagenes/pantalla.jpg" style="width: 1024px; height: 100%;" />
    </div>

</body>

<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>

</html>
