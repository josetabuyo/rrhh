<%@ control language="C#" autoeventwireup="true" inherits="FormulariosOtros_ControlSeleccionDeArea, App_Web_ljz3an1m" %>

<style type="text/css">
    .style1
    {
        height: 32px;
    }
    .style2
    {
        height: 11px;
    }
    .style3
    {
        height: 45px;
    }
</style>

<script type="text/javascript">
    function presionoTecla() {
        if (window.event.keyCode == 13) {
            theForm.<% Response.Write(this.Button1.ClientID); %>.click; 
        }
    }
</script>

<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="background-image: url('Imagenes/bordeTablaSup.PNG'); " 
            class="style1">
            &nbsp;
            <asp:ImageButton ID="ImageButton1" runat="server"  
                ImageUrl="~/Imagenes/btnVolver.PNG" onclick="ImageButton1_Click" 
                style="margin-right: 0px"  />
            <asp:Label ID="Label3" runat="server" Font-Names="Arial Black" 
                Font-Size="Small" Text="Volver"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: left" class="style2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Buscador de Áreas" 
                Font-Names="Arial Black" Font-Size="Medium"></asp:Label>
        &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center" class="style3">
            <asp:Label ID="Label2" runat="server" 
                Text="Escriba una parte del nombre del área."></asp:Label>
        </td>
    </tr>
    <tr style="font-size: 12pt; font-family: Times New Roman">
        <td style="text-align: center;">
            <asp:TextBox ID="TextBox1" runat="server" Width="368px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" 
                OnCommand="Button1_Command" Enabled="False" />
        </td>
    </tr>
    <tr>
        <td style="text-align: center;">
            &nbsp;<asp:ListBox ID="ListBox1" runat="server" Height="200px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"
                AutoPostBack="True" Visible="False"></asp:ListBox>
            &nbsp;
        </td>
    </tr>
    <tr style="font-size: 12pt; font-family: Times New Roman">
        <td style="width: 232px">
            &nbsp;
        </td>
    </tr>
    <tr style="font-size: 12pt; font-family: Times New Roman">
        <td style="background-image: url(Imagenes/bordeTablaInf.PNG); width: 200px; height: 19px">
            &nbsp;
        </td>
    </tr>
</table>
