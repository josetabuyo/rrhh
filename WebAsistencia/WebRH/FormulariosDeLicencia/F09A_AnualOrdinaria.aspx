<%@ Page Language="C#" MasterPageFile="~/FormulariosDeLicencia/MPSolicitudLicencia.master"
    AutoEventWireup="true" CodeFile="F09A_AnualOrdinaria.aspx.cs" Inherits="FormulariosDeLicencia_Default"
    Title="Untitled Page" %>
<%@ Register Src="Partes/SaldoOrdinaria.ascx" TagName="SaldoOrdinaria" TagPrefix="uc6" %>
<%@ Register Src="Partes/FirmaAutorizante.ascx" TagName="FirmaAutorizante" TagPrefix="uc5" %>
<%@ Register Src="Partes/AceptarCancelar.ascx" TagName="AceptarCancelar" TagPrefix="uc4" %>
<%@ Register Src="Partes/FirmaRecepcion.ascx" TagName="FirmaRecepcion" TagPrefix="uc3" %>
<%@ Register Src="Partes/FirmaSolicitante.ascx" TagName="FirmaSolicitante" TagPrefix="uc2" %>
<%@ Register Src="Partes/DesdeHasta.ascx" TagName="DesdeHasta" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHDatos" runat="Server">
    <%--para que no se pueda imprimir por fuera del sistema--%>
    <style type="text/css">
        @media print {
           .no_imprimible  
           {
               display: none !important;
           }
        }
    </style>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="../Scripts/deshabilitarImpresion.js"></script>
    <%--para que no se pueda imprimir por fuera del sistema--%>

    &nbsp;
    <table>
        <tr>
            <td style="width: 303px">
                <uc1:DesdeHasta ID="DesdeHasta1" runat="server" />
                <br />
                <br />
            </td>
            <td valign="bottom">
                <uc2:FirmaSolicitante ID="FirmaSolicitante1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="16px" Text="Autorización del Funcionario inmediato superior" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 303px; height: 127px;">
                <uc6:SaldoOrdinaria ID="SaldoOrdinaria1" runat="server" EnableViewState="true" />
            </td>
            <td valign="top" style="height: 127px">
                <table width="100%" style="text-align:left;">
                    <tr>
                        <td>
                            <asp:RadioButton ID="RBOtorgada" runat="server" Text="Otorgada" Font-Names="Tahoma" Font-Size="16px" GroupName="GN" AutoPostBack="True" OnCheckedChanged="RBOtorgada_CheckedChanged" /><br />
                            <asp:RadioButton ID="RBDenegada" runat="server" Text="Denegada por razones de servicio" Font-Names="Tahoma" Font-Size="16px" GroupName="GN" AutoPostBack="True" OnCheckedChanged="RBDenegada_CheckedChanged" />
                        </td>
                    </tr>
                </table>
                <br /><br /><br />
                <uc5:FirmaAutorizante ID="FirmaAutorizante1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
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
                <uc4:AceptarCancelar ID="AceptarCancelar1" runat="server"/>
            </td>
        </tr>
    </table>
</asp:Content>
