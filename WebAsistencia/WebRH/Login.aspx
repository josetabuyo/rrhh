﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

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
                <input type="text" id="usuario" class="span3" nullValue="usuario" runat="server"/><br />
                <input type="password" id="password" class="span3" nullValue="contraseña" runat="server"/><br />
                <div style="position: relative; display: inline-block; width: 260px;">
                    <a id="lnk_registrarse" style="margin-left: 25px; margin-right: 20px;">Registrarse </a>
                    <button id="fat-btn" data-loading-text="Iniciando..." class=" btn btn-primary" style="margin-bottom: 15px;"> 
                        Iniciar Sesión </button><br />
                    <a id="lnk_recuperar" style="cursor: pointer; margin-left: 125px;">¿Olvidó sus datos?</a> 
                 </div>
                <div id="loginAlertaInvalido" class="alert  alert-error" runat="server">
                     <a class="close" data-dismiss="alert">×</a> <strong>Error</strong> El nombre de
                                usuario o la contraseña ingresados no son v&aacute;lidos o el usuario está dado de baja.
                </div>  
            </div>
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
    lnk_registrarse.click(function () { 
        PantallaRegistro.abrir();
    });
    lnk_recuperar.click(function () {
        PantallaRegistro.recuperar();
    });
</script>
</html>
