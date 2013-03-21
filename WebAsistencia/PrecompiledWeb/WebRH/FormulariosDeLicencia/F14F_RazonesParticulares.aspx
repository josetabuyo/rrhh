<%@ page language="C#" masterpagefile="~/FormulariosDeLicencia/MPSolicitudLicencia.master" autoeventwireup="true" inherits="FormulariosDeLicencia_Default, App_Web_5jbnjflg" title="Untitled Page" %>

<%@ Register Src="Partes/NotificacionAgente.ascx" TagName="NotificacionAgente" TagPrefix="uc5" %>

<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc2" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" runat="Server">
    <table width="100%">
        <tr>
            <td  valign="top">
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se justifique la inasistencia del día"></asp:Label>
                <br />
                <asp:TextBox ID="TBDesde" runat="server"  Enabled="False" ToolTip="Presione el boton para seleccionar la fecha." Width="100px"></asp:TextBox>
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
            <td valign="bottom">
                <br />
                <br />
                <br />
                <uc1:FirmaSolicitante ID="FirmaSolicitante1" runat="server"></uc1:FirmaSolicitante>
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Autorización del Funcionario inmediato superior"></asp:Label></td>
        </tr>
        <tr>
            <td align="center"  valign="bottom">
                <table width="100%" style="text-align: left;">
                    <tr>
                        <td>
                            <asp:RadioButton ID="RBJustificada" runat="server" Text="Justificada" GroupName="Otorgada" Font-Names="Tahoma" Font-Size="12px" OnCheckedChanged="RBJustificada_CheckedChanged" AutoPostBack="True" /><br />
                            <asp:RadioButton ID="RBSinGoce" runat="server" Text="Justificada sin goce de haberes (suma a los límites del Art. 14h)"
                                GroupName="Otorgada"  Font-Names="Tahoma" Font-Size="12px" OnCheckedChanged="RBSinGoce_CheckedChanged" AutoPostBack="True" /><br />
                            <asp:RadioButton ID="RBNoJustificada" runat="server" Text="No justificada (Dará lugar a sanciones previstas)"
                                GroupName="Otorgada" Font-Names="Tahoma" Font-Size="12px" OnCheckedChanged="RBNoJustificada_CheckedChanged" AutoPostBack="True" /></td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label>&nbsp;</td>
            <td align="center" valign="bottom">
                <uc2:FirmaAutorizante ID="FirmaAutorizante1" runat="server"></uc2:FirmaAutorizante>
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
                <uc4:AceptarCancelar ID="AceptarCancelar1" runat="server" ></uc4:AceptarCancelar>
            </td>
        </tr>
    </table>
</asp:Content>
