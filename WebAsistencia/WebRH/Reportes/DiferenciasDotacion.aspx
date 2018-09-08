<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiferenciasDotacion.aspx.cs" Inherits="Reportes_DiferenciasDotacion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Diferencias Dotacion</title>
    <%= Referencias.Css("../")%>            
    <%= Referencias.Javascript("../")%>
        
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Reportes</span> <br/> <span style='font-size:12px;'> Reportes </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
    
    <div>
    
    </div>
    </form>
</body>
</html>
