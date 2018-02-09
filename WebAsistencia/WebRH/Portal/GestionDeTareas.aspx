<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionDeTareas.aspx.cs"
    Inherits="Portal_GestionDeTareas" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/ConsultaIndividual.ascx" TagName="Consulta" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Portal RRHH</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width">
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
    <script type="text/javascript" src="editor.js"></script>
    <script type="text/javascript" src="ckeditor/ckeditor.js"></script>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../Reportes/Reportes.css" />
    <link rel="stylesheet" type="text/css" href="estilosPortalSecciones.css" />
    <link rel="stylesheet" href="estrellas.css">
    <link rel="stylesheet" href="chat.css" />
    <link rel="stylesheet" href="font-awesome.min.css" />
    <link rel="stylesheet" href="lato.css" />
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css" />
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="tabs.css" />
    <link rel="stylesheet" type="text/css" href="tabstyles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <%--<div style="text-align: center;" class="caja_izq no-print">
            <p style="margin: 25px; font-size: 2.1em; color: #fff;">
                Menú</p>
            <input id="btn_consultas_pendientes" type="button" class="btn_gestion_consulta" style="margin: 10px;
                width: 170px; font-size: smaller;color:#000" value="TAREAS PENDIENTES" />

        </div>--%>
        <div class=" papel">
            <div style="float: left;">
                <label style="float: left">
                    Derivar a:</label>
                <div style="float: left; margin-top: -5px;" id="selector_usuario" class="selector_personas">
                    <input id="buscador" type="hidden" class="buscarPersona" />
                </div>
                <input id="btn_derivar_tareas" type="button" class="btn_gestion_consulta" style="font-size: smaller;
                    padding: 6px; margin: 1px; margin-top: -6px; height: 30px;" value="Derivar" />
            </div>
            <div id="tareas">
                <input type="text" id="search" class="search buscador" placeholder="Buscar" style="height: 35px;
                    float: right" />
                <svg class="hidden">
			<defs>
				<path id="tabshape" d="M80,60C34,53.5,64.417,0,0,0v60H80z"/>
			</defs>
		</svg>
                <div class="tabs tabs-style-shape">
                    <nav>
						<ul>
							<li>
								<a href="#section-shape-1">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span>MIS TAREAS</span>
								</a>
							</li>
							<li>
								<a href="#section-shape-2">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span class="tab_oscuro">TAREAS SIN ASIGNACIÓN</span>
								</a>
							</li>
							<li>
								<a href="#section-shape-3">
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<svg viewBox="0 0 80 60" preserveAspectRatio="none"><use xlink:href="#tabshape"></use></svg>
									<span>TAREAS ASIGNADAS A OTROS</span>
								</a>
							</li>
						</ul>
					</nav>
                    <div class="content-wrap">
                        <section id="section-shape-1" numero_tab="1"></section>
                        <section id="section-shape-2" numero_tab="2"></section>
                        <section id="section-shape-3" numero_tab="3"></section>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div id="pantalla_detalle_alerta" style="display: none;">
    </div>
    <div id="pantalla_consulta_individual" style="display: none">
        <p style="font-size: xx-large; text-align: center; margin-top: 10px;">
            Consulta Individual</p>
        <br />
        <uc3:Consulta ID="Consulta1" runat="server" />
    </div>
    <div id="plantillas">
        <div class="vista_persona_en_selector">
            <div id="contenedor_legajo" class="label label-warning">
                <div id="titulo_legajo">
                    Leg:</div>
                <div id="legajo">
                </div>
            </div>
            <div id="nombre" style="color: #000; font-size: 12px;">
            </div>
            <div id="apellido" style="color: #000; font-size: 12px;">
            </div>
            <div id="contenedor_doc" class="label label-default">
                <div id="titulo_doc">
                    Doc:</div>
                <div id="documento">
                </div>
            </div>
        </div>
    </div>
</body>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Componentes/GestionDeTareas.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
<script type="text/javascript" src="tabs.js"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        Backend.start(function () {
            $("#btn_derivar_tareas").click(function () {
                GestionDeTareas.DerivarTareas();
            });
            GestionDeTareas.ObtenerUsuarioLogueado();
            GestionDeTareas.buscadorDePersonas();
            GestionDeTareas.getTareasParaGestion();
            //SELECCION DE TABS
            (function () {
                [ ].slice.call(document.querySelectorAll('.tabs')).forEach(function (el) {
                    new CBPFWTabs(el);
                });
            })();
        });
    });
</script>
</html>
