<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionDDJJ104.aspx.cs" Inherits="DDJJ104_Impresion_ImpresionDDJJ104" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">    
    <title>Impresión Declaración Jurada DDJJ104</title>
    <style>
        .SaltoDePagina
        {
            page-break-after: always;
        }
        
        @media print
        {
            #ocultar
            {
                display: none;
            }
        }
            
        
        
    </style>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="margin:10px">
    <div>
        
        <div align="right" 
            style="font-size: medium; font-family: 'ShelleyAllegro BT';">Leyenda...</div>
        <br />
        <img src="../../Imagenes/EscudoMDS.png" width="200px" height="80px" alt="" />
        
        <br />

        <div align="center" style="font-size: small">FORMULARIO DE DECLARACION JURADA</div>
        <div align="center" style="font-size: small">CERTIFICACION DE SERVICIOS</div>
        <br />
        <div align="center" style="font-size: small">DECISION ADMINISTRATIVA Nº 104/2001</div>
        <div align="center" style="font-size: small">(Resolución SME 34/01)<br/></div>
        <br />
        <div style="font-size: medium">Por el presente, certifico con carácter de Declaración Jurada, en mi condición de titular de la a <b><a id="AreaDDJJ104" style="text-transform: uppercase"></a></b> dependiente de <b><a id="AreaDependenciaDDJJ104" style="text-transform: uppercase"></a></b> ubicada en <b><a id="AreaDireccionDDJJ104" style="text-transform: uppercase"></a></b>, que las personas citadas en el listado adjuntos han cumplimentado la prestación de servicios correspondiente al mes de <b><a id="MesDDJJ104" style="text-transform: uppercase"></a></b> del año<b><a id="AnioDDJJ104" style="text-transform: uppercase"></a></b>.</div>

        <br />
            <div ID="PanelImpresion" runat="server" align="center" style="width: 100% ; height:100%"></div>
        <br />
        <input type="button" onclick="window.print();" value="Imprimir" id="ocultar" />

    </div>
    </form>
</body>
</html>

