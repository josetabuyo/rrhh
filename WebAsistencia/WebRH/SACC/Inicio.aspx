<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="SACC_Inicio" %>
<%--<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>--%>
<%@ Register Src="~/BarraMenu/BarraMenuInicioSACC.ascx" TagName="BarraMenuInicioSACC" TagPrefix="uc4" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Apoyo de Creación de Capacidades</title>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" /> 
    
       
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>

    <link id="link4" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link2" rel="stylesheet" href="EstilosSACC.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />

    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
        <uc4:BarraMenuInicioSACC ID="BarraMenu" UrlPassword="../" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <%--<uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />--%>
        <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
       <%-- <a id="go" rel="leanModal" name="signup" href="#signup">With Close Button</a>--%>
    </form>

    <%--<div style="width:35%; height:63px; display:inline; position:absolute; top:0px; left:26%;  background-color:#0e1824;"></div>--%>
    <div style="background-color:#122b48; margin-top:-17px; text-align:center;" ><img alt="fondo" src="../Imagenes/pantalla.jpg" style="width:1024px; height:100%;"  /></div>

        
</body>

</html>
