<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividual.aspx.cs" Inherits="Reportes_ConsultaRapida" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Rapida</title>
     <%= Referencias.Css("../")%>           
        <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>           
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
        <link href="Reportes.css" rel="stylesheet" type="text/css"/>
        <link href="timeline.css" rel="stylesheet" type="text/css"/>
       <%= Referencias.Javascript("../")%>
        
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Reportes</span> <br/> <span style='font-size:12px;'> Reportes </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
    
    
    <div id="contenedor_consulta_rapida" style="margin:30px;">
        <a style="font-size: 1.6em;display: block;margin-bottom: 10px;" href="Reportes.aspx">Volver</a>
      <h1 style="font-weight: 200; text-align:center;">Consulta Individual</h1>
        <div id="buscador_de_personas">
            <p class="buscarPersona" style="display: inline-block;">Buscar persona:
                <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                    <input id="buscador" type="hidden" />
                </div>
            </p>
        </div>
        
        <span id="mensaje"></span>
        <div id="panel_izquierdo" class="estilo_formulario" style="opacity:0;">
            <div id="foto_usuario" class="foto_usuario" class="bloque_foto">
                
                
                <%--<img id="foto_usuario" src="../Imagenes/silueta.gif" alt="Usuario" width="128" height="128">--%>
                <!--<input id="btn_timeline" type="button" value="Carrera" class="btn btn-primary" />-->
            </div>
            <img id="foto_usuario_generica" class="foto_usuario" src="../Imagenes/silueta.gif" style="margin-top: 25px;"/>
                <div id="panel_datos_personales">
                    <div class="linea dato_personal">
                            <fieldset>
                            <legend>Datos Personales</legend>
                            <div>
                                <p class="bloque_consulta"><label>Legajo: </label><span id="legajo_consulta"></span></p>
                                <p class="bloque_consulta"><label>Documento: </label><span id="documento_consulta"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta"><label>Nombre: </label><span id="nombre_consulta"></span></p>
                                <p class="bloque_consulta"><label>Edad: </label><span id="edad"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta"><label>F. Nacimiento: </label><span id="fechaNacimiento"></span></p>
                                <p class="bloque_consulta"><label>Sexo: </label><span id="sexo"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta"><label>Estado Civil: </label><span id="estadoCivil"></span></p>
                                <p class="bloque_consulta"><label>CUIL: </label><span id="cuil"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta_full"><label>Domicilio: </label><span id="domicilio"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta_full"><label>Estudio: </label><span id="estudio"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta_full"><label>Estado: </label><span id="baja"></span></p>
                                <p class="bloque_consulta_full" style="display:none;"><label>Bloqueo Sueldo: </label><span id="bloqueo" ></span></p>
                                <p class="bloque_consulta_full" style="display:none;"><label>Gremio: </label><span id="cargo_gremial" ></span></p>
                                <p class="bloque_consulta_full" style="display:none;"><label>Acta: </label><span id="acto_alta" ></span></p>
                            </div>
                        </fieldset>
                    </div>
                </div>
                <div class="linea dato_personal">
                    <fieldset>
                        <legend>Cargo y Actividad</legend>
                            <div>
                            <p class="bloque_consulta_full"><label>Sector: </label><span id="sector"></span></p> 
                        </div>
                        <div>
                            <p class="bloque_consulta"><label>Nivel y Grado: </label><span id="nivel_grado"></span></p>
                            <p class="bloque_consulta"><label>Planta: </label><span id="planta"></span></p>
                        </div>
                        <div>
                            <p class="bloque_consulta"><label>Cargo: </label><span id="cargo"></span></p>
                            <p class="bloque_consulta"><label>Agrupamiento: </label><span id="agrupamiento"></span></p>
                        </div>
                        <div>
                            <p class="bloque_consulta"><label>Ing. Min.: </label><span id="ing_min"></span></p>
                         </div>  
                    </fieldset>
                    </div>
                         <!--<div class="linea dato_personal">
                            <fieldset>
                                <legend>Antiguedad</legend>
                                <div>
                                    <p class="bloque_consulta"><label>Estado: </label><span id="estado"></span></p>
                                    <p class="bloque_consulta"><label>Privada: </label><span id="privada"></span></p>
                                    <p class="bloque_consulta"><label>Resta: </label><span id="resta"></span></p>
                                </div>
                                <div>
                                    <p class="bloque_consulta"><label>Ing. Min.: </label><span id="ing_min"></span></p>
                                    <p class="bloque_consulta"><label>Ant. Min: </label><span id="ant_min"></span></p>
                                    <p class="bloque_consulta"><label>Total: </label><span id="total"></span></p>
                                 </div>
                            </fieldset>
                         </div>   -->
        </div>
        <div id="lean_overlay" class="estilo_formulario">
        <div class="modal_close_concursar"></div>
            
            <section class="col-center" style="background-color:#e9f0f5; width:80%;" id="cd-timeline">
                <div style="color:#fff; text-align: center; position: inherit; background: #303e49; padding: 15px; line-height: 100px;">
                    <h2 style="position: inherit;">Carrera Admnistrativa</h2>
                </div>
                <div id="contenedor_timeLine">
                </div>
                <!-- INSERTAR LAS PLANTILLAS -->

            </section>
        </div>
    </div>
        <div id="plantillas">
            <div class="vista_persona_en_selector">
                <div id="contenedor_legajo" class="label label-warning">
                    <div id="titulo_legajo">Leg:</div>
                    <div id="legajo"></div>
                </div> 
                <div id="nombre"></div>
                <div id="apellido"></div>
                <div id="contenedor_doc" class="label label-default">
                    <div id="titulo_doc">Doc:</div>
                    <div id="documento"></div>         
                </div>   
            </div>

            	<div id="bloque_timeline"  class="bloque_timeline cd-timeline-block">
		            <div class="cd-timeline-img">
			            <img src="../Imagenes/ic_documento.png" alt="Picture" />
		            </div> <!-- cd-timeline-img -->
 
		            <div class="cd-timeline-content">
			            <h2 class="titulo_hito"></h2>
			            <p class="descripcion_hito"></p>
			            <span class="cd-date"></span>
		            </div> <!-- cd-timeline-content -->
	            </div> <!-- cd-timeline-block -->
        </div>
    </form>
