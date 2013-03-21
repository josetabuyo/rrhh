<%@ page language="C#" masterpagefile="~/FormulariosDeLicencia/MPSolicitudLicencia.master" autoeventwireup="true" inherits="FormulariosDeLicencia_Default, App_Web_viy2pb45" title="Untitled Page" %>

<%@ Register Src="Partes/Saldo14H.ascx" TagName="Saldo14H" TagPrefix="uc7" %>

<%@ Register Src="Partes/NotificacionAgente.ascx" TagName="NotificacionAgente" TagPrefix="uc5" %>
<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc2" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc1" %>
<%@ Register Src="Partes/SaldoOrdinaria.ascx" TagName="SaldoOrdinaria" TagPrefix="uc6" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se justifique la inasistencia del día"></asp:Label>
                <br />
                <asp:TextBox ID="TBDesde" runat="server" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."
                    Width="100px"></asp:TextBox>
                <asp:Button ID="BCalendarioDesde" runat="server" Text="..." OnClick="BCalendarioDesde_Click" /><br />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="Black" Height="1px" Visible="False" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
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
            <td valign="bottom" style="width: 250px;">
                <br />
                <br />
                <br />
                <uc1:FirmaSolicitante ID="FirmaSolicitante1" runat="server"></uc1:FirmaSolicitante>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left;">
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="16px" Text="Autorización del Funcionario inmediato superior"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 303px; height: 127px;">
                &nbsp;<uc7:Saldo14H ID="Saldo14H1" runat="server" />
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label></td>
            <td valign="top" style="height: 127px">
                <table width="100%" style="text-align: left;">
                    <tr>
                        <td>
                            <asp:RadioButton ID="RBOtorgada" runat="server" Text="Otorgada" Font-Names="Tahoma"
                                Font-Size="16px" GroupName="GN" AutoPostBack="True" OnCheckedChanged="RBOtorgada_CheckedChanged" /><br />
                            <asp:RadioButton ID="RBDenegada" runat="server" Text="Denegada (corresponde sanción)"
                                Font-Names="Tahoma" Font-Size="16px" GroupName="GN" AutoPostBack="True" 
                                oncheckedchanged="RBDenegada_CheckedChanged" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <uc5:FirmaAutorizante ID="FirmaAutorizante1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc5:NotificacionAgente ID="NotificacionAgente1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:FirmaRecepcion ID="FirmaRecepcion1" runat="server"></uc3:FirmaRecepcion>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <uc4:AceptarCancelar ID="AceptarCancelar1" runat="server"></uc4:AceptarCancelar>
            </td>
        </tr>
    </table>
</asp:Content>
