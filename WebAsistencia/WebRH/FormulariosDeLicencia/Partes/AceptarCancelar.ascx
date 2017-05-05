<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AceptarCancelar.ascx.cs"
    Inherits="FormulariosDeLicencia_Partes_AceptarCancelar" %>
<table>
    <tr>
        <td>
            <asp:Button ID="BCancelar" runat="server" Text="Cancelar" 
                onclick="BCancelar_Click" CssClass="btn" />
        </td>
        <td>
            <asp:Button ID="BAceptar" runat="server" Text="Enviar e Imprimir" OnClick="BAceptar_Click" OnClientClick="javascript: ImprimirPantalla()" CssClass="btn" />
        </td>
    </tr>
</table>