</body>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
    <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
    <script type="text/javascript" src="../Scripts/Persona.js"></script>
    <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
    <script type="text/javascript" src="Reportes.js"></script>
    <script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" >
  
    $("#btn_timeline").leanModal({ top: 200, overlay: 1, closeButton: ".modal_close" });

    $(document).ready(function ($) {


        Backend.start(function () {
            Reportes.iniciarConsultaRapida();
        });
       

        var timelineBlocks = $('.cd-timeline-block'),
		offset = 0.8;

        //hide timeline blocks which are outside the viewport
        hideBlocks(timelineBlocks, offset);

        //on scolling, show/animate timeline blocks when enter the viewport
        $(window).on('scroll', function () {
            (!window.requestAnimationFrame)
			? setTimeout(function () { showBlocks(timelineBlocks, offset); }, 100)
			: window.requestAnimationFrame(function () { showBlocks(timelineBlocks, offset); });
        });

        function hideBlocks(blocks, offset) {
            blocks.each(function () {
                ($(this).offset().top > $(window).scrollTop() + $(window).height() * offset) && $(this).find('.cd-timeline-img, .cd-timeline-content').addClass('is-hidden');
            });
        }

        function showBlocks(blocks, offset) {
            blocks.each(function () {
                ($(this).offset().top <= $(window).scrollTop() + $(window).height() * offset && $(this).find('.cd-timeline-img').hasClass('is-hidden')) && $(this).find('.cd-timeline-img, .cd-timeline-content').removeClass('is-hidden').addClass('bounce-in');
            });
        }
    });

    
</script> 
</html>
