<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalculoDeLicenciaOrdinaria.aspx.cs"
    Inherits="FormulariosDeLicencia_CalculoDeLicenciaOrdinaria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        * 
        {
            box-sizing: border-box;
        }
        table 
        {
            border-spacing: 0;
            border-collapse: collapse;
            background-color: transparent;
            border-color: grey;
        }
        
        table th 
        {
            background-color: #f5f5f5;
        }
        
        th 
        {
            text-align: left;
            font-weight: bold;
        }
        
        table th, table td 
        {
            padding: 5px 15px;
            //border: 1px solid #dddddd;
        }
        body 
        {
            color: #333;
            font-size: 16px;
            line-height: 1.5em;
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif !important;
        }
        table td {

            //padding:0px;
            //border:0px;
        }
        
        .usufructo-a 
        {
            background-color: #C4FFDF;
        }
        
        .usufructo-b 
        {
            background-color: #C4DFFF;
        }
        
        .autorizacion-a 
        {
            background-color: #C4C4C4;
        }
        
        .autorizacion-b 
        {
        }
        
        .perdidas 
        {
            background-color: #FFAFA0;
        }
        
        .vencidas
        {
            background-color: #88FF00;
        }

    </style>
    <script type="text/javascript" src="Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label>Csv Dnis</asp:Label><br />
                <asp:TextBox ID="textbox_dni" runat="server"></asp:TextBox>
                <asp:Button runat="server" Text="Buscar" /><br />
                <asp:CheckBox Text="Persistir Resultados" runat="server" ID="ChkPersistirResultados" Checked="false" />
                <small>(LIC_LogSaldosCalculoLicencia / LIC_LogAnalisisCalculoLicencia)</small>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Table ID="tabla_analsis" runat="server">
                </asp:Table>
            </td>
            <td>
                <asp:Table ID="tabla_saldo" runat="server">
                </asp:Table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
