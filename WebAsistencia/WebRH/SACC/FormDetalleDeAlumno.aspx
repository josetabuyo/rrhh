<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalleDeAlumno.aspx.cs" Inherits="SACC_FormDetalleDeAlumno" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />

    <style>
        
        .subtitulos 
        {
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);
        }
        ul.tabs 
        {
            margin: 0;  
            padding: 0;  
            float: left;  
            list-style: none;  
            height: auto;  
            width: 80%; 
            border-left:2px solid #777; 
            border-bottom:2px solid #777;
        }
        ul.tabs li 
        {
            float: left;  
            margin-left: 0px;  
            
            width:25%;
            text-align:center;
            border: 0px solid #000; 
            overflow: hidden; 
            position: relative; 
            background: #bbb; 
            border-left:0px; 
            margin-bottom:-2px;
            background-image: linear-gradient(bottom, rgb(73,136,199) 36%, rgb(199,222,255) 70%);
            background-image: -o-linear-gradient(bottom, rgb(73,136,199) 36%, rgb(199,222,255) 70%);
            background-image: -moz-linear-gradient(bottom, rgb(73,136,199) 36%, rgb(199,222,255) 70%);
            background-image: -webkit-linear-gradient(bottom, rgb(73,136,199) 36%, rgb(199,222,255) 70%);
            background-image: -ms-linear-gradient(bottom, rgb(73,136,199) 36%, rgb(199,222,255) 70%);
            -webkit-border-radius: 8px;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            border-radius: 8px;
            
        }
        
        ul.tabs li a 
        {
            text-decoration: none; 
            color: #fff; 
            display: block; 
            font-size: 20px; 
            font-weight:bold; 
            padding: 10px 0px; 
            /*padding: 10px 20px; */
        }
        ul.tabs li a:hover 
        {
            background-image: linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -o-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -moz-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -webkit-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -ms-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
             -webkit-border-radius: 8px;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            border-radius: 8px;
            padding: 10px 0px; 
        }
        
        ul.tabs li.active, html ul.tabs li.active a:hover  
        {
            background-image: linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -o-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -moz-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -webkit-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            background-image: -ms-linear-gradient(bottom, rgb(199,222,255) 36%, rgb(73,136,199) 70%);
            border-bottom: 2px solid #eee; 
            }
 
        .Contenedor
        {
            border: 2px solid #777; 
            border-top: none; 
            overflow: hidden; 
            clear: both; 
            float: left; 
            width: 80%; 
            height:500px;
            background: #eee;
            -webkit-border-bottom-right-radius: 8px;
            -webkit-border-bottom-left-radius: 8px;
            -moz-border-radius-bottomright: 8px;
            -moz-border-radius-bottomleft: 8px;
            border-bottom-right-radius: 8px;
            border-bottom-left-radius: 8px;
            background-image: linear-gradient(bottom, rgb(189,222,255) 42%, rgb(232,241,255) 71%);
            background-image: -o-linear-gradient(bottom, rgb(189,222,255) 42%, rgb(232,241,255) 71%);
            background-image: -moz-linear-gradient(bottom, rgb(189,222,255) 42%, rgb(232,241,255) 71%);
            background-image: -webkit-linear-gradient(bottom, rgb(189,222,255) 42%, rgb(232,241,255) 71%);
            background-image: -ms-linear-gradient(bottom, rgb(189,222,255) 42%, rgb(232,241,255) 71%);
        }
        .Contenido 
        {
            padding: 15px; 
            font-size: 12px;        
        }
        
        .imagen 
        {
            float:left;
            margin:10px 10px;
           
            }
        
        .contenedor_tabla 
        {

            }
            
        .contenedor_ficha 
        {
            width:80%;
            /*border:1px solid #000;   */
            font-size:11px;
            margin-bottom:10px;
        }
        
        .fila_impar, .fila_par 
        {
            height:20px; 
            /*background:#87baed; */
            /*border:1px solid #000;*/
        }
        .fila_impar .contenedor_celda 
        {
            background:#87baed;
            }
        
        .contenedor_celda 
        {
            width:40%;
            float:left;
            border:1px solid #000;
            
        }
        
        .titulo 
        {
            text-transform:uppercase;
            font-weight:bold;
            /*margin-right:20%;*/
            }
            
        .dato 
        {
            /*padding-left:100px;*/
        }
        .nombre 
        {
            font-size:1.5em;
            font-weight:bold;
        }
        .oficina 
        {
            font-size:1.2em;
            }
    
    </style>

