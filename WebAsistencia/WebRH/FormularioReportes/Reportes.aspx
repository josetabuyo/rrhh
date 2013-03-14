<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="FormularioReportes_Reportes" %>
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
	height: 100%;
}
.contenedor_separador{
	background-color: #FFF;
	height: 105px;
	display: inline-block;
}

.imagen_separador{
	padding-top: 50px;
}
.contenedor_consultas{
	margin-left: 400px;
	margin-top: 50px;
}
.link_viaticos{
	margin-top: 35px;
}


	


</style>

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
</head>

<body onload="MM_preloadImages('Imagenes/Botones/Botones Nuevos/cerrar_s2.png','Imagenes/Botones/Botones Listado/editar_s2.png','Imagenes/Botones/Botones Listado/imprimir_seleccion_s2.png','Imagenes/Botones/agregar_lista_s1_s2.png','Imagenes/Botones/Solicitud Viaticos/quitar_s2.png','Imagenes/Botones/Solicitud Viaticos/guardar_s1_s2.png','Imagenes/Botones/Solicitud Viaticos/limpiar_s2.png','Imagenes/Botones/buscar_s2.png','Imagenes/Botones/viaticos_area_s2.png','Imagenes/Botones/viaticos_provincia_s2.png','Imagenes/Botones/viatico_area_provincia_s2.png','Imagenes/Botones/viatico_persona_s2.png','Imagenes/Botones/ranking_agente_s2.png')">
<form id="form1" runat="server">
     <uc8:BarraMenu ID="BarraMenu" runat="server" />   
   

<div class= "contenedor_principal">
		<div class= "contenedor_separador"> 
        	<div class= "imagen_separador"> 
			<img src="../Imagenes/separador_consultas.png" width="340" height="54" alt="separador_consultas" />
			</div>
		</div>
            
            <div class= "contenedor_consultas">
            <div class= "link_viaticos">
<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('viaticos_area','','../Imagenes/Botones/viaticos_area_s2.png',1)"><img src="../Imagenes/Botones/viaticos_area_s1.png" name="viaticos_area" width="184" height="22" border="0" id="viaticos_area" /></a>
</div>
                
                <div class= "link_viaticos">
<a href="FReportePorProvincia.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('viaticos_provincia','','../Imagenes/Botones/viaticos_provincia_s2.png',1)"><img src="../Imagenes/Botones/viaticos_provincia_s1.png" name="viaticos_provincia" width="205" height="19" border="0" id="viaticos_provincia" /></a>
				</div>
                
                <div class= "link_viaticos">
<a href="FReportePorAreaYProvincia.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('viatico_area_provincia','','../Imagenes/Botones/viatico_area_provincia_s2.png',1)"><img src="../Imagenes/Botones/viatico_area_provincia_s1.png" name="viatico_area_provincia" width="276" height="22" border="0" id="viatico_area_provincia" /></a>
				</div>
                
                <div class= "link_viaticos">
<a href="ReportePorAgente.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('viaticos_persona','','../Imagenes/Botones/viatico_persona_s2.png',1)"><img src="../Imagenes/Botones/viatico_persona_s1.png" name="viaticos_persona" width="196" height="20" border="0" id="viaticos_persona" /></a>
</div>
                
                <div class= "link_viaticos">
<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('ranking_agente','','../Imagenes/Botones/ranking_agente_s2.png',1)"><img src="../Imagenes/Botones/ranking_agente_s1.png" name="ranking_agente" width="213" height="20" border="0" id="ranking_agente" /></a>
				</div>
            </div>

</div>

 </form>
</body>

</html>
