<%@ Page Language="C#" MasterPageFile="~/FormulariosDeLicencia/MPSolicitudLicencia.master"
    AutoEventWireup="true" CodeFile="F14B_FallecimientoDeFamiliar.aspx.cs" Inherits="FormulariosDeLicencia_Default"
    Title="Untitled Page" %>

<%@ Register Src="Partes/DesdeHasta.ascx" TagName="DesdeHasta" TagPrefix="uc6" %>

<%@ Register Src="Partes/NotificacionAgente.ascx" TagName="NotificacionAgente" TagPrefix="uc5" %>
<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc2" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top" style="width: 386px">        
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se me justifique inasistencia por fallecimiento de Familiar a partir del día"></asp:Label>
                <br />
                <asp:TextBox ID="TBDesde" runat="server" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."
                    Width="100px"></asp:TextBox>
                <asp:Button ID="BCalendarioDesde" runat="server" Text="..." OnClick="BCalendarioDesde_Click"/>
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
                <br />
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Días laborales que corresponde autorizar según familiar fallecido:"></asp:Label><br />
                &nbsp;<br />
                <table style="text-align:left;">
                    <tr>
                        <td style="width: 92px">
                            <asp:RadioButton ID="rbConyugue" runat="server" Text="Conyugue" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                OnCheckedChanged="RadioButton1_CheckedChanged" /></td>
                        <td><asp:RadioButton ID="rbAbuelo" runat="server" Text="Abuelo/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                OnCheckedChanged="RadioButton4_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td style="width: 92px">
                            <asp:RadioButton ID="rbHijo" runat="server" Text="Hijo/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                OnCheckedChanged="RadioButton2_CheckedChanged" /></td>
                                <td><asp:RadioButton ID="rbNieto" runat="server" Text="Nieto/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                        OnCheckedChanged="RadioButton6_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td style="width: 92px">
                            <asp:RadioButton ID="rbPadreMadre" runat="server" Text="Padre/Madre" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                OnCheckedChanged="RadioButton3_CheckedChanged" /></td>
                                <td><asp:RadioButton ID="rbSuegro" runat="server" Text="Suegro/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                        OnCheckedChanged="RadioButton7_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td style="width: 92px">
                            &nbsp;</td>
                                <td><asp:RadioButton ID="rbYerno" runat="server" Text="Yerno/Nuera-Cuñado/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                        OnCheckedChanged="RadioButton8_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td style="width: 92px">
                            &nbsp;</td>
                                <td>
                            <asp:RadioButton ID="rbHermano" runat="server" Text="Hermano/a" GroupName="Otorgada"
                                Font-Names="Tahoma" Font-Size="12px" AutoPostBack="True" 
                                        OnCheckedChanged="RadioButton5_CheckedChanged" /></td>
                    </tr>
                </table>
                <br />
                <br />
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
            <td colspan="2" style="height: 33px">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Autorización del Funcionario inmediato superior"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="bottom" style="width: 386px">
                <table width="100%" style="text-align: left;">
                    <tr>
                        <td>
                            <uc6:DesdeHasta ID="DesdeHasta1" runat="server" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                &nbsp;</td>
            <td align="center" valign="bottom">
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label><br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
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
                <uc3:FirmaRecepcion ID="FirmaRecepcion1" runat="server"></uc3:FirmaRecepcion>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <uc4:AceptarCancelar ID="AceptarCancelar1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
