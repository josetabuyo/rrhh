<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParteDiario.aspx.cs" Inherits="ParteDiario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parte Diario de Novedades - RRHH</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <!-- Begin cabecera-->
    <table width="630" align="center" border="0">
        <tr>
            <td align="center" colspan="6">
                
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/Imagenes/btnVolver.PNG" onclick="ImageButton2_Click" 
                    style="width: 25px; margin-right: 8px; margin-top: 0px; margin-bottom: 156px" />
                
                <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" 
                    EnableTheming="False" EnableViewState="False" Font-Names="Arial Black" 
                    Height="19px" 
                    style="margin-left: 0px; margin-right: 10px; margin-top: 9px; margin-bottom: 152px" 
                    Text="Volver" Width="53px" />
                <img src="Imagenes/membrete-web-2009.gif" width="500" style="margin-left: 0px">
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <table width="100%" align="center" border="0">
                        <tr>
                            <td valign="top" colspan="6" align="center">
                                Parte Diario de Novedades
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <br />
                                Unidad:
                            </td>
                            <td colspan="5">
                                <br />
                                <asp:Label ID="LArea" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Fecha:
                            </td>
                            <td colspan="5">
                                &nbsp;<asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <!--end cabecera-->
                        <!--begin detalle-->
                        <tr>
                            <td colspan="6">
                                <asp:Table ID="TablaAsentes" runat="server" Width="100%">
                                    <asp:TableHeaderRow>
                                    <asp:TableCell ColumnSpan="3"></asp:TableCell>
                                    <asp:TableCell><asp:Label runat="server" Text="Periodo de Ausencia"></asp:Label></asp:TableCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableHeaderRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label1" runat="server" Text="Legajo"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Label ID="Label2" runat="server" Text="Apellido y Nombre"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Label ID="Label3" runat="server" Text="Novedad"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Label ID="Label4" runat="server" Text="Desde"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:Label ID="Label5" runat="server" Text="Hasta"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </td>
                        </tr>

                        <!--begin pie-->
                        <tr>
                            <td colspan="6" align="center">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <table border="0">
                                    <tr>
                                        <td>
                                            &nbsp;<asp:Label runat="server" 
                                                Text="* Licencia(s) pendiente(s) de aprobación" Font-Size="Smaller" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <br />
                                            <br />
                                            ---------------------------------<br />
                                            Firma y Sello del Responsable de Unidad
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                            <fieldset>
                                                <table border="0">
                                                    <tr>
                                                        <td align='left' valign="top" colspan="2">
                                                            Recepci&oacute;n en la Direcci&oacute;n de Administraci&oacute;n de Personal de
                                                            la Direcci&oacute;n General de Recursos Humanos y Organizaci&oacute;n
                                                            <br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ---------------------------------<br />
                                                            Firma y Sello del Responsable de Recepci&oacute;n
                                                        </td>
                                                        <td valign="bottom" align="center">
                                                            ______/______/______<br />
                                                            Fecha<br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                Temporalmente las licencias medicas figuraran en la pagina web y en el parte diaro
                                bajo la leyenda "ausente con aviso" hasta tanto se termine la integración de los
                                modulos del Sistema.
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <!--<a href="#"><img name="boton" src="http://www.webrh.des/img/btnParte.bmp" onClick="imprimir();" border="0"></a>-->
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:ImageButton ID="ImageButton1" runat="server" />
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
    <!--end pie-->
    </form>
</body>
</html>
