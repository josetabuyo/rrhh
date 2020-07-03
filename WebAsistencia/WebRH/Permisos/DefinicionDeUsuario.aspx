<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefinicionDeUsuario.aspx.cs" Inherits="Permisos_DefinicionDeUsuario" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
        <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />
        <link rel="stylesheet" href="Permisos.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>   
         
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
 

        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
       
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>
            
            <div class="caja_der papel">
                <br />
                <div class="cajaPermisos">
                    <div id="buscador_de_personas">
                        <p class="buscarPersona" style="display: inline-block;">Buscar persona:
                            <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" type="hidden" />
                            </div>
                        </p>
                    </div>
                </div>

            <!--
            <div id="panel_usuarios_por_area" >
                <p class="persona_baja_con_funcionalidades">Consultar Usuarios Por Área</p>
                    <div id="lista_areas_para_consultar" style="display: inline;">
                        
                    </div>
                    <div id="selector_area_usuarios" class="selector_areas" style="position: inherit; display: inline;">
                        <input id="Hidden1" type="hidden" class="buscarUsuarioPorArea" />
                    </div>
                <div id="contenedor_usuarios_por_area">
                    <p id="p_nombre_area"></p>
                    <table id="tabla_usuarios_por_area"></table>
                </div>
                 <hr />  
             </div> 

              <div id="panel_personas_de_baja_con_permisos" >
                <p class="persona_baja_con_funcionalidades">Consultar Personas de Baja con Permisos</p>
                <input type="button" value="Consultar" id="btn_buscar_personas_de_baja" class="btn btn-primary" />
                <div id="contenedor_personas_de_baja">
                    <table id="tabla_personas_de_baja"></table>
                </div>
                <hr />  
             </div> -->


            <div id="panel_datos_usuario" style="display:none">
                <div id="panel_superior_izquierdo" class="estilo_formulario">
                    <div id="contenedor_foto">
                        <div id="foto_usuario"> </div>
                        <img id="foto_usuario_generica" src="usuario.png"/>
                        <div id="barrita_cambio_foto">
                            <div>Cambiar</div>
                        </div>
                    </div>
                    <div id="cambio_imagen_pendiente" >
                        <img src="camera.png"/>
                    </div>
                    <div id="panel_datos_personales">
                        <div class="linea dato_personal">
                            <div id="nombre2"></div>
                            <div id="apellido2"></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Documento:</div>
                            <div id="documento2" ></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Legajo:</div>
                            <div id="legajo2"></div>    
                        </div>     
                        <div class="linea dato_personal">
                            <div>Email:</div>
                            <div id="email"></div>   
                            <input id="btn_modificar_mail" type="button" class="btn-primary botonesPermisos" value="Modificar"  /> 
                        </div>      
                        <input id="btn_credencial_usuario" type="button" class="btn-primary botonesPermisos" value="Credencial" />           
                    </div>
                    <div id="panel_password">
                        <div class="linea linea_nombre_usuario">
                            <div class="titulo">Nombre de Usuario</div>
                            <div id="txt_nombre_usuario"> </div>  
                        </div>
                        <div class="linea linea_passwrd">
                            <div class="titulo">Contraseña:</div>
                            <input id="btn_reset_password" type="button" class="btn-primary botonesPermisos" value="Resetear" />
                        </div>
                        <div class="seccion_verificacion_usuario">
                            <div id="usuario_verificado">DNI Verificado</div>    
                            <div id="usuario_no_verificado">DNI No Verificado</div>    
                            <input id="btn_verificar_usuario" type="button" class="btn-primary botonesPermisos" value="Verificar"  />
                        </div>
                    </div>
                </div> 
            </div> 

                <div id="caja_permisos_actuales" style="display:none;">
                    <legend style="margin-top: 20px;">PERMISOS ACTUALES</legend>
                    <div id="tabla_permisos">
    
                    </div>

                    <div id="caja_funcionalidades">
                         <input type="text" id="search" class="search buscador" style="height: 30px;" placeholder="Buscar Funcionalidad"  />
                         <div id="tabla_funcionalidades">
    
                        </div>
                    </div>
                    
                </div>
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

            	
        </div>
    </form>
</body>


<script type="text/javascript" src="../MAU/VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="../MAU/Autorizador.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/AdministradorDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/Usuario.js"></script>
<script type="text/javascript" src="../MAU/HabilitadorDeControles.js"></script>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>


<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeEntidades.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeEntidades.js"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<script type="text/javascript" src="Permisos.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>



<script type="text/javascript" >

    $(document).ready(function ($) {

     
        Backend.start(function () {
            Permisos.init();
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {
                
                Permisos.iniciarConsultaRapida();
                //FC: para importar el HabilitadorDeControles y afecte la seccion izquierda
                var imported = document.createElement('script');
                    imported.src = '../MAU/HabilitadorDeControles.js';
                document.head.appendChild(imported);


                $('#btnPantallaAsignarPerfil').click(function () {
                    $(".caja_der").load("AsignacionDePerfiles.htm", function () {
                        Permisos.iniciarPantallaAsignacionPerfiles();
                        Permisos.getPerfilesDelUsuario();
                        Permisos.getPerfilesConFuncionalidades();

                        $("#dialog").dialog({
                            autoOpen: false,
                            show: {
                                effect: "blind",
                                duration: 1000
                            },
                            hide: {
                                effect: "explode",
                                duration: 1000
                            }
                        });

                        $("#mostrarDialogo").click(function () {
                            $("#dialog").dialog("open");
                        });
                        
                    });
                });//FIN clickBtnPantalla
                
                $('#btnPantallaAsignarFuncionalidad').click(function () {
                    $(".caja_der").load("AsignacionDeFuncionalidades.htm", function () {
                        Permisos.iniciarPantallaAsignacionFuncionalidad();
                        Permisos.getFuncionalidadesDelUsuario();


                        
                    });
                });

                $("#btnBuscarPersonasDeBaja").click(function () {
                    $(".caja_der").load("ConsultaPermisosDeBaja.htm", function () {
                        Permisos.getPersonasDeBajaConPermisos();
                    });
                   
                });

                $("#btnBuscarUsuariosPorArea").click(function () {
                    $(".caja_der").load("ConsultarUsuariosPorArea.htm", function () {
                        Permisos.buscadorUsuariosPorArea();
                    });
                   
                });


                

                

            });
 
        });
    });

</script> 
</html>
