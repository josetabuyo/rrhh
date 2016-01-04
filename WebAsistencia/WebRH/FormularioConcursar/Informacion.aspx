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
                 <p>Como resultado de este trabajo se elaborarán las Actas de Admitidos y No admitidos al Concurso, las cuales serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
              
                <br />
                <div id="texto-central-titulo" class="sub_etapas">Proceso de evaluación:</div>
                <p><img alt="2" src="../Imagenes/iconos/004.jpg" />
                <b>4.1)</b> <b>Evaluación de Antecedentes Curriculares y Laborales:</b><br /> El Comité de selección evaluará los antecedentes de los postulantes de acuerdo a la información y documentación que hayan presentado en la etapa de inscripción, ponderándolos equitativamente en función de instrumentos previamente elaborados.</p>
                <p>Como resultado de esta ponderación se elaborarán las Actas de Ponderación de Antecedentes, las cuales serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
                <p><img alt="2" src="../Imagenes/iconos/005.jpg" />
                <b>4.2) Evaluación Técnica:</b><br /> De carácter presencial. Se evaluarán los conocimientos y capacidades del postulante según los 
                requerimientos típicos del puesto de trabajo en cuestión.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
                <p><img alt="2" src="../Imagenes/iconos/006.jpg" />
                <b>4.3) Evaluación Mediante Entrevista Laboral: </b><br />Se realizará al menos un encuentro del postulante con el Comité para evaluar su 
                adecuación a los requerimientos del puesto.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
                <p><img alt="2" src="../Imagenes/iconos/007.jpg" />
                <b>4.4) Evaluación del Perfil Psicológico: </b><br />Será realizada por profesional matriculado para ponderar la adecuación de las características de personalidad vinculadas con el desempeño laboral efectivo de acuerdo al puesto al cual concursa.</p>
                <p>Al igual que en las etapas anteriores las Actas con los resultados de esta etapa serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>

                <br />
                <div id="Div1" class="sub_etapas">Etapa Final:</div>
                <p><img alt="2" src="../Imagenes/iconos/008.jpg" />
                <b>5) Calificacion final: </b><br />Los puntajes obtenidos por cada participante en todas y cada una de las etapas, serán ponderados en función de la relevancia porcentual respectiva asignada en las Bases del Concursos.</p>
                <p>De esta manera se obtendrá la Puntuación final del candidato para cada uno de los perfiles a los que se haya postulado.</p>
                <p><img alt="2" src="../Imagenes/iconos/009.jpg" />
                <b>6) Elaboración y Publicación del Orden de Mérito:</b></p>
                <p>Las nóminas de candidatos que alcanzaron satisfactoriamente la última etapa del Concurso, se ordenan decrecientemente de acuerdo al puntaje ponderado alcanzado en la Calificación Final, conformando ello el Orden de Mérito para ese perfil.</p>
                <p>El Orden de Mérito así elaborado se incluye en la correspondiente Acta de Comité y se eleva para aprobación de la máxima autoridad del Organismo.</p>
                <p>Tanto el Acta como la posterior Resolución Ministerial también serán publicadas en este sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
                <p><img alt="2" src="../Imagenes/iconos/010.jpg" />
                <b>7) Designación</b></p>
                <p>Oportunamente, se inicia el proceso de designación del cargo en Planta Permanente, mediante acto administrativo, conforme al Orden de Mérito y en función de la elección que manifestarán en caso de haber ganado más de un puesto.</p>
            </div>
		</div><!-- .entry-content -->
        <div>
        <br />
            <div class="preguntas_frecuentes">
                <div style="font-size:2.2em;" class="titulo_postulaciones">Preguntas Frecuentes</div>
                <p>(Elaborado en base a material relacionado publicado en la página www.concursar.gob.ar)<br />
                    (Para ver la respuesta a cada pregunta, hacer click con el mouse sobre la misma)
                </p>
        	        <p name="faq_1" class="disparador">1) ¿Cuándo comienza la inscripción?</p>
                    <div id="faq_1" class="texto_escondido">
                        <p style="text-align: left;">El proceso de inscripción comienza con la preinscripción electrónica y  se completa con la inscripción documental, momento en el que se entrega toda la documentación obligatoria  para finalizar el proceso de inscripción.</p>
                        <p style="text-align: left;">Podrá consultar las fechas de cada concurso en este mismo sitio y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a></p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>
                    <p name="faq_2" class="disparador">2) ¿Quiénes se pueden presentar a la convocatoria?</p>
                    <div id="faq_2" class="texto_escondido">
                        <p style="text-align: left;">Los cargos se concursan a través de dos tipos de convocatorias: las generales y las abiertas.</p>
                        <p style="text-align: left;">En las generales sólo pueden postularse quienes al momento de la inscripción se encuentren trabajando en el marco del Convenio Colectivo de Trabajo Sectorial del Sistema Nacional de Empleo Público (SINEP)*, sea en Planta Permanente, Planta Transitoria, o designado&nbsp; de conformidad con el artículo 9º del Anexo de la Ley 25164.</p>
                        <p style="text-align: left;">En las abiertas pueden postularse todas las personas que acrediten la idoneidad y los requisitos establecidos en las bases de cada concurso.</p>
                        <p style="text-align: left;">En todos los casos se recomienda tener en cuenta los requisitos excluyentes de cada cargo.</p>
                        <p style="text-align: left;">* Se recomienda consultar en el área de Recursos Humanos de su organismo si usted está encuadrado en el SINEP.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_3" class="disparador">3) ¿Qué es el SINEP?</p>
                    <div id="faq_3" class="texto_escondido">
                        <p style="text-align: left;">El Convenio Colectivo de Trabajo Sectorial del personal del Sistema Nacional de Empleo Público (SINEP) fue homologado oportunamente por Decreto del Poder Ejecutivo Nacional N° 2.098 del 03 de diciembre de 2008 y rige para la mayoría de los trabajadores que se desempeñan en distintos organismos de la Administración Pública Nacional Central y Descentralizada (Jefatura de Gabinete, Ministerios, organismos descentralizados), en cargos de Planta Permanente, Planta Transitoria y en el régimen de contrataciones de conformidad con el artículo 9º del Anexo de la Ley 25164.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_4" class="disparador">4) ¿Me puedo postular a más de un cargo?</p>
                    <div id="faq_4" class="texto_escondido">
                        <p style="text-align: left;">Sí, puede postularse a cuantos cargos desee, teniendo en cuenta los requisitos excluyentes de cada uno de ellos (disponibles en las Bases del concurso).</p>
                        <p style="text-align: left;">Recuerde que deberá presentar la documentación requerida y los formularios de inscripción tantas veces como cargos a los que postule.&nbsp;</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_5" class="disparador">5) ¿Puedo concursar si trabajo en otro sector de la Administración Pública?</p>
                    <div id="faq_5" class="texto_escondido">
                        <p style="text-align: left;">&nbsp;Sí, pero en el caso de quedar designado en algún puesto deberá renunciar al anterior, dado que no se puede percibir más de una remuneración del Estado.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_6" class="disparador">6) ¿Dónde se realiza la inscripción?</p>
                    <div id="faq_6" class="texto_escondido"  >
                        <p style="text-align: left;">Primero deberá realizar la preinscripción electrónica a través de este mismo sitio web.</p>
                        <p style="text-align: left;">Luego, deberá presentar los formularios impresos y la documentación debidamente certificada que corresponda a los datos ingresados en la preinscripción, en el  lugar que se indique en cada llamado respectivo para la inscripción documental.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_7" class="disparador">7) ¿Cómo hago para inscribirme?</p>
                    <div id="faq_7" class="texto_escondido">
                        <p style="text-align: left;">El proceso de inscripción está conformado por dos instancias:</p>
                        <p style="text-align: left;"> 1.	Pre-inscripción electrónica: se realiza vía Internet a través de este sitio web volcando todos sus datos personales, académicos y laborales, realizando la postulación e imprimiendo los formularios obligatorios para entregar el día de la inscripción documental (Anexos I, II y III).</p>
                        <p style="text-align: left;"> 2.	Inscripción documental: una vez realizada la pre-inscripción electrónica, deberá concurrir personalmente en los días y horarios previstos en la convocatoria y con la documentación requerida para cada cargo (ver Pregunta 11. ¿Qué debo presentar el día de la inscripción documental?), al lugar que corresponda según la convocatoria elegida.</p>
                        <p style="text-align: left;">En el caso de no poseer copia certificada ante escribano público, se deberá concurrir con original y fotocopia de la documentación a presentar.</p>
                        <p style="text-align: left;">En caso de no poder asistir, podrá ser reemplazado por un apoderado debidamente acreditado.(ver pregunta 9).</p>
                        <p style="text-align: left;">Si usted reside a más de 50 kilómetros del lugar de inscripción o acredita certificado de discapacidad, podrá enviar la documentación debidamente certificada por correo postal (en cuyo caso deberá adjuntar certificado de domicilio o copia del certificado de discapacidad, respectivamente).</p>
                       
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_8" class="disparador">8) ¿Cómo verifico si completé la preinscripción?</p>
                    <div id="faq_8" class="texto_escondido" >
                        <p style="text-align: left;">Cuando el sistema informático le permita imprimir los tres Anexos necesarios para la inscripción documental usted habrá completado esa instancia.&nbsp;</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_9" class="disparador">9) ¿Cómo puedo autorizar a un apoderado para que realice la inscripción documental en mi nombre?</p>
                    <div id="faq_9" class="texto_escondido" >
                        <p style="text-align: left;">Deberá acreditarlo ante un escribano público, y su apoderado deberá presentar el poder en la mesa de inscripción.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_10" class="disparador">10) ¿Qué debo presentar el día de la inscripción documental?</p>
                    <div id="faq_10" class="texto_escondido">
                        <p style="text-align: left;">Para cada uno de los cargos a los cuales se postule deberá presentar la documentación que se detalla a continuación:</p>
                        <ul>
                            <li>FORMULARIO DE SOLICITUD Y FICHA DE INSCRIPCIÓN (Anexo I)</li>
                            <li>DECLARACIÓN JURADA Y CONSTANCIA DE RECEPCIÓN Y ACEPTACIÓN DEL REGLAMENTO Y BASES DEL CONCURSO (Anexo II)</li>
                            <li>CONSTANCIA DE RECEPCIÓN DE LA SOLICITUD, FICHA DE INSCRIPCIÓN Y DE LA DOCUMENTACIÓN PRESENTADA (Anexo III)</li>
                        </ul>
                        <p style="text-align: left;">Estos tres anexos se obtienen al momento de realizar la preinscripción electrónica.</p>
                        <ul>
                            <li>Fotocopia de los certificados de estudios formales y de la documentación que respalde toda otra información volcada en el Anexo I, Formulario de Solicitud y Ficha de Inscripción. Se deberá concurrir con una copia fiel de la documentación que avale los antecedentes consignados. En caso de no contar con copias autenticadas, deberá concurrir a la inscripción con la documentación original y fotocopia. En el lugar de la inscripción documental se realizará la correspondiente constatación y certificación. La ausencia de lo requerido o la falta de presentación de la documentación original llevará a no considerar el antecedente declarado</li>
                            <li>&nbsp;Si usted no fuera personal comprendido en el Sistema Nacional de Empleo Público (SINEP) deberá adjuntar, además, DOS (2) fotografías recientes tipo carné, tamaño CUATRO POR CUATRO (4X4) cm. y fotocopia de las DOS (2) primeras hojas del Documento Nacional de Identidad así como de aquella hoja en la que figure el domicilio actualizado.</li>
                            <li>Su curriculum vitae actualizado.</li>
                            <li>2 fotos 4 x 4 (carnet)&nbsp;</li>
                        </ul>
                        <p style="text-align: left;">La documentación deberá estar firmada por usted en todas sus hojas.</p>
                        <p style="text-align: left;">Los únicos estudios que se considerarán certificados a través de declaración jurada son los de manejo de programas informáticos y los idiomas (que posiblemente sean evaluados en otras etapas).</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_11" class="disparador"> 11) ¿Qué pasa si alguno de los títulos que declaro aún está en trámite? </p>
                    <div id="faq_11" class="texto_escondido" >
                        <p style="text-align: left;">Deberá presentar la documentación original (y copia) que dé cuenta de esa situación, certificando el cumplimiento de todas las obligaciones académicas y administrativas previas al otorgamiento del título, y acreditando que sólo queda pendiente la entrega formal del mismo.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_12" class="disparador"> 12) ¿Qué pasa si no tengo toda la documentación que me solicitan al inscribirme? </p>
                    <div id="faq_12" class="texto_escondido" >
                        <p style="text-align: left;">Los antecedentes que no estén respaldados por la documentación correspondiente no impedirán la inscripción, pero no serán considerados como válidos para el concurso.</p>
                        <p style="text-align: left;">Tenga en cuenta que cada cargo concursado exige el cumplimiento de ciertos requisitos excluyentes. Si usted no los acredita debidamente podrá completar la inscripción, pero no será incluido en la lista de admitidos al concurso.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_13" class="disparador"> 13) ¿Cómo y cuándo me entero si fui admitido? </p>
                    <div id="faq_13" class="texto_escondido" >
                        <p style="text-align: left;">En este sitio, y en <a target="_blank"  href="http://www.desarrollosocial.gob.ar/concursos">www.desarrollosocial.gob.ar/concursos</a> se informará la nómina de inscriptos y la lista de admitidos y no admitidos. El cronograma tentativo se encontrará consignado en las bases de cada concurso.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_14" class="disparador"> 14) ¿Cómo se desarrolla el proceso de concurso? </p>
                    <div id="faq_14" class="texto_escondido" >
                        <p style="text-align: left;">Una vez que el Comité de Selección haya determinado el listado de postulantes Admitidos y No Admitidos en base al cumplimiento o no de los requisitos excluyentes, el proceso se desarrollará en cuatro etapas:</p>
                        <ol>
                            <li>Evaluación de antecedentes curriculares y laborales</li>
                            <li>Evaluación técnica</li>
                            <li>Evaluación mediante entrevista laboral</li>
                            <li>Evaluación del perfil psicológico (si corresponde)</li>
                        </ol>
                        <p style="text-align: left;">Las instancias son sucesivas y excluyentes: esto significa que deberá aprobar cada una de ellas para acceder a la siguiente.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_15" class="disparador"> &nbsp;15) ¿Cómo puedo saber cuáles serán los contenidos que se evaluarán en las etapas del concurso? </p>
                    <div id="faq_15" class="texto_escondido" >
                        <p style="text-align: left;">Leyendo el perfil de cada cargo al que se postula, que se encuentra en las Bases del Concurso. Se le podrá preguntar o proponer ejercicios que guarden relación con cualquiera de los ítems mencionados en las mismas, tanto en lo referente a los Requisitos y Competencias expresamente enunciados, como a lo descripto en “Responsabilidad del Puesto” o en “Principales Tareas” de dicho perfil.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_16" class="disparador"> 16) ¿Cómo se decide quién gana el concurso? </p>
                    <div id="faq_16" class="texto_escondido" >
                        <p style="text-align: left;">Las primeras tres etapas (Evaluación de antecedentes curriculares y laborales; Evaluación técnica; y Evaluación mediante entrevista laboral) serán evaluadas y calificadas por el Comité de Selección. Quienes obtengan al menos 60 puntos sobre los 100 posibles en cada una de las etapas, podrán acceder a la siguiente.</p>
                        <p style="text-align: left;">Superadas las tres primeras etapas, el postulante accederá a la instancia de evaluación del perfil psicológico. Allí se ponderará la adecuación de las características de personalidad del postulante a las necesidades y exigencias del cargo.</p>
                        <p style="text-align: left;">Concluidas estas etapas, el postulante que obtenga el mayor puntaje total será el que gane el concurso.</p>
                        <p style="text-align: left;">En las Bases encontrará una explicación detallada de este tema.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_17" class="disparador"> 17) ¿Existe alguna consideración particular para las personas discapacitadas? </p>
                    <div id="faq_17" class="texto_escondido" >
                        <p style="text-align: left;">Sí. En caso de empate en el puntaje final entre dos o más postulantes, se otorgará prioridad en el orden de mérito a las personas con alguna discapacidad (que deberá ser acreditada mediante certificado emitido por autoridad competente y presentada junto con la documentación en el momento de la inscripción).</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_18" class="disparador"> 18) ¿Si quedé seleccionado, cuándo empiezo a trabajar? </p>
                    <div id="faq_18" class="texto_escondido" >
                        <p style="text-align: left;">Usted será citado por el área de Recursos Humanos del organismo al cual pertenece el cargo, para completar la documentación necesaria para su designación por Decreto del Poder Ejecutivo Nacional.</p>
                        <p style="text-align: left;">Una vez publicado el Decreto, la prestación de servicios comenzará dentro de los 30 días corridos desde la fecha de notificación.&nbsp;</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_19" class="disparador"> 19) ¿Cuál es la remuneración? </p>
                    <div id="faq_19" class="texto_escondido" >
                        <p style="text-align: left;">Depende del cargo al que se postule. Los valores se encuentran consignados en las Bases del Concurso y están expresadas en importe bruto.</p>
                        <p style="text-align: left;">&nbsp;</p>
                    </div>

                    <p name="faq_20" class="disparador"> 20) ¿Cuál es la carga horaria del puesto de trabajo? </p>
                    <div id="faq_20" class="texto_escondido" >
                        <p style="text-align: left;">Los cargos de nivel A, B, C y D tienen una carga horaria de 40 horas semanales. Los cargos E y F, de 35 horas semanales.</p>
                        <p style="text-align: left;">En caso de tratarse de personas de entre 16 y 18 años, la carga será de 30 horas semanales.</p>
                        <p style="text-align: left;">En todos los casos, el horario de ingreso depende del puesto.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_21" class="disparador"> 21) ¿Cuál es el lugar de trabajo? </p>
                    <div id="faq_21" class="texto_escondido" >
                        <p style="text-align: left;">El lugar de trabajo depende del cargo al cual se postule y se encuentra consignado en las bases del concurso.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_22" class="disparador"> 22) ¿Hay alguna edad límite de ingreso? </p>
                    <div id="faq_22" class="texto_escondido" >
                        <p style="text-align: left;">Sólo la prevista para acceder a la jubilación.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_23" class="disparador"> 23) ¿Durante cuánto tiempo estaré contratado si soy seleccionado? </p>
                    <div id="faq_23" class="texto_escondido" >
                        <p style="text-align: left;">El postulante que quede seleccionado ingresará a la Planta Permanente del organismo correspondiente. Superado el período de prueba de 12 meses su designación quedará firme, lo que implica que se encontrará en relación de dependencia hasta que decida renunciar, se jubile o incurra en alguna falta que amerite su cesantía, exoneración o despido.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_24" class="disparador"> 24) ¿Qué pasa si soy extranjero? </p>
                    <div id="faq_24" class="texto_escondido" >
                        <p style="text-align: left;">Aunque el llamado a concurso está dirigido a argentinos nativos, naturalizados o por opción, los extranjeros también pueden inscribirse.</p>
                        <p style="text-align: left;">En caso de resultar seleccionados, el titular del organismo al cual pertenece el cargo podrá solicitar al Jefe de Gabinete de Ministros la excepción del cumplimiento de este requisito.</p>
                        <p style="text-align: left;">&nbsp;&nbsp;</p>
                    </div>

                    <p name="faq_25" class="disparador"> 25) ¿Qué significa que los datos tienen carácter de declaración jurada? </p>
                    <div id="faq_25" class="texto_escondido" >
                        <p style="text-align: left;">Que todo lo volcado por el postulante en el Sistema de Inscripción, como así también en la documentación presentada al momento de la inscripción documental, reviste carácter de verdad y, por lo tanto, cualquier falsedad que pudiera comprobarse dará lugar a su exclusión del concurso.</p>
                        <div class="separadorcopete">&nbsp;</div>  
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
