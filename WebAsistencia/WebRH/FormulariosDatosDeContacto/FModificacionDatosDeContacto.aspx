<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FModificacionDatosDeContacto.aspx.cs" Inherits="FormulariosDatosDeContacto_FModificacionDatosDeContacto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Información de contacto - Sistema RRHH</title>
</head>
<body style="background-color: #8694A4;">
    <form id="form1" runat="server">
        <div>
            &nbsp;</div>
        <table style="width: 100%; text-align: center">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 80%; background-color: #ffffff;
                        text-align: left">
                        <tr>
                            <td style="background-image: url(../Imagenes/bordeTabla2SupIzq.PNG); width: 18px">
                                &nbsp;
                            </td>
                            <td colspan="3" style="background-image: url(../Imagenes/bordeTabla2Sup.PNG)">
                                &nbsp;
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2SupDer.PNG); width: 22px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); height: 49px;">
                                &nbsp;
                            </td>
                            <td style="width: 150px; height: 49px;">
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                    ImageUrl="~/Imagenes/btnVolver.PNG" onclick="ImageButton2_Click"  />
                                <asp:Label ID="Label1" runat="server" Font-Names="Arial Black" 
                                    Font-Size="Small" Text="Volver"></asp:Label>
                            </td>
                            <td style="height: 49px;" align="center">
                                &nbsp;</td>
                            <td align="right" style="font-size: 12pt; color: #000000; font-family: Times New Roman;
                                height: 49px; width: 150px">
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    ImageUrl="~/Imagenes/BotonSalirOff.PNG" onclick="ImageButton1_Click" />&nbsp;</td>
                            <td style="font-size:12pt; background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px; font-family: Times New Roman; height: 49px;">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px; height: 19px;">
                            </td>
                            <td colspan="3" align="center" style="height: 20px; padding: 25px;">
                                <h3>
                                <asp:Label ID="LArea" runat="server" Font-Names="Tahoma" Width="100%" 
                                    Font-Bold="True"></asp:Label></h3>
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px; height: 19px;">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px; height: 19px;">
                            </td>
                            <td colspan="3" align="left" style="height: 20px; padding: 0px 0px 0px 25px; ">
                                <h4>
                                <asp:Label ID="LEtiquetaResponsables" runat="server" Font-Names="Tahoma" Width="100%" 
                                    Font-Bold="True">Responsables</asp:Label></h4>
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px; height: 19px;">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px; height: 19px;">
                            </td>
                            <td colspan="3" align="left" style="height: 20px; padding: 0px 0px 15px 25px;">
                                <asp:Label ID="LResponsables" runat="server" Font-Names="Tahoma" Width="100%" 
                                    Font-Bold="False"></asp:Label>
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px; height: 19px;">
                            </td>
                        </tr>

                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px;">
                            </td>
                            <td colspan="3" align="left" style="height: 20px; padding: 0px 0px 0px 25px;">
                                <h4>
                                <asp:Label ID="LEtiquetaDireccion" runat="server" Font-Names="Tahoma" Width="100%" 
                                    Font-Bold="True">Dirección</asp:Label></h4>
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px;">
                            </td>
                        </tr>

                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px;">
                            </td>
                            <td colspan="3" align="left" style="height: 20px; padding: 0px 0px 15px 25px;">
                                <asp:Label ID="LDireccion" runat="server" Font-Names="Tahoma" Width="100%" 
                                    Font-Bold="False" ForeColor="Gray"></asp:Label>
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px;">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 17px; height: 19px;">
                            </td>
                            <td colspan="3" style="padding: 0px 25px 25px 25px; ">
                                <table width="100%" border="0px" cellpadding="4px" cellspacing="4px">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView_Telefonos" runat="server" 
                                                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Font-Names="Tahoma" 
                                                ForeColor="Black" GridLines="Vertical" Width="100%">
                                                <AlternatingRowStyle BackColor="#E0E4E8" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Id" Visible="False" DataField="Id" />
                                                    <asp:BoundField HeaderText="Teléfonos" DataField="Contacto" />
                                                </Columns>
                                                <HeaderStyle BackColor="#8694A4" ForeColor="White"/>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            <asp:GridView ID="GridView_Fax" runat="server" AutoGenerateColumns="False" 
                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                                CellPadding="3" Font-Names="Tahoma" ForeColor="Black" GridLines="Vertical" 
                                                Width="100%">
                                                <AlternatingRowStyle BackColor="#E0E4E8" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Fax" />
                                                </Columns>
                                                <HeaderStyle BackColor="#8694A4" ForeColor="White" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            <asp:GridView ID="GridView_Email" runat="server" AutoGenerateColumns="False" 
                                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                                CellPadding="3" Font-Names="Tahoma" ForeColor="Black" GridLines="Vertical" 
                                                Width="100%">
                                                <AlternatingRowStyle BackColor="#E0E4E8" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="E-mail" />
                                                </Columns>
                                                <HeaderStyle BackColor="#8694A4" ForeColor="White" />
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px; height: 19px;">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2Izq.PNG); width: 5px">
                                &nbsp;
                            </td>
                            <td colspan="3" align="center">
                                &nbsp;</td>
                            <td style="background-image: url(../Imagenes/bordeTabla2Der.PNG); width: 18px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url(../Imagenes/bordeTabla2InfIzq.PNG)">
                                &nbsp;
                            </td>
                            <td colspan="3" style="background-image: url(../Imagenes/bordeTabla2Inf.PNG)">
                                &nbsp;
                            </td>
                            <td style="background-image: url(../Imagenes/bordeTabla2InfDer.PNG); width: 18px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>