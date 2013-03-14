<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlDetalleDeViaticos.ascx.cs" Inherits="FormularioDetalleDeViaticos_ControlDetalleDeViaticos" EnableViewState="False" %>
<asp:Table ID="TablaPersonas" runat="server"></asp:Table>
<br />
<asp:Table ID="TablaEstadias" runat="server"></asp:Table>
<asp:Table ID="TablaPasajes" runat="server"></asp:Table>
<asp:Button ID="BotonModificar" Text="Modificar" runat="server" CssClass="btn btn-primary" 
    onclick="Modificar_Click" />
<div class="container" align="left">
<br />
    <asp:Label ID="lbValidacion72horas" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="" EnableTheming="False" Font-Size="13px"></asp:Label>
</div>