<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Postulaciones.aspx.cs" Inherits="FormularioConcursar_Postulaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
   

     <style>
     
      .contenedor_concursar 
    {
        width: 59%;
        margin-left:19%;
    }
     
     .navbar {
    margin-top: 30px;
    }

.navbar-inner, .fondo_gris_gradiente {  
    background-color: #389abe;  
    background-image: -moz-linear-gradient(top,  #dbdbdb 0%, #f9f9f9 100%); /* FF3.6+ */  
    background-image: -webkit-gradient(linear, left top, left bottombottom, color-stop(0%,#dbdbdb), color-stop(100%,#f9f9f9)); /* Chrome,Safari4+ */  
    background-image: -webkit-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* Chrome10+,Safari5.1+ */  
    background-image: -o-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* Opera 11.10+ */  
    background-image: -ms-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* IE10+ */  
    background-image: linear-gradient(to bottombottom,  #dbdbdb 0%,#f9f9f9 100%); /* W3C */  
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#dbdbdb', endColorstr='#f9f9f9',GradientType=0 ); /* IE6-9 */  
    
} 

.navbar .nav > li > a {
  color: #00293d !important;
}

.navbar .nav > li > a:hover 
{
    color: #0c3f59 !important;
    }
    
.navbar .nav > li > a:hover {
  color: #0c3f59;
  text-decoration: none;
  /*background-color: #0074cc;*/
}

.navbar .nav .active > a,
.navbar .nav .active > a:hover {
  color: #999;
  text-decoration: none;
  /*background-color: #0074cc;*/
}

     
     .accordion 
     {
        width: 100%;  
     }
         
    .accordion-group {
        margin-bottom: 2px !important;
        border: none !important;
        -webkit-border-radius: 4px;
        -moz-border-radius: 4px;
        border-radius: 4px;
        
    }
    
    .accordion-inner {
      padding: 9px 15px;
      border: none;
    }
     
     .accordion .accordion-heading a {  
        color:  #0088cc !important;  
        line-height: 15px;  
        /*display: block;  */
        font-size: 12pt;  
        text-indent: 10px;  
        text-decoration:none;  
        background-image: none;
        
    } 

.accordion .accordion-heading:first-of-type {  
    background-color: #fff !important;  
} 
    .btn_concursar {
            display: inline-block;
            
            margin-bottom: 0;
            font-size: 13px;
            line-height: 18px;
            color: #333333;
            text-align: center;
            text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
            
            cursor: pointer;
            background-color: #f5f5f5;
            background-image: -ms-linear-gradient(top, #ffffff, #e6e6e6);
            background-image: -webkit-gradient(linear, 0 0, 0 100%, from(#ffffff), to(#e6e6e6));
            background-image: -webkit-linear-gradient(top, #ffffff, #e6e6e6);
            background-image: -o-linear-gradient(top, #ffffff, #e6e6e6);
            background-image: linear-gradient(top, #ffffff, #e6e6e6);
            background-image: -moz-linear-gradient(top, #ffffff, #e6e6e6);
            background-repeat: repeat-x;
            border: 1px solid #cccccc;
            border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
            border-color: #e6e6e6 #e6e6e6 #bfbfbf;
            border-bottom-color: #b3b3b3;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            filter: progid:dximagetransform.microsoft.gradient(startColorstr='#ffffff', endColorstr='#e6e6e6', GradientType=0);
            filter: progid:dximagetransform.microsoft.gradient(enabled=false);
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
        }
     
     </style>

</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar">
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
                    <ul id="Ul1" class="nav"  runat="server">
                        <li><a href="PanelDeControl.aspx" >Panel de Control</a></li>
                        <li><a href="Postulaciones.aspx" >Postulaciones</a></li>
                        <li><a href="CargaInformacionPersonal.aspx" >MI CV</a></li>
                    </ul>
       
                    <ul id="Ul2" class="nav pull-right"  runat="server">
                    </ul>
                    </div><!-- /.nav-collapse -->
                </div>
            </div><!-- /navbar-inner -->
        </div><!-- /navbar -->
        
        <input type="text" style="width: 90%;"  placeholder="Buscar"/><a class="btn_concursar btn-small" href="#">Buscar</a>

    <div class="accordion" id="accordion" >

        <div style="float:left; width:30%;">

        <div class="accordion-group">
            <div id="ancla2" class="accordion-heading ">
                <a class="accordion-toggle titulo_acordion" style="" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                    Abogado
                </a>   
            </div>
            <div id="collapseTwo" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Abogacía</span><br/>
                     <input type="checkbox"/><span> Analista Jurídico</span><br/>
                      <input type="checkbox"/><span> Dictaminante</span><br/>
                       <input type="checkbox"/><span> Experto / Especializado</span><br/>
                       <input type="checkbox"/><span> Litigante / Sumariante</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="ancla3" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                Abordaje Territorial
            </a>    
            </div>
            <div id="collapseThree" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Lic. Cs Educación</span><br/>
                    <input type="checkbox"/><span> Lic. Cs. Políticas</span><br/>
                    <input type="checkbox"/><span> Lic. Sociología</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div1" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                Administrativo
            </a>    
            </div>
            <div id="collapseFour" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Asistente Administrativo</span><br/>
                    <input type="checkbox"/><span> Auxiliar Administrativo</span><br/>
                    <input type="checkbox"/><span> Resp Administrativo (Jefat.Depto)</span><br/>
                    <input type="checkbox"/><span> Responsable Administrativo</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div3" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                Administrativo / Contable
            </a>    
            </div>
            <div id="collapseFive" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Contabilidad</span><br/>
                    <input type="checkbox"/><span> Contabilidad / Lic Economía</span><br/>
                    <input type="checkbox"/><span> Resp Administrativo (Jefat.Depto)</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div5" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
               Arquitecto
            </a>    
            </div>
            <div id="collapseSix" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Arquitectura</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div7" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                Auditoría
            </a>    
            </div>
            <div id="collapseSeven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Medicina</span><br/>
                    <input type="checkbox"/><span> Varios / Lic Economía</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div9" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                Auxiliares
            </a>    
            </div>
            <div id="collapseEight" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Auxiliar de Maestr y Mant.</span><br/>
                    <input type="checkbox"/><span> Cadete / Gestor</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div11" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseNine">
                Comunicación
            </a>    
            </div>
            <div id="collapseNine" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Ceremonial</span><br/>
                    <input type="checkbox"/><span> Comunicación</span><br/>
                    <input type="checkbox"/><span> Lic. Comunicación Soc / Periodista</span><br/>
                    <input type="checkbox"/><span> Lic. RRPP</span><br/>
                    <input type="checkbox"/><span> Periodista</span>
                </div>
            </div>
        </div>

        </div>

        <div style="float:left; width:30%;  ">

        <div class="accordion-group">
            <div id="Div13" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseTen">
                Deportes
            </a>    
            </div>
            <div id="collapseTen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Deporte y Actividad Física</span><br/>
                    <input type="checkbox"/><span> Lic. Dep y Act Fís</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div15" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseEleven">
                Diseño / Imagen / Sonido
            </a>    
            </div>
            <div id="collapseEleven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Diseño / Imagen / Sonido</span>
                </div>
            </div>
        </div>
      
        <div class="accordion-group">
            <div id="Div17" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseTwelve">
                Gestión de la información
            </a>    
            </div>
            <div id="collapseTwelve" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Administración</span><br/>
                    <input type="checkbox"/><span> Resp Administrativo (Jefat.Depto)</span><br/>
                    <input type="checkbox"/><span> Sistemas Información</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div19" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseThirteen">
                Gestión de programas
            </a>    
            </div>
            <div id="collapseThirteen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Administración</span><br/>
                    <input type="checkbox"/><span> Administración / Lic. Sociología</span><br/>
                    <input type="checkbox"/><span> Lic. Economía</span><br/>
                    <input type="checkbox"/><span> Mantenimiento</span><br/>
                    <input type="checkbox"/><span> Nutrición</span><br/>
                    <input type="checkbox"/><span> Nutrición/Ing Alimentos</span><br/>
                    <input type="checkbox"/><span> Psicología</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div21" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseFourteen">
               Gestión de rrhh
            </a>    
            </div>
            <div id="collapseFourteen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Administración</span><br/>
                    <input type="checkbox"/><span> Capacitación</span><br/>
                    <input type="checkbox"/><span> Medicina</span><br/>
                    <input type="checkbox"/><span> Psicología</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div23" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseFifteen">
               Mantenimiento
            </a>    
            </div>
            <div id="collapseFifteen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Ing. Telecomunicac.</span><br/>
                    <input type="checkbox"/><span> Resp Administrativo (Jefat.Depto)</span><br/>
                    <input type="checkbox"/><span> Responsable Administrativo</span>
                </div>
            </div>
        </div>

        <div class="accordion-group">
            <div id="Div25" class="accordion-heading">
            <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseSeventeen">
               Trabajo Social
            </a>    
            </div>
            <div id="collapseSeventeen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                    <input type="checkbox"/><span> Trabajo Social</span>
                </div>
            </div>
        </div>
        </div>

    </div>

    <div class="feedPostulaciones sombra_y_redondeado " style="clear: both; padding-top:20px;">
        <h3 class="subtitulo_postulaciones"><a href="#">Programador para RRHH/ CABA </a></h3>
        <p class="feedAvisoDescripcion">Se require programadores con conocimientos avanzados en c# y un lenguaje proximamente a inventar para...<a href="#">Ver mas</a></p>
        <a class="btn_concursar btn-small" href="PreInscripcion.aspx">Aplicar</a>
        <a class="btn_concursar btn-small" href="#">Ver postulación</a>
    </div>
    <div class="feedPostulaciones sombra_y_redondeado ">
        <h3 class="subtitulo_postulaciones"><a href="#">Adminitrador de Redes RRHH/ CABA </a></h3>
        <p class="feedAvisoDescripcion">Se require expertos en Redes para administrar la infraestructura de todo el ministerior...<a href="#">Ver mas</a></p>
        <a class="btn_concursar btn-small" href="PreInscripcion.aspx">Aplicar</a>
        <a class="btn_concursar btn-small" href="#">Ver postulación</a>
    </div>

    </div>
    </form>
</body>
    <%= Referencias.Javascript("../") %>

<script type="text/javascript">

 $(document).ready(function () {
     
    $(".collapse").collapse(hide);

});
</script>
</html>
