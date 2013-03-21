<%@ control language="C#" autoeventwireup="true" inherits="FormulariosDeLicencia_Partes_DesdeHasta, App_Web_e5ojhnt4" %>
<table>
    <tr>
        <td valign="top" style="width: 105px">
            <asp:Label ID="Label1" runat="server" Text="Licencia Desde" Font-Names="Tahoma" Font-Size="16px"></asp:Label>
        </td>
        <td style="width: 205px" >
            <asp:TextBox ID="TBDesde" runat="server" Width="100px" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."></asp:TextBox>
            <asp:Button ID="BCalendarioDesde" runat="server" Text="..." OnClick="BCalendarioDesde_Click" /><asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="Black" Height="1px" Width="200px" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged">
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
        <td valign="top" style="width: 105px">
            <asp:Label ID="Label2" runat="server" Text="Licencia Hasta" Font-Names="Tahoma" Font-Size="16px"></asp:Label>
        </td>
        <td style="width: 205px">
            <asp:TextBox id="TBHasta" runat="server" Width="100px" Enabled="False" ToolTip="Presione el boton para seleccionar la fecha."></asp:TextBox>
            <asp:Button ID="BCalendarioHasta" runat="server" Text="..." OnClick="BCalendarioHasta_Click" /><asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999"
                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="Black" Height="1px" Width="200px" Visible="False" OnSelectionChanged="Calendar2_SelectionChanged">
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
</table>
