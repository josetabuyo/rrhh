<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeEvaluaciones.aspx.cs" Inherits="SACC_FormPlanillaDeEvaluaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Planilla De Evaluaciones</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.10.2.custom/development-bundle/ui/minified/i18n/jquery.ui.datepicker-es.min.js"></script>
    <script type="text/javascript" src="planilla_ingreso.js"></script>
    <style type="text/css">
    .text_2caracteres
    {
        max-width: 20px;
        margin-left: 3px;
    }
    .text_10caracteres
    {
        max-width: 100px;
        margin-left: 17px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" class="div_izquierdo2" style="margin:10px;">
        <label>Curso:&nbsp;</label>
        <select id="CmbCurso" onchange="javascript:cargar_instancias(this.value);" runat="server">
            <option value="0">Seleccione</option>
        </select><br />
        <label>Instancia:&nbsp;</label>
        <select id="CmbInstancia" onchange="javascript:admin_planilla.cargarPlanilla();" runat="server">
            <option value="-1">Seleccione</option>
        </select>
    <div>
    <div id="ContenedorPlanilla" style="display:inline-block"></div>
    <br />
    <input type="button" id="BtnGuardarEvaluaciones" onclick="javascript:admin_planilla.guardarPlanilla();" value="Guardar Cambios" style="display:none;" />
    <input type="button" id="BtnImprimir" value="Imprimir" style="display:none;" />
    </div>
    </div>
    
    </form>
</body>
<script type="text/javascript">
    var admin_planilla;
    function cargar_instancias(id_curso) {
        var data_post = JSON.stringify({
            'id_curso': id_curso
        });

        $.ajax({
            url: "../AjaxWS.asmx/GetInstanciasDeEvaluacion",
            type: "POST",
            data: data_post,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                var combo_instancias = document.getElementById("CmbInstancia");

                combo_instancias.options.length = 0;
                combo_instancias.add(new Option("Seleccione", "-1"));
                if (respuesta.length > 1) {
                    combo_instancias.add(new Option("Todos", "0"));
                }

                for (var i = 0; i < respuesta.length; i++) {
                    combo_instancias.add(new Option(respuesta[i].Descripcion, respuesta[i].Id));
                }
                admin_planilla.cargarPlanilla();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    
    }

    var AdministradorDeEvaluaciones = function () {
        var _this = this;
        var pla;
        var evaluaciones_originales;
        _this.cargarPlanilla = function (id_curso) {
            var data_post = JSON.stringify({
                'id_curso': $("#CmbCurso").val(),
                'id_instancia': $("#CmbInstancia").val()
            });

            $.ajax({
                url: "../AjaxWS.asmx/GetPlanillaEvaluaciones",
                type: "POST",
                data: data_post,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    if (respuesta.MensajeError === "") {
                        _this.dibujarGrilla(respuesta);
                        evaluaciones_originales = JSON.parse(respuestaJson.d).Evaluaciones;
                    }
                    else {
                        alert(respuesta.MensajeError);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        };
        _this.guardarPlanilla = function () {

            var evaluaciones = [];
            for (var i = 0; i < pla.evaluaciones.length; i++) {
                var ev = pla.evaluaciones[i];
                ev.Calificacion = ev.nota.html.val();
                evaluaciones.push({Id : ev.Id,
                                    Calificacion : ev.nota.html.val(),
                                    DNIAlumno : ev.DNIAlumno,
                                    IdCurso : ev.IdCurso,
                                    Fecha : ev.fecha.html.val(),
                                    IdInstancia : ev.IdInstancia
                                    });
            }
            alert(JSON.stringify(evaluaciones));
            alert(JSON.stringify(evaluaciones_originales));

            var data_post = JSON.stringify({
                "evaluaciones_nuevas": JSON.stringify(evaluaciones),
                "evaluaciones_originales": JSON.stringify(evaluaciones_originales)
            });
            $.ajax({
                url: "../AjaxWS.asmx/GuardarEvaluaciones",
                type: "POST",
                data: data_post,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    if (respuesta.MensajeError === "") {
                        /*_this.dibujarGrilla(respuesta);
                        evaluaciones_originales = JSON.parse(respuestaJson.d).Evaluaciones;*/
                        alert(respuestaJson);
                    }
                    else {
                        alert(respuesta.MensajeError);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

        };
        _this.dibujarGrilla = function (planilla) {

            var mostrar_grilla = false;
            var columnas = []

            var contenedor_grilla = $("#ContenedorPlanilla");
            var cmb_instancia = $("#CmbInstancia");
            var readonly = cmb_instancia.val() == 0;
            pla = new Planilla(planilla, readonly);

            contenedor_grilla.html("");
            $("#BtnGuardarEvaluaciones").hide();

            if (cmb_instancia.val() >= 0) {
                columnas.push(new Columna("Nombre", { generar: function (fila) { return fila.alumno; } }));
                for (var i = 0; i < pla.instancias.length; i++) {
                    columnas.push(new Columna(pla.instancias.html(i), new GeneradorCalificacionEvaluacion(pla.instancias[i])));
                }

                var grilla = new Grilla(columnas);
                grilla.SetOnRowClickEventHandler(function () {
                    return true;
                });
                grilla.CargarObjetos(pla.grilla());
                grilla.DibujarEn(contenedor_grilla);
                if (readonly) {
                    $("#BtnGuardarEvaluaciones").hide();
                } else {
                    $("#BtnGuardarEvaluaciones").show();
                }
            }
        }
    }
    $(document).ready(function () {
        admin_planilla = new AdministradorDeEvaluaciones();
    });
</script>
</html>
