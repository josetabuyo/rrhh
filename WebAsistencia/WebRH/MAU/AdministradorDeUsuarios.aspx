<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdministradorDeUsuarios.aspx.cs" Inherits="MAU_Permisos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH - Permisos de usuario</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>    
    <link rel="stylesheet" href="Permisos.css" type="text/css"/>    
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
    <link href="ui.dynatree.css" rel="stylesheet" type="text/css">
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.A.U.</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />        
        <div id="administrador_usuarios">
            <div id="panel_busqueda">
                <div id="selector_usuario" class="selector_personas">
                    <input id="buscador" type=hidden />
                </div>
            </div>  
            <div id="panel_datos_usuario" style="display:none">
                <div id="panel_izquierdo" class="estilo_formulario">
                    <img id="foto_usuario" src="usuario.png" alt="Usuario" width="128" height="128">
                    <div id="panel_datos_personales">
                        <div class="linea">
                            <div id="nombre" class="dato"></div>
                            <div id="apellido" class="dato"></div>
                        </div>
                        <div class="linea">
                            <div class="titulo">Documento:</div>
                            <div id="documento" class="dato"></div>
                        </div>
                        <div class="linea">
                            <div class="titulo">Legajo:</div>
                            <div id="legajo" class="dato"></div>    
                        </div>                
                    </div>
                    <div>
                        <div class="titulo">Nombre de Usuario:</div>
                        <input id="txtNombreUsuario" type="text" class="dato_editable"/>    
                    </div>
                    <div>
                        <div class="titulo">Contraseña:</div>
                        <input id="btnResetPassWord" type="button"/>
                        <div>Fecha de Expiración:</div>
                        <div id="dtpFechaExpiracionPassWord"></div>
                    </div>
                    <legend class="subtitulos"> Areas que Administra </legend>
                    <div id="listaAreasAdministradas">                        
                    </div>
                    <input id="btnAgregarArea" type=button class="btn btn-default" value="+"/>
                </div>                
                <div id="panel_derecho" class="estilo_formulario">
                    <legend class="subtitulos"> Permisos </legend>
                    <div id="vista_permisos"> </div>            
                </div>  
            </div>     
        </div>
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
    </div>
</body>
<%= Referencias.Javascript("../")%>
<script type="text/javascript" src="VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="ServicioDeSeguridad.js"></script>
<script type="text/javascript" src="NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="AdministradorDeUsuarios.js"></script>
<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/ServicioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="jquery.dynatree.min.js" ></script>


<script type="text/javascript">
    $(document).ready(function () {
        var adm_usuarios = new AdministradorDeUsuarios();
    });
</script>
</html>
