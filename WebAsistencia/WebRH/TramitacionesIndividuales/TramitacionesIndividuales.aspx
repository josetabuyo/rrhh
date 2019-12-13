<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TramitacionesIndividuales.aspx.cs" Inherits="TramitacionesIndividuales_TramitacionesIndividuales" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tramitaciones Individuales</title>

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
                <br />
                <div class="cajaPermisos">
                    <div id="buscador_de_personas">
                        <p class="buscarPersona" style="display: inline-block;">Buscar persona:
                            <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" type="hidden" />
                            </div>
                        </p>
                    </div>
                </div>

                <div id="cajaSelectorDocumentos" class="cajaSelectorDocumentos" style="display:none;">
                    <label>Seleccione el tipo de documento a recepcionar</label>
                    <select id="comboTiposDeDocumento">
                        <option value="FotocopiaDNI.htm">Fotocopia DNI</option>
                        <option value="CambioDomicilio.htm">DDJJ Cambio domicilio</option>
                        <option value="CambioObraSocial.htm">Cambio Obra Social</option>
                        <option value="estudio">Carga Estudio</option>
                    </select>
                </div>
                 <div id="caja_documentos_cargados" style="display:none;">
                    <legend style="margin-top: 20px;">Documentos Cargados o Pendientes del mismo tipo</legend>
                    <div id="tabla_documentos">
    
                    </div>
                     <button id="btnCargarComponente">Cargar Nuevo</button>
                </div>

            </div>
        </div>

         
        <div id="plantillas">
            <div class="vista_persona_en_selector">
                <div id="contenedor_legajo" class="label label-warning">
                    <div id="titulo_legajo">Leg:</div>
                    <div id="legajo"></div>
                </div> 
                <div id="nombre"></div>
                <div id="apellido"></div>
                <div id="contenedor_doc" class="label label-default">
                    <div id="titulo_doc">Doc:</div>
                    <div id="documento"></div>         
                </div>   
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

<script type="text/javascript" src="TramitacionesIndividuales.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>



<script type="text/javascript" >

    $(document).ready(function ($) {

     
        Backend.start(function () {
            TramitacionesIndividuales.init();
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {
                
                TramitacionesIndividuales.iniciarConsultaRapida();
                //FC: para importar el HabilitadorDeControles y afecte la seccion izquierda
                var imported = document.createElement('script');
                    imported.src = '../MAU/HabilitadorDeControles.js';
                document.head.appendChild(imported);


                $('#btnCargarComponente').click(function (e) {
                    e.preventDefault();
                    var componente = $('#comboTiposDeDocumento').children("option:selected").val();
                    $(".caja_der").load(componente, function () {
                       
                       
                        
                    });
                });




            });
 
        });
    });

</script> 

</html>
