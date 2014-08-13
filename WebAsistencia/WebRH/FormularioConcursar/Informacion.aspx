<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Informacion.aspx.cs" Inherits="FormularioConcursar_Informacion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    	<div class="contenedor_concursar" >
            <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
        
        <div class="entry-content">
		    <div id="texto-central">
                <div id="texto-central-titulo">¿QUÉ ES UN CONCURSO?</div>
                <p>Es un proceso de selección que brinda la oportunidad de promover y ascender al personal de carrera para su incorporación a Planta 
                Permanente. También da la opción de regularizar diferentes modalidades de contrataciones existentes hoy dentro del SINEP. Comprende tres 
                grandes etapas: la INSCRIPCIÓN, el PROCESO DE EVALUACIÓN y, finalmente, ORDEN DE MÉRITO Y DESIGNACIÓN.</p>
                <div id="texto-central-titulo"><strong>Etapas</strong></div>
                <p><img alt="1" src="http://www.mecon.gov.ar/concursos/images/nro1.png" /></p>
                <div id="texto-central-titulo">Inscripción</div>
                <p><b>1.1) <span style="text-decoration: underline;">Pre inscripción electrónica</span>:</b><br />
                Deberás ingresar a la WEB (<a href="" target="_parent">www.ministeriodesarrollosocial.gov.ar/concursos</a>) y cargar tus datos a través 
                del Sistema Concursar. De esa carga se crearán una serie de formularios que necesitarás tener para completar la inscripción documental.<br />
                <b>1.2) <span style="text-decoration: underline;">Inscripción documental</span>:</b><br />
                Deberás acercarte para presentar los formularios impresos obtenidos en la pre-inscripción electrónica y el Currículum Vitae actualizado 
                junto a TODA la documentación de respaldo para certificar los datos consignados en dichos formularios. (se solicitarán copias y 
                originales, para validar las mismas)<b></b></p>
                <p><img alt="" src="http://www.mecon.gov.ar/concursos/images/nro2.png" /></p>
                <div id="texto-central-titulo">Proceso de evaluación:</div>
                <p><b>2.1)</b> <b>Evaluación de Antecedentes Curriculares y Laborales:</b> El Comité de selección evaluará los antecedentes de los 
                postulantes de acuerdo a la información y documentación que hayan presentado en la etapa de inscripción.<br />
                <b>2.2) Evaluación Técnica:</b> De carácter presencial. Se evaluarán los conocimientos y capacidades del postulante según los 
                requerimientos típicos del puesto de trabajo en cuestión.<br />
                <b>2.3) Evaluación Mediante Entrevista Laboral: </b>Se realizará al menos un encuentro del postulante con el Comité para evaluar su 
                adecuación a los requerimientos del puesto.<br />
                <b>2.4) Evaluación del Perfil Psicológico: </b>Será realizada por profesional matriculado para ponderar la adecuación de las características de personalidad vinculadas con el desempeño laboral efectivo de acuerdo al puesto al cual concursa.</p>
                <p><img alt="" src="http://www.mecon.gov.ar/concursos/images/nro3.png" /></p>
                <div id="texto-central-titulo">Orden de mérito y de designación:</div>
                <p><b>3.1)</b> El  Orden de Mérito se publicará en los sitio<a href="" >www.mecon.gov.ar/concursos</a> y 
                <a href="" >www.concursar.gob.ar</a>.<br />
                <b>3.2)</b> Se inicia el proceso de designación del cargo en Planta Permanente, mediante acto administrativo, conforme al Orden de 
                Mérito y en función de la elección que manifestarán en caso de haber ganado más de un puesto.</p>
            </div>
		</div><!-- .entry-content -->
        </div>
    </form>
</body>
 <%= Referencias.Javascript("../") %>
</html>
