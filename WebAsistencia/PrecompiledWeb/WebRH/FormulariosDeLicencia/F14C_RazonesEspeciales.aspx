<%@ page language="C#" masterpagefile="~/FormulariosDeLicencia/MPSolicitudLicencia.master" autoeventwireup="true" inherits="FormulariosDeLicencia_Default, App_Web_vlgihptl" title="Untitled Page" %>

<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc2" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" runat="Server">
    <table width="100%">

<%--        <script type="text/javascript">
		function activarSubmit(cajaDeTexto,campoDeFecha,botonAceptar) {
			if(cajaDeTexto.value != '' && campoDeFecha.value != '') {
				botonAceptar.disabled = false;
			} else {
				botonAceptar.disabled = true;
			}
	    }
        </script>--%>

        <tr>
            <td style="width: 369px" valign="bottom">
                <asp:Label ID="Label1" runat="server" Text="Solicito a Ud. se justifique la inasistencia del día"></asp:Label>
                <br />
                <asp:TextBox ID="TBDesde" runat="server" Width="100px" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."></asp:TextBox><asp:Button
                    ID="BCalendarioDesde" runat="server" OnClick="BCalendarioDesde_Click" Text="..." /><br />
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
            <td>
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 369px" valign="top" align="center">
                <asp:Label ID="Label2" runat="server" Text="por las siguientes razones:"></asp:Label><br />
                <asp:TextBox ID="TBRazones" runat="server" Height="76px" Width="277px" Rows="4" 
                    TextMode="MultiLine" ontextchanged="TextBox1_TextChanged" 
                    AutoPostBack="True"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="(Completar antes de imprimir)"></asp:Label></td>
            <td valign="bottom" align="center">
                <uc1:FirmaSolicitante ID="FirmaSolicitante1" runat="server" />
            </td>
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
            <td valign="bottom" align="center" style="width: 369px">
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="_____/______/______"></asp:Label><br />
                <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="12px" Text="Fecha"></asp:Label>&nbsp;</td>
            <td valign="bottom" align="center">
                <uc2:FirmaAutorizante ID="FirmaAutorizante1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:FirmaRecepcion ID="FirmaRecepcion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <uc4:AceptarCancelar ID="AceptarCancelar1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
