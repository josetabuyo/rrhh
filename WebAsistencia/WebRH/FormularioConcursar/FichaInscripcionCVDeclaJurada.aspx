<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FichaInscripcionCVDeclaJurada.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript">
         function ImprimirCVPostulado() {
             window.print();
         }
     
     </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="contenedor_concursar">

<p class="top-header">Recuerde firmar todas y cada una de las hojas que integran su Ficha de inscripción.<br>La ausencia de su firma invalida la valoración del antecedente declarado.</p>

<hr class="linea-top"/>

<div class="principal">
<p class="encabezado">FICHA DE INSCRIPCIÓN<br>PRESENTACIÓN CURRICULUM VITAE<br>DECLARACIÓN JURADA</p>

<p class="general oferta-empleo"><span class="atributos">Postulación Nº: </span>2233</p>

<div class="tabla sombra_y_redondeado">
    <table class="tabla-inscripcion">
        <tbody>
            <tr>
                <td style="width: 60%"><p class="general p-tabla"><span class="atributos">Oferta de Empleo Nº: </span>32.267</p></td>
                <td style="width: 40%"><p class="general p-tabla"><span class="atributos">Tipo de Convocatoria: </span>GENERAL</p></td>
            </tr>
            <tr>
                <td colspan="2" class="tabla-inscripcion-td" ><p class="general p-tabla"><span class="atributos">Denominación del Cargo: </span>Abogado asesor especializado en Empleo Público</p></td>
            </tr>
	
            <tr>
                <td colspan="2" class="tabla-inscripcion-td"><p class="general p-tabla"><span class="atributos">Agrupamiento: </span>GENERAL</p></td>
            </tr>
    
            <tr>
                <td><p class="general p-tabla"><span class="atributos">Nivel Escalafonario: </span>A</p></td>
                <td><p class="general p-tabla"><span class="atributos">Nivel de Jefatura: </span></p></td>
            </tr>
        </tbody>
    </table>
</div>


<div class="info-gral posicion degrade_modulo sombra_y_redondeado">
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">I.</span> Información Personal</p>
	<p class="nombre-h"><span class="atributo-apelido">AYÁN, </span>Verónica</p>
    <br>
	<p class="general"><span class="atributos">DNI: </span>32.267.529</p>
	<p class="general"><span class="atributos">Estado Civil: </span>Soltera</p>
	<p class="general"><span class="atributos">Fecha de Nacimiento: </span>22/03/1986</p>
	<p class="general"><span class="atributos">Lugar de Nacimiento: </span>Buenos Aires</p>
	<p class="general"><span class="atributos">Nacionalidad: </span>Argentina</p>
	<p class="general"><span class="atributos">Domicilio Personal: </span>Italia 465 - Timbre 3 - Lomas de Zamora - C.P: 1832</p>
	
	
</div>

<div class="info-notif-avisos posicion degrade_modulo sombra_y_redondeado">
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">II.</span> Información Requerida para Recibir Notificaciones y Avisos</p>
	<p class="general"><span class="atributos">Domicilio: </span>Italia 465 - Timbre 3 - Lomas de Zamora - C.P: 1832</p>
	<p class="general"><span class="atributos">Teléfonos: </span>4281-2685 / 15 5059 5930</p>
	<p class="general"><span class="atributos">Corro Electrónico: </span>ayanvero@gmail.com</p>
	</div>

<div class="antec-academ posicion degrade_modulo sombra_y_redondeado">
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">III.</span> Antecedentes Académicos</p>
	
	<div class="tit-pos">
	<p class="sub-titulos">Títulos Educativos</p>
	<hr class="lineas-subraya"/>
	
	<p class="general"><span class="atributos">- En Curso: </span>- Universitario - U.B.A. - F.A.D.U. - Dis. de Imágen y Sonido</p>
	<p class="general"><span class="atributos">- Año de Egreso: 2004 </span>- Secundario Completo - Instituto Grilli - Bachillerato de Economía y Gestión de las Organizaciones</p>
	</div>
		
	<div class="tit-pos">
	<p class="sub-titulos">Otras Certificaciones / Actividades de Capacitación</p>
	<hr class="lineas-subraya"/>
	<p class="general"><span class="atributos">- Año de Egreso: 2014 </span>- Centro Cultural Matienzo - Curso Intensivo: Del Guión a la Actuación</p>
	<p class="general"><span class="atributos">- Año de Egreso: 2010 </span>- Sindicato de Cinematografía Argentina - Centro de Formación Profesional - Curso Completo de Edición
	</div>
	
	<div class="tit-pos">
	<p class="sub-titulos">Actividad Docente</p>
	<hr class="lineas-subraya"/>
	<p class="no-hay-datos">No hay datos cargados</p>
	</div>
	
	<div class="tit-pos">
	<p class="sub-titulos">Eventos Académicos</p>
	<hr class="lineas-subraya"/>
	<p class="general"><span class="atributos">- Imágenes Forenses:</span>
    Docente en el Curso de Aspirantes para Instructores Judiciales para la Provincia de Buenos Aires (“Imágenes Forenses”). Procuración General de la Provincia de Buenos Aires, año 2007.</p>
	</div>
	
	<div class="tit-pos">
	<p class="sub-titulos">Publicaciones o Trabajos de Investigación</p>
	<hr class="lineas-subraya"/>
    <p class="general"><span class="atributos">- Publicación: </span>
	"Imágenes Forenses" - Instituto Universitarios de la Policía Federal Argentina, Inédito. Año 2007.</p>
	</div>
	
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
</div>

<div class="tit-pos posicion degrade_modulo sombra_y_redondeado">
	<p class="titulos degrade sombra_y_redondeado"><span class="letra-bold">VI.</span> Motivos por los que se Postula al Cargo</p>
		<p class="motivos-cargo">Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per.</p>
	</div>

<div class="posicion">
		<div class="decla-jurada"><p style="text-align:center; font-size:12px; font-weight:bold;"><span style="font-size: 13px">DECLARACIÓN JURADA Y CONSTANCIA DE RECEPCIÓN Y ACEPTACIÓN DEL REGLAMENTO Y BASES DEL CONCURSO</span></p>
		Declaro bajo juramento que:<br>
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

<p class="p-imprimir"><button onclick="ImprimirCVPostulado()">Imprimir Curriculum</button></p>
</div>	
</div>


<p class="top-header posicion">Recuerde firmar todas y cada una de las hojas que integran su Ficha de inscripción.<br>La ausencia de su firma invalida la valoración del antecedente declarado.</p>

</div>

    </form>
</body>

</html>
