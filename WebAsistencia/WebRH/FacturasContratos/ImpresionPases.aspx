<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionPases.aspx.cs" Inherits="FacturasContratos_ImpresionPases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Impresión de Pase a Contabilidad</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div  align="right" style="font-size: x-small; font-family: 'ShelleyAllegro BT';">
                <b><a id="LeyendaPorAnio"></a></b>
            </div>
            
            <br />
            <img src="../../Imagenes/EscudoMDS.png" width="150" height="60" alt="" />

            <div id="nroPase"></div>
            <div id="fecha"></div>

            <br />
            <div runat="server" align="center" style="width: 100%">
                <div id="PanelImpresion" runat="server" align="center" style="width: 90%; height: 100%; font-size: small"></div>
            </div>
            
            <br />
            <input type="button" value="Imprimir" id="ocultar" />



        </div>
    </form>
</body>

    <script type="text/javascript">
        Backend.start(function () {
            $(document).ready(function () {
                $("#ocultar").click(function () {
                    window.print();        
                });
            });
        });
    </script>


</html>
