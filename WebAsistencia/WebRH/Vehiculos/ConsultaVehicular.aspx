<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaVehicular.aspx.cs" Inherits="Vehiculos_ConsultaVehicular" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> Consulta Vehicular</title>
    <link rel="stylesheet" href="css/ConsultaVehicular.css" type="text/css"/>
    <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body class="body-detalle">
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" 
            Feature="<div style='margin-top: 6px;'> <span style='font-size:20px; font-weight: bold;'>Consulta Vehicular</span> <br/> <span style='font-size:12px;'> Consulta Vehicular </span> </div>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
            <div id="contenedor_controles">
                <input type=text id=txt_codigo_verificacion />
                <input type=button id=btn_verificar value="Verificar"/>
            </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

    </form>
</body>
    <%= Referencias.Javascript("../") %>    

    <script type="text/javascript">
        $(document).ready(function () {
            Backend.start(function() {
                $("#btn_verificar").click(function(){
                    window.location = "DetalleVehiculo.aspx?" + $("#txt_codigo_verificacion").val();
                });
            });
        });
    </script>   
</html>