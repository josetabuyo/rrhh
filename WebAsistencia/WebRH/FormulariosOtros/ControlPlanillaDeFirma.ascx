<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPlanillaDeFirma.ascx.cs"
    Inherits="ControlPlanillaDeFirma" %>
    
<table style="text-align: center;">
    <tr>
        <td colspan="3">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/membrete-web-2015.gif"
                Width="610px" Height="99px" /></td>
    </tr>
    <tr>
        <td class="negroTH" align="center">
           
            <table width="100%" border="0" >
            <tr><td align="right">
                <asp:Image ID="ImbBarcode" runat="server" Height="26px" Width="310px" />
                
				</td></tr>
            </table>
           
            <fieldset>
                <!--CABECERA-->
                <table border="0" style="width: 100%; text-align: center; border-collapse: collapse;">
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="Label1" runat="server" Text="Agente: "></asp:Label>
                            <asp:Label ID="LNombreAgente" runat="server" Text="Label"></asp:Label></td>
                        <td>
                        </td>
                        <td style="text-align:left;">
                            <asp:Label ID="Label2" runat="server" Text="DNI: "></asp:Label>
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
            <table style="width: 100%; height: 629; text-align: center; border-collapse: collapse;" border='1'>
                <tr style="height: 20;">
                    <td style="width: 6%; height: 20;"><asp:Label ID="Label5" runat="server" Text="Día"></asp:Label></td>
                    <td style="width: 21.5%;" colspan="2"><asp:Label ID="Label9" runat="server" Text="Entrada"></asp:Label></td>
                    <td style="width: 21.5%;" colspan="2"><asp:Label ID="Label7" runat="server" Text="Salida"></asp:Label></td>
                    <td style="width: 6%;"><asp:Label ID="Label8" runat="server" Text="Día"></asp:Label></td>
                    <td style="width: 21.5%;" colspan="2"><asp:Label ID="Label6" runat="server" Text="Entrada"></asp:Label></td>
                    <td style="width: 21.5%;" colspan="2"><asp:Label ID="Label10" runat="server" Text="Salida"></asp:Label></td>
                </tr>
                <tr style="height: 20;">
                    <td style="width: 6%; height: 20;"></td>
                    <td style="width: 7%;"><asp:Label ID="Label16" runat="server" Text="Hora"></asp:Label></td>
                    <td style="width: 14.5%;"><asp:Label ID="Label17" runat="server" Text="Firma"></asp:Label></td>
                    <td style="width: 8%;"><asp:Label ID="Label19" runat="server" Text="Hora"></asp:Label></td>
                    <td style="width: 14.5%;"><asp:Label ID="Label20" runat="server" Text="Firma"></asp:Label></td>
                    <td style="width: 6%;"></td>
                    <td style="width: 7%;"><asp:Label ID="Label15" runat="server" Text="Hora"></asp:Label></td>
                    <td style="width: 14.5%;"><asp:Label ID="Label18" runat="server" Text="Firma"></asp:Label></td>
                    <td style="width: 8%;"><asp:Label ID="Label21" runat="server" Text="Hora"></asp:Label></td>
                    <td style="width: 14.5%;"><asp:Label ID="Label22" runat="server" Text="Firma"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="10" style="font-size: 13px;">
                        <asp:Table ID="Table1" runat="server" Width="100%">
                        </asp:Table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
