<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="FormularioConcursar_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <link rel="stylesheet" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="cuerpo1" class="cuerpo_claro">
    </div>

    <div id="cuerpo2" class="cuerpo_oscuro">
        <div id="panel_derecho"></div>
        
        <div id="panel_izquierdo" class="panel_izquierdo">
        
            <div class="label_login">
                <label for="usuario">Usuario <em>*</em></label>
                <input id="usuario" type="text" style="width:150px;" />
                <br />
                <label for="contraseña">Contraseña<em>*</em></label>
                <input id="contraseña" type="text" style="width:150px;" />
               
            </div>
            
        </div>
    </div>

    </div>
    <div id="cuerpo3">
    
    
    </div>
    </form>
</body>
 <%= Referencias.Javascript("../") %>
</html>
