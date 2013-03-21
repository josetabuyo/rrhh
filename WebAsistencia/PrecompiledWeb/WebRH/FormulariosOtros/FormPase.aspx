<%@ page language="C#" autoeventwireup="true" inherits="FormPase, App_Web_ljz3an1m" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema RRHH - Formulario de pase</title>
    <style type="text/css">
        .style1
        {
            height: 253px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; text-align: center">
                <tr>
                    <td>
                        <table style="text-align: center;" width="500" border="0">
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" 
                                        ImageUrl="~/Imagenes/membrete-web-2009.gif" Width="500px" />
                                </td>
                            </tr>
                        </table>
                        <table style="text-align: center;" width="500" border="0">
                            <tr>
                                <td colspan="2" class="style1">
                                    <fieldset>
                                        <table border="0">
                                            <tr>
                                                <td align="right" class="AzulTHBIG">
                                                    <asp:Label ID="Label1" runat="server" Text="Memorandum Nº"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/<asp:Label
                                                        ID="LPeriodo" runat="server" Text="Label"></asp:Label><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="negroth">
                                                    <p>
                                                        <asp:Label ID="Label2" runat="server" Text="Buenos Aires,"></asp:Label>
                                                        &nbsp;&nbsp; &nbsp;<asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label></p>
                                                    <p>
                                                        &nbsp;</p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="negroTH" style="text-align:left;">
                                                    <b>A:</b>
                                                    <asp:Label ID="Label3" runat="server" Text="Dirección General de Recursos Humanos y Organización"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="negroTH" style="text-align:left;">
                                                    <b>De:</b>
                                                    <asp:Label ID="LAreaEmisora" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="negroTH">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="negroTH">
                                                    <p style="text-align: justify;">
                                                        <asp:Label ID="Label4" runat="server" Text="Se solicita a esa Dirección General efectuar el cambio de lugar de trabajo de"></asp:Label>
                                                        <asp:Label ID="LNombre" runat="server"></asp:Label>
                                                        <asp:Label ID="Label5" runat="server" Text=", Documento Nº"></asp:Label>
                                                        <asp:Label ID="LDocumento" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="Label6" runat="server" Text=", quien pasa a trabajar en "></asp:Label><asp:Label
                                                            ID="LArea" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Text=" a partir del dia de la fecha."></asp:Label>
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="negroTH">
                                    <asp:Label ID="Label8" runat="server" Text="-----------------------------"></asp:Label><br />
                                    <asp:Label ID="Label10" runat="server" Text="Firma y Sello del Responsable Directo del Area actual"></asp:Label><br />
                                </td>
                                <td class="negroth" align="right">
                                    <asp:Label ID="Label9" runat="server" 
                                        Text="-------------------------------------------------"></asp:Label><br />
                                    <asp:Label ID="Label11" runat="server" Text="Firma y Sello del Responsable Area de Recepción Dirección General de Recursos Humanos y Organización"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="negroTH" colspan="2" align="center" style="height: 26px">
                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                                        style="margin-left: 86px; margin-right: 0px" Text="Cancelar" Width="136px" />
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
                                        OnClientClick="javascript: window.print()" Text="Enviar e Imprimir" 
                                        style="margin-left: 112px" />&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
