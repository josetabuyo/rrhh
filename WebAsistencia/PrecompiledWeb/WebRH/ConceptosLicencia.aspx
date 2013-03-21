<%@ page language="C#" autoeventwireup="true" inherits="ConceptosLicencia, App_Web_wmo2dmtk" %>

<%@ Register Src="ControlGrupoConceptosLicencia.ascx" TagName="ControlGrupoConceptosLicencia"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema RRHH - Selección de concepto de Licencia</title>
    <style type="text/css">
        .style1
        {
            width: 268435456px;
        }
        .style2
        {
            height: 19px;
            width: 268435456px;
        }
    </style>
</head>
<body style="background-color: #8694A4;">
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;<table style="width: 100%; text-align: center">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" style="width: 98%; background-color: #ffffff;
                            text-align: left">
                            <tr>
                                <td style="background-image: url(Imagenes/bordeTabla2SupIzq.PNG); width: 18px">
                                    &nbsp;
                                </td>
                                <td colspan="3" style="background-image: url(Imagenes/bordeTabla2Sup.PNG)" 
                                    class="style1">
                                    &nbsp;
                                </td>
                                <td style="background-image: url(Imagenes/bordeTabla2SupDer.PNG); width: 21px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="background-image: url(Imagenes/bordeTabla2Izq.PNG); width: 17px; height: 19px">
                                </td>
                                <td align="center" colspan="3" class="style2">
                                    &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="21px" 
                                        ImageUrl="~/Imagenes/btnVolver.PNG" onclick="ImageButton2_Click" 
                                        style="margin-left: 0px; margin-right: 0px; margin-top: 11px; margin-bottom: 0px" 
                                        Width="26px" />
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial Black" 
                                        Font-Size="Small" Text="Volver"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
                                    <asp:Label ID="LNombreGrupo" runat="server" Font-Names="Tahoma" Font-Size="15pt"
                                        ForeColor="#5A6573" Text="Seleccione Licencia a Solicitar"></asp:Label>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" 
                                        ImageUrl="~/Imagenes/BotonSalirOff.PNG" onclick="ImageButton1_Click" 
                                        
                                        style="margin-left: 176px; margin-right: 9px; margin-top: 0px; margin-bottom: 0px" />
                                    <br />
                                    <br />
                                   
                                    <asp:Table ID="TablaGrupos" runat="server">
                                    </asp:Table>
                                    <br />
                                    <br />
                                </td>
                                <td style="background-image: url(Imagenes/bordeTabla2Der.PNG); width: 18px; height: 19px; font-size: 12pt; font-family: Times New Roman;">
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="background-image: url(Imagenes/bordeTabla2Izq.PNG); width: 5px">
                                    &nbsp;
                                </td>
                                <td align="center" colspan="3" class="style1">
                                    &nbsp;<br />
                                </td>
                                <td style="background-image: url(Imagenes/bordeTabla2Der.PNG); width: 18px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="background-image: url(Imagenes/bordeTabla2InfIzq.PNG)">
                                    &nbsp;
                                </td>
                                <td colspan="3" style="background-image: url(Imagenes/bordeTabla2Inf.PNG)" 
                                    class="style1">
                                    &nbsp;
                                </td>
                                <td style="background-image: url(Imagenes/bordeTabla2InfDer.PNG); width: 18px">
                                    &nbsp;
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
