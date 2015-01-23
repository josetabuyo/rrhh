<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VistaPreliminar.aspx.cs" Inherits="FormularioConcursar_VistaPreliminar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title></title>
     <%= Referencias.Css("../")%>        
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
<a class="general atributos" style="float: right; margin: 20px; font-size:25px;" href="PanelDeControl.aspx" >Volver</a>
    <form id="form1" runat="server">
    
    <div class="contenedor_concursar">

<hr class="linea-top"/>

<div class="principal">
<div id="imprimir">
    <p class="encabezado">PRESENTACIÓN CURRICULUM VITAE</p>

        <div class="info-gral posicion fondo_form">
	        <p class="titulos degrade"><span class="letra-bold">I.</span> Información Personal</p>
	        <p class="nombre-h"><span id="cv_apellido" class="atributo-apelido"></span><span id="cv_nombre"></span></p>
            <br>
	        <p class="general"><span class="atributos">DNI: </span><span id="cv_dni"></span></p>
	        <p class="general"><span class="atributos">Estado Civil: </span><span id="cv_estadoCivil"></span></p>
	        <p class="general"><span class="atributos">Fecha de Nacimiento: </span><span id="cv_fechNac"></span></p>
	        <p class="general"><span class="atributos">Lugar de Nacimiento: </span><span id="cv_lugarNac"></span></p>
	        <p class="general"><span class="atributos">Nacionalidad: </span><span id="cv_nac"></span></p>
	        <p class="general"><span class="atributos">Domicilio Personal: </span><span id="cv_domPersonal"></span></p>
	
	
        </div>

        <div class="info-notif-avisos posicion fondo_form">
	        <p class="titulos degrade"><span class="letra-bold">II.</span> Información Requerida para Recibir Notificaciones y Avisos</p>
	        <p class="general"><span class="atributos">Domicilio: </span><span id="cv_domLegal">Italia 465 - Timbre 3 - Lomas de Zamora - C.P: 1832</span></p>
	        <p class="general"><span class="atributos">Teléfonos: </span><span id="cv_telefono">4281-2685 / 15 5059 5930</span></p>
	        <p class="general"><span class="atributos">Corro Electrónico: </span><span id="cv_mail">ayanvero@gmail.com</span></p>
	    </div>

        <div id="caja_antecedentes_academicos" style="page-break-before:always"></div>
        <div id="caja_actividades_decentes" ></div>
        <div id="caja_eventos_academicos"></div>
        <div id="caja_publicaciones"></div>
        <div id="caja_matriculas"></div>
        <div id="caja_instituciones" ></div>
        <div id="caja_experiencias_laborales"></div>
        <div id="caja_otras_aptitudes" ></div>

        </div>

        <div class="div-pie-tabla">
            <p class="p-imprimir"><button class="btn btn-primary" onclick="ImprimirCVPostulado()">Imprimir Curriculum</button></p>
        </div>
    	
</div>




</div>
<a class="general atributos" style="float: right; margin: 20px; font-size:25px;" href="PanelDeControl.aspx" >Volver</a>

        <asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="FichaDeclaracionJurada.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    Backend.start(function () {
        $(document).ready(function () {
            curriculum = JSON.parse($('#curriculum').val());
            FichaDeclaracionJurada.dibujarCV(curriculum);
        });
    });

    function ImprimirCVPostulado() {

        var ventana_impresion = window.open();
        var div_para_imprimir = document.getElementById('imprimir');
        var texto_de_impresion = div_para_imprimir.innerHTML;
        texto_de_impresion = texto_de_impresion.replace(/sombra_y_redondeado/g, '');
        texto_de_impresion = texto_de_impresion.replace(/antec-academ posicion fondo_form/g, 'antec-academ fondo_form');
        texto_de_impresion = texto_de_impresion.replace("motivos-cargo", "");

        ventana_impresion.document.open();
        ventana_impresion.document.write('<html><title>::Previsualización::</title><link rel="stylesheet" type="text/css" href="EstilosPostular.css" /></head><body onload="window.print()">')
        ventana_impresion.document.write(texto_de_impresion);
        ventana_impresion.document.write('</html>');
        ventana_impresion.document.close();


    }

</script>

</html>

