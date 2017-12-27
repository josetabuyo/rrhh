<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluacionDesempenio.aspx.cs"
    Inherits="EvaluacionDesempenio_EvaluacionDesempenio" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Comprobacion de Códigos GDE</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div style="text-align: center; width: 100%;">
        <table style="text-align: center; width: 100%;top:50px;">
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <a id="btn_listado_agentes" requierefuncionalidad="52" class="acomodar_botones_del_menu btn btn-primary"
                        href="ListadoAgentes.aspx">Listado Agentes Evaluables</a>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <a id="btn_comprobacion_gde" requierefuncionalidad="58" class="acomodar_botones_del_menu btn btn-primary"
                        href="ComprobacionGDEListadoAgentes.aspx">Comprobacion GDE</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
