<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteXPersona.aspx.cs" Inherits="CtrlAcc_ReporteXPersona" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte Control de Acceso</title>
    <script type="text/javascript" src="../Scripts/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0px !important;">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
        <div>
            Nombre:
            <input type="text" id="txtNombre" />
            <br />
            Apellido:
            <input type="text" id="txtApellido" />
            <br />
            <input type="button" id="btnPrueba" value="Test" />
            <div id="result"></div>
        </div>
    </form>
</body>
<script type="text/javascript" src="ReporteXPersona.js"></script>
</html>
