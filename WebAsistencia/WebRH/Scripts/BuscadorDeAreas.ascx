<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BuscadorDeAreas.ascx.cs"  Inherits="Scripts_BuscadorDeAreas" %>
<link rel="stylesheet" type="text/css" href="../estilos/SelectorDeAreas.css" />
<link rel="stylesheet" type="text/css" href="../scripts/select2-3.4.4/select2.css" />

<script type="text/javascript" src="../Scripts/underscore-min.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<input id="hfIdArea" type="hidden" /> 


<div id="buscador_de_area" class="selector_areas">Área:
    <input id="buscador" type="hidden" />
</div>
            

<div id="plantillas">
        <div class="vista_area_en_selector">
            <div id="nombre"></div> 
        </div>
    </div>

<script type="text/javascript">
    $(document).ready(function ($) {
        this.selector_de_areas = new SelectorDeAreas({
            ui: $("#buscador_de_area"),
            repositorioDeAreas: new RepositorioDeAreas(new ProveedorAjax("../")),
            placeholder: "Ingrese área a buscar",
            alSeleccionarUnArea: function (area) {
                //alert(area.id);
                $("#hfIdArea").val(area.id);
            }
        });

    });
</script>


