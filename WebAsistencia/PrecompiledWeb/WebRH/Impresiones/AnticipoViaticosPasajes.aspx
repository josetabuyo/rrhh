<%@ page language="C#" autoeventwireup="true" inherits="Impresiones_AnticipoViaticosPasajes, App_Web_bmi1lyey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style2
        {
            width: 221px;
        }
        .style3
        {
            width: 219px;
        }
        .style6
        {
            width: 306px;
            text-align: center;
        }
        .style7
        {
            width: 355px;
            font-family: Arial;
            font-size: small;
        }
        .style8
        {
            width: 380px;
        }
        .style9
        {
            width: 365px;
        }
        .style10
        {
            width: 431px;
        }
        .style12
        {
            font-family: Arial;
        }
        .style13
        {
            font-family: Arial;
            font-size: small;
        }
        .style14
        {
            width: 431px;
            font-family: Arial;
            font-size: small;
        }
        .style15
        {
            font-size: small;
        }
    </style>
</head>
<body>
    <div style="text-align: center" class="style12">
        <asp:Label ID="Label1" runat="server" Text="ANEXO II"></asp:Label>
    </div>
    <div style="text-align: center" class="style12">
        <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="SOLICITUD DE ANTICIPO DE VIATICOS Y PASAJES"></asp:Label>
    </div>
    <form id="form1" runat="server" style="border: thin solid #808080;">
    <div>
        <span class="style12"><span class="style15">
        <asp:Label ID="Label3" runat="server" 
            Text="Se solicita el anticipo de los fondos necesarios para el cumplimiento de la comisión de servicios que se detalla a continuación." 
            style="font-family: Arial; font-size: small"></asp:Label>
        </span></span>
        <br class="style13" />
        <br class="style13" />
        <div>
            <span class="style12"><span class="style15">
            <asp:Label ID="Label4" runat="server" Text="Agente:" 
                Style="font-weight: 700; font-size: small;"></asp:Label>
            </span></span>&nbsp;<span class="style12"><span class="style15"><asp:Label 
                ID="lblAgente" runat="server" style="font-family: Arial; font-size: small"></asp:Label>
            </span></span>
        </div>
        <div>
            <span class="style13">
            <asp:Label ID="Label5" runat="server" Text="Dependencia donde presta servicio:" Style="font-weight: 700"></asp:Label>
            </span>&nbsp;<span class="style13"><asp:Label ID="lblDependencia" 
                runat="server"></asp:Label>
            </span>
        </div>
        <div>
            <span class="style13">
            <asp:Label ID="Label6" runat="server" Text="Teléfono:" Style="font-weight: 700"></asp:Label>
            </span>&nbsp;<span class="style13"><asp:Label ID="lblTelefono" runat="server"></asp:Label>
            </span>
        </div>
        <table style="width: 100%;">
            <tr>
                <td class="style3">
                    <span class="style13">
                    <asp:Label ID="Label7" runat="server" Text="Categoria:" Style="font-weight: 700"></asp:Label>
                    </span>&nbsp;<span class="style13"><asp:Label ID="lblCategoria" runat="server"></asp:Label>
                    </span>
                </td>
                <td class="style2">
                    <span class="style13">
                    <asp:Label ID="Label8" runat="server" Text="Legajo N°:" Style="font-weight: 700"></asp:Label>
                    </span>&nbsp;<span class="style13"><asp:Label ID="lblLegajo" runat="server"></asp:Label>
                    </span>
                </td>
                <td>
                    <span class="style13">
                    <asp:Label ID="Label9" runat="server" Text="CUIT/CUIL N°:" Style="font-weight: 700"></asp:Label>
                    </span>&nbsp;<span class="style13"><asp:Label ID="lblCUIT" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <span class="style13">
        <asp:Label ID="Label10" runat="server" Text="Comisión a:" Style="font-weight: 700"></asp:Label>
        </span>&nbsp;<span class="style13"><asp:Label ID="lblComision" runat="server"></asp:Label>
        </span>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style8">
                <span class="style13">
                <asp:Label ID="Label11" runat="server" Text="Fecha de iniciación:" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblFechaInicio" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td>
                <span class="style13">
                <asp:Label ID="Label13" runat="server" Text="Hora:" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblHoraInicio" runat="server"></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <span class="style13">
                <asp:Label ID="Label12" runat="server" Text="Fecha de finalización:" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblFechaFin" runat="server"></asp:Label>
                </span>
            </td>
            <td>
                <span class="style13">
                <asp:Label ID="Label14" runat="server" Text="Hora:" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblHoraFin" runat="server"></asp:Label>
                </span>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="style8">
                <span class="style13">
                <asp:Label ID="Label15" runat="server" Text="Son:" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblDias" runat="server"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label16" runat="server" Text="días de viáticos a $" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPesosDiario" 
                    runat="server"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label17" runat="server" Text="diarios." Style="font-weight: 700"></asp:Label>
                </span>
            </td>
            <td>
                <span class="style13">
                <asp:Label ID="Label18" runat="server" Text="Total $" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblTotalPesos" runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style8">
                <span class="style13">
                <asp:Label ID="Label19" runat="server" Text="Pasajes / Combustible $" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPasajesPesos" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td>
                <span class="style13">
                <asp:Label ID="Label20" runat="server" Text="Eventuales $" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblEventualesPesos" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style8">
                <span class="style13">
                <asp:Label ID="Label21" runat="server" Text="Programa N°" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblProgramaNro" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td>
                <span class="style13">
                <asp:Label ID="Label22" runat="server" Text="Actividad N°" Style="font-weight: 700"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblActividadNro" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
    </table>
    <br class="style13" />
    <br class="style13" />
    <br class="style13" />
    <table style="width: 100%;">
        <tr>
            <td class="style6">
                <hr noshade="noshade" style="height: 1px; width: 80%" />
                <span class="style13">
                <asp:Label ID="Label23" runat="server" Style="text-align: center" Text="Firma del Superior"></asp:Label>
                </span>
            </td>
            <td style="text-align: center">
                <hr noshade="noshade" style="height: 1px; width: 80%" />
                <span class="style13">
                <asp:Label ID="Label24" runat="server" Text="Firma Funcionario Autorizante"></asp:Label>
                </span>
            </td>
        </tr>
    </table>
    <hr noshade="noshade" style="height: 1px; color: #808080" />
    <table style="width: 100%;">
        <tr>
            <td class="style7" valign="top">
                <asp:Label ID="Label25" runat="server" 
                    Text="APROBADO, pase a Departamento de Contaduría para liquidación del gasto, cumplido siga al Departamento de Tesorería para su pago por Fondo Rotatorio." 
                    style="font-family: Arial; font-size: small"></asp:Label>
            </td>
            <td style="text-align: center">
                <br class="style13" />
                <br class="style13" />
                <br class="style13" />
                <hr noshade="noshade" style="height: 1px; width: 80%" />
                <span class="style13">
                <asp:Label ID="Label26" runat="server" Text="Director General de Administración"></asp:Label>
                </span>
            </td>
        </tr>
    </table>
    <div>
        <hr style="height: 3px; color: #808080" />
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style9">
                <span class="style13">
                <asp:Label ID="Label27" runat="server" Style="font-weight: 700" Text="Son:"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblDiasDPEP" runat="server" Text="Label"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label29" runat="server" Style="font-weight: 700" Text="días de viáticos a $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPesosDiarioDPEP" 
                    runat="server"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label31" runat="server" Style="font-weight: 700" Text="diarios."></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style9">
                <span class="style13">
                <asp:Label ID="Label32" runat="server" Style="font-weight: 700" Text="Total $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblTotalPesosDPEP" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style9">
                <span class="style13">
                <asp:Label ID="Label33" runat="server" Style="font-weight: 700" Text="Pasajes $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPasajesPesosDPEP" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style9">
                <span class="style13">
                <asp:Label ID="Label34" runat="server" Style="font-weight: 700" Text="Eventuales $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblEventualesPesosDPEP" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td style="text-align: center">
                <hr noshade="noshade" style="height: 1px; width: 90%" />
                <span class="style13">
                <asp:Label ID="Label35" runat="server" Text="Director de Prog. y Ejecución Presupuestaria"></asp:Label>
                </span>
            </td>
        </tr>
    </table>
    <hr style="height: 3px; color: #808080" />
    <div>
        <span class="style12"><span class="style15">
        <asp:Label ID="Label36" runat="server" 
            Text="Recibí del Ministerio de Desarrollo Social, la suma de " 
            style="font-size: small; font-family: Arial"></asp:Label>
        <asp:Label ID="lblRecibiPesosLetra" runat="server"></asp:Label>
        </span></span>&nbsp;<span class="style12"><span class="style15"><asp:Label 
            ID="Label37" runat="server" Text="($" 
            style="font-size: small; font-family: Arial"></asp:Label>
        </span></span>&nbsp;<span class="style12"><span class="style15"><asp:Label 
            ID="lblRecibiPesosNro" runat="server" 
            style="font-size: small; font-weight: 700; font-family: Arial"></asp:Label>
        </span></span>&nbsp;<span class="style12"><span class="style15"><asp:Label 
            ID="Label39" runat="server" 
            Text=") con cargo de rendir cuenta, según el siguiente detalle:" 
            style="font-size: small; font-family: Arial"></asp:Label>
        </span></span>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="style10">
                <span class="style13">
                <asp:Label ID="Label40" runat="server" Style="font-weight: 700" Text="Son:"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblDiasRebici" runat="server"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label41" runat="server" Style="font-weight: 700" Text="días de viáticos a $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPesosDiarioRebici" 
                    runat="server"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="Label42" runat="server" Style="font-weight: 700" Text="diarios."></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style10">
                <span class="style13">
                <asp:Label ID="Label43" runat="server" Style="font-weight: 700" Text="Total $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblTotalPesosRebici" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style10">
                <span class="style13">
                <asp:Label ID="Label44" runat="server" Style="font-weight: 700" Text="Pasajes $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblPasajesPesosRebici" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <td class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style10">
                <span class="style13">
                <asp:Label ID="Label45" runat="server" Style="font-weight: 700" Text="Eventuales $"></asp:Label>
                </span>&nbsp;<span class="style13"><asp:Label ID="lblEventualesPesosRebici" 
                    runat="server"></asp:Label>
                </span>
            </td>
            <br class="style13" />
            <td style="text-align: center" class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style14">
                <asp:Label ID="Label47" runat="server" 
                    Text="Autorizo a la Dirección General de Administración a descontar de mis haberes, si dentro de las 72 hs., de cumplida la comisión no rindo el importe correspondiente al presente viático." 
                    style="font-size: small; font-family: Arial"></asp:Label>
            </td>
            <td style="text-align: center" class="style13">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
            </td>
            <td style="text-align: center">
                <hr noshade="noshade" style="height: 1px; width: 80%" />
                <span class="style13">
                <asp:Label ID="Label46" runat="server" Text="Agente Comisionado"></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
            </td>
            <td style="text-align: center" class="style13">
                <asp:Label ID="lblApellidoNombrePersona" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
