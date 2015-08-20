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
        
        #PanelImpresion>table
            {
                border-spacing:0px;  
                border-collapse:collapse;  
            }
        
        #PanelImpresion>table th, #PanelImpresion>table td
            {
                border:1px solid;    
            }
            
          
             
        @media print
        {
            #ocultar
            {
                display: none;
            }
            
            .APELLIDO
            {
              width: 400px;
            }
            
            .CUIL/CUIT
            {
              width: 400px;
            }
            
            .ESCALAFON
            {
              width: 300px;
            }
            
            .NIVEL
            {
              width: 100px;
            }
            
        }      
        
    </style>
   <%-- <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />--%>

</head>
<body>
    <form id="form1" runat="server" style="margin:10px">
    <div>
        
        <div align="right" 
            style="font-size: small; font-family: 'ShelleyAllegro BT';"> 
                <b><a id="LeyendaPorAnioDDJJ104"></a></b>
            </div>
        <br />
        <img src="../../Imagenes/EscudoMDS.png" width="200px" height="80px" alt="" />
        
        <div runat="server" align="center">
            <b><a id="NroDDJJ104" style="text-transform: uppercase"></a></b>
        </div>

        <br />
        <br />
        <br />
        <br />

        <div align="center" style="font-size: smaller"><b>FORMULARIO DE DECLARACION JURADA</b></div>
        <div align="center" style="font-size: smaller">CERTIFICACION DE SERVICIOS</div>
        <br />
        <div align="center" style="font-size: smaller"><b>DECISION ADMINISTRATIVA Nº 104/2001</b></div>
        <div align="center" style="font-size: smaller">(Resolución SME 34/01)<br/></div>
        <br />
        
        <div runat="server" align="center">
            <div style="width: 90%; font-size: small; text-align: justify;">Por el presente, certifico con carácter de Declaración Jurada, en mi condición de titular de la a <b><a id="AreaDDJJ104" style="text-transform: uppercase"></a></b> dependiente de <b><a id="AreaDependenciaDDJJ104" style="text-transform: uppercase"></a></b> ubicada en <b><a id="AreaDireccionDDJJ104" style="text-transform: uppercase"></a></b>, que las personas citadas en el listado adjuntos han cumplimentado la prestación de servicios correspondiente al mes de <b><a id="MesDDJJ104" style="text-transform: uppercase"></a></b> del año <b><a id="AnioDDJJ104" style="text-transform: uppercase"></a></b>.</div>
        </div>

        <br />
            <div runat="server" align="center" style="width: 100%">
                <div ID="PanelImpresion" runat="server" align="center" 
                    style="width: 90%; height:100%; font-size:small" ></div>
            </div>
        <br />
        <input type="button" onclick="window.print();" value="Imprimir" id="ocultar"  />

    </div>
    </form>
</body>
</html>

