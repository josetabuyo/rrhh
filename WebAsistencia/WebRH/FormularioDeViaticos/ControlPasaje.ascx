<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPasaje.ascx.cs"
    Inherits="ControlPasaje" %>
<%@ Register Src="ControlProvinciaLocalidad.ascx" TagName="ControlProvinciaLocalidad"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<style type="text/css">
    .style1
    {
        width: 64px;
    }
</style>
<%--<uc1:ControlProvinciaLocalidad ID="CPLOrigen" runat="server" /> --%>
<%--<uc1:ControlProvinciaLocalidad ID="CPLDestino" runat="server" />     --%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td align="center" class="style1">
                </td>
                <td>
                    <asp:Label ID="Label7" CssClass="control-label" Text="Fecha De Viaje" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="TBFechaViaje" runat="server" CssClass="input-small" 
                        MaxLength="10" />
                    <cc1:CalendarExtender ID="TBFECHAVIAJE_CalendarExtender" Format="dd/MM/yyyy" runat="server"
                        TargetControlID="TBFECHAVIAJE" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBFechaViaje"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TBFechaViaje" ErrorMessage="Fecha incorrecta" 
                        ValidationExpression="^\d\d\/\d\d\/\d\d\d\d$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                    <asp:Label ID="Label2" CssClass="control-label" Text="Origen" runat="server" />
                </td>
                <td>
                    <span style="padding-right: 5px;">
                        <asp:Label ID="Label1" runat="server" Text="Provincia"></asp:Label></span>
                </td>
                <td>
                    <asp:DropDownList ID="DDLProvinciasDesde" runat="server" Width="120px" OnSelectedIndexChanged="DDLProvinciasDesde_SelectedIndexChanged"
                        AutoPostBack="True" OnLoad="DDLProvinciasDesde_Load">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvDDLProvinciasDesde" runat="server" ControlToValidate="DDLProvinciasDesde"
                            ErrorMessage="*"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                </td>
                <td>
                    <span style="padding-right: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label></span>
                </td>
                <td>
                    <asp:DropDownList ID="DDLLocalidadesDesde" runat="server" Width="120px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvDDLLocalidadesDesde" runat="server" ControlToValidate="DDLLocalidadesDesde"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1" align="center">
                    <asp:Label ID="Label3" CssClass="control-label" Text="Destino" runat="server" />
                </td>
                <td>
                    <span style="padding-right: 5px;">
                        <asp:Label ID="Label6" runat="server" Text="Provincia"></asp:Label></span>
                </td>
                <td>
                    <asp:DropDownList ID="DDLProvinciasHasta" runat="server" Width="120px" OnSelectedIndexChanged="DDLProvinciasHasta_SelectedIndexChanged"
                        AutoPostBack="True" OnLoad="DDLProvinciasHasta_Load">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvDDLProvinciasHasta" runat="server" ControlToValidate="DDLProvinciasHasta"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                </td>
                <td class="controls">
                    <span style="padding-right: 10px;">
                        <asp:Label ID="Label10" runat="server" Text="Localidad"></asp:Label></span>
                </td>
                <td class="controls">
                    <asp:DropDownList ID="DDLLocalidadesHasta" runat="server" Width="120px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvDDLLocalidadHasta" runat="server" ControlToValidate="DDLLocalidadesHasta"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    <%--            </ContentTemplate>
             </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                </td>
                <td class="control-group">
                    <asp:Label ID="Label5" CssClass="control-label" Text="Transporte" runat="server" />
                </td>
                <td class="controls">
                    <asp:DropDownList ID="DDLMediosDeTransporte" CssClass="input-medium" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                </td>
                <td class="control-group">
                    <asp:Label ID="Label8" CssClass="control-label" Text="Medios de Pago" runat="server" />
                </td>
                <td class="controls">
                    <asp:DropDownList ID="DDLMediosDePago" CssClass="input-medium" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style1">
                </td>
                <td class="control-group">
                    <asp:Label ID="Label9" CssClass="control-label" Text="Precio" runat="server" />
                </td>
                <td class="controls">
                    <asp:TextBox ID="TBPrecio" runat="server" Width="86px" Height="22px" 
                        MaxLength="8"></asp:TextBox>
                    <cc2:FilteredTextBoxExtender ID="TBPrecio_FilteredTextBoxExtender" ValidChars="1234567890."
                        runat="server" TargetControlID="TBPrecio">
                    </cc2:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TBPrecio"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TBPrecio" ErrorMessage="Importe incorrecto" 
                        ValidationExpression="^\d+\.?\d*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
