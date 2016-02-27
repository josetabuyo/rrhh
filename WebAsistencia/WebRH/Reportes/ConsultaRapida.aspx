<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaRapida.aspx.cs" Inherits="Reportes_ConsultaRapida" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Rapida</title>
     <%= Referencias.Css("../")%>           
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>        
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
         <link href="Reportes.css" rel="stylesheet" type="text/css"/>
         <link href="timeline.css" rel="stylesheet" type="text/css"/>
       <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
        <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
        <script type="text/javascript" src="../Scripts/Persona.js"></script>
        <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
        <script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
        <script type="text/javascript" src="../Scripts/jquery-barcode.js"></script>       
        <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
        <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
        <script type="text/javascript" src="Reportes.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Reportes</span> <br/> <span style='font-size:12px;'> Reportes </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
    <div id="contenedor_consulta_rapida" style="margin:30px;">
        
        <div id="buscador_de_personas">
            <p class="buscarPersona">Buscar persona:
                <div id="selector_usuario" class="selector_personas">
                    <input id="buscador" type=hidden />
                </div>
            </p>
        </div>

        <div id="panel_izquierdo" class="estilo_formulario">
            <div class="bloque_foto">
                <img id="foto_usuario" src="../Imagenes/silueta.gif" alt="Usuario" width="128" height="128">
                <input id="btn_timeline" type="button" value="Timeline" class="btn btn-primary" />
            </div>
                <div id="panel_datos_personales">
                    <div class="linea dato_personal">
                            <fieldset>
                            <legend>Datos Personales</legend>
                            <div>
                                <p class="bloque_consulta"><label>Legajo: </label><span id="legajo"></span></p>
                                <p class="bloque_consulta"><label>Documento: </label><span id="documento"></span></p>
                            </div>
                            <div>
                                <p class="bloque_consulta"><label>Nombre: </label><span id="nombre"></span></p>
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
                               
                    </fieldset>
                    </div>
                         <div class="linea dato_personal">
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
                         </div>   
        </div>
        <div id="lean_overlay" class="estilo_formulario">
        <div class="modal_close_concursar"></div>
            
            <section style="background-color:#e9f0f5;" id="cd-timeline">
                <div style="color:#fff; text-align: center; position: inherit; background: #303e49; padding: 15px; line-height: 100px;">
                    <h2 style="position: inherit;">Carrera Admnistrativa</h2>
                </div>
	            <div class="cd-timeline-block">
		            <div class="cd-timeline-img">
			            <img src="../Imagenes/ic_documento.png" alt="Picture" />
		            </div> <!-- cd-timeline-img -->
 
		            <div class="cd-timeline-content">
			            <h2>Aprobación de Contrato</h2>
			            <p>Organismo: Sec. Coord. y Monit. Inst / Agrupamiento: General</p>
                        <p>Nivel:1 / Grado: 0 / Cargo: Tecnico-Administrativo</p>
			            <span class="cd-date">2010-09-01</span>
		            </div> <!-- cd-timeline-content -->
	            </div> <!-- cd-timeline-block -->
                <div class="cd-timeline-block">
		            <div class="cd-timeline-img">
			            <img src="../Imagenes/ic_documento.png" alt="Picture" />
		            </div> <!-- cd-timeline-img -->
 
		            <div class="cd-timeline-content">
			            <h2>Cambio de agrupamiento</h2>
			            <p>Paso a agrupamiento PROFESIONAL</p>
			            <span class="cd-date">20/01/2016</span>
		            </div> <!-- cd-timeline-content -->
	            </div> <!-- cd-timeline-block -->
                <div class="cd-timeline-block">
		            <div class="cd-timeline-img">
			            <img src="../Imagenes/ic_documento.png" alt="Picture" />
		            </div> <!-- cd-timeline-img -->
 
		            <div class="cd-timeline-content">
			            <h2>Nombramiento</h2>
			            <p>Fue nombrano a Director</p>
			            <span class="cd-date">01/02/2016</span>
		            </div> <!-- cd-timeline-content -->
	            </div> <!-- cd-timeline-block -->
                 <div class="cd-timeline-block">
		            <div class="cd-timeline-img">
			            <img src="../Imagenes/ic_documento.png" alt="Picture" />
		            </div> <!-- cd-timeline-img -->
 
		            <div class="cd-timeline-content">
			            <h2>Nombramiento</h2>
			            <p>Fue nombrano a Director</p>
			            <span class="cd-date">01/02/2016</span>
		            </div> <!-- cd-timeline-content -->
	            </div> <!-- cd-timeline-block -->
 
	            
            </section>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript" >

    Reportes.iniciarConsultaRapida();

    $("#btn_timeline").leanModal({ top: 200, overlay: 1, closeButton: ".modal_close" });

    jQuery(document).ready(function ($) {
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
