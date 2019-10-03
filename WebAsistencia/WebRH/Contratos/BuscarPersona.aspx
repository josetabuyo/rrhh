<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BuscarPersona.aspx.vb" Inherits="Contratos_BuscarPersona" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Buscador Contratos</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta name="viewport" content="width=device-width"/>
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
    
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/> 
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet"  href="EstiloBuscarPersona.css" />
    <link rel="stylesheet" href="../MAU/Permisos.css" type="text/css"/>    
       
    
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet"/>
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet"/>

    
       
</head>

<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq">
            </div>
            
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


<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<script type="text/javascript" src="BuscarPersona.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>



<script type="text/javascript" >

    $(document).ready(function ($) {

     
        Backend.start(function () {
            //para cargar el menu izquierdo 
            $(".caja_izq").load("PanelIzquierdo.html", function () {
                Permisos.init();
                Permisos.iniciarConsultaRapida();
            });
 
        });
    });

</script> 
</html>

