<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<%@ Register src="SiCoI/Componentes/AutoCompleteTextBox.ascx" tagname="AutoCompleteTextBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sistema RRHH</title>
    <script type="text/javascript" src="bootstrap/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="bootstrap/js/jquery-ui-1.8.21.custom.min.js"></script>
    <link id="link2" rel="stylesheet" href="bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link1" rel="stylesheet" href="~/Estilos/estilos-custom.css" type="text/css"
        runat="server" />
   
</head>
<body id="bodyLogin">
    <form id="formLogin" runat="server">
        <div id="contenidosLogin">        
            <div id="loginControles">
                <input type="text" id="usuario" class="span3" placeholder="usuario" runat="server"/><br />
                <input type="password" id="password" class="span3" placeholder="contraseña" runat="server"/><br />
                <div id="loginBoton">
                    <button id="fat-btn" data-loading-text="Iniciando..." class=" btn btn-primary"> 
                        Iniciar Sesión
                    </button>
                    
                </div>
                <div id="loginAlertaInvalido" class="alert  alert-error" runat="server">
                    <a class="close" data-dismiss="alert">×</a> <strong>Error</strong> El nombre de
                        usuario o la contraseña ingresados no son v&aacute;lidos.
            </div>
           
        </div>
    </div>
    </form>
    <script type="text/javascript" src="bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="bootstrap/js/jquery.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap-button.js"></script>
</body>
</html>
