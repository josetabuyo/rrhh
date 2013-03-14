<%@ Page Language="C#" MasterPageFile="~/FormulariosDeLicencia/MPSolicitudLicencia.master" AutoEventWireup="true" CodeFile="F14A_Nacimientos.aspx.cs" Inherits="FormulariosDeLicencia_Default" Title="Untitled Page" %>
<%@ Register Src="Partes/DesdeHasta.ascx" TagName="DesdeHasta" TagPrefix="uc7" %>
<%@ Register Src="Partes/NotificacionAgente.ascx" TagName="NotificacionAgente" TagPrefix="uc5" %>
<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc2" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc1" %>
<%@ Register Src="Partes/SaldoOrdinaria.ascx" TagName="SaldoOrdinaria" TagPrefix="uc6" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" Runat="Server">
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se me otorgue licencia por nacimiento de hijo:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
       
        <tr>
            <td valign="top">
                &nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Fecha del Nacimiento"></asp:Label><asp:TextBox
                    ID="TBDesde" runat="server" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."
                    Width="100px"></asp:TextBox><asp:Button ID="BCalendarioDesde" runat="server" OnClick="BCalendarioDesde_Click"
                        Text="..." /><br />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="Black" Height="1px" OnSelectionChanged="Calendar1_SelectionChanged"
                    Visible="False" Width="200px">
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="Gray" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                </asp:Calendar>
                </td>
            <td style="width: 261px" valign="bottom">
                <br />
                <br />
                <br />
                <uc1:firmasolicitante id="FirmaSolicitante1" runat="server"></uc1:firmasolicitante>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"
                    Text="Autorización del Funcionario inmediato superior"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 303px; height: 127px">
                <uc7:desdehasta id="DesdeHasta1" runat="server"></uc7:desdehasta>
            </td>
            <td style="width: 261px; height: 127px" valign="top">
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label><br />
                <br />
                <br />
                <br />
                <uc5:firmaautorizante id="FirmaAutorizante1" runat="server"></uc5:firmaautorizante>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc5:notificacionagente id="NotificacionAgente1" runat="server"></uc5:notificacionagente>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:firmarecepcion id="FirmaRecepcion1" runat="server"></uc3:firmarecepcion>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <uc4:aceptarcancelar id="AceptarCancelar1" runat="server"></uc4:aceptarcancelar>
            </td>
        </tr>
    </table>
</asp:Content>

