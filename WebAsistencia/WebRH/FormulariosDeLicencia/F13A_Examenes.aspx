<%@ Page Language="C#" MasterPageFile="~/FormulariosDeLicencia/MPSolicitudLicencia.master"
    AutoEventWireup="true" CodeFile="F13A_Examenes.aspx.cs" Inherits="FormulariosDeLicencia_Default"
    Title="Untitled Page" %>

<%@ Register Src="Partes/DesdeHasta.ascx" TagName="DesdeHasta" TagPrefix="uc7" %>
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
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se me otorgue licencia para rendir exámen de acuerdo a los términos que especifico:"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Ciclo:"></asp:Label>
                        </td>
                        <td style="height: 22px; text-align: left;">
                            <asp:RadioButton ID="rbSecundario" runat="server" AutoPostBack="True" GroupName="Ciclo"
                                OnCheckedChanged="rbSecundario_CheckedChanged" Text="Secundario (Máx.: 3 días)" /><br />
                            <asp:RadioButton ID="rbTerciario" runat="server" AutoPostBack="True" GroupName="Ciclo"
                                OnCheckedChanged="rbTerciario_CheckedChanged" Text="Ingreso/Terciario/Univ/Posgrado (Max.: 6 días)" /></td>
                    </tr>
                    <tr>
                    <td>
                            <asp:Label ID="Label6" runat="server" Text="Fecha de Examen:"></asp:Label></td>
                        <td style="text-align:right;">
                            <asp:TextBox ID="TBFechaDeExamen" runat="server" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."
                                Width="100px"></asp:TextBox>
                            <asp:Button ID="BCalendarioDesde" runat="server" OnClick="BCalendarioDesde_Click"
                                    Text="..." /><br />
                            <asp:Calendar ID="CalendarExamen" runat="server" BackColor="White" BorderColor="#999999"
                                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                ForeColor="Black" Height="1px" OnSelectionChanged="CalendarExamen_SelectionChanged"
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
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:right;">
                            <uc7:DesdeHasta ID="DesdeHasta1" runat="server" />
                        </td>
                    </tr>
                </table>
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
                <table width="100%" style="text-align: left;">
                    <tr>
                        <td style="height: 62px">
                            <fieldset>
                                <table>
                                    <tr>
                                        <td style="width: 303px;">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Overline="False"
                                                Font-Size="16px" Text="Usados en el Presente año:"></asp:Label><br />
                                            <asp:Label ID="LDiasUsados" runat="server" Text="0 Días"></asp:Label></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 62px">
                            <fieldset>
                                <table>
                                    <tr>
                                        <td style="width: 303px;">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Overline="False"
                                                Font-Size="16px" Text="Máximo permitido Anualmente:"></asp:Label><br />
                                            <asp:Label ID="Label9" runat="server" Text="Secundario: 12 días"></asp:Label><br />
                                            <asp:Label ID="Label10" runat="server" Text="Ingreso/Terciario/Univ/Posgrado: 20 días "></asp:Label></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="height: 127px">
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label><br />
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
