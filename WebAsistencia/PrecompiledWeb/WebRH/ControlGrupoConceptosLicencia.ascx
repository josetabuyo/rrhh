<%@ control language="C#" autoeventwireup="true" inherits="ControlGrupoConceptosLicencia, App_Web_0ueh1v31" %>
&nbsp;
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td style="background-image: url(Imagenes/bordeTablaSupIzq.PNG); width: 22px">
        </td>
        <td colspan="2" style="background-image: url(Imagenes/bordeTablaSup.PNG)">
            &nbsp;</td>
        <td style="background-image: url(Imagenes/bordeTablaSupDer.PNG); width: 22px; background-repeat:no-repeat;">
        </td>
        <td style="width: 21px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 8px; background-image: url(Imagenes/bordeTablaIzq.PNG); background-repeat:no-repeat; background-repeat:repeat-y;">
        </td>
        <td colspan="2" style="height: 21px; text-align: center;">
            <asp:Label ID="LNombreGrupo" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="15pt"
                ForeColor="#5A6573"></asp:Label></td>
        <td style="width: 22px; background-image: url(Imagenes/bordeTablaDer.PNG); background-repeat:repeat-y;">
            &nbsp;
        </td>
        <td style="width: 21px;">
            &nbsp;</td>
    </tr>
    <tr>
    <td style="background-image: url(Imagenes/bordeTablaIzq.PNG); background-repeat: repeat-y;"></td>
        <td colspan="2">
        <hr />
        </td>
        <td style="background-image: url(Imagenes/bordeTablaDer.PNG); width: 22px;"></td>
    </tr>
    <tr>
        <td style="width: 8px; background-image: url(Imagenes/bordeTablaIzq.PNG);">
        </td>
        <td style="width: 232px;">
            <asp:Table ID="TConceptos" runat="server">
            </asp:Table>
        </td>
        <td>
            <asp:Label ID="LDetalleGrupo" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="Small"></asp:Label></td>
        <td style="width: 22px; background-image: url(Imagenes/bordeTablaDer.PNG);">
            &nbsp;</td>
        <td style="width: 21px;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 8px; background-image: url(Imagenes/bordeTablaInfIzq.PNG); height: 19px;">
        </td>
        <td style="width: 200px; background-image: url(Imagenes/bordeTablaInf.PNG); height: 19px;"
            colspan="2">
            &nbsp;</td>
        <td style="width: 22px; background-image: url(Imagenes/bordeTablaInfDerCL.PNG); height: 19px; background-repeat:no-repeat;">
        </td>
        <td style="width: 21px;">
            &nbsp;</td>
    </tr>
</table>
