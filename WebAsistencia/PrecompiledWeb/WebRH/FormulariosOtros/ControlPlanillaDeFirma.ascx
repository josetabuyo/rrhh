<%@ control language="C#" autoeventwireup="true" inherits="ControlPlanillaDeFirma, App_Web_ljz3an1m" %>
    
<table style="text-align: center;">
    <tr>
        <td colspan="3">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/membrete-web-2013.gif"
                Width="610px" Height="99px" /></td>
    </tr>
    <tr>
        <td class="negroTH" align="center">
           
            <table width="100%" border="0" >
            <tr><td align="right">
                <asp:Image ID="ImbBarcode" runat="server" Height="26px" />
                
				</td></tr>
            </table>
           
            <fieldset>
                <!--CABECERA-->
                <table border="0" style="width: 100%; text-align: center;">
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="Label1" runat="server" Text="Agente: "></asp:Label>
                            <asp:Label ID="LNombreAgente" runat="server" Text="Label"></asp:Label></td>
                        <td>
                        </td>
                        <td style="text-align:left;">
                            <asp:Label ID="Label2" runat="server" Text="Nro. Documento: "></asp:Label>
                            <asp:Label ID="LDocumento" runat="server" Text="Label"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align:left;">
                            <asp:Label ID="Label3" runat="server" Text="Sector: "></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="LSector"></asp:Label></td>
                        <td valign="top">
                        </td>
                        <td colspan="2">
                            <!--Horario-->
                            <fieldset>
                                <table border="0" style="width: 100%; text-align: center;">
                                    <tr>
                                        <td colspan='4'>
                                            <asp:Label ID="Label11" runat="server" Text="Horario"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="De:"></asp:Label></td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="A:"></asp:Label></td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Periodo:" Width="52px"></asp:Label>
                            <asp:Label ID="LPeriodo" runat="server" Text="Label"></asp:Label></td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <table style="width: 100%; height: 629; text-align: center;" border='1'>
                <tr style="height: 20;">
                    <td style="width: 16.6%; height: 20;">
                        <asp:Label ID="Label5" runat="server" Text="Día"></asp:Label></td>
                    <td style="width: 16.6%;">
                        <asp:Label ID="Label9" runat="server" Text="Entrada"></asp:Label></td>
                    <td style="width: 16.6%;">
                        <asp:Label ID="Label7" runat="server" Text="Salida"></asp:Label></td>
                    <td style="width: 16.6%;">
                        <asp:Label ID="Label8" runat="server" Text="Día"></asp:Label></td>
                    <td style="width: 16.6%;">
                        <asp:Label ID="Label6" runat="server" Text="Entrada"></asp:Label></td>
                    <td style="width: 16.6%;">
                        <asp:Label ID="Label10" runat="server" Text="Salida"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Table ID="Table1" runat="server" Width="100%">
                        </asp:Table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
