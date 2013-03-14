<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FReportePorProvincia.aspx.cs" Inherits="FormularioReportes_FReportePorProvincia" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
.contenedor_imagen_separador{
	margin-top: 50px;
	display: inline-block;
}
.contenedor_volver_consulta{
	display: inline-block;
	margin-left: 880px;
}
.contenedor_consulta{
	width: 32%;
	height: 450px;
	background-color: #999;
	display: inline-block;
	vertical-align: top;
}
.contenedor_tabla{
	width: 60%;
	height: 350px;
	display: inline-block;
	margin-left: 40px;
	vertical-align: top;
	margin-top: 25px;

}
.contenedor_provincia{
	margin-top: 35px;
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 12px;
	font-weight: bold;
	color: #000;
	
}
.selector_provincias{
	margin-top: 10px;
}
.contenedor_periodo{
	margin-top: 45px;
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
.fecha_hasta{
	
	margin-left: 35px;
	font-family: "Humnst777 BT";
	font-size: 11px;
	color: #000;
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
	margin-top: 30px;
}
.periodo_datos_provincia{
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
	margin-top: 15px;
	margin-left: 520px;
	font-family: "Humnst777 BT";
	font-size: 12px;
	color: #06C;
	display:inline-block;
}
.tabla_area_provincia{

	 width: 640px;
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
.contenedor_scroll{
	margin-right: 135px;
	margin-top: 5px;
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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server" />
        <uc8:BarraMenu ID="BarraMenu" runat="server" />   

        <div class="contenedor_principal">
        
            <div class="contenedor_imagen_separador">
                <img src="../Imagenes/separador_viaticos_provincia.png" width="339" height="60" alt="viaticos_provincia" />
            </div>
                <div class="contenedor_volver_consulta"><a href="../FormularioReportes/Reportes.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('volver_consulta','','../Imagenes/Botones/volver_consulta_s2.png',1)"><img src="../Imagenes/Botones/volver_consulta_s1.png" name="volver_consulta" width="140" height="16" border="0" id="volver_consulta" /></a>
                </div>
                       
                       
        <div class="contenedor_consulta">
        	<div class="contenedor_provincia"> PROVINCIA 
            <div class="contenedor_scroll" style="overflow-y: auto; height: 160px" >
            <div class="selector_provincias">
              
            <asp:ListBox ID="DDLProvincias" Width="150px" runat="server" 
            SelectionMode="Multiple" Rows="7"></asp:ListBox>
  
            </div>
          </div>
          </div>
          <div class="contenedor_periodo"> PERIODO
          </div>
          <div class="contenido_fecha"> Fecha Desde:  <asp:TextBox ID="TBFechaDesde" runat="server" CssClass="contenido_tab" name = "TBFechaDesde" MaxLength="10" />
            <cc1:CalendarExtender ID="TextBox1_CalendarExtender" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaDesde" />
          </div> 
          
          <div class="contenedor_calendario"><img src="../Imagenes/Botones/calendario_s1.jpg" width="23" height="23" alt="calendario" /> </div>
          <div class="contenido_fecha"> Fecha Hasta:  <asp:TextBox ID="TBFechaHasta"  runat="server" CssClass="contenido_tab" MaxLength="10" />
            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaHasta" />
 
          </div>

          <div class="contenedor_calendario"> <img src="../Imagenes/Botones/calendario_s1.jpg" width="23" height="23" alt="calendario" /></div>
          <div class="contenedor_boton_buscar">
                <asp:Button ID="btn_buscar" runat="server" onclick="Button1_Click" Width="58" Height="23" Text="" />
          </div>
          <%--<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('boton_buscar','','../Imagenes/Botones/buscar_s2.png',1)"><img src="../Imagenes/Botones/buscar.png" name="boton_buscar" width="54" height="22" border="0" id="boton_buscar" /></a>--%>
        </div>
        
        
        <div class="contenedor_tabla">
        		<div class="periodo_datos_provincia"> PERIODO </div>
                <div class="periodo_datos_provincia"><asp:Label ID="label_fecha_desde" runat=server Text="" /><asp:Label ID="label_fecha_hasta" runat=server Text="" /></div>
                <div class="contenedor_subrayado"> <img src="../Imagenes/subrayado.png" width="640" height="3" alt="subrayado" /></div>
   		  <div class="contenedor_exportar_excel"> <a href="#">Exportar a Excel</a></div>
                
<%--                <div class="tabla_area_provincia">
                <table width="640" border="0">
                <tr>
                <td width="166" height="25" align="center" bgcolor="#000033" class= "encabezado">PROVINCIA</td>
                <td width="182" height="25" align="center" bgcolor="#000033" class= "encabezado">CANTIDAD DE VIATICOS</td>
                <td width="145" height="25" align="center" bgcolor="#000033" class= "encabezado">MONTO TOTAL</td>
                <td width="129" height="25" align="center" bgcolor="#000033" class= "encabezado">TOTAL DÍAS</td>
                </tr>
                <tr>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">Cordoba</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">15</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">$3500</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">20</td>
                </tr>
                <tr>
                <td height="20" align="center" bgcolor="#FFFFFF" class= "contenido_tabla">Misiones</td>
                <td height="20" align="center" bgcolor="#FFFFFF" class= "contenido_tabla">12</td>
                <td height="20" align="center" bgcolor="#FFFFFF" class= "contenido_tabla">$2200</td>
                <td height="20" align="center" bgcolor="#FFFFFF" class= "contenido_tabla">18</td>
                </tr>
                <tr>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">Catamarca</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">13</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">$3000</td>
                <td height="20" align="center" bgcolor="#CCCCCC" class= "contenido_tabla">20</td>
                </tr>
                </table>--%>

            <div class= "detalle_viatico_cuerpo_detalle">
                 <asp:Table ID="TablaResultado" runat="server"></asp:Table>
            </div>
       
                

          </div>

		</div> 

    <div>
    
    </div>
          
        
      
       
    </form>
</body>
</html>
