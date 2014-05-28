<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>Login - Sistema RRHH</title>
    <%= Referencias.Css("../")%>
    <link id="link1" rel="stylesheet" href="~/Estilos/estilos-custom.css" type="text/css" />
   
</head>
<body id="bodyLogin">
    <form id="formLogin" runat="server">
        <div id="contenidosLoginPostular">        
            <div id="loginControles">
                <input type="text" id="usuario" class="span3" nullValue="usuario" runat="server"/><br />
                <input type="password" id="password" class="span3" nullValue="contraseña" runat="server"/><br />
                <input type="button" id="btn_login" value="Ingresar" class="btn btn-default" />
                <a href="#" id="lnk_registrarse">Registrarse</a>
        </div>
    </div>
    </form>
    <%= Referencias.Javascript("../")%>
</body>
<script>
    var lnk_registrarse = $("#lnk_registrarse");
    lnk_registrarse.click(function () {
        $("<div>").load("Registrarse.htm").dialog({
            modal: true,
            buttons: {
                "Cancelar": function () {
                    $(this).dialog("close");
                },
                Aceptar: function () {
                    $(this).dialog("close");
                }
            }
        });
    });
</script>
</html>
