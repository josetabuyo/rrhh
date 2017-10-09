<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SaldoOrdinaria.ascx.cs"
    Inherits="FormulariosDeLicencia_Partes_SaldoOrdinaria" %>
<table width="100%" style="text-align: left;">
    <tr>
        <td>
            <fieldset>
                <div style="display: inline-block;">
                    <asp:Label ID="LDisponibles" runat="server" Font-Names="Tahoma" Font-Size="16px"
                        Text="Disponibles" Font-Bold="True"></asp:Label><br />
                    <asp:Table ID="TDiasDisponibles" runat="server">
                    </asp:Table>
                    <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="16px" Text="Solicitadas"
                        Font-Bold="True"></asp:Label><br />
                    &nbsp; &nbsp;
                    <asp:Label ID="LSolicitadas" runat="server" Font-Names="Tahoma" Font-Size="Small"
                        Text="0 días"></asp:Label>
                </div>
                <div style="display: inline-block; position: absolute; margin-left: 5px; border-left: 1px solid #000;">
                    <div style="margin-left: 5px;">
                        <asp:Label ID="Label_Segmentos" runat="server" Font-Names="Tahoma" Font-Size="16px"
                            Text="Segmentos" Font-Bold="True"></asp:Label><br />
                        <asp:Label ID="Label_Segmentos_Disponibles" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Disponibles" Font-Bold="True"></asp:Label><br />
                        &nbsp; &nbsp;
                        <asp:Label ID="LSDisponibles" runat="server" Font-Names="Tahoma" Font-Size="Small" CssClass="segmento1" Text="0 días"></asp:Label>
                        <br />
                        <asp:Label ID="Label_Segmentos_Utilizados" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Utilizados" Font-Bold="True"></asp:Label><br />
                        &nbsp; &nbsp;
                        <asp:Label ID="LSDUtilizados" runat="server" Font-Names="Tahoma" Font-Size="Small" Text="0 días"></asp:Label>
                    </div>
                </div>
            </fieldset>
        </td>
    </tr>
</table>
