<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Postulaciones.aspx.cs" Inherits="FormularioConcursar_Postulaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="MenuConcursar.ascx" TagName="MenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
   
   <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <style>
     
      .contenedor_concursar 
    {
        width: 59%;
        margin-left:19%;
    }

      .buscador
      {
       width: 70%;
       margin-top:10px;    
      }
      
      .listas li
      {
          margin-bottom: 5px;
      }
      
     
     </style>

</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <div id="contenido_inscripcion" class="contenedor_concursar">
    
    <uc3:MenuConcursar runat="server" />
    
        <div>
            <h2 class="titulo_postulaciones">Proceso de Postulación => Perfiles, Cargos y Bases</h2>
            
        </div>

        <uc4:Pasos ID="Pasos" runat="server" /> 
        <div style="clear:both;"></div>
        <p>Ud. puede acotar la búsqueda por cualquier criterio, escriba al menos 3 caracteres en el campo para buscar el puesto que desee</p>           
        
        <div id="ContenedorPlanilla">
         <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"/>
         <!--<a class="btn_concursar btn-small" href="#">Buscar</a>-->

        <table id="tabla_perfiles" style="width:100%;"></table>

        <h3>Pasos para la inscripción electrónica</h3>
        <br />
        <h4>Paso 1: Documentación</h4>
        <br />
        <p>Para la Inscripción Documental deberás tener un usuario y contraseña en el Sistema de Gestión Documental Electrónica (GDE). Para consultar por la generación de usuarios, podés escribir a ayuda.gde@desarrollosocial.gob.ar o comunicarte al (011) 4379-3902 / 3903.</p>
        <p>En caso de que no hayas realizado la actividad de capacitación acerca del Sistema GDE podés solicitar una vacante completando el siguiente <a href="https://docs.google.com/forms/d/e/1FAIpQLSdOIfc7xEYJCCUmxhL-Vop0y3iOQp92WN7XSFZXDmiGlfT48w/viewform">Formulario de Pre – Inscripción</a></p>
        <p>Toda la documentación requerida a presentar debe ser escaneada e incluída en un archivo de tipo PDF (es un formato de documento digital – de uso muy común - que comúnmente se abre con el software conocido como Adobe Acrobat Reader ®).</p>
        <p>Es importante respetar el siguiente orden al escanear la documentación para incluir en el archivo PDF:</p>

        <ol class="listas">
            <li>Documento Nacional de identidad (ambas caras del DNI tarjeta o DOS (2) primeras hojas del DNI y de la hoja donde figure el domicilio actualizado).</li>
            <li>Fotografía reciente tipo carné, tamaño 4x4 cm.</li>
            <li>Currículum Vitae (imprimir y escanear el mismo que confeccionaste en este mismo Módulo POSTULAR  recordá  firmar previamente todas las hojas).</li>
            <li>Certificación de antecedentes académicos (solamente título secundario).</li>
            <li>Certificación de actividades de capacitación (opcional).</li>
            <li>Certificación de experiencias laborales:
                <ol>
                    <li>Certificación de servicios expedida y firmada por la Dirección de Administración de Personal de la Dirección General de Recursos Humanos y Organización</li>
                    <li>Certificación de tareas expedida y firmada por el Superior inmediato del postulante</li>
                </ol>
            </li>
            <li>Certificación de Idiomas extranjeros (opcional).</li>
            <li>Certificación de competencias informáticas (opcional).</li>
        </ol>
        <br />
        <h4>Paso 2: Generación de Informe Gráfico en GDE con Documentación Escaneada</h4>
        <br />
        <p><b>ES FUNDAMENTAL QUE TODA LA DOCUMENTACIÓN ESCANEADA SE ENCUENTRE INCLUÍDA EN UN ÚNICO ARCHIVO PDF.</b></p>
        <br />
        <ol class="listas">
            <li>Ingresá a <a href="https://portal.gde.gob.ar">https://portal.gde.gob.ar</a> e iniciá sesión con tu usuario y contraseña. Hacé click en el botón "Acceso a GDE".</li>
            <li>En el sector izquierdo, donde figuran los Módulos GDE seleccioná el módulo GEDO</li>
            <li>En la solapa “Mis Tareas” hacé click en "Inicio de documento".</li>
            <li>Hacer click en la lupa que se encuentra dentro del recuadro "Tipo de documento". Buscar la opción de "INFORME GRÁFICO" que corresponde al acrónimo “IFGRA”.</li>
            <li>Una vez que esté seleccionada la opción de Informe Gráfico, hacer click en el botón "Producirlo yo mismo".</li>
            <li>Poner de nombre de Referencia “Inscripción electrónica – Nº de D.N.I. – Apellido”.</li>
            <li>En la solapa "Producción" hacer click en el botón “Seleccionar archivo” y adjuntá el archivo PDF con la documentación escaneada anteriormente.</li>
            <li>Finalizada la carga, seleccionar la opción "Firmar yo mismo el documento" y luego "Firmar con certificado".</li>
            <li>Al firmar digitalmente con tu usuario el "Informe Gráfico" generado en el punto anterior aparecerá un mensaje confirmando que se ha generado correctamente el documento con su correspondiente número de GDE (similar al siguiente "IF-2017-9999999-APN-xxx#MDS").</li>
            <li>Es fundamental que el número GDE sea copiado y pegado en los espacios destinados a tal efecto 	en la pantalla de PREINSCRIPCION.</li>
            <li>Recomendamos descargar el documento para tener una constancia del mismo (en el PDF podrás visualizar el número GDE). </li>
            <li>Finalizado este proceso en el GDE, recordá cerrar sesión haciendo click en "salir".</li>
        </ol>
        <br />
        <h4>Paso 3: Preinscripción</h4>
        <br />
        <ol>
            <li>Desde esta misma pantalla, debes hacer click en la columna "Acciones" en la tabla de arriba en el texto "Postularme" del cargo correspondiente</li>
            <li>En la pantalla siguiente se te pedirá de validar que tus datos personales estén actualizados.</li>
            <li>En caso de haber continuado verás las caracteristicas del cargo al que te estás postulando y los espacios reservados para guardar los números de los INFORMES GRÁFICOS generados en el GDE. Deberás ingresar los mismos en dichas casillas, luego aceptar las bases y condiciones del concurso y continuar.</li>
            <li>Por último verás la finalización del proceso con el número de Postulación, de Informes y el resumen del Cargo.</li>
        </ol>
        <br />
        <h3>Otras consideraciones</h3>

        <p><div style="font-weight:bold; float:left">Convocatorias Generales: &nbsp</div> Sólo pueden postularse quienes al momento de hacerlo se encuentren trabajando en el marco del Convenio Colectivo de Trabajo Sectorial del Sistema Nacional de Empleo Público (SINEP)*, 
        sea en Planta Permanente, Planta Transitoria o designado de conformidad con el artículo 9° del Anexo de la Ley 25164. Se recomienda consultar en el área de Recursos Humanos de su organismo si usted está encuadrado en el SINEP</p>
        <p> <div style="font-weight:bold; float:left">Convocatorias Abiertas:&nbsp</div> Pueden postularse todas las personas que acrediten la idoneidad y los requisitos establecidos en las bases de cada concurso. </p>
        <p style="font-weight:bold; font-style:italic">En todos los casos se recomienda tener en cuenta los requisitos excluyentes de cada cargo.</p>
        </div>
          
    </div>


     <asp:HiddenField ID="perfiles" runat="server" />
      <asp:HiddenField ID="postulaciones" runat="server" />
      <asp:HiddenField ID="curriculum" runat="server" />
    </form>
</body>
    <%= Referencias.Javascript("../") %>
   
      <script type="text/javascript" src="Perfil.js" ></script>
<script type="text/javascript">
    $('#tab_cargos').addClass('active');

    $(document).ready(function () {
        $(".collapse").collapse("show");

        var perfiles = JSON.parse($('#perfiles').val());
        var postulaciones = JSON.parse($('#postulaciones').val());
        var curriculum = JSON.parse($('#curriculum').val());

        Perfil.armarLista(perfiles, postulaciones, curriculum);

        var options = {
            valueNames: ['Perfil', 'Nivel', 'Agrupamiento', 'Vacantes']
        };

        var featureList = new List('ContenedorPlanilla', options);

    });

    $('.actions').attr('style', 'display:none');
</script>
</html>
