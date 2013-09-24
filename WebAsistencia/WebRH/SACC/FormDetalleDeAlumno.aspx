<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalleDeAlumno.aspx.cs" Inherits="SACC_FormDetalleDeAlumno" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>

    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link5" rel="stylesheet" href="EstilosSACC.css" type="text/css" runat="server" /> 
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>

    <style type="text/css">

    </style>

</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
     <fieldset>
        <legend class="subtitulos">Ficha del Alumno</legend>
     </fieldset>
     <div id="contenedor_global">
     <div id="datos_personales" class="contenedor_ficha">
        <p class="nombre">Nombre: <span id="nombre" class=""></span></p>
        <p class="nombre">Oficina: <span id="oficina" class=""></span></p>
        <img id="ficha_alumno" src="../Imagenes/silueta.gif" alt="foto" width="95" height="95"  class="imagen" />
              
        <div id="contenedor_tabla">
            <div class="fila_impar">
                <div class="contenedor_celda">
                    <span class="titulo">DNI:</span>
                    <span id="dni" class="dato"> 25.315.235</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Perfil:</span>
                    <span id="perfil" class="dato"> Alumno</span>
                </div>
            </div>
            <div class="fila_par">
                <div class="contenedor_celda">
                    <span class="titulo">T&eacute;lefono:</span>
                    <span id="telefono" class="dato"> 4444-4444</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Modalidad:</span>
                    <span id="modalidad" class="dato"> Fines CENS</span>
                </div>
            </div>
            <div class="fila_impar">
                <div class="contenedor_celda">
                    <span class="titulo">Celular:</span>
                    <span id="celular" class="dato"> 15-4444-4444</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Estado:</span>
                    <span id="estado" class="dato"> Cursando</span>
                </div>
            </div>
            <div class="fila_par">
                <div class="contenedor_celda">
                    <span class="titulo">Mail:</span>
                    <span id="mail" class="dato"> carla@gmail.com</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Cursando A&ntilde;o:</span>
                    <span id="anio_cursando" class="dato"> 2do a&ntilde;o</span>
                </div>
            </div>
            <div class="fila_impar">
                <div class="contenedor_celda">
                    <span class="titulo">Direccion:</span>
                    <span id="direccion" class="dato">Av. Alvear 2145 Piso 4 dto B</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Tutor:</span>
                    <span id="tutor" class="dato"> Juan Perez</span>
                </div>
            </div>
            <div class="fila_par">
                <div class="contenedor_celda">
                    <span class="titulo">Fecha Nac.:</span>
                    <span id="fecha_nac" class="dato"> 10/08/1984</span>
                </div>
                <div class="contenedor_celda">
                    <span class="titulo">Fecha Ingreso:</span>
                    <span id="fecha_ingreso" class="dato"> 01/01/2012</span>
                </div>
            </div>
        </div>
     </div>

     <ul class="tabs">
        <li><a href="#tab1">Cursadas</a></li>
        <li><a href="#tab2">Asistencias</a></li>
        <li><a href="#tab3">Evaluaciones</a></li>
        <li><a href="#tab4">Perfil</a></li>
    </ul>
    <div class="Contenedor">
        <div id="tab1" class="Contenido">
            <h2 class="sub_eval">Listado de Cursos Inscriptos</h2>
            <div id="ContenedorPlanillaCursos" runat="server"></div>
        </div>
        <div id="tab2" class="Contenido">
            <h2 class="sub_eval">Listado de Asistencia por Curso</h2>
            <h2 class="sub_eval">Detalle de Asistencia por Curso</h2>
        </div>
        <div id="tab3" class="Contenido">
            <div style=" width:55%; margin-right:20px; float:left;">
                <h2 class="sub_eval">Calificaciones por Curso</h2>
                
                <div id="ContenedorPlanillaEvaluaciones"  runat="server"></div>
            </div>
            <div style="width: 40%; display: inline; float: left;">
                <h2 id="sub_eval_nota"></h2>
                <div id="ContenedorPlanillaEvaluacionesDetalle" runat="server"></div>
            </div>
        </div>
        <div id="tab4" class="Contenido">
            <h2 class="sub_eval">Perfil</h2> 
        <div  class="content">
         <ul>
                <li>Asistencia: <small>Viene siempre</small></li>
                <li>Puntulidad: <small>Suele llegar tarde los dias martes por problemas personales</small></li>    
                <li>Nivel de Compromiso: <small>Alto</small></li>
                <li>Participación: <small>Media</small></li>
                <li>Cumplimiento con las Tareas: <small>Cumple siempre con la tarea</small></li>
                <li>Integración al Grupo: <small>Es solitario</small></li>
                <li>Respeta las Normas de Convivencia: <small>Suele respetar las normas</small></li>
                <li>Responsabilidad: <small>Muy responsable</small></li>
            </ul>
        </div>

        </div>
    </div>
    </div>

     <asp:HiddenField ID="alumnoJSON" runat="server" EnableViewState="true"/>
     <asp:HiddenField ID="cursosJSON" runat="server" EnableViewState="true"/>
     <asp:HiddenField ID="evaluacionesJSON" runat="server" EnableViewState="true"/>

    <script type="text/javascript" src="../Scripts/Grilla.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/FichaAlumno.js"></script>

    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>


    <script type="text/javascript">
        var AdministradorFichaAlumno = function () {

            var items_pantalla = {
                alumno: JSON.parse($('#alumnoJSON').val()),
                cursos_inscriptos: JSON.parse($('#cursosJSON').val()),
                evaluaciones_por_curso: JSON.parse($('#evaluacionesJSON').val()),
                contenedorPlanillaCursos: $('#ContenedorPlanillaCursos'),
                contenedorPlanillaEvaluaciones: $('#ContenedorPlanillaEvaluaciones'),
                contenedorPlanillaEvaluacionesDetalle: $('#ContenedorPlanillaEvaluacionesDetalle'),
                sub_eval_2: $("#sub_eval_nota"),
                PlanillaCursos: $("<div>"),
                PlanillaEvaluaciones: $("<div>"),
                PlanillaEvaluacionesDetalle: $("<div>"),
                ficha_nombre: $('#nombre'),
                ficha_oficina: $('#oficina'),
                ficha_dni: $('#dni'),
                ficha_telefono: $('#telefono'),
                ficha_perfil: $('#perfil'),
                ficha_modalidad: $('#modalidad'),
                ficha_celular: $('#celular'),
                ficha_estado:  $('#estado'),
                ficha_mail: $('#mail'),
                ficha_aniocursado: $('#anio_cursando'),
                ficha_direccion:  $('#direccion'),
                ficha_tutor:  $('#tutor'),
                ficha_fecha_nac: $('#fecha_nac'),
                ficha_ingreso: $('#fecha_ingreso')
            }

            var ficha_alumno = new FichaAlumno(items_pantalla);

        };

        //FUNCTION PARA TABS
        $(document).ready(function () {
            $(".Contenido").hide(); //Para ocultar los DIV's con contenido
            $("ul.tabs li:first").addClass("active").show(); //Activamos el primer TAB
            $(".Contenido:first").show(); //Muestra el contenido respectivo al primer TAB

            //Al clickar sobre los Tabs
            $("ul.tabs li").click(function () {
                $("ul.tabs li").removeClass("active"); //Anula todas las selecciones
                $(this).addClass("active"); //Asigna la clase Active al TAB Seleccionado
                $(".Contenido").hide(); //Esconde todo el contenido de la tab
                var activeTab = $(this).find("a").attr("href"); //Ubica los valores HREF y A para enlazarlos y activarlos
                $(activeTab).fadeIn(); //Habilita efecto Fade en la transición de contenidos
                return false;
            });

            AdministradorFichaAlumno();
         
            
            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
        });

	
    </script>
    </form>
</body>
</html>
