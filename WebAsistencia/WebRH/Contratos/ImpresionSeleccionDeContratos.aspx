<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionSeleccionDeContratos.aspx.cs"
    Inherits="Contratos_ImpresionSeleccionDeContratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impresión de informe</title>

    <%--<script type="text/javascript" src="../scripts/bootstrap/js/jquery.js">--%>
    <%--<%= Referencias.Javascript("../../") %>--%>
    
    <style type="text/css"  >
        
        .SaltoDePagina
        {
            PAGE-BREAK-AFTER: always;
        }
        
        #PanelImpresion>table
        {
            width:100%;
            border-spacing:0px;  
            border-collapse:collapse; 
            position:relative; 
        }   
        
        #PanelImpresion>table tr
        {
            page-break-inside:avoid;
            page-break-after:always;
            height:15px;
        }        
        
        #PanelImpresion>table th, #PanelImpresion>table td
        {
            border:1px solid;               
        }        
           
        .celda
        {
             page-break-inside:avoid;
             page-break-after:always;
        }
         
        
        
        @media print
        {

        #ocultar
        {
            display: none;
        }
                        
        #PanelImpresion>table
        {
            width:100%;
            border-spacing:0px;  
            border-collapse:collapse; 
            position:relative; 
        }   
        
        #PanelImpresion>table tr
        {
            page-break-inside:avoid;
            page-break-after:always;
            
        }        
        
        #PanelImpresion>table th, #PanelImpresion>table td
        {
            border:1px solid;               
        }        
           
        .celda
        {
             page-break-inside:avoid;
             page-break-after:always;
        }
            
        }      
        
    </style>




</head>
<body>
    <form id="form1" runat="server">
    <div align="right" style="width: 95%; font-size: small; font-family: 'ShelleyAllegro BT';">
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
    <input type="button" value="Imprimir" id="ocultar" onclick="window.print()" />
    </form>
</body>



<%--
<script type="text/javascript">
    Backend.start(function () {
        $(document).ready(function () {
            $("#ocultar").click(function () {
                window.print();

            });
        });
    });
   
</script>
--%>

</html>
