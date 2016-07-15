<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BuscadorDePersonas.ascx.cs"
    Inherits="Scripts_BuscadorDePersonas" %>

     <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>

    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
    <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
    <script type="text/javascript" src="../Scripts/Persona.js"></script>
    <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
    <script type="text/javascript" src="../MAU/AdministradorDeUsuarios.js"></script>

<div id="buscador_de_personas">
    <p style="display: inline-block;">
        Persona:
        <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
            <input id="buscador" type="hidden" />
        </div>
    </p>
</div>

<div id="plantillas">
    <div class="vista_persona_en_selector">
        <div id="contenedor_legajo" class="label label-warning">
            <div id="titulo_legajo">
                Leg:</div>
            <div id="legajo">
            </div>
        </div>
        <div id="nombre">
        </div>
        <div id="apellido">
        </div>
        <div id="contenedor_doc" class="label label-default">
            <div id="titulo_doc">
                Doc:</div>
            <div id="documento">
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function ($) {
        //var adm_usuarios = new AdministradorDeUsuarios();
        this.selector_usuario = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo",
            alSeleccionarUnaPersona: function (persona_seleccionada) {
                alert(persona_seleccionada.nombre);
            }
        });

    });
</script>
