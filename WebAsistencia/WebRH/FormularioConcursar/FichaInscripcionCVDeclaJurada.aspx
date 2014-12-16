﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FichaInscripcionCVDeclaJurada.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
<a class="general atributos" style="float: right; margin: 20px; font-size:25px;" href="PanelDeControl.aspx" >Volver</a>
    <form id="form1" runat="server">
    
    <div class="contenedor_concursar">
    
<p class="top-header">Recuerde firmar todas y cada una de las hojas que integran su Ficha de inscripción.<br>La ausencia de su firma invalida la valoración del antecedente declarado.</p>

<hr class="linea-top"/>

<div class="principal">
<p class="encabezado">FICHA DE INSCRIPCIÓN<br>PRESENTACIÓN CURRICULUM VITAE<br>DECLARACIÓN JURADA</p>

<p class="general oferta-empleo"><span class="atributos">Postulación Nº: </span><span id="num_postulacion"></span></p>

<div class="tabla sombra_y_redondeado">
    <table class="tabla-inscripcion">
        <tbody>
            <tr>
                <td style="width: 60%"><p class="general p-tabla"><span class="atributos">Oferta de Empleo Nº: </span><span id="numero_puesto"></span></p></td>
                <td style="width: 40%"><p class="general p-tabla"><span class="atributos">Tipo de Convocatoria: </span><span id="puesto_tipo"></span></p></td>
            </tr>
            <tr>
                <td colspan="2" class="tabla-inscripcion-td" ><p class="general p-tabla"><span class="atributos">Denominación del Cargo: </span><span id="puesto_denominacion"></span></p></td>
            </tr>
	
            <tr>
                <td colspan="2" class="tabla-inscripcion-td"><p class="general p-tabla"><span class="atributos">Agrupamiento: </span><span id="puesto_agrupamiento"></span></p></td>
            </tr>
    
            <tr>
                <td><p class="general p-tabla"><span class="atributos">Nivel Escalafonario: </span><span id="puesto_nivel"></span></p></td>
                <td><p class="general p-tabla"><span class="atributos">Nivel de Jefatura: </span><span id="puesto_jefatura"></span></p></td>
            </tr>
        </tbody>
    </table>
</div>


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
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">II.</span> Información Requerida para Recibir Notificaciones y Avisos</p>
	<p class="general"><span class="atributos">Domicilio: </span><span id="cv_domLegal">Italia 465 - Timbre 3 - Lomas de Zamora - C.P: 1832</span></p>
	<p class="general"><span class="atributos">Teléfonos: </span><span id="cv_telefono">4281-2685 / 15 5059 5930</span></p>
	<p class="general"><span class="atributos">Corro Electrónico: </span><span id="cv_mail">ayanvero@gmail.com</span></p>
	</div>

<div id="caja_antecedentes_academicos" ></div>
<div id="caja_actividades_decentes" ></div>
<div id="caja_eventos_academicos"></div>
<div id="caja_publicaciones"></div>
<div id="caja_matriculas"></div>
<div id="caja_instituciones" ></div>
<div id="caja_experiencias_laborales"></div>
<div id="caja_otras_aptitudes" ></div>

   
	<!--
    
     <p class="titulos degrade sombra_y_redondeado"> Publicaciones</p>
	<div class="tit-pos">
	<p class="sub-titulos">Publicaciones o Trabajos de Investigación</p>
	<hr class="lineas-subraya"/>
    <p class="general"><span class="atributos">- Publicación: </span>
	"Imágenes Forenses" - Instituto Universitarios de la Policía Federal Argentina, Inédito. Año 2007.</p>
	</div>
	
     <p class="titulos degrade sombra_y_redondeado"> Matriculas</p>
	<div class="tit-pos">
	<p class="sub-titulos">Matrícula Profesional</p>
	<hr class="lineas-subraya"/>
	<p class="general"><span class="atributos">- Matrícula Profesional Nº: </span>11.111 - Diseñadora de Imagen y Sonido (Universidad de Buenos Aires)</p>
	</div>
	
	<div class="tit-pos">
	<p class="sub-titulos">Pertenencia a Instituciones Académicas o Profesionales Relevantes</p>
	<hr class="lineas-subraya"/>
	<p class="no-hay-datos">No hay datos cargados</p>	
	</div>
	

<div class="exp-lab-rel posicion degrade_modulo sombra_y_redondeado">
<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">IV.</span> Experiencias Laborales Relevantes</p>
	
    <div class="tit-pos">
	<p class="sub-titulos">Ocupaciones</p>
	<hr class="lineas-subraya"/>
	
	<p class="general"><span class="atributos">- 01/01/2007 al 31/12/2010</span>- Ámbito Privado - Contratado - Empresa Sarasa - Técnico Administrativo
	<p class="general"><span class="atributos">- 01/01/2005 al 31/12/2007</span>- Ámbito Privado - Contratado - Empresa La lalala - Recepcionista
	<span class="general"><span class="atributos">- 01/01/2010 al 31/12/2013</span>- Ámbito Privado - Contratado - Empresa Farafa - Encargado de Área
	</div>

</div>

