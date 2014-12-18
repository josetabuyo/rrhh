<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Saldo14F.ascx.cs"
    Inherits="FormulariosDeLicencia_Partes_Saldo14F" %>
<table width="100%" style="text-align:left;">
    <tr>
        <td>
            <fieldset>
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="12px"
                    Text="Disponibles para este mes:" Font-Bold="True"></asp:Label>
                &nbsp; &nbsp;
                <asp:Label ID="LDiasMes" runat="server" Font-Names="Tahoma" Font-Size="Small" Text="0 días"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Disponibles para este año:" Font-Bold="True"></asp:Label>
                &nbsp; &nbsp;
                <asp:Label ID="LDiasAnual" runat="server" Font-Names="Tahoma" Font-Size="Small"
                    Text="0 días"></asp:Label></fieldset>
        </td>
    </tr>
</table>
