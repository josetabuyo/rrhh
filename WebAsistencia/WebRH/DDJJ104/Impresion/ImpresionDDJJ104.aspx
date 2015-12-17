<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionDDJJ104.aspx.cs" Inherits="DDJJ104_Impresion_ImpresionDDJJ104" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">    
    <title>Impresión Declaración Jurada DDJJ104</title>

    <%= Referencias.Javascript("../../") %>
   
    <style type="text/css"  >
        
        .SaltoDePagina
        {
            PAGE-BREAK-AFTER: always;
        }
        
        #PanelImpresion>table
        {
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
         
        #fecha
        {
            text-align:right; 
            margin-right:100px;
            margin-top:20px;
        }
        
        #nroddjj104
        {
            float:right;
            margin-right: 60px;
        }
        
        .APELLIDO_Y_NOMBRE
        {
            width: 40%;
            font-size:10px;
        }          
        
        .CUIL_CUIT
        {
            width: 20%;
            text-align:center;
            font-size:10px;
        }

        .ESCALAFON_O_MODALIDAD_DE_CONTRATACION
        {
            width: 30%;
            text-align:center;
            font-size:10px;
        }

        .NIVEL_O_CATEGORIA
        {
            width: 10%;
            text-align:center;
            font-size:10px;
        }          

        .sort
		{
			font-size:11px;
		}
        
        @media print
        {
            #fecha
            {
                margin-right: 0px;
            }
        
            #nroddjj104
            {
                margin-right: 0px;
            }
        
            #ocultar
            {
                display: none;
            }
            
            .APELLIDO_Y_NOMBRE
            {
                width: 40%;
                font-size:10px;
            }          
        
            .CUIL_CUIT
            {
                width: 20%;
                text-align:center;
                font-size:10px;
            }
            
            .ESCALAFON_O_MODALIDAD_DE_CONTRATACION
            {
                width: 30%;
                text-align:center;
                font-size:10px;
            }
            
            .NIVEL_O_CATEGORIA
            {
                width: 10%;
                text-align:center;
                font-size:10px;
            }          
        
            .sort
		    {
			    font-size:11px;
		    }
            
            #PanelImpresion>table
        {
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
   <%-- <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />--%>

</head>
<body>
    <form id="form1" runat="server" style="margin:10px">
    <div>
        
        <div align="right" 
            style="font-size: x-small; font-family: 'ShelleyAllegro BT';"> 
                <b><a id="LeyendaPorAnioDDJJ104"></a></b>
            </div>
        <br />
        <img src="../../Imagenes/EscudoMDS.png" width="150px" height="60px" alt="" />
        
        <%--<div align="right">
            <b><a id="NroDDJJ104" style="text-transform: uppercase"></a></b>
        </div>--%>
        <div id="nroddjj104"></div>
        <div id="fecha">
        </div>
<%--        <asp:HiddenField ID="IdDDJJ104" runat="server" />
        <br />--%>
        <div align="center" style="font-size: x-small"><b>FORMULARIO DE DECLARACION JURADA</b></div>
        <div align="center" style="font-size: x-small">CERTIFICACION DE SERVICIOS</div>
        <br />
        <div align="center" style="font-size: x-small"><b>DECISION ADMINISTRATIVA Nº 104/2001</b></div>
        <div align="center" style="font-size: x-small">(Resolución SME 34/01)<br/></div>
        <br />
        
        <div runat="server" align="center">
            <div style="width: 90%; font-size: small; text-align: justify;">Por el presente, certifico con carácter de Declaración Jurada, en mi condición de titular de la <b><a id="AreaDDJJ104"></a></b> dependiente de <b><a id="AreaDependenciaDDJJ104"></a></b> ubicada en <b><a id="AreaDireccionDDJJ104"></a></b>, que las personas citadas en el listado adjuntos han cumplimentado la prestación de servicios correspondiente al mes de <b><a id="MesDDJJ104"></a></b> del año <b><a id="AnioDDJJ104"></a></b>.</div>
        </div>

        <br />
            <div runat="server" align="center" style="width: 100%">
                <div ID="PanelImpresion" runat="server" align="center" style="width: 90%; height:100%; font-size:small" ></div>
            </div>
        <br />
        <input type="button"  value="Imprimir" id="ocultar"  />
        
        <%--<input type="button" onclick="ImprimirPorImpresora();" value="Imprimir" id="ocultar"  />--%>
        <%--<div id="divBotonImprimir">
            <input id="boton_imprimir" type=button value="imprimir"/>
        </div>
        <div id="nro_DDJJ" style="display:none"></div>--%>
    </div>
    </form>
</body>

<script type="text/javascript">
    Backend.start(function () {
        $(document).ready(function () {
            $("#ocultar").click(function () {
                window.print();        

                //var idDDJJ = $("#IdDDJJ104");
                //Backend.MarcarDDJJ104Impresa(IdDDJJ104.innerText, 3)
//                .onSuccess(function (respuesta) {
//                if (respuesta) {            
//                }
//                })
//                .onError(function (error, as, asd) {
//                    alertify.alert(error);
//                });
            });
        });
    });
   
</script>
</html>

