<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdministradorDeUsuarios.aspx.cs" Inherits="MAU_Permisos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH - Permisos de usuario</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>    
    <link rel="stylesheet" href="Permisos.css" type="text/css"/>    
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
    <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>    
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link href="ui.dynatree.css" rel="stylesheet" type="text/css"/>
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0px !important;">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.A.U.</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div id="administrador_usuarios">            
            <div id="panel_busqueda">
                <div id="instrucciones_de_uso">Ingrese la persona que desea administrar</div>
                <div id="selector_usuario" class="selector_personas">
                    <input id="buscador" type=hidden class="buscarPersona" />
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
                    <div id="cambio_imagen_pendiente" RequiereFuncionalidad = "50">
                        <img src="camera.png"/>
                    </div>
                    <div id="panel_datos_personales">
                        <div class="linea dato_personal">
                            <div id="nombre"></div>
                            <div id="apellido"></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Documento:</div>
                            <div id="documento" ></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Legajo:</div>
                            <div id="legajo"></div>    
                        </div>     
                        <div class="linea dato_personal">
                            <div>Email:</div>
                            <div id="email"></div>   
                            <input id="btn_modificar_mail" type="button" class="btn btn-warning" value="Modificar"  RequiereFuncionalidad = "45"/> 
                        </div>      
                        <input id="btn_credencial_usuario" type="button" class="btn btn-warning" value="Credencial" />           
                    </div>
                    <div id="panel_password">
                        <div class="linea linea_nombre_usuario">
                            <div class="titulo">Nombre de Usuario</div>
                            <div id="txt_nombre_usuario"> </div>  
                        </div>
                        <div class="linea linea_passwrd">
                            <div class="titulo">Contraseña:</div>
                            <input id="btn_reset_password" type="button" class="btn btn-warning" value="resetear" RequiereFuncionalidad = "25"/>
                        </div>
                        <div class="seccion_verificacion_usuario">
                            <div id="usuario_verificado">DNI Verificado</div>    
                            <div id="usuario_no_verificado">DNI No Verificado</div>    
                            <input id="btn_verificar_usuario" type="button" class="btn btn-warning" value="Verificar"  RequiereFuncionalidad = "21"/>
                        </div>
                    </div>
                </div> 
                <div id="panel_inferior_izquierdo" class="estilo_formulario">
                    <legend class="subtitulos"> Areas </legend>
                    <div id="panel_areas_administradas" RequiereFuncionalidad = "24">
                        <div id="lista_areas_administradas">
                        
                        </div>
                        <div id="selector_area_administrada" class="selector_areas">
                            <input id="buscador" type=hidden />
                        </div>
                        <%--<input id="btn_agregar_area" type=button class="btn btn-primary" value="+"/>--%>
                    </div>
                </div>           
                <div id="panel_derecho" class="estilo_formulario">
                    <legend class="subtitulos"> Funcionalidades </legend>
                    <div id="vista_permisos"> </div>            
                </div> 
                
            </div> 
              <hr />  
             <div id="panel_usuarios_por_area" RequiereFuncionalidad = "30" >
                <p class="persona_baja_con_funcionalidades">Consultar Usuarios Por Área</p>
                    <div id="lista_areas_para_consultar" style="display: inline;">
                        
                    </div>
                    <div id="selector_area_usuarios" class="selector_areas" style="position: inherit; display: inline;">
                        <input id="buscador" type="hidden" class="buscarUsuarioPorArea" />
                    </div>
                <div id="contenedor_usuarios_por_area">
                    <p id="p_nombre_area"></p>
                    <table id="tabla_usuarios_por_area"></table>
                </div>
                 <hr />  
             </div> 

              <div id="panel_personas_de_baja_con_permisos" RequiereFuncionalidad = "29">
                <p class="persona_baja_con_funcionalidades">Consultar Personas de Baja con Permisos</p>
                <input type="button" value="Consultar" id="btn_buscar_personas_de_baja" class="btn btn-primary" />
                <div id="contenedor_personas_de_baja">
                    <table id="tabla_personas_de_baja"></table>
                </div>
                <hr />  
             </div> 
        </div>
         <div class="loader"><!-- DIV PARA LOADER AJAX --></div>
    </form>
   


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
        <div class="vista_area_en_selector">
            <div id="nombre"></div> 
        </div>
        <div class="area_administrada">
            <div id="nombre_area">Secretaría de Coordinación y Monitoreo Institucional</div>
            <input id="btn_quitar_area" type=button class="btn btn-primary" value="-"/>
        </div>
        <div id="pantalla_actualizacion_imagen">
            <div id="titulo_actualizacion_imagen">Solicitud de cambio de imágen</div>
            <div id="panel_imagenes">
                <div id="imagen_anterior"></div>
                <div id="imagen_nueva"></div>            
            </div>
            <input type="button" id="btn_rechazar_cambio_imagen" class="btn btn-danger" value="Rechazar"/>
            <input type="button" id="btn_aceptar_cambio_imagen" class="btn btn-success" value="Aceptar"/>
        </div>
    </div>
   
</body>
<script type="text/javascript" src="VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="Autorizador.js"></script>
<script type="text/javascript" src="RepositorioDeFuncionalidades.js"></script>
<script type="text/javascript" src="RepositorioDeUsuarios.js"></script>
<script type="text/javascript" src="NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="AdministradorDeUsuarios.js"></script>
<script type="text/javascript" src="Usuario.js"></script>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="jquery.dynatree.min.js" ></script>

<script type="text/javascript" src="../Scripts/Spin.js" ></script>

<script type="text/javascript">
    $(document).ready(function () {
        Backend.start(function () {
            var adm_usuarios = new AdministradorDeUsuarios();
        });
    });


</script>
</html>
