<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitarCredencialProvisoria.aspx.cs" Inherits="Credenciales_SolicitarCredencialProvisoria" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pedido de Credencial</title>
    <link rel="stylesheet" type="text/css" href="SolicitarCredencialProvisoria.css" />
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>   
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/> 
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
</head>
    <body>    
        <form id="form1" runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Datos Abiertos</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div id="formulario_solicitud">
            <h2>Pedido de Credencial</h1>
            <div><label for="txt_dni">DNI</label> <input id="Text1" type="text" /></div>
            <div><label for="txt_apellido">Apellido</label> <input id="txt_apellido" type="text" /></div>
            <div><label for="txt_nombres">Nombres</label> <input id="txt_nombres" type="text" /></div>
            <div><label for="txt_email">Email</label> <input id="txt_email" type="text" /></div>
            <div><label for="dtp_fechanacimiento">F. Nacimiento</label> <input id="dtp_fechanacimiento" type="text" /></div>
            <div><label for="txt_telefono">Teléfono</label> <input id="txt_telefono" type="text" /></div>
            <div><div id="vista_previa_foto"></div><input id="btn_subirfoto" type="button" value = "Subir foto"/></div>
            <div><label for="cmb_tipocredencal">Tipo de Credencial</label> <select id="cmb_tipocredencal"></select></div>
            <div><label for="cmb_autorizante">Autorizante</label>
                <div id="cmb_autorizante" class="selector_personas">
                    <input id="buscador" type=hidden class="buscarPersona" />
                </div>
            </div>
            <div><label for="cmb_vinculo">Vínculo</label> <select id="cmb_vinculo"></select></div>
            <div><label for="cmb_lugarentrega">Lugar de entrega</label> <select id="cmb_lugarentrega"></select></div>
            <div><input id="btn_guardar" value="Guardar" type="button"/></div>
        </div>
        </form>
    </body>
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
</html>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
<script type="text/javascript" src="SolicitarCredencialProvisoria.js"></script>