<div class="otras-aptitudes posicion degrade_modulo sombra_y_redondeado">

	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">V.</span> Otras Aptitudes Laborales</p>
	
    <div class="tit-pos">
	<p class="sub-titulos">Idiomas Extranjeros</p>
	<hr class="lineas-subraya"/>
	<p class="general"><span class="atributos">- Inglés: </span> Avanzado</p>
    <p class="general"><span class="atributos">- Francés: </span> Intermedio</p>
    <p class="general"><span class="atributos">- Italiano: </span> Básico</p>
	</div>

    <div class="tit-pos">
	<p class="sub-titulos">Competencias Informáticas</p>
	<hr class="lineas-subraya"/>
	<p class="general"><span class="atributos">- Microsoft Office 2013: </span> Manejo avanzando</p>
    <p class="general"><span class="atributos">- Microsoft Windows XP/7/8: </span> Básico</p>
    <p class="general"><span class="atributos">- Adobe Photoshop Ver 14.1.2: </span> Avanzado</p>
    </div>

    <div class="tit-pos">
	<p class="sub-titulos">Otras Capacidades Personales</p>
	<hr class="lineas-subraya"/>
	<p class="no-hay-datos">No hay datos cargados</p>
	</div>

    <div class="tit-pos">
	<p class="sub-titulos">Otras Observaciones</p>
	<hr class="lineas-subraya"/>
	<p class="no-hay-datos">No hay datos cargados</p>
    </div>
</div>-->

<div class="tit-pos posicion fondo_form">
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">VI.</span> Motivos por los que se Postula al Cargo</p>
		<p id="motivo_postulacion" class="motivos-cargo"></p>
	</div>

<div class="posicion">
		<div class="decla-jurada"><p style="text-align:center; font-size:12px; font-weight:bold;"><span style="font-size: 13px">DECLARACIÓN JURADA Y CONSTANCIA DE RECEPCIÓN Y ACEPTACIÓN DEL REGLAMENTO Y BASES DEL CONCURSO</span></p>
		    Declaro bajo juramento que:<br/>
		    <span class="letra-bold">a)</span> Los datos consignados en la siguiente Solicitud y Ficha de Inscripción son completos, verdaderos y atinentes al perfil del puesto de trabajo o función a concursar;<br>
		    <span class="letra-bold">b)</span> Que los certificados, fotocopias y demás documentación entregada es auténtica o copia fiel de sus respectivos originales;<br> 
		    <span class="letra-bold">c)</span> Reúno los requisitos previstos en los Artículos 4º y 5º del Anexo de la Ley Nº 25.164, y su Decreto reglamentario Nº1.421/2002, y artículos concordantes del Convenio Colectivo de Trabajo General de la Administración Pública Nacional (Decreto Nº214/06), a los que acepto conocer y aceptar;<br>
		    <span class="letra-bold">d)</span> Reúno los requisitos para acceder al Agrupamiento y Nivel Escalafonario del cargo a concursar, previstos por el Sistema Nacional de Empleo Público (Decreto Nº2.098/08);<br>
		    <span class="letra-bold">e)</span> Conozco y acepto los términos de la presente Resolución de la SECRETARIA DE GESTIÓN PÚBLICA de la JEFATURA DE GABINETE DE MINISTROS que aprueba este Formulario de Solicitud y Ficha de Inscripción;<br>
		    <span class="letra-bold">f)</span> Conozco y acepto las Bases del Concurso en el que solicito inscribirme, cuya copia he recibido en este acto de inscripción; tomando conocimiento del cronograma y metodologías de las etapas del proceso, de las materias o temáticas a aboradar en la(s) prueba(s) y entrevista(s) fijadas o de las asignaturas del Curso de Selección si fuera aplicable, de los puntajes a asignar a las diversas características a considerar, con los cambios que pudiera resolver el Comité de Selección a los efectos de mejor proveer, y que serán comunicados con la antelación suficiente;<br>
		    <span class="letra-bold">g)</span> He sido notificado de la ubicación de la cartelera y de la dirección de la página WEB en la que se notificarán las diversas incidencias y resultados del presente proceso de selección;<br>
		    <span class="letra-bold">h)</span> Acepto que las notificaciones a que del lugar el desarrollo del proceso en el que solicito ser inscripto puedan ser efectuados en las direcciones domiciliarias y electrónicas así como del teléfono y/o fax que he comunicado en la presente solicitud.<br>
		</div>
		
	</div>

<div class="div-pie-tabla">

<table border="border-collapse: collapse" style="border-collapse: collapse" class="pie-tabla">
<tr>
<td class="td-pie-tabla"><span class="letra-bold">Fecha de Inscripción</span></td>
<td class="td-pie-tabla"><span class="letra-bold">Firma y Aclaración del Inscripto o Apoderado</span></td>
</tr>
</table>

<p class="p-imprimir"><button class="btn btn-primary" onclick="ImprimirCVPostulado()">Imprimir Curriculum</button></p>
</div>	
</div>


<p class="top-header posicion">Recuerde firmar todas y cada una de las hojas que integran su Ficha de inscripción.<br>La ausencia de su firma invalida la valoración del antecedente declarado.</p>


</div>
<a class="general atributos" style="float: right; margin: 20px; font-size:25px;" href="PanelDeControl.aspx" >Volver</a>

        <asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="FichaDeclaracionJurada.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">    
    function ImprimirCVPostulado() {
        window.print();
    }

    Backend.start(function () {
        $(document).ready(function () {
            curriculum = JSON.parse($('#curriculum').val());
            FichaDeclaracionJurada.armarFicha();
        });
    });
</script>

</html>