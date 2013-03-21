<%@ page language="C#" masterpagefile="~/FormulariosDeLicencia/MPSolicitudLicencia.master" autoeventwireup="true" inherits="FormulariosDeLicencia_Default, App_Web_muj1scsa" title="Untitled Page" %>

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

<%--                <script type="text/javascript">
		            function activarSubmit(cajaDeTexto,campoDeFecha,cajaDeTexto2, botonAceptar) {
			            if(cajaDeTexto.value != '' && campoDeFecha.value != '' && cajaDeTexto2.value != '') {
				            botonAceptar.disabled = false;
			            } else {
				            botonAceptar.disabled = true;
			            }
	                }
                </script>--%>

                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se me otorgue licencia de acuerdo a los artículos arriba especificados, a partir de"></asp:Label>
                <br />
                <asp:TextBox ID="TBDesde" runat="server" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."
                    Width="100px"></asp:TextBox>
                <asp:Button ID="BCalendarioDesde" runat="server" Text="..." OnClick="BCalendarioDesde_Click" />
                <asp:Label ID="Label3" runat="server" Text="por 30 (treinta) días corridos."></asp:Label><br />
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
                <table width="100%" style="text-align: center;">
                    <tr>
                        <td>
                            <fieldset>
                                <table style="text-align: left;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Apellido y Nombres: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TBApellido" runat="server" 
                                                ontextchanged="TBApellido_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="Documento: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TBDocumento" runat="server" 
                                                ontextchanged="TBDocumento_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
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
                &nbsp;<br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label></td>
            <td valign="top" style="height: 127px">
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
