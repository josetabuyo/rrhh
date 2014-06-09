<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelDeControl.aspx.cs" Inherits="FormularioConcursar_PanelDeControl" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >
    

    <div class="navbar" style="font-size: 15px;">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                </a>
                <a class="brand" href="#"></a>
                <div class="nav-collapse navbar-responsive-collapse">
                <ul class="nav"  runat="server">
                <li><a href="PanelDeControl.aspx" >Panel de Control</a></li>
                <li><a href="Postulaciones.aspx" >Postulaciones</a></li>
                <li><a href="CargaInformacionPersonal.aspx" >MI CV</a></li>
                </ul>
       
                <ul class="nav pull-right"  runat="server">
                </ul>
                </div><!-- /.nav-collapse -->
            </div>
        </div><!-- /navbar-inner -->
    </div><!-- /navbar -->
    
        <div class="panel_izquierdo" style="height:auto;" >
            <legend>Novedades</legend>
            <p>Se comunica a todos los postulantes que el concurso para ocupar las vacantes dará comienzo el día 25 de mayo del año corriente. <br/>
                Para inscribirse deberan primero completar el CV de manera online a través de esta misma página, y luego deberán aplicar al puesto en el que tienen interés. <br />
                En caso de no cumplir los requisitos para un determinado puesto, el sistema les avisará sobre la imposibilidad de inscripción para ese en particular. <br/>
                Ante cualquier duda, por favor comunicarse con la oficina de RRHH.
            </p>
            <legend>Postulaciones Abiertas</legend>
         
        </div>
        <div class="panel_derecho">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title" style="">Mi CV</h3>
              </div>
              <div class="panel-body estilo_paneles fondo_form ">
                <a href="#" ><span><img width="22px" height="22px" src="../Imagenes/Botones/impresora.png" />&nbsp;Imprimir</span></a>    
                <a href="#" ><span><img width="22px" height="22px" src="../Imagenes/Botones/guardar.png" />&nbsp;Descargar</span></a>                 
                <hr style=" margin:5px; padding-bottom:0; color: #9cbbc0; background-color: #9cbbc0; height: 1px;"/>
                <a class="cvFotoUsuario " href="#"><img src="../Imagenes/silueta.gif" alt="Avatar Usuario" width="65" /></a>
                <div class="cvOverview"> 
                	<p class=""><a class="cvNombrePostulante" href="#">Wilbur Smith</a></p>
                    <p class="cvEstadoCv">Tu CV está al  <span id="Span1">85</span>%</p>
                    <div class="cvProgress">
                        <div class="cvProgressBar cvProgressBarAlta" style="width: 85%"></div>
                    </div>
                </div>
              </div>
            </div>

            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title" >Mis Postulaciones</h3>
              </div>
              <div class="panel-body estilo_paneles fondo_form ">
                 <div class="feedPostulacionesAplicadas sombra_y_redondeado">
                    <h3 class="subtitulo_postulaciones"><a href="#">Programador para RRHH/ CABA </a></h3>
                    <hr class="SubrayadoPostulaciones degrade"/>
                    <p>Se require programadores con conocimientos avanzados en c# y un lenguaje proximamente a inventar para...<a href="#">Ver mas</a></p>
                    <p style="text-align: right; font-size:12px;"><a style="margin-top: 100px; text-align:left;"class="link-cv" href="FichaInscripcionCVDeclaJurada.aspx">CV postulado</a></p>
                    
                    </div>
                <div class="feedPostulacionesAplicadas sombra_y_redondeado">
                    <h3 class="subtitulo_postulaciones"><a href="#">Adminitrador de Redes RRHH/ CABA </a></h3>
                    <hr class="SubrayadoPostulaciones degrade"/>
                    <p>Se require expertos en Redes para administrar la infraestructura de todo el ministerior...<a href="#">Ver mas</a></p>
                    <p style="text-align: right; font-size:12px;"><a style="margin-top: 100px; text-align:left;"class="link-cv" href="FichaInscripcionCVDeclaJurada.aspx">CV postulado</a></p>
                    
                </div>
              </div>
            </div>

        </div>
    </div>

    
    </form>
</body>
 <%= Referencias.Javascript("../") %>

</html>
