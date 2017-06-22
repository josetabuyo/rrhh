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

     <style type="text/css">
     .texto_escondido 
     {
        display:none;
        }
         
             
             .disparador, .disparador:hover
             {
                 text-decoration:none;
                 cursor:pointer;
                 color: #0088cc;
                 text-align: left;
                 }
     
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    	<div class="contenedor_concursar" >
            <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
        
        <div class="entry-content">
		    <div id="texto-central">
                <div id="texto-central-titulo" class="titulo_postulaciones">¿QUÉ ES UN CONCURSO?</div>
                <p>Es un proceso de selección que brinda la oportunidad de promover y ascender al personal de carrera para su incorporación a Planta 
                Permanente. También da la opción de regularizar diferentes modalidades de contrataciones existentes hoy dentro del SINEP. Comprende tres 
                grandes etapas: la INSCRIPCIÓN, el PROCESO DE EVALUACIÓN y, finalmente, ORDEN DE MÉRITO Y DESIGNACIÓN.</p>

                <div style="text-align:center;" ><img alt="etapas" src="../Imagenes/etapasPostular.jpg" width="550" height="500px" /></div>

                <div id="texto-central-titulo"><strong style="font-size:2.2em;" class="titulo_postulaciones">Etapas </strong></div>
                <br />
                <div id="texto-central-titulo" class="sub_etapas">Inscripción</div>
                <p><img alt="2" src="../Imagenes/iconos/001.jpg" />
                <b>1) <span style="text-decoration: underline;">Pre inscripción electrónica</span>:</b><br />
                Comienza con la carga (o actualización) de tu Currículum Vitae (historial personal, académico, laboral y profesional) que puedes realizar en esta misma página.</p>
                <p>Se completa con la postulación que realices en uno o más Puestos de un Llamado datos a través del Sistema Concursar. De esa carga se crearán una serie de formularios que necesitarás tener para completar la inscripción documental.</p>
                <p><img alt="2" src="../Imagenes/iconos/002.jpg" />
                
                <b>2) <span style="text-decoration: underline;">Inscripción documental</span>:</b><br />
                Deberás acercarte para presentar los formularios impresos obtenidos en la pre-inscripción electrónica y el Currículum Vitae actualizado junto a TODA la documentación de respaldo para certificar los datos consignados en dichos formularios. Los formularios, que se imprimen cuando realices cada postulación son:<b></b></p>
                <ul>
                    <li>FORMULARIO DE SOLICITUD Y FICHA DE INSCRIPCIÓN (Anexo I)</li>
                    <li>DECLARACIÓN JURADA Y CONSTANCIA DE RECEPCIÓN Y ACEPTACIÓN DEL REGLAMENTO Y BASES DEL CONCURSO (Anexo II)</li>
                    <li>CONSTANCIA DE RECEPCIÓN DE LA SOLICITUD, FICHA DE INSCRIPCIÓN Y DE LA DOCUMENTACIÓN PRESENTADA (Anexo III)</li>
                </ul>
                <p>Con respecto al resto de la documentación, se debe recordar que se solicitarán copias y originales, para validar las primeras.</p>

                <p><img alt="2" src="../Imagenes/iconos/003.jpg" />
                
                <div id="Div2" class="sub_etapas">Admisión</div>
                <br />
                <b>3) <span style="text-decoration: underline;">Listado Admitidos y No Admitidos</span>:</b><br />
                 Una vez culminada la Etapa de Inscripción Documental, cada Comité se abocará a analizar la documentación presentada y evaluar el cumplimiento de los requisitos excluyentes especificados en cada perfil convocado.<b></b></p>
                 <p>Como resultado de este trabajo se elaborarán las Actas de Admitidos y No admitidos al Concurso, las cuales serán publicadas en este sitio.</p>
              
                <br />
                <div id="texto-central-titulo" class="sub_etapas">Proceso de evaluación:</div>
                <p><img alt="2" src="../Imagenes/iconos/004.jpg" />
                <b>4.1)</b> <b>Evaluación de Antecedentes Curriculares y Laborales:</b><br /> El Comité de selección evaluará los antecedentes de los postulantes de acuerdo a la información y documentación que hayan presentado en la etapa de inscripción, ponderándolos equitativamente en función de instrumentos previamente elaborados.</p>
                <p>Como resultado de esta ponderación se elaborarán las Actas de Ponderación de Antecedentes, las cuales serán publicadas en este sitio.</p>
                <p><img alt="2" src="../Imagenes/iconos/005.jpg" />
                <b>4.2) Evaluación Técnica:</b><br /> De carácter presencial. Se evaluarán los conocimientos y capacidades del postulante según los 
                requerimientos típicos del puesto de trabajo en cuestión.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio.</p>
                <p><img alt="2" src="../Imagenes/iconos/006.jpg" />
                <b>4.3) Evaluación Mediante Entrevista Laboral: </b><br />Se realizará al menos un encuentro del postulante con el Comité para evaluar su 
                adecuación a los requerimientos del puesto.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio.</p>
                <p><img alt="2" src="../Imagenes/iconos/007.jpg" />
                <b>4.4) Evaluación del Perfil Psicológico: </b><br />Será realizada por profesional matriculado para ponderar la adecuación de las características de personalidad vinculadas con el desempeño laboral efectivo de acuerdo al puesto al cual concursa.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio.</p>

                <br />
                <div id="Div1" class="sub_etapas">Etapa Final:</div>
                <p><img alt="2" src="../Imagenes/iconos/008.jpg" />
                <b>5) Calificacion final: </b><br />Los puntajes obtenidos por cada participante en todas y cada una de las etapas, serán ponderados en función de la relevancia porcentual respectiva asignada en las Bases del Concursos.</p>
                <p>De esta manera se obtendrá la Puntuación final del candidato para cada uno de los perfiles a los que se haya postulado.</p>
                <p><img alt="2" src="../Imagenes/iconos/009.jpg" />
                <b>6) Elaboración y Publicación del Orden de Mérito:</b></p>
                <p>Las nóminas de candidatos que alcanzaron satisfactoriamente la última etapa del Concurso, se ordenan decrecientemente de acuerdo al puntaje ponderado alcanzado en la Calificación Final, conformando ello el Orden de Mérito para ese perfil.</p>
                <p>El Orden de Mérito así elaborado se incluye en la correspondiente Acta de Comité y se eleva para aprobación de la máxima autoridad del Organismo.</p>
                <p>Tanto el Acta como la posterior Resolución Ministerial también serán publicadas en este sitio.</p>
                <p><img alt="2" src="../Imagenes/iconos/010.jpg" />
                <b>7) Designación</b></p>
                <p>Oportunamente, se inicia el proceso de designación del cargo en Planta Permanente, mediante acto administrativo, conforme al Orden de Mérito y en función de la elección que manifestarán en caso de haber ganado más de un puesto.</p>
            </div>
		</div><!-- .entry-content -->
        <div>
        <br />
            <div class="preguntas_frecuentes">
                <div style="font-size:2.2em;" class="titulo_postulaciones">Preguntas Frecuentes</div>
                <p>(Para ver la respuesta a cada pregunta, hacer click con el mouse sobre la misma)<br /></p>

        	        <p name="faq_1" class="disparador">1) ¿Me puedo postular a más de un cargo?</p>
                    <div id="faq_1" class="texto_escondido">
                        <p style="text-align: left;">Sí, podés postularte a cuantos cargos desees, teniendo en cuenta los requisitos excluyentes de cada uno de ellos disponibles en las Bases del Concurso.</p>
                    </div>

                    <p name="faq_2" class="disparador">2) ¿Puedo concursar si trabajo en otro sector de la Administración Pública?</p>
                    <div id="faq_2" class="texto_escondido">
                        <p style="text-align: left;">No, porque se trata de una Convocatoria Interna a la cual sólo pueden postularse los/as agentes que actualmente trabajan para el Ministerio de Desarrollo Social de la Nación.</p>
                    </div>

                    <p name="faq_3" class="disparador">3) ¿Cómo puedo autorizar a un/a apoderado/a para que realice la inscripción documental en mi nombre?</p>
                    <div id="faq_3" class="texto_escondido">
                        <p style="text-align: left;">Deberás acreditarlo ante un/a escribano/a público/a, y tu apoderado/a deberá presentar el poder en la mesa de inscripción.</p>
                    </div>

                    <p name="faq_4" class="disparador">4) ¿Qué pasa si alguno de los títulos que declaro aún está en trámite?</p>
                    <div id="faq_4" class="texto_escondido">
                        <p style="text-align: left;">Deberás presentar la documentación que dé cuenta de esa situación, certificando el cumplimiento de todas las obligaciones académicas y administrativas previas al otorgamiento del título, y acreditando que sólo queda pendiente la entrega formal del mismo.</p>
                    </div>

                    <p name="faq_5" class="disparador">5) ¿Qué pasa si no tengo toda la documentación que me solicitan al inscribirme?</p>
                    <div id="faq_5" class="texto_escondido">
                        <p style="text-align: left;">Los antecedentes que no estén respaldados por la documentación correspondiente no te impedirán la inscripción, pero no serán considerados como válidos para el concurso.</p>
                        <p style="text-align: left;">Tené en cuenta que cada cargo concursado exige el cumplimiento de ciertos requisitos excluyentes. Si no los acreditás debidamente vas a poder completar la inscripción, pero no serás incluído/a en la nómina de admitidos/as al concurso.</p>
                    </div>

                    <p name="faq_6" class="disparador">6) ¿Existe alguna consideración particular para las personas discapacitadas?</p>
                    <div id="faq_6" class="texto_escondido"  >
                        <p style="text-align: left;">Sí. En caso de empate en el puntaje final entre dos o más postulantes, se otorgará prioridad en el orden de mérito a las personas con alguna discapacidad (que deberá ser acreditada mediante certificado emitido por autoridad competente y presentada junto con la documentación en el momento de la inscripción). El mismo beneficio lo tendrán los/as postulantes que acrediten ser Veteranos/as de guerra.</p>
                    </div>

                    <p name="faq_7" class="disparador">7) ¿Si quedé seleccionado/a, cuándo empiezo a trabajar?</p>
                    <div id="faq_7" class="texto_escondido">
                        <p style="text-align: left;">La Dirección General de Recursos Humanos y Organización te citará para que completes la documentación necesaria para tu designación.</p>
                        <p style="text-align: left;">Una vez publicado el acto administrativo de designación, la prestación de servicios comenzará dentro de los 30 días corridos desde la fecha de notificación.</p>
                    </div>

                    <p name="faq_8" class="disparador">8) ¿Cuál es la remuneración?</p>
                    <div id="faq_8" class="texto_escondido" >
                        <p style="text-align: left;">Depende del cargo al que te postules. Los valores se encuentran consignados en las Bases del Concurso y están expresadas en importe bruto.</p>
                    </div>

                    <p name="faq_9" class="disparador">9) ¿Cuál es la carga horaria del puesto de trabajo?</p>
                    <div id="faq_9" class="texto_escondido" >
                        <p style="text-align: left;">Los cargos de nivel C y D tienen una carga horaria de 40 horas semanales. En ambos casos, el horario de ingreso depende del puesto.</p>
                    </div>

                    <p name="faq_10" class="disparador">10) ¿Cuál es el lugar de trabajo?</p>
                    <div id="faq_10" class="texto_escondido">
                        <p style="text-align: left;">El lugar de trabajo depende del cargo al cual te postules y se encuentra consignado en las Bases del Concurso.</p>
                    </div>

                    <p name="faq_11" class="disparador"> 11) ¿Hay alguna edad límite de ingreso? </p>
                    <div id="faq_11" class="texto_escondido" >
                        <p style="text-align: left;">Sólo la prevista para acceder a la jubilación.</p>
                    </div>

                    <p name="faq_12" class="disparador"> 12) ¿Durante cuánto tiempo estaré contratado/a si soy seleccionado/a?</p>
                    <div id="faq_12" class="texto_escondido" >
                        <p style="text-align: left;">Si sos seleccionado/a ingresará a la Planta Permanente del organismo. Superado el período de prueba de 12 meses tu designación quedará firme, lo que implica que te encontrarás en relación de dependencia hasta que decidas renunciar, jubilarte o incurra en alguna falta que amerite tu cesantía, exoneración o despido.</p>
                    </div>

                    <p name="faq_13" class="disparador"> 13) ¿Qué pasa si soy extranjero/a? </p>
                    <div id="faq_13" class="texto_escondido" >
                        <p style="text-align: left;">Aunque el llamado a concurso está dirigido a argentinos/as nativos/as, naturalizados/as o por opción, si sos extranjero/a también podés inscribirte.</p>
                        <p style="text-align: left;">En caso de resultar seleccionado/a, el/la  titular del organismo podrá solicitar al/ a la Jefe/a de Gabinete de Ministros la excepción del cumplimiento de este requisito.</p>
                    </div>

                    <p name="faq_14" class="disparador"> 14) ¿Qué significa que los datos tienen carácter de declaración jurada? </p>
                    <div id="faq_14" class="texto_escondido" >
                        <p style="text-align: left;">Que toda la documentación que presentes reviste carácter de verdad y, por lo tanto, cualquier falsedad que pudiera comprobarse dará lugar a la exclusión del concurso.</p>
                        <p style="text-align: left;">Los únicos estudios que se considerarán certificados a través de declaración jurada son los de manejo de programas informáticos y los idiomas (que posiblemente sean evaluados en otras etapas).</p>
                    </div>
                </div>
            </div>
            </div>
    </form>
</body>
 <%= Referencias.Javascript("../") %>
    <script type="text/javascript">
        $('#tab_info').addClass('active');

        $(document).ready(function () {

            $('.disparador').click(function () {
                var id = $(this).attr("name");
                if ($("#" + id).attr("class") == 'desplegado') {
                    $("#" + id).slideUp(600);
                    $("#" + id).attr("class", "texto_escondido")
                } else {
                    $("#" + id).slideDown(200);
                    $("#" + id).attr("class", "desplegado")
                }
            })

        });

    </script>
</html>
