<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nomina - Sistema RRHH</title>
    <%= Referencias.Css("")%>
    <%= Referencias.Javascript("") %>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:BarraMenu ID="BarraMenu1" runat="server" UrlEstilos="Estilos/" UrlImagenes ="Imagenes/" />
    <table style="width: 100%; text-align: center">
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="3" align="center" style="height: 19px">
                <br />
                <br />
                <br />
                &nbsp;<asp:Label ID="LArea" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="18px"
                    ForeColor="#5A6573"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ImageButton3" class="btn" runat="server" Text="Imprimir Plantilla de Firmas"
                    OnClick="ImageButton3_Click" EnableViewState="False" Style="text-align: center" />
                <asp:Button ID="ImageButton5" class="btn" runat="server" Text="Enviar e Imprimir Parte"
                    OnClick="ImageButton5_Click" EnableViewState="False" Style="text-align: center" />
                       <asp:Button ID="btn_GestionViaticos" class="btn" runat="server" Text="Gestionar Viáticos" RequiereFuncionalidad = "11"
                    OnClick="btn_GestionViaticos_Click" EnableViewState="False" Style="text-align: center" />
                <br />
                <br />
            </td>
        </tr>
        <br />
        <tr style="font-size: 12pt; font-family: Times New Roman">
            <td colspan="3" align="center">
                <strong>
                    <asp:Table ID="TAgentes" runat="server">
                    </asp:Table>
                </strong>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
