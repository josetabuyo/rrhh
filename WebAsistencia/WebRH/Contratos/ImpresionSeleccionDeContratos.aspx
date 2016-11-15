<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionSeleccionDeContratos.aspx.cs"
    Inherits="Contratos_ImpresionSeleccionDeContratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impresión de informe</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="right" style="width: 95%; font-size: x-small; font-family: 'ShelleyAllegro BT';">
        <b><a id="LeyendaPorAnio"></a></b>
    </div>
    <br />
    <img src="../Imagenes/EscudoMDS.png" width="150px" height="60px" alt="" />
    
    <div id="Fecha" align="right" style="width: 95%"></div>
    
    <div align="center" style="font-size: medium">
        <b>Renovación de contratos 2017</b></div>
    <div align="center" style="font-size: medium">
        Informe de solicitud Nº <b><a id="NroInforme"></a></b>.</div>
    <br />
    <div runat="server" align="center" style="width: 100%">
        <div id="PanelImpresion" runat="server" align="center" style="width: 90%; height: 100%;font-size: small"></div>
       
    </div>
    <br />
    <input type="button" value="Imprimir" id="ocultar" />
    </form>
</body>
</html>
