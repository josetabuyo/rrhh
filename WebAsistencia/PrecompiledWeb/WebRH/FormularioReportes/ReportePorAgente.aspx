<%@ page language="C#" autoeventwireup="true" inherits="FormularioReportes_ReportePorAgente, App_Web_4uazzpdl" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	background-color: #CCC;

}
.barra_menu_fondo {
    background-color: #003;
    height: 120px;
}

.barra_menu_fondo a {
    text-decoration: none;
}

.barra_menu_contenedor {
    position: absolute;
    left: 50%;
    width: 1024px;
    margin-left: -512px;
    margin-top: 10px;
}

.logo_sistema {
    float: left;
}

.contenedor_logos_derecha
{
    float:right;  
} 

.logo_ministerio {
    margin-left: 25px;
}

.bloque_inferior
{
    margin-top: 85px;
    font-size: 15px;
    font-family: Arial, Helvetica, sans-serif;    
}
.label_bienvenido {
    
    color: #FFF;
    clear: both;
    display:inline;
}
.label_usuario {
    color: #09F;
    display:inline;
}

.botones_menu_usuario
{
    float:right;
}

.boton_menu_usuario {
    margin-left:5px;
}
.contenedor_principal{
	position: absolute;
	left: 50%;
	width: 1024px;
	margin-left: -512px;
	background-color: #FFF;
	height:100%;
}
.contenedor_volver_consulta{
	margin-left: 15px;
}
.contenedor_separador{
	margin-top: 50px;
}
.contenedor_volver_consulta{
	display: inline-block;
	margin-left: 880px;
	margin-top: -20px;
}
.contenedor_consulta{
	width: 32%;
	height: 350px;
	background-color: #999;
	display: inline-block;
	vertical-align: top;
}
.contenedor_tabla{
	width: 63%;
	height: 350px;
	display: inline-block;
	margin-left: 40px;
	vertical-align: top;
	margin-top: 25px;
}
.contenido_datos_agente{
	margin-top: 35px;
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 12px;
	font-weight: bold;
	color: #000;
}
.datos_dni{
	margin-top: 10px;
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 11px;
	color: #000;
}
.contenido_periodo{
	margin-top: 35px;
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 12px;
	font-weight: bold;
	color: #000;
}
.contenido_fecha{
	margin-top: 10px;
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 11px;
	color: #000;
	display: inline-block;
}

.contenido_tab{
    padding_left:25px;
	display: inline-block;
	padding-top: 10px;
}
.contenedor_calendario{
	display:inline-block;
}
.contenedor_boton_buscar{
	margin-left: 250px;
	margin-top: 20px;
}

.tabla_datos_agente{

	width:640px;
}
.encabezado {
	font-family: "Humnst777 BT";
	font-size: 10px;
	color: #FFF;
}
.contenido_tabla {
	font-family: "Humnst777 BT";
	font-size: 10px;
	color: #000;
}
.periodo_tabla_datos_agente{
	font-family: "Humnst777 BT";
	font-size: 12px;
	color: #000;
	font-weight: bold;
	margin-left: 10px;
}
.contenedor_subrayado{
	margin-top: 3px;
	margin-left: 10px;
}
.contenedor_exportar_excel{
	text-align: right;
	margin-top: 15px;
	font-family: "Humnst777 BT";
	font-size: 12px;
	color: #06C;
}


</style>
<script src="SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
<script src="SpryAssets/SpryValidationTextarea.js" type="text/javascript"></script>
<script type="text/javascript">
    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
        }
    }

    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }

    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
</script>
<link href="SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
<link href="SpryAssets/SpryValidationTextarea.css" rel="stylesheet" type="text/css" />
<link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
</head>

