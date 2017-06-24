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

                <br />
                <div id="Div3" class="titulo_postulaciones">¿QUÉ ES UNA CONVOCATORIA INTERNA?</div>
                <br />
                <p>El artículo 135 del Decreto N° 2098/2008 establece "con carácter excepcional y transitorio, hasta el 31 de diciembre de 2018, como otro Tipo de 
                convocatoria, la Convocatoria Interna. En la misma podrá participar el personal que revista como personal permanente y no permanente, según los 
                artículos 8° y 9° de la Ley N° 25.164 de la jurisdicción u organismo al que pertenezca la vacante a cubrir."</p>
                <p>Esto implica que en esta Convocatoria Interna pueden participar los/las agentes que revistan como personal permanente y no permanente del 
                Ministerio de Desarrollo Social de la Nación, según los artículos 8° y 9° de la Ley N° 25.164. Dicha convocatoria tendrá carácter excepcional y 
                transitorio hasta el 31 de diciembre del 2018.</p>

                <br />
                <div id="Div4" class="titulo_postulaciones">¿QUIÉNES PUEDEN POSTULARSE?</div>
                <br />
                <p>Para postularte, tenés que cumplir con los siguientes requisitos excluyentes:</p>
                <ul>
                    <li style="margin-bottom:5px;">Acreditar experiencia laboral de 10 años o más en la administración pública. Este requisito no será aplicable a las personas con discapacidad que se postulen al cargo que se encuentra bajo el régimen de reserva del artículo 8 de la Ley N° 22.431.</li>
                    <li style="margin-bottom:5px;">Prestar servicios en la jurisdicción al momento de la inscripción bajo los Arts. 8° y 9° de la Ley N° 25.164.</li>
                    <li style="margin-bottom:5px;">Acreditar título de nivel secundario completo.</li>
                    <li>Acreditar certificado único de discapacidad (CUD), emitido por una autoridad competente, Este requisito sólo será aplicable a las personas que se postulen al cargo que se encuentra bajo el régimen de reserva del artículo 8 de la Ley N° 22.431.</li>
                </ul>

                <br />
                <div id="Div5" class="titulo_postulaciones">¿QUIÉNES INTEGRAN LOS COMITES DE SELECCIÓN?</div>
                <br />

                <p>Los integrantes de cada Comité de Selección podés consultarlos haciendo click sobre el número identificatorio de cada Comité que se puede observar en la tabla de Cargos Disponibles.</p>
                <br />
                <div id="texto-central-titulo"><strong style="font-size:2.2em;" class="titulo_postulaciones">Etapas </strong></div>
                <br />
                <br />
                <div id="texto-central-titulo" class="sub_etapas">Inscripción</div>
                <br />
                
                <%--<img alt="2" src="../Imagenes/iconos/001.jpg" />--%>
                <p><b>1) <span style="text-decoration: underline;">Pre inscripción electrónica</span>:</b></p><br />
                <p>Comienza con la carga (o actualización) de tu Currículum Vitae (historial personal, académico, laboral y profesional) que puedes realizar en esta misma página.</p>
                <p>Luego, debés realizar la postulación en el cargo o en los cargos en que estés interesado/a.</p>
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/002.jpg" />--%>
                <p><b>2) <span style="text-decoration: underline;">Inscripción documental</span>:</b></p>
                <br />
                <p>Para la Inscripción Documental deberás tener un usuario y contraseña en el Sistema de Gestión Documental Electrónica (GDE). Para consultar por la generación de usuarios, podés escribir a ayuda.gde@desarrollosocial.gob.ar o comunicarte al (011) 4379-3902 / 3903.</p>
                <p>En caso de que no hayas realizado la actividad de capacitación acerca del Sistema GDE podés solicitar una vacante completando el siguiente <a href="https://docs.google.com/forms/d/e/1FAIpQLSdOIfc7xEYJCCUmxhL-Vop0y3iOQp92WN7XSFZXDmiGlfT48w/viewform" target="_blank">Formulario de Pre – Inscripción</a></p>
                <p>La carga de tu documentación al sistema GDE y su envío a la Secretaría Técnica del Concurso comprende:</p>
                <ol>
                    <li style="margin-bottom:5px;">Imprimir y firmar en todas las páginas el Curriculum Vitae que confeccionaste en este mismo Módulo POSTULAR.</li>
                    <li style="margin-bottom:5px;">Escanear el Curriculum Vitae debidamente firmado conjuntamente con toda la documentación de respaldo para certificar los datos consignados.</li>
                    <li style="margin-bottom:5px;">Todos los documentos escaneados deben ser agrupados en un archivo de tipo PDF (es un formato de documento digital – de uso muy común - que comúnmente se abre con el software conocido como Adobe Acrobat Reader ®).</li>
                    <li style="margin-bottom:5px;">El archivo PDF es el que se carga en el sistema GDE confeccionando un “Informe Gráfico” dentro del Módulo GEDO del citado sistema GDE.</li>
                    <li >Al firmar digitalmente con tu usuario el “Informe Gráfico” generado en el punto anterior, el GDE te otorgará un número de informe similar al siguiente “IF-2017-9999999-APN-xxx#MDS” este número deberás copiarlo y pegarlo en el espacio que para ello se incluye en la pantalla de POSTULARME de esta misma página.</li>
                </ol>

                <p>Una vez generado completada la postulación, tenés que acercarte con TODA la documentación ORIGINAL de respaldo al edificio de la calle Alsina 1886 de esta Ciudad Autónoma de Buenos Aires de 10.00hs. a 16.00hs. en los días que se establezcan para la Inscripción Documental, oportunidad en la que los agentes de registro certificarán su validez con respecto a los originales presentados.</p>

                
                <%--<img alt="2" src="../Imagenes/iconos/003.jpg" />--%>
                <br />
                <div id="Div6" class="sub_etapas">Nómina de Inscriptos</div>
                <br />
                <p>Una vez finalizada la etapa de Inscripción Documental, cada Comité elabora una Nómina con los/as agentes que realizaron con éxito la inscripción.</p>
                <p>A partir de esta instancia, y en cada una de las etapas siguientes, se elaboran las Actas donde vas a encontrar los resultados de cada etapa del Proceso de Selección.</p>
                <br />
                <p><b>3) <span style="text-decoration: underline;">Nómina de Admitidos y No Admitidos</span>:</b></p><br />
                 
                 <p>Una vez culminada la Etapa de Inscripción Documental, cada Comité se abocará a analizar la documentación presentada y evaluar el cumplimiento de los requisitos excluyentes especificados en cada perfil convocado.</p>
                 <p>Como resultado de este trabajo se elaborarán las Actas de Admitidos y No admitidos al Concurso, las cuales serán publicadas en este sitio.</p>
              
                <br />
                <div id="texto-central-titulo" class="sub_etapas">4) Proceso de evaluación</div>
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/004.jpg" />--%>
                <p><b>4.1) Evaluación de Antecedentes Curriculares y Laborales:</b></p><br /> 
                <p>El Comité de selección evaluará los antecedentes de los postulantes de acuerdo a la información y documentación que hayan presentado en la etapa de inscripción, ponderándolos equitativamente en función de instrumentos previamente elaborados.</p>
                <p>Como resultado de esta ponderación se elaborarán las Actas de Ponderación de Antecedentes, las cuales serán publicadas en este sitio.</p>
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/005.jpg" />--%>
                <p><b>4.2) Evaluación Técnica:</b></p><br /> 
                <p>La misma es de carácter presencial y se evaluarán los conocimientos y capacidades de los/as postulantes según los requerimientos del puesto de trabajo. En la evaluación, se te podrá preguntar o proponer ejercicios que guarden relación con cualquiera de los ítems mencionados en las Bases del Concurso, tanto en lo referente a los Requisitos y Competencias expresamente enunciados, como a lo descripto en “Responsabilidad del Puesto” o en “Principales Actividades” de dicho perfil.</p>
                
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/006.jpg" />--%>
                <p><b>4.3) Evaluación Mediante Entrevista Laboral: </b></p><br />
                <p>Se realizará al menos un encuentro del/ de la postulante con el Comité para evaluar su adecuación a los requerimientos del puesto.</p>
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/007.jpg" />--%>
                <p><b>4.4) Evaluación del Perfil Psicológico: </b></p><br />
                <p>En los perfiles de Agrupamiento Profesional esta etapa es realizada por profesional matriculado para ponderar la adecuación de las características de personalidad vinculadas con el desempeño laboral efectivo de acuerdo al puesto al cual concursa.</p>

                <br />
                <div id="Div1" class="sub_etapas">Etapa Final:</div>
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/008.jpg" />--%>
                <p><b>5) Calificacion final: </b></p><br />
                <p>Los puntajes obtenidos por cada participante en todas y cada una de las etapas, serán ponderados en función de la relevancia porcentual respectiva asignada en las Bases del Concursos.</p>
                <p>De esta manera se obtendrá la Puntuación final del candidato para cada uno de los perfiles a los que se haya postulado.</p>
                 <br />
                <%--<img alt="2" src="../Imagenes/iconos/009.jpg" />--%>
                <p><b>6) Elaboración y Publicación del Orden de Mérito:</b></p><br />
                <p>Las nóminas de candidatos que alcanzaron satisfactoriamente la última etapa del Concurso, se ordenan decrecientemente de acuerdo al puntaje ponderado alcanzado en la Calificación Final, conformando ello el Orden de Mérito para ese perfil.</p>
                <p>El Orden de Mérito así elaborado se incluye en la correspondiente Acta de Comité y se eleva para aprobación de la máxima autoridad del Organismo.</p>
               
                <br />
                <%--<img alt="2" src="../Imagenes/iconos/010.jpg" />--%>
                <p><b>7) Designación</b></p>
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
