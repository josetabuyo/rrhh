<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Menú Principal</title>
        <%= Referencias.Css("../")%>   
    </head>


    <link rel="stylesheet" type="text/css" href="../Scripts/bootstrap/css/component.css" />

    <body>
        <form runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />        
    
            <div id="menu_principal">
            
            </div>
        </form>
                

        <div id="plantillas">
            <div class="item_de_menu_principal">
              	<a class="hi-icon" 
								data-toggle="tooltip" data-placement="right" title="" >
								</a>
            </div>
        </div>

            <div class="container">
			<!-- Top Navigation -->
			<section id="set-8">
				<div class="hi-icon-wrap hi-icon-effect-8">
					<a href="" id="licencia" class="hi-icon" 
								data-toggle="tooltip" data-placement="right" title="" 
								data-original-title="Modulo para cargar licencias de los agentes" >Licencias</a>
					<a href="" id="macc" class="hi-icon" 
								data-toggle="tooltip" data-placement="right" title="" 
								data-original-title="Modulo para administrar las asistencias de cursos">MACC</a>
					<a href="" id="mesa" class="hi-icon" data-toggle="tooltip" data-placement="right" title="" 
								data-original-title="Modulo para administrar el movimiento de los documentos">Mesa de Entrada</a>
				</div>
			</section>
			<li>
			<a id="tul" href="#" data-toggle="tooltip" data-placement="right" title="" data-original-title="Tooltip on right asfasdf ksdgjafjkasdgf klsdfkasdf"></a>
			

			</li>
			
		</div><!-- /container -->








        <%= Referencias.Javascript("../")%>

        <script type="text/javascript" src="MenuPrincipal.js"></script>
        <script type="text/javascript" src="VistaDeItemDeMenuPrincipal.js"></script>
        <script type="text/javascript" src="../MAU/Autorizador.js"></script>
        <script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

         <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tooltip.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                var menu = new MenuPrincipal({ ui: $("#menu_principal"), autorizador: new Autorizador(new ProveedorAjax("../")) });

                $('#licencia').tooltip();
                $('#macc').tooltip();
                $('#mesa').tooltip();

            });
        </script> 
        
    
		
	</script>
        
          
    </body>    
</html>

