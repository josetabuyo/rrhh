<%@ page language="C#" autoeventwireup="true" inherits="Impresiones_MemorandumPasajes, App_Web_bmi1lyey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style5
        {
            width: 59px;
            font-family: Arial;
            font-size: small;
        }
        .style7
        {
            width: 127px;
            font-family: Arial;
            font-size: small;
        }
        .style8
        {
            width: 97px;
            font-family: Arial;
            font-size: small;
        }
        .style9
        {
            width: 93px;
            font-family: Arial;
            font-size: small;
        }
        .style10
        {
            width: 120px;
            font-family: Arial;
            font-size: small;
        }
        .style11
        {
            width: 696px;
        }
        .style12
        {
            width: 113px;
            font-family: Arial;
            font-size: small;
        }
        .style13
        {
            text-align: center;
            font-family: Arial;
            font-size: small;
        }
        .style14
        {
            width: 21px;
            font-family: Arial;
            font-size: small;
        }
        .style15
        {
            width: 44px;
            font-family: Arial;
            font-size: small;
        }
        .style16
        {
            font-family: Arial;
        }
        .style17
        {
            font-family: Arial;
            font-size: small;
        }
        .style18
        {
            font-size: small;
        }
        .style19
        {
            width: 113px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style20
        {
            width: 93px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style21
        {
            width: 127px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style22
        {
            width: 120px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style23
        {
            width: 59px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style24
        {
            width: 97px;
            font-family: Arial;
            font-size: small;
            text-align: center;
        }
        .style25
        {
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="border: thin solid #808080; font-family: Arial;
    font-size: small;">
    <div style="text-decoration: underline; text-align: center" class="style17">
        <asp:Label ID="Label1" runat="server" Text="MEMORANDUM" Style="font-weight: 700"></asp:Label>
    </div>
    <br class="style17" />
    <div class="style17">
        <asp:Label ID="lblAreaDestino" runat="server" Text="A:" Style="font-weight: 700"></asp:Label>
    </div>
    <br class="style17" />
    <div class="style17">
        <asp:Label ID="lblAreaOrigen" runat="server" Text="DE:" Style="font-weight: 700"></asp:Label>
    </div>
    <hr />
    <div class="style17" align="right">
        <asp:Label ID="Label4" runat="server" Text="Ref. solicitud de pasajes, viáticos y eventuales."
            Style="text-align: right; font-weight: 700;"></asp:Label>
    </div>
    <br />
    <div>
        <span class="style16"><span class="style18">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Por el presente se solicita el anticipo de viáticos y, en caso de corresponder, eventuales y pasajes a nombre de"></asp:Label>
            &nbsp;</span><asp:Label ID="lblApellidoNombre" runat="server"></asp:Label>
            &nbsp;</span><asp:Label ID="Label28" runat="server" Text="de acuerdo al detalle que se indica:"></asp:Label>
    </div>
    <br class="style17" />
    <table style="width: 100%;">
        <tr style="border: thin solid #808080">
            <td class="style24">
                <asp:Label ID="Label15" runat="server" Text="Apellido y Nombre" Style="text-align: left;
                    font-weight: 700;"></asp:Label>
            </td>
            <td class="style23">
                <asp:Label ID="Label16" runat="server" Text="Documento" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style22">
                <asp:Label ID="Label17" runat="server" Text="Categoría y Legajo" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style21">
                <asp:Label ID="Label18" runat="server" Text="Fecha de nacimiento" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style20">
                <asp:Label ID="Label19" runat="server" Text="Nacionalidad" Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="lblApellido" runat="server"></asp:Label>
            </td>
            <td class="style5">
                <asp:Label ID="lblDocumento" runat="server"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblCategoriaLegajo" runat="server"></asp:Label>
            </td>
            <td class="style7">
                <asp:Label ID="lblFechaNacimiento" runat="server"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblNacionalidad" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br class="style17" />
    <table class="style11">
        <tr>
            <td class="style19">
                <asp:Label ID="Label20" runat="server" Text="Tramo" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="Label22" runat="server" Text="Destino" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="Label23" runat="server" Text="Fecha" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style13" colspan="2">
                <asp:Label ID="Label24" runat="server" Text="Horario" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="Label21" runat="server" Text="Transporte" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="Label2" runat="server" Text="Medio de pago" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style19">
                <asp:Label ID="Label3" runat="server" Text="Precio" Style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;
            </td>
            <td class="style12">
                &nbsp;
            </td>
            <td class="style12">
                &nbsp;
            </td>
            <td class="style12" align="center">
                <asp:Label ID="Label25" runat="server" Text="Salida" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style12" align="center">
                <asp:Label ID="Label26" runat="server" Text="Llegada" Style="font-weight: 700"></asp:Label>
            </td>
            <td class="style14">
                &nbsp;
            </td>
            <td class="style14">
                &nbsp;
            </td>
            <td class="style14">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="lblTramo" runat="server"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="lblDestino" runat="server"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
            <td class="style15">
                <asp:Label ID="lblHoraSalida" runat="server"></asp:Label>
            </td>
            <td class="style14">
                <asp:Label ID="lblHoraLlegada" runat="server"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="lblTransporte" runat="server"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="lblMedioPago" runat="server"></asp:Label>
            </td>
            <td class="style12">
                <asp:Label ID="lblPrecio" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <asp:Label ID="Label33" runat="server" Text="Detalle de adelanto de viáticos" 
            style="font-weight: 700"></asp:Label>
    </div>
    <br/>
    <table style="width:100%;">
        <tr>
            <td class="style25">
                <asp:Label ID="Label29" runat="server" Text="Zona"></asp:Label>
            </td>
            <td class="style25">
                <asp:Label ID="Label30" runat="server" Text="Dias"></asp:Label>
            </td>
            <td class="style25">
                <asp:Label ID="Label31" runat="server" Text="$ Diarios"></asp:Label>
            </td>
            <td class="style25">
                <asp:Label ID="Label32" runat="server" Text="$ Total viáticos"></asp:Label>
            </td>
            <td class="style25">
                $ Eventuales</td>
            <td class="style25">
                $ Pasajes</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblZonas" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDias" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPesosDiarios" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPesosTotal" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPesosEventules" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPesosPasajes" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    </form>
</body>
</html>
