<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMComites.aspx.cs" Inherits="EvaluacionDesempenio_ABMComites" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reuniones de Comite</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div>
        <table>
            <tr style="height:50px;">
                <td>
                    Proceso Evaluatorio
                </td>
                <td>
                    <select>
                        <option value="1">2016 - Planta Permamente</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha:
                </td>
                <td>
                    <input type="text" id="txt_fecha" style="width: 110px;" 
                        class="hasDatepicker" >
                </td>
            </tr>
            <tr>
                <td>
                    Hora
                </td>
                <td>
                    <input type="text"></input>
                </td>
            </tr>
            <tr>
                <td>
                    Lugar
                </td>
                <td>
                    <input type="text"></input>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