</head>
<body>
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
     <fieldset>
        <legend class="subtitulos">Ficha del Alumno</legend>
     </fieldset>

     <div id="datos_personales" class="contenedor_ficha">
        <p id="nombre" class="nombre"></p>
        <p class="oficina">Oficina:<span id="oficina" class=""></span></p>
        <img id="ficha_alumno" src="../Imagenes/31475729.jpg" alt="foto" width="95" height="95"  class="imagen" />
              
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
        <li><a href="#tab3">M&aacute;s informaci&oacute;n</a></li>
    </ul>
    <div class="Contenedor">
        <div id="tab1" class="Contenido">
            <h2>Listado de Cursos Inscriptos</h2>
        </div>
        <div id="tab2" class="Contenido">
            <h2>Listado de Asistencia por Curso</h2>
            <h2>Detalle de Asistencia por Curso</h2>
        </div>
        <div id="tab3" Class="Contenido">
            <h2>Calificaciones por Curso</h2>
        </div>
        <div id="tab4" Class="Contenido">
            <h2>Mas informacion</h2>
        </div>
    </div>


     <asp:HiddenField ID="alumnoJSON" runat="server" EnableViewState="true"/>

    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>

    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>


    <script type="text/javascript">
        var AdministradorFichaAlumno = function () {
            var alumno = JSON.parse($('#alumnoJSON').val());

            var EncabezadoPlanilla;
            contenedorFichaAlumno = $('#contenedor_tabla');
            //var columnas = [];

            $('#nombre').html(alumno.Nombre);
            $('#oficina').html(alumno.LugarDeTrabajo);
            $('#dni').html(alumno.Documento);
            $('#perfil').html('Alumno');
            $('#telefono').html(alumno.Telefono);
            $('#modalidad').html(alumno.Modalidad.Descripcion);
            $('#celular').html(alumno.Celular);
            $('#estado').html(alumno.EstadoDeCursada);
            $('#mail').html(alumno.Mail);
            $('#anio_cursando').html(alumno.CicloCursado);
            $('#direccion').html(alumno.Direccion);
            $('#tutor').html(alumno.Tutor);
            $('#fecha_nac').html(alumno.FechaDeNacimiento);
            $('#fecha_ingreso').html(alumno.FechaDeIngreso);

            //columnas.push(new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento } }));


            //FichaAlumno = new FichaAlumno();


            //PlanillaAlumnos.AgregarEstilo("tabla_macc");
            //PlanillaAlumnos.agregarBuscador();

            //PlanillaAlumnos.SetOnRowClickEventHandler(function (un_alumno) {
            //    panelAlumno.CompletarDatosAlumno(un_alumno);
            //});

            //FichaAlumno.CargarObjetos(Alumnos);
            //FichaAlumno.DibujarEn(contenedorFichaAlumno);



            /* panelAlumno.CompletarDatosAlumno = function (un_alumno) {

            $("#input_dni").val("");
            $("#idAlumnoAVer").val(un_alumno.Id);
            $("#lblDatoApellido").val(un_alumno.Apellido);
            $("#lblDatoNombre").val(un_alumno.Nombre);
            $("#lblDatoDocumento").val(un_alumno.Documento);
            $("#lblDatoTelefono").val(un_alumno.Telefono);
            $("#lblDatoMail").val(un_alumno.Mail);
            $("#lblDatoDireccion").val(un_alumno.Direccion);
            $("#cmbPlanDeEstudio").val(un_alumno.Modalidad.Id);
            $("#idBaja").val(un_alumno.Baja);
            $("#btnAgregarAlumno").attr("disabled", true);
            $("#btnModificarAlumno").attr("disabled", false);
            $("#btnQuitarAlumno").attr("disabled", false);
            };*/


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
        });

        $(document).ready(function () {
            AdministradorFichaAlumno();

        });
    </script>
    </form>
</body>
</html>
