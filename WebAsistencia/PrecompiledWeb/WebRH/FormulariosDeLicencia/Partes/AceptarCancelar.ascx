<%@ control language="C#" autoeventwireup="true" inherits="FormulariosDeLicencia_Partes_AceptarCancelar, App_Web_e5ojhnt4" %>
<table>
    <tr>
        <td>
            <asp:Button ID="BCancelar" runat="server" Text="Cancelar" 
                onclick="BCancelar_Click" CssClass="btn" />
        </td>
        <td>
            <asp:Button ID="BAceptar" runat="server" Text="Enviar e Imprimir" OnClick="BAceptar_Click" OnClientClick="javascript: window.print()" CssClass="btn" />
        </td>
    </tr>
</table>
