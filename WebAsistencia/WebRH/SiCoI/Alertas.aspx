<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alertas.aspx.cs"
    Inherits="AltaDeDocumento" EnableEventValidation="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SICOI</title>
    <link rel="stylesheet" href="../Estilos/EstilosSICOI.css" type="text/css"/>
    <%= Referencias.Css("../")%>
    <style type="text/css">
        #uiPanelDecontrol
        {
            text-align: center;
        }
    </style>
</head>
<body class="body-detalle">
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.Co.I</span> <br/> <span style='font-size:12px;'> Módulo de Comunicación  <br/> Interna</span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div id="uiPanelDecontrol">
            <div id="lblEstado" class="label label-important"></div>
            <input type="button" id="btnIniciarServicioDeAlertas" class="alertas_boton_start" value="Iniciar" />
            <input type="button" id="btnDetenerServicioDeAlertas" class="alertas_boton_stop" value="Detener" />
        </div>   
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="PanelDeControlDeAlertas.js"> </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var panel = new PanelDeControlDeAlertas({ ui: $("#uiPanelDecontrol")});
        });
    </script>   
</html>