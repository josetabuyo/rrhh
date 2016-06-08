<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AprobacionDeSolicitudes.aspx.cs" Inherits="Protocolo_AprobacionDeSolicitudes" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <title>Solicitudes de Modificación de Area</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
        <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/" UrlPassword="../" />
        <div>
    
        </div>
    </form>
</body>


<%= Referencias.Javascript("../") %>

<script type="text/javascript">
    $(document).ready(function () {
        Backend.start(function () {
            
        });
    });

</script>

</html>
