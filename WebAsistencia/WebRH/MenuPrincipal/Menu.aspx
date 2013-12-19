<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Menu Principal</title>
        <%= Referencias.Css("../")%>   
    </head>
    <body>
        <form runat="server">
            <div id="menu_principal">
            
            </div>
        </form>
        <div id="plantillas">
            <div class="item_de_menu_principal">
                <label id="caption_item"></label>
            </div>
        </div>
        <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="MenuPrincipal.js"></script>
        <script type="text/javascript" src="VistaDeItemDeMenuPrincipal.js"></script>
        <script type="text/javascript" src="../MAU/Autorizador.js"></script>
        <script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>
        <script type="text/javascript">
            $(document).ready(function () { 
                var menu = new MenuPrincipal({ ui: $("#menu_principal"), autorizador: new Autorizador(new ProveedorAjax("../"))});
            });
        </script>   
    </body>    
</html>

