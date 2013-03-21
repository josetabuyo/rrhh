<%@ control language="C#" autoeventwireup="true" inherits="FormulariosDeLicencia_Partes_DatosDelAgente, App_Web_e5ojhnt4" %>
<%--<table style="width:100%;text-align:left;">
    <tr>
        <td style="height: 22px; text-align:left;">
            <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Agente:" EnableTheming="False" Font-Size="16px"></asp:Label>
            <asp:Label ID="LAgente" runat="server" Text="Label" Font-Names="Tahoma" EnableTheming="False" Font-Size="16px"></asp:Label>
        </td>
        <td style="height: 22px;text-align:left;">
            <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Documento:" EnableTheming="False" Font-Size="16px"></asp:Label>
            <asp:Label ID="LDocumento" runat="server" Text="Label" Font-Names="Tahoma" EnableTheming="False" Font-Size="16px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:left;">
            <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Underline="True"
                Text="Dependencia:" EnableTheming="False" Font-Size="16px"></asp:Label>
            <asp:Label ID="LArea" runat="server" Text="Label" Font-Names="Tahoma" EnableTheming="False" Font-Size="16px"></asp:Label></td>
    </tr>
</table>
LO QUE ESTA ARRIBA ES LO QUE HABIA ANTES, LO DE ABAJO ES NUEVO
--%>
        
       
<%-- <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Agente:" EnableTheming="False" Font-Size="16px"></asp:Label>--%>
<asp:Label ID="LAgente" CssClass="agente" runat="server" Text="Label" EnableTheming="False" ></asp:Label> 
<br />      
<%-- <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Documento:" EnableTheming="False" Font-Size="16px"></asp:Label>--%>
<asp:Label ID="LDocumento" CssClass="documento" runat="server" Text="Label" EnableTheming="False" ></asp:Label> 
<br />            
<%-- <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Dependencia:" EnableTheming="False" Font-Size="16px"></asp:Label>--%>
<asp:Label ID="LArea" CssClass="area" runat="server" Text="Label" EnableTheming="False" ></asp:Label>      
<br />  
<br />    
<%--<asp:Label ID="Label4" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Categoria:" EnableTheming="False" Font-Size="16px"></asp:Label>--%>
<asp:Label ID="LCategoria" CssClass="categoria" runat="server" Text="Label" EnableTheming="False" ></asp:Label>
            

