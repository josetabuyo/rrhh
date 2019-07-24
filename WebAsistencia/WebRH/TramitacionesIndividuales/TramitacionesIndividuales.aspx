<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TramitacionesIndividuales.aspx.cs" Inherits="TramitacionesIndividuales_TramitacionesIndividuales" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Tramitaciones Individuales</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>    
    
</head>
<body>
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.A.U.</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div>
            <div id="buscador_personas">
            </div>
        </div>
    </form>
</body>
</html>

<script src="TramitacionesIndividuales.js" type="text/javascript"></script>