<body onload="MM_preloadImages('Imagenes/Botones/Botones Nuevos/cerrar_s2.png','Imagenes/Botones/Botones Listado/editar_s2.png','Imagenes/Botones/Botones Listado/imprimir_seleccion_s2.png','Imagenes/Botones/agregar_lista_s1_s2.png','Imagenes/Botones/Solicitud Viaticos/quitar_s2.png','Imagenes/Botones/Solicitud Viaticos/guardar_s1_s2.png','Imagenes/Botones/Solicitud Viaticos/limpiar_s2.png','Imagenes/Botones/Solicitud Viaticos/agregar_lista_s2.png','Imagenes/Botones/buscar_s2.png','Imagenes/Botones/volver_consulta_s1_s2.png','Imagenes/Botones/volver_consulta_s2.png')">

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server" />
     <uc8:BarraMenu ID="BarraMenu" runat="server" /> 
     
     
     <div class="contenedor_principal"> 
        	<div class= "contenedor_separador">
            <img src="../Imagenes/separador_viaticos_agentes.png" width="339" height="60" alt="viaticos_agente" />
            </div>
            <div class="contenedor_volver_consulta"><a href="../FormularioReportes/Reportes.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('volver_consulta','','../Imagenes/Botones/volver_consulta_s2.png',1)"><img src="../Imagenes/Botones/volver_consulta_s1.png" width="140" height="16" id="volver_consulta" /></a></div>
          <div class= "contenedor_consulta"> 
            		<div class="contenido_datos_agente"> DATOS DEL AGENTE
                    </div>
                    <div class="datos_dni"> DNI: <asp:TextBox ID="textbox_dni" runat="server"></asp:TextBox>
                    </div>
                    <div class="contenido_periodo"> PERIODO
                    </div>
                    <div class="contenido_fecha"> Fecha Desde:  <asp:TextBox ID="TBFechaDesde" runat="server" CssClass="contenido_tab" name = "TBFechaDesde" MaxLength="10" />
                        <cc1:CalendarExtender ID="TextBox1_CalendarExtender" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaDesde" />
                    </div>
                    <div class="contenedor_calendario"> <img src="../Imagenes/Botones/calendario_s1.jpg" width="23" height="23" alt="calendario" /></div>
                    
					<div class="contenido_fecha"> Fecha Hasta:  <asp:TextBox ID="TBFechaHasta"  runat="server" CssClass="contenido_tab" MaxLength="10" />
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaHasta" />
                   </div>
                    <div class="contenedor_calendario"><img src="../Imagenes/Botones/calendario_s1.jpg" width="23" height="23" alt="calendario" /></div>
                    <div class="contenedor_boton_buscar"> 
                        <asp:Button ID="btn_buscar" runat="server" Width="58px" Height="23px" onclick="Button1_Click" Text="" />
                        <%--<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('buscar','','Imagenes/Botones/buscar_s2.png',1)">
                        <img src="../Imagenes/Botones/buscar.png" name="buscar" width="54" height="22" border="0" id="buscar" />
                        </a>--%>
                    </div>
            </div>
            
            <div class= "contenedor_tabla">
            		
                        <div class="periodo_tabla_datos_agente"> PERIODO </div>
                        <div class="periodo_tabla_datos_agente"><asp:Label ID="label_fecha_desde" runat=server Text="" /><asp:Label ID="label_fecha_hasta" runat=server Text="" /></div>
                    <div class="contenedor_subrayado"> <img src="../Imagenes/subrayado.png" width="640" height="3" alt="subrayado" /></div>   
                    	<div class="contenedor_exportar_excel"> <a href="#">Exportar a Excel</a>
                        </div>

                           
                    <asp:Table ID="TablaResultado" runat="server"></asp:Table>
                    
         <%--     <div class= "tabla_datos_agente">
                    <table width="640" border="0" align="left">
                    <tr>
                    <td width="63" height="15" align="center" bgcolor="#000033" class= "encabezado">DNI</td>
                    <td width="114" height="15" align="center" bgcolor="#000033" class= "encabezado">NOMBRE DEL AGENTE</td>
                    <td width="255" height="15" align="center" bgcolor="#000033" class= "encabezado">ÁREA</td>
                    <td width="68" height="15" align="center" bgcolor="#000033" class= "encabezado">CANT. DE VIÁTICOS</td>
                    <td width="75" height="15" align="center" bgcolor="#000033" class= "encabezado">MONTO DE VIÁTICO</td>
                    <td width="39" height="15" align="center" bgcolor="#000033" class= "encabezado">DÍAS</td>
                    </tr>
                    <tr>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">29.753.914</td>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">CALCAGNO, Agustín Emanuel</td>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">Dir. de Diseño de Desarrollo Organizacional para la Gestión de Personas</td>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla"> 20</td>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">$20.000</td>
                    <td height="30" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">40</td>
                    </tr>
                    </table>
              </div>--%>
        </div>
</div>


    </form>
</body>
</html>
