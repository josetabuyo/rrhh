<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Saldo14F.ascx.cs"
    Inherits="FormulariosDeLicencia_Partes_Saldo14F" %>
<table width="100%" style="text-align:left;">
    <tr>
        <td>
            <fieldset>
                <asp:Label ID="LDisponibles" runat="server" Font-Names="Tahoma" Font-Size="16px"
                    Text="Disponibles en el Mes" Font-Bold="True"></asp:Label><br />
                <asp:Table ID="TDiasDisponibles" runat="server">
                </asp:Table>
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="16px" Text="Solicitadas" Font-Bold="True"></asp:Label><br />
                &nbsp; &nbsp;
                <asp:Label ID="LSolicitadas" runat="server" Font-Names="Tahoma" Font-Size="Small"
                    Text="0 días"></asp:Label></fieldset>
        </td>
    </tr>
</table>
