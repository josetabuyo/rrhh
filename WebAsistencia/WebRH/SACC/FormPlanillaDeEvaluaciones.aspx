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
        <label>Curso:&nbsp;&nbsp;&nbsp;&nbsp;</label>
        <select id="CmbCurso" onchange="javascript:cargar_instancias(this.value);" runat="server">
            <option value="0">Seleccione</option>
        </select>
        <br />
        <div id="ContenedorInstancia">
        </div>
        
    <div>
    <div id="ContenedorPlanilla" style="display:inline-block"></div>
    <br />
    <input type="button" id="BtnGuardarEvaluaciones" onclick="javascript:admin_planilla.guardarPlanilla();" value="Guardar Cambios" style="display:none;" />
    <input type="button" id="BtnImprimir" onclick="javascript:admin_planilla.imprimirPlanilla();" value="Imprimir" style="display:none;" />
    <input type="hidden" id="accion" value="" runat="server" />
    </div>
    </div>
    
    </form>
</body>
<script type="text/javascript">
    var admin_planilla;
    function cargar_instancias(id_curso) {
        var instancias;
        var accion = $("#accion").val();
        var contenedor = $("#ContenedorInstancia");
        contenedor.html("");
        if (id_curso > 0) {
            if (accion == "c") {
                var etiqueta = $("<label>").text("Instancias");
                instancias = $("<select>").attr("id", "Instancias").change(function () {
                    admin_planilla.cargarPlanilla();
                }).get(0);

                instancias.options.length = 0;
                instancias.add(new Option("Seleccione", "-1"));
                contenedor.append(etiqueta).append($(instancias));
            } else {
                var instancias = $("<input>").attr("type", "hidden").attr("id", "Instancias");
                contenedor.append(instancias);
            }
            if (id_curso > 0) {
                var data_post = JSON.stringify({
                    'id_curso': id_curso
                });

                $.ajax({
                    url: "../AjaxWS.asmx/GetInstanciasDeEvaluacion",
                    type: "POST",
                    async: false,
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (accion == "c") {
                            if (respuesta.length > 1) {
                                instancias.add(new Option("Todos", 0));
                            }
                            for (var i = 0; i < respuesta.length; i++) {
                                instancias.add(new Option(respuesta[i].Descripcion, respuesta[i].Id));
                            }
                        } else {
                            instancias.val("0");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            }
            admin_planilla.cargarPlanilla();    
        }else{
            admin_planilla.limpiarGrilla();
        }
    }

    var AdministradorDeEvaluaciones = function () {
        var _this = this;
        var pla;
        var evaluaciones_originales;
        var readonly = $("#accion").val() == "a";
        var contenedor_grilla = $("#ContenedorPlanilla");
        var btn_guardar = $("#BtnGuardarEvaluaciones");
        var btn_imprimir = $("#BtnImprimir");

        _this.limpiarGrilla = function () {
            contenedor_grilla.html("");
            btn_guardar.hide();
        }

        _this.cargarPlanilla = function () {
            _this.limpiarGrilla();
            var instancias = $("#Instancias").val();
            var cursos = $("#CmbCurso").val();
            if (instancias && instancias != "-1") {
                var data_post = JSON.stringify({
                    'id_curso': cursos,
                    'id_instancia': instancias
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
            } else {
                contenedor_grilla.html("");
            }
        };
        _this.guardarPlanilla = function () {

            var evaluaciones = [];
            for (var i = 0; i < pla.evaluaciones.length; i++) {
                var ev = pla.evaluaciones[i];
                ev.Calificacion = ev.nota.html.val();
                evaluaciones.push({ Id: ev.Id,
                    Calificacion: ev.nota.html.val(),
                    DNIAlumno: ev.DNIAlumno,
                    IdCurso: ev.IdCurso,
                    Fecha: ev.fecha.html.val(),
                    IdInstancia: ev.IdInstancia
                });
            }
            //alert(JSON.stringify(evaluaciones));
            //alert(JSON.stringify(evaluaciones_originales));

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
                    _this.cargarPlanilla();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

        };
        _this.dibujarGrilla = function (planilla) {
            var columnas = []

            var instancias = $("#Instancias");

            pla = new Planilla(planilla, readonly);

            if (instancias.val() >= 0) {
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
                    btn_guardar.hide();
                    btn_imprimir.show();
                } else {
                    btn_guardar.show();
                    btn_imprimir.hide();
                }
            }
        }
        _this.imprimirPlanilla = function () {
            var w = window.open();

            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");
            w.document.write("<style>div_print{margin:20px;}.text_2caracteres{max-width: 20px;margin-left: 3px;}.text_10caracteres{max-width: 100px;margin-left: 17px;}</style>");
            w.document.write("<div class='div_print'><br>Curso: " + $("#CmbCurso option:selected").text() + "<br><br></div>");
            w.document.write(contenedor_grilla.html());
            w.print();
            //w.close();
        }
    }
    $(document).ready(function () {
        admin_planilla = new AdministradorDeEvaluaciones();
    });
</script>
</html>
