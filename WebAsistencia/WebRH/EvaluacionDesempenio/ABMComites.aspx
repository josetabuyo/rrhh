<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMComites.aspx.cs" Inherits="EvaluacionDesempenio_ABMComites" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reuniones de Comite</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="EstilosEvalDesempenio.css" type="text/css" />
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link rel="stylesheet" href="../scripts/select2-3.4.4/select2.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div class="contenedor_comites">
        <hr style="clear: both; background-color: #0088cc;" />
        <div id="contenedor_comites">

                            <fieldset style="width: 100%;">
                                <legend><a id="btn_agregar_comite" class="link">Nuevo Comite</a></legend>
                                <h4>Comites</h4>
                                <div id="ContenedorPlanillaComites" runat="server">
                                    <table id="tabla_comites" class="table table-striped">
                                    </table>
                                </div>
                            </fieldset>
        </div>
        <div id="contenedor_comites">
            <asp:HiddenField ID="ComitesHiddenField" runat="server" />
            
        </div>
    </div>
    <%----------------- MODAL DE VISTA PRELIMINAR ---------------------%>
    <input type="text" id="urlAjax" value="" style="display: none;" />
    <div id="plantillas">
        <div class="botonera_grilla">
            <img id="btn_editar" src="../Imagenes/edit2.png" />
            <img id="btn_eliminar" src="../Imagenes/icono_eliminar2.png" />
        </div>
    </div>
    <div id="un_div_modal" style="width: 65%; height: 500px; overflow: scroll;" class="form_concursar">
        <div class="modal_close_comites">
        </div>
        <div id="contenido_modal">
        </div>
    </div>
    </form>
</body>
<%= Referencias.Javascript("../")%>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"> </script>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
<script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"></script>
<script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="../Scripts/opentip/opentip-jquery-excanvas.min.js"></script>
<script type="text/javascript" src="../FormularioConcursar/PanelDetalleGenerico.js"></script>
<script type="text/javascript" src="../FormularioConcursar/PanelListaDeAntecedentesAcademicos.js"></script>
<script type="text/javascript" src="PanelListaDeComites.js"></script>
<script type="text/javascript" src="./ABMComites.js"></script>
<script type="text/javascript">
    Backend.start();

    $(document).ready(function () {
        var comites = JSON.parse($('#ComitesHiddenField').val());
        //ABMComites.completarDatos(comites[0]);

        PanelListaDeComites.armarGrilla(comites);

        //Activar leanModal
        $('a[rel*=leanModalConcursar]').click(function () {
            var _this = $(this);
            if (_this.attr("data-url") !== undefined) {
                var div = $("#contenido_modal");
                div.html("");
                $.ajax({
                    url: _this.attr("data-url"),
                    success: function (r) {
                        div.append(r);
                    }
                });
            }
        });

        $('a[rel*=leanModalConcursar]').leanModal({ top: 300, closeButton: ".modal_close_concursar" });
    });
        
</script>
</html>
