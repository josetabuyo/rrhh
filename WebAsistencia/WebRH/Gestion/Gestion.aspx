<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gestion.aspx.cs" Inherits="Gestion_Gestion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestion</title>

     <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />
        <link rel="stylesheet" href="Permisos.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>   
         
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
 

        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div class="caja_izq" style="text-align:center;" ></div>
            
            <div class="caja_der papel">
                
                <div class="divBotonesGestion" >Personas</div>
                <div class="divBotonesGestion" id="btnPantallaTramitaciones">Tramitaciones</div>
                <div class="divBotonesGestion">Licencias/Presentismo</div>
                <div class="divBotonesGestion">Cargas Patrimoniales</div>
                <div class="divBotonesGestion">Evaluacion de Desempeño</div>
                <div class="divBotonesGestion">Protocolos de Areas</div>

            </div>
        </div>

    </form>
</body>


<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeUsuarios.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>


<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>

<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<script type="text/javascript" src="Gestion.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>



<script type="text/javascript" >

    $(document).ready(function ($) {

     
        Backend.start(function () {
            Gestion.init();
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {
                
               
                //FC: para importar el HabilitadorDeControles y afecte la seccion izquierda
                var imported = document.createElement('script');
                    imported.src = '../MAU/HabilitadorDeControles.js';
                document.head.appendChild(imported);


                $('#btnPantallaTramitaciones').click(function (e) {
                    e.preventDefault();
                    $(".caja_der").load('TramitacionesNuevas.html', function () {
                       
  
                    });
                });




            });
 
        });
    });

</script> 

</html>
