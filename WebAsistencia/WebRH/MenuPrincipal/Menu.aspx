<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Menú Principal</title>
        <%= Referencias.Css("../")%>   
        
        <%= Referencias.Javascript("../")%>
    </head>


    <link rel="stylesheet" type="text/css" href="MenuPrincipal.css" />

    <body>
        <form runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
            <div id="set-8" class="container">
				<div id="menu_principal" class="hi-icon-wrap hi-icon-effect-8">
            
                </div>
            </div>
        </form>
                

        <div id="plantillas">
            <div class="item_de_menu_principal">
                <!--[if !IE]><!-->
<%--                <div class="linea_gradiente"></div>--%>
                <!--<![endif]-->
              	<a class="hi-icon" data-toggle="tooltip" data-placement="right" title="" id="aaaa">
                    <!--[if !IE]><!-->
                    <div class="circulo circulo1"></div>
                    <div class="circulo circulo2"></div>
                    <div class="circulo circulo3"></div>
                    
                    <!--<![endif]-->
                </a>
                <%--<div id="contenedor_descripcion_item">--%>
                  <%-- <div id="descripcion_item"> Esta es una descripcion </div>--%>

                   
                <%--</div>--%>
            </div>
        </div>
        
        <script type="text/javascript" src="MenuPrincipal.js"></script>
        <script type="text/javascript" src="VistaDeItemDeMenuPrincipal.js"></script>
        <script type="text/javascript" src="../MAU/Autorizador.js"></script>
        <script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>
        <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tooltip.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                var menu = new MenuPrincipal({ ui: $("#menu_principal"), autorizador: new Autorizador(new ProveedorAjax("../")) });
            });
        </script> 
	
    </body>    
</html>

