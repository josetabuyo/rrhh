<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPase.aspx.cs" Inherits="FormPase" %>

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
    <%--para que no se pueda imprimir por fuera del sistema--%>
    <style type="text/css">
        @media print
        {
            .no_imprimible
            {
                display: none !important;
            }
        }
    </style>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../Scripts/deshabilitarImpresion.js"></script>
    <%--para que no se pueda imprimir por fuera del sistema--%>
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
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/membrete-web-2009.gif"
                                    Width="500px" />
                            </td>
                        </tr>
                    </table>
                    <table style="text-align: center;" width="500" border="0">
                        <tr>
                            <td colspan="2" class="style1">
                                <fieldset>
                                    <table border="0">
                                        <tr>
                                            <td align="right" class="AzulTHBIG" style="text-align:left;">
                                                <asp:Label ID="Label1" runat="server" Text="Nº"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/<asp:Label
                                                    ID="LPeriodo" runat="server" Text="Label"></asp:Label><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="negroth">
                                                <p>
                                                    <asp:Label ID="Label2" runat="server" Text="Buenos Aires,"></asp:Label>
                                                    &nbsp;&nbsp; &nbsp;<asp:Label ID="LFecha" runat="server" Text="Label"></asp:Label></p>
                                                
                                            </td>
                                            </tr><tr>
                                            <td>
                                                <p><b><u>MEMORANDO</u></b></p>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="negroTH" style="text-align: left;">
                                                <b>A:
                                                <asp:Label ID="Label3" runat="server" Text="DIRECCIÓN GENERAL DE RECURSOS HUMANOS Y ORGANIZACIÓN"></asp:Label></b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="negroTH" style="text-align: left;">
                                                <b>De:
                                                <asp:Label ID="LAreaEmisora" runat="server" Text="Label"></asp:Label></b>
                                            </td>
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
                                                    <asp:Label ID="Label6" runat="server" Text=", quien pasa a desempeñarse en "></asp:Label><asp:Label
                                                        ID="LArea" runat="server" Text="Label"></asp:Label>
                                                    <asp:Label ID="Label7" runat="server" Text=" a partir del dia:"></asp:Label><%=DateTime.Today.ToString("dd/MM/yyyy") %>
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
                            <td class="negroTH" style="text-align:left">
                                <asp:Label ID="Label8" runat="server" Text="-------------------------------------"></asp:Label><br />
                                <asp:Label ID="Label10" runat="server" Text="Firma y Sello del Responsable directo del área actual (Rango no inferior a Director)"></asp:Label><br />
                            </td>
                            <td class="negroth" style="text-align:right">
                                <asp:Label ID="Label9" runat="server" Text="-------------------------------------"></asp:Label><br />
                                <asp:Label ID="Label11" runat="server" Text="Firma y Sello del Responsable directo del área de recepción (Rango no inferior a Director)"></asp:Label><br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            <br /><br />
                            <asp:Label ID="Label12" runat="server" Text="-------------------------------------------------"></asp:Label><br />
                            <asp:Label ID="Label13" runat="server" Text="Dirección General de Recursos Humanos y Organización"></asp:Label><br />                                
                            
                        </tr>
                        <tr>
                            <td class="negroTH" colspan="2" align="center" style="height: 26px">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="margin-left: 86px;
                                    margin-right: 0px" Text="Cancelar" Width="136px" />
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="javascript: window.print()"
                                    Text="Enviar e Imprimir" Style="margin-left: 112px" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
