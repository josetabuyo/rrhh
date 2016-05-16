<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Portal.aspx.cs" Inherits="Portal_Portal" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <link rel="stylesheet" href="estilosPortal.css" type="text/css" media="screen"/>
        <!-- CSS media query on a link element -->
        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortal.css" />
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <style>
            *{
                margin:0;
                padding:0;
            }
            body{
                font-family:Arial;
                background-color: #031427;
                /*background:#fff url(../Imagenes/portal/bg.png) no-repeat top center;*/
            }
            .title{
                width:548px;
                height:119px;
                position:absolute;
                top:400px;
                left:150px;
                background:transparent url(title.png) no-repeat top left;
            }
            a.back{
                background:transparent url(back.png) no-repeat top left;
                position:fixed;
                width:150px;
                height:27px;
                outline:none;
                bottom:0px;
                left:0px;
            }
            #content{
                margin:0 auto;
            }


        </style>
        <%= Referencias.Javascript("../")%>
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PORTAL</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div id="content">
            <a class="back" href="http://tympanus.net/codrops/2010/04/29/awesome-bubble-navigation-with-jquery"></a>
            <div class="title"></div>

            <div class="navigation" id="nav">
                <img src="../Imagenes/portal/principal.png" alt="" width="199" height="199" style="position: absolute;top: 550px;left: 900px;"/>
                <div class="item user">
                    <img src="../Imagenes/portal/bg_user.png" alt="" width="199" height="199" class="circle"/>
                    <a href="#" class="icon"></a>
                    <h2 style="left: 0; position: absolute;top: -50px;line-height: 25px;text-indent: 0px; text-align: center;">DATOS PERSONALES</h2>
                    <ul>
                        <li><a href="#">Profile</a></li>
                        <li><a href="#">Properties</a></li>
                        <li><a href="#">Privacy</a></li>
                    </ul>
                </div>
                <div class="item home">
                    <img src="../Imagenes/portal/bg_home.png" alt="" width="199" height="199" class="circle"/>
                    <a href="#" class="icon"></a>
                    <h2>ESTUDIOS</h2>
                    <ul>
                        <li><a href="#">Portfolio</a></li>
                        <li><a href="#">Services</a></li>
                        <li><a href="#">Contact</a></li>
                    </ul>
                </div>
                <div class="item shop">
                    <img src="../Imagenes/portal/bg_shop.png" alt="" width="199" height="199" class="circle"/>
                    <a href="#" class="icon"></a>
                    <h2>LICENCIAS</h2>
                    <ul>
                        <li><a href="#">Catalogue</a></li>
                        <li><a href="#">Orders</a></li>
                        <li><a href="#">Offers</a></li>
                    </ul>
                </div>
                <div class="item camera">
                    <img src="../Imagenes/portal/bg_camera.png" alt="" width="199" height="199" class="circle"/>
                    <a href="#" class="icon"></a>
                    <h2>NOTIFICACIONES</h2>
                    <ul>
                        <li><a href="#">Gallery</a></li>
                        <li><a href="#">Prints</a></li>
                        <li><a href="#">Submit</a></li>
                    </ul>
                </div>
                <div class="item fav">
                    <img src="../Imagenes/portal/bg_fav.png" alt="" width="199" height="199" class="circle"/>
                    <a href="#" class="icon"></a>
                    <h2>CAPACITACIONES</h2>
                    <ul>
                        <li><a href="#">Social</a></li>
                        <li><a href="#">Support</a></li>
                        <li><a href="#">Comments</a></li>
                    </ul>
                </div>
                
            </div>
        </div>
    </form>
     <!-- The JavaScript -->

        <script type="text/javascript" src="../Scripts/jquery.easing.1.3.js"></script>
        <script type="text/javascript">
            $(function () {
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
            });
        </script>
</body>
</html>
