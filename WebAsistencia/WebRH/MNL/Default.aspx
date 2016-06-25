<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MNL_Default" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RRHH - Novedades de Liquidaci&oacute;n</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <link rel="stylesheet" href="../FormularioConcursar/EstilosPostular.css" />
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body clas="">
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.N.L.</span> <br/> <span style='font-size:12px;'> Novedades de Liquidaci&oacute;n </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div class="accordion-group">
        <div id="ancla2" class="accordion-heading ">
            <a class="accordion-toggle titulo_acordion" style="" data-toggle="collapse" data-parent="#accordion"
                href="#collapseOne">I. OBRAS SOCIALES </a>
        </div>
        <div id="collapseOne" class="accordion-body collapse">
            <div class="accordion-inner fondo_form">
                <fieldset style="width: 100%;">
                    <legend><a id="btn_agregar_cambio_obra_social" class="link">Cambiar obra social</a></legend>
                    <h4>
                        Cambios Anteriores</h4>
                    <div id="ContenedorPlanillaCambiosObraSocial" runat="server">
                        <table id="tabla_cambios_obra_social" class="table table-striped">
                        </table>
                    </div>
                </fieldset>
            </div>
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
        <div class="modal_close_concursar">
        </div>
        <div id="contenido_modal">
        </div>
    </div>
    <asp:HiddenField ID="novedades" runat="server" />
    </form>
</body>
<script type="text/javascript" src="PanelListaDeCambiosObraSocial.js"></script>
<%= Referencias.Javascript("../") %>

<script type="text/javascript" src="../FormularioConcursar/PanelDetalleGenerico.js"></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
<script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"> </script>
<script type="text/javascript" src="../Scripts/String.js"> </script>


<script type="text/javascript">
    Backend.start();

     $(document).ready(function () {
        $(".collapse").collapse('show');

        novedades = JSON.parse($('#novedades').val());
        
        PanelListaDeCambiosObraSocial.armarGrilla(novedades);

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

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#fff');
        $("tbody tr:odd").css('background-color', 'transparent ');
    });

</script>
        

</html>
<!--<table align="center">
        <tr>
            <td>
                <div>
                    Seleccione Persona:
                </div>
                <div>
                    Folio:
                    <input type="text" width="20" />/<input type="text" />-<input type="text" />
                </div>
                <div>
                    *Tipo de Novedad:
                </div>
                <select>
                    <option selected>Cambio de Obra Social</option>
                </select>
                <div>
                    *Fecha:
                </div>
                <div>
                    *Nro Afiliado
                </div>
            </td>
            <td>
            </td>
            <td>
                <table border="1">
                    <tr>
                        <td>
                            Nro Folio
                        </td>
                        <td>
                            Obra Social
                        </td>
                        <td>
                            Fecha
                        </td>
                        <td>
                            Nro Afiliado
                        </td>
                    </tr>
                    <tr>
                        <td>
                            00/024-24
                        </td>
                        <td>
                            Ospaña
                        </td>
                        <td>
                            18/06/2016
                        </td>
                        <td>
                            ABC287489
                        </td>
                    </tr>
                    <tr>
                        <td>
                            00/016-16
                        </td>
                        <td>
                            UPCN
                        </td>
                        <td>
                            18/06/2015
                        </td>
                        <td>
                            ABC287489
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        Backend.start(function () {
            //var adm_usuarios = new AdministradorDeUsuarios();
        });
    });
</script>
--> 