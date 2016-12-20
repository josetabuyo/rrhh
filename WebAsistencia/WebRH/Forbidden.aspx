<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forbidden.aspx.cs"
    Inherits="SeleccionDeArea" %>
<%@ Register Src="ControlArea.ascx" TagName="ControlArea" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>No tiene permisos para ésta URL</title>
    <link rel="stylesheet" href="Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="Estilos/alertify.default.css" />
    <%= Referencias.Css("")%>
</head>

<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="Imagenes/" UrlEstilos="Estilos/" />
</form>
</body>

<script type="text/javascript" src="Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
<script type="text/javascript" src="Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js"></script>
<script type="text/javascript" src="Scripts/alertify.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        alertify.alert("", "No tiene permisos para entrar a esta página");
    });
</script>
</html>
