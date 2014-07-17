<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Postulaciones.aspx.cs" Inherits="FormularioConcursar_Postulaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
   
   <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
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
    
      .buscador
      {
       width: 70%;
       margin-top:10px;    
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

        <div id="ContenedorPlanilla">
         <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"/><a class="btn_concursar btn-small" href="#">Buscar</a>

        <table id="tabla_puestos" style="width:100%;">
        
        
        </table>

        </div>
          
    </div>


     <asp:HiddenField ID="puestos" runat="server" />
    </form>
</body>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="Puesto.js" ></script>
<script type="text/javascript">

    $(document).ready(function () {

        $(".collapse").collapse("show");

        var puestos = JSON.parse($('#puestos').val());
        Puesto.armarLista(puestos);

        var options = {
            valueNames: ['Puesto', 'Nivel', 'Agrupamiento', 'Vacantes']
        };

        var featureList = new List('ContenedorPlanilla', options);

    });
</script>
</html>
