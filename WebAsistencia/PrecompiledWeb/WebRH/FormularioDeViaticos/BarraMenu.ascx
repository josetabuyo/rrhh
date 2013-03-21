<%@ control language="C#" autoeventwireup="true" inherits="FormularioDeViaticos_BarraMenu, App_Web_e4vz2srb" %>
<div class="navbar navbar-fixed-top">
    <div class="navbar-inner">
        <div class="container">
            <a class="brand" href="#">Sistema RRHH - Licencias</a>
            <%-- <title>Formulario de Viáticos - Solicitud</title>--%>
            <ul class="nav">
                <li class="divider-vertical"></li>
                <li>
                    <asp:LinkButton ID="VolverAInicio" runat="server" OnClick="VolverAInicioLinkButton_Click">Inicio</asp:LinkButton>
                </li>
               <%-- <li class="divider-vertical"></li>
                <li>
                    <asp:LinkButton ID="SolicitarViaticoLinkButton" runat="server" OnClick="SolicitarViaticoLinkButton_Click">Solicitar Vi&aacute;tico</asp:LinkButton>
                </li>
                <li class="divider-vertical"></li>
                <li>
                    <asp:LinkButton ID="DetalleDeViaticoLinkButton" runat="server" OnClick="DetalleDeViaticoLinkButton_Click">Detalle Vi&aacute;tico</asp:LinkButton>
                </li>--%>
                <li class="divider-vertical"></li>
            </ul>
            <ul class="nav pull-right">
                <li class="divider-vertical"></li>
                <li>
                    <asp:LinkButton ID="LabelUsuario" runat="server">Texto Varible(User Name)</asp:LinkButton>
                </li>
                <li class="divider-vertical"></li>
                <li>
                    <asp:LinkButton ID="CerrarSessionLinkButton" runat="server" OnClick="CerrarSessionLinkButton_Click">Cerrar Sesi&oacute;n</asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
</div>
