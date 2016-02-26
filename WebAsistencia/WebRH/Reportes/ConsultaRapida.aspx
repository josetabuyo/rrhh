<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaRapida.aspx.cs" Inherits="Reportes_ConsultaRapida" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Rapida</title>
     <%= Referencias.Css("../")%>           
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>        
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
       <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
        <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
        <script type="text/javascript" src="../Scripts/Persona.js"></script>
        <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
        <script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
        <script type="text/javascript" src="../Scripts/jquery-barcode.js"></script>       
        <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
        <script type="text/javascript" src="Reportes.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Reportes</span> <br/> <span style='font-size:12px;'> Reportes </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
    <div id="contenedor_consulta_rapida" style="margin:30px;">
        
        <div id="buscador_de_personas">
            <p class="buscarPersona">Buscar persona:
                <div id="selector_usuario" class="selector_personas">
                    <input id="buscador" type=hidden />
                </div>
            </p>
        </div>

        <div>
            <fieldset>
                <legend>Datos Personales</legend>
                <p><label>Nombre:</label><span id="nombre"></span></p>
                <p><label>Legajo:</label><span id="legajo"></span></p>
                <p><label>Fecha Nacimiento:</label><span id="fechaNacimiento"></span></p>
                <p><label>Edad:</label><span id="edad"></span></p>
                <p><label>Estado Civil:</label><span id="estadoCivil"></span></p>
                <p><label>Sexo</label><span id="sexo"></span></p>
                <p><label>CUIL</label><span id="cuil"></span></p>
                <p><label>Documento</label><span id="documento"></span></p>
                <p><label>Domicilio</label><span id="domicilio"></span></p>
                <p><label>Estudio</label><span id="estudio"></span></p>

            </fieldset>

            <fieldset>
                <legend>Cargo y Actividad</legend>
                <p><label>Sector:</label><span id="sector"></span></p>
                <p><label>Nivel y Grado:</label><span id="nivel_grado"></span></p>
                <p><label>Planta:</label><span id="planta"></span></p>
                <p><label>Cargo:</label><span id="cargo"></span></p>
                <p><label>Agrupamiento:</label><span id="agrupamiento"></span></p>
            </fieldset>

            <fieldset>
                <legend>Antiguedad</legend>
                <p><label>Estado:</label><span id="estado"></span></p>
                <p><label>Privada:</label><span id="privada"></span></p>
                <p><label>Resta:</label><span id="resta"></span></p>
                <p><label>Ing. Min.:</label><span id="ing_min"></span></p>
                <p><label>Ant. Min:</label><span id="ant_min"></span></p>
                 <p><label>Total:</label><span id="total"></span></p>
            </fieldset>
        </div>

    </div>
    </form>
</body>
<script type="text/javascript" >

    Reportes.iniciarConsultaRapida();

    
</script> 
</html>
