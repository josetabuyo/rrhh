<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<%@ Register src="SiCoI/Componentes/AutoCompleteTextBox.ascx" tagname="AutoCompleteTextBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sistema RRHH</title>
    <%= Referencias.Css("")%>
    <link id="link1" rel="stylesheet" href="~/Estilos/estilos-custom.css" type="text/css" />
    <link rel="stylesheet" href="Scripts/vex-2.1.1/css/vex-theme-os.css" />
    <link rel="stylesheet" href="Scripts/vex-2.1.1/css/vex.css" />
</head>
<body id="bodyLogin">
    <form id="formLogin" runat="server">
        <div id="contenidosLogin">        
            <div id="loginControles">
                <div class="row pagination-centered text-centered" style="margin: 0 auto; background-color: rgba(66, 66, 66, 0.38);padding: 10px; position: absolute; right: 0;margin-top: -80px; width: 30%; width: 25%; margin-right: 50px;">
                    <img src="Imagenes/warning.png" alt="actualizacion" width="50" height="50" />
                    <h5 style="color: white; aligment: center">Bienvenidos !!! <br /><br />
                    Comunicamos a todos los visitantes que actualmente este es un sitio de uso interno del Ministerio de Desarrollo Social. <br /> <br /></h5>
                    <%--<h5 style="color: white;aligment: Justify">En este momento NO SE ENCUENTRA VIGENTE NINGUNA BUSQUEDA de personal, ni Proceso de Selección, ni Concurso por parte de este Organismo. <br /><br />
                    Por este motivo, si bien es posible realizar la carga de los datos personales y Currículum Vitae, dichos datos NO SERÁN UTILIZADOS en lo inmediato para incorporaciones al Ministerio.--%></h5>
                </div>
                
           
                <input type="text" id="usuario" class="span3" nullValue="usuario" autofocus runat="server"/><br />
                <input type="password" id="password" class="span3" nullValue="contraseña" runat="server"/><br />
                <div style="position: relative; display: inline-block; width: 260px;">
                    
                    <button id="fat-btn" data-loading-text="Iniciando..." class=" btn btn-primary" style="margin-bottom: 15px;"> 
                        Iniciar Sesión </button><br />
                        <a id="lnk_registrarse" style="margin-left: 25px; margin-right: 20px;">Registrame </a>
                    <%--<a href="http://www.plataformapersonas.com.ar/archivos/instructivo.pdf" target="_blank">Instructivo del Sistema</a>--%>
                    <a id="lnk_recuperar" style="cursor: pointer; ">¿Olvidé mi clave?</a>
                     <br />
                     <div style="font-size: 0.7em; margin: 10px auto; width: 500px; margin-left: -120px; display: inline-block;">
                        <input style="width: 190px;" class="btn btn-primary" id="linkAcerca" value="¿Para que se utiliza este sitio?" />
                        <input style="width: 190px;" class="btn btn-primary" id="linkAcceso" value="Instructivo de Acceso" />
                     </div>
                    <%-- <a href="Imagenes/SIGIRH_Acerca.jpg" target="_blank"></a>
                     <a href="Imagenes/SIGIRH_Registro.jpg" target="_blank"></a>--%>
                 </div>
                <div id="loginAlertaInvalido" class="alert  alert-error" runat="server">
                     <a class="close" data-dismiss="alert">×</a> <strong>Error</strong> El nombre de
                                usuario o la contraseña ingresados no son v&aacute;lidos o el usuario está dado de baja.
                </div>  
            </div>
            <div style="margin: 0 auto; ;padding: 10px; position: absolute; right: 0; bottom:0; margin-bottom: 5px; margin-right: 50px; color: beige;">Versión: 1.1</div>
        <div id="registrarse_dialog"></div>
        <div id="recuperar_dialog"></div>
    </div>
    </form>
    <%= Referencias.Javascript("") %>
    <script type="text/javascript" src="Scripts/vex-2.1.1/js/vex.combined.min.js"></script>
    <script type="text/javascript" src="RegistroPostular/PantallaRegistro.js">  </script>
</body>
<script>
    vex.defaultOptions.className = 'vex-theme-os';
    var lnk_recuperar = $("#lnk_recuperar");
    var lnk_registrarse = $("#lnk_registrarse");

    var lnk_acceso = $("#linkAcceso");
    var lnk_acerca = $("#linkAcerca");

    lnk_registrarse.click(function () { 
        PantallaRegistro.abrir();
    });
    lnk_recuperar.click(function () {
        PantallaRegistro.recuperar();
    });

    lnk_acceso.click(function () {
        PantallaRegistro.mostrarInformacionAcceso();
    });
    lnk_acerca.click(function () {
        PantallaRegistro.mostrarInformacionAcerca();
    });
    
</script>
</html>
