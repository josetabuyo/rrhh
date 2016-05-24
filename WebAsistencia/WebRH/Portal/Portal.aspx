<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Portal.aspx.cs" Inherits="Portal_Portal" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <link rel="stylesheet" href="estilosPortal.css" type="text/css" media="screen"/>
        <!-- CSS media query on a link element -->
        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortal.css" />
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PORTAL</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div id="content">

            <div class="navigation ch-grid" id="nav">
                <img src="../Imagenes/portal/portal_empleado.png" alt="" class="principal"/>
                
                
                <%--<div class="item datosPersonales test ch-item ch-img-3" data-toggle="tooltip" data-placement="right" title="DATOS PERSONALES">--%>
                   <%-- <img src="../Imagenes/portal/bg_user.png" alt="" width="100" height="100" class="circle"/>--%>
                   <div class="ch-item ch-img-1 item datosPersonales test">				
		                <div class="ch-info-wrap">
			                <div class="ch-info">
				                <div class="ch-info-front ch-img-1"></div>
				                <div class="ch-info-back">
					                <h3 style="font-size: 12px;text-align: center;margin-top: 10px;">DATOS PERSONALES</h3>
				                </div>	
			                </div>
		                </div>
                        <a href="#" class="icon "  ></a>
	                </div>
                    
               <%-- </div>--%>
                <div class="item estudios test" data-toggle="tooltip" data-placement="right" title="ESTUDIOS">
                    <%--<img src="../Imagenes/portal/bg_home.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item licencias" data-toggle="tooltip" data-placement="right" title="LICENCIAS">
                    <%--<img src="../Imagenes/portal/bg_shop.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item notificaciones" data-toggle="tooltip" data-placement="right" title="NOTIFICACIONES">
                    <%--<img src="../Imagenes/portal/bg_camera.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item capacitaciones" data-toggle="tooltip" data-placement="right" title="CAPACITACIONES">
                   <%-- <img src="../Imagenes/portal/bg_fav.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item beneficios" data-toggle="tooltip" data-placement="right" title="BENEFICIOS">
                    <%--<img src="../Imagenes/portal/bg_fav.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item viaticos" data-toggle="tooltip" data-placement="right" title="VIÁTICOS">
                   <%-- <img src="../Imagenes/portal/bg_fav.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>
                <div class="item perfil" data-toggle="tooltip" data-placement="right" title="PERFIL">
                    <%--<img src="../Imagenes/portal/bg_fav.png" alt="" width="199" height="199" class="circle"/>--%>
                    <a href="#" class="icon"></a>
                </div>

            </div>

        </div>
        <div style="color: #fff; width: 100%; position: absolute; top: 720px;">
            <p style="text-align: center;"> &copy; PROPIEDAD INTELECTUAL / TODOS LOS DERECHOS RESERVADOS / MINISTERIO DE DESARROLLO SOCIAL</p>
        </div>
        
    </form>
     <!-- The JavaScript -->

        <script type="text/javascript" src="../Scripts/jquery.easing.1.3.js"></script>
        <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tooltip.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });

            /*$(function () {
                $('#nav > div').hover(
                function () {
                    var $this = $(this);
                    $this.find('img').stop().animate({
                        'width': '199px',
                        'height': '199px',
                        'top': '-25px',
                        'left': '-25px',
                        'opacity': '1.0'
                    }, 500, 'easeOutBack', function () {
                        $(this).parent().find('ul').fadeIn(700);
                    });

                    $this.find('a:first,h2').addClass('active');
                },
                function () {
                    var $this = $(this);
                    $this.find('ul').fadeOut(500);
                    $this.find('img').stop().animate({
                        'width': '52px',
                        'height': '52px',
                        'top': '0px',
                        'left': '0px',
                        'opacity': '0.1'
                    }, 5000, 'easeOutBack');

                    $this.find('a:first,h2').removeClass('active');
                }
            );
            });*/
        </script>
</body>
</html>
