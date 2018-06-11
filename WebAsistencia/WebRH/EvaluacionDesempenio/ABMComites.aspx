<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMComites.aspx.cs" Inherits="EvaluacionDesempenio_ABMComites" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reuniones de Comite</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 17px;">
        </h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align: center;" class="caja_izq">
            </div>
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">Comités</legend>
                <div id="tabla_comites">
                </div>
            </div>
            <asp:HiddenField ID="ComitesHiddenField" runat="server" />
        </div>
    </div>
    <div id="pantallaDetalleComites" style="display: none;" class="">
        <div id="contenido_form_comite" class="fondo_form">
            <fieldset>
                <div>
                    Fecha:
                    <input id="fecha_1" campo="fecha_1" type="text" placeholder="dd/mm/aaaa" style="flex-grow: 100;
                        margin-left: 20px;" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="hora">
                        Hora <em>*</em></label>
                    <input id="hora" type="text" style="width: 160px;" maxlength="100" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="lugar">
                        Lugar <em>*</em></label>
                    <input id="txt_lugar" type="text" style="width: 160px;" maxlength="100" />
                </div>

                <div class="grupo_campos nueva_linea">
                    <!--<legend><a id="btn_agregar_ue" class="link">Agregar Unidad de Evaluacion</a></legend>-->
                    Integrantes
                    <div id="ContenedorPlanillaIntegrantes" runat="server">
                        <table id="tabla_integrantes" class="table table-striped">
                        </table>
                    </div>
                </div>
                <div class="grupo_campos">
                    <label for="cmb_periodo">
                        Proceso Evaluatorio <em>*</em></label>
                    <select id="cmb_periodo" style="width: 280px;">
                    </select>
                </div>
                <div class="grupo_campos nueva_linea">
                    <!--<legend><a id="btn_agregar_ue" class="link">Agregar Unidad de Evaluacion</a></legend>-->
                    Unidades de Evaluacion
                    <div id="ContenedorPlanillaUnidadesEvaluacion" runat="server">
                        <table id="tabla_unidades_evaluacion" class="table table-striped">
                        </table>
                    </div>
                </div>
            </fieldset>
            <div class="btn-fld">
                <input type="button" class="btn btn-primary" id="btn_guardar" value="Agregar" />
            </div>
            <input type="hidden" id="txt_AntecedenteAcademico_id" />
        </div>
    </div>
    <div id="plantillas">
        <div class="botonera_grilla">
            <img id="btn_editar" src="../Imagenes/edit2.png" height="25px" />
            <img id="btn_eliminar" src="../Imagenes/icono_eliminar2.png" height="25px"  />
            <input type="hidden" id="hidden_model" />
        </div>
        <div class="botonera_grilla_ues">
            <img id="btn_eliminar_ue" src="../Imagenes/icono_eliminar2.png" height="25px"  />
            <input type="hidden" id="hidden1" />
        </div>

    </div>
    </form>
    <script type="text/javascript" src="../Scripts/Spin.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var comites = JSON.parse($('#ComitesHiddenField').val());
            Backend.start(function () {

                var spinner = new Spinner({ scale: 2 });
                spinner.spin($("html")[0]);

                Backend.GetPeriodosEvaluacion()
                .onSuccess(function (periodos) {
                    _.forEach(periodos, function (periodo) {
                        var opt = $("<option>");
                        opt.text(periodo.descripcion_periodo);
                        opt.attr("value", periodo.Id);
                        $("#pantallaDetalleComites").find("#cmb_periodo").append(opt);
                    });
                });

                Backend.GetAllComites().onSuccess(
                function (comites) {
                    //var comites = JSON.parse(comites_json);
                    var detalle_ues;
                    Backend.GetEstadosEvaluaciones().onSuccess(
                    function (ues) {
                        detalle_ues = ues;
                    });


                    var _this = this;
                    $("#tabla_comites").empty();
                    var divGrilla = $("#tabla_comites");
                    var columnas = [];

                    columnas.push(new Columna("Periodo", { generar: function (model) { return model.Periodo.descripcion_periodo; } }));
                    columnas.push(new Columna("Fecha", { generar: function (model) { return model.Fecha.substring(0, 10); } }));
                    columnas.push(new Columna("Unidades de Evaluacion", { generar: function (model) {
                        var ues = model.UnidadesEvaluacion;
                        if (ues.length == 0) {
                            return "No especificado";
                        }
                        if (ues.length == 1) {
                            return ues[0].NombreArea;
                        }
                        return ues[0].NombreArea & " y " & (ues.length - 1).toString() & " ue mas";
                    }
                    }));

                    columnas.push(new Columna('Acciones', {
                        generar: function (model) {
                            var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                            var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                            var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");
                            var hidden_model = contenedorBtnAcciones.find("#hidden_model");
                            hidden_model.attr('value', JSON.stringify(model));

                            btn_editar.click(function () {
                                vex.defaultOptions.className = 'vex-theme-os';
                                vex.open({
                                    afterOpen: function ($vexContent) {
                                        var ui = $("#pantallaDetalleComites").clone();
                                        var model = JSON.parse(btn_editar.prevObject.find("#hidden_model").val())
                                        //fix del datepicker cuando haces .clone() de la plantilla, quedan dos componentes
                                        //con el mismo id, y jquery datepicker funciona mal.
                                        ui.find('#fecha_1').attr("id", "fecha_clone_id");
                                        ui.find('#fecha_clone_id').datepicker({
                                            dateFormat: "dd/mm/yy",
                                            onSelect: function (date) {
                                                //ui.find('#fecha_clone_id').text('test');
                                            }
                                        });
                                        ui.find('#fecha_clone_id').datepicker("setDate", new Date(model.Fecha));
                                        ui.find('#txt_lugar').val(model.Lugar);


                                        /***
                                        GRILLA: Unidades de Evaluacion
                                        */
                                        //
                                        var _this = this;
                                        var grilla_ue = ui.find("#tabla_unidades_evaluacion");
                                        grilla_ue.empty();
                                        var columnas_ue = [];

                                        columnas_ue.push(new Columna("Unidad Eval.", { generar: function (ue) { return ue.NombreArea; } }));
                                        columnas_ue.push(new Columna("Destacados.", { generar: function (ue) { return 12; } }));
                                        columnas_ue.push(new Columna("Bueno", { generar: function (ue) { return 15; } }));
                                        columnas_ue.push(new Columna("Regular", { generar: function (ue) { return 11; } }));
                                        columnas_ue.push(new Columna("Deficiente", { generar: function (ue) { return 10; } }));
                                        columnas_ue.push(new Columna("Total Evaluados", { generar: function (ue) { return 48; } }));
                                        columnas_ue.push(new Columna("Provisoria", { generar: function (ue) { return 1; } }));
                                        columnas_ue.push(new Columna("Pendiente", { generar: function (ue) { return 5; } }));
                                        columnas_ue.push(new Columna("Total General", { generar: function (ue) { return 5; } }));
                                        columnas_ue.push(new Columna("Acciones", {
                                            generar: function (ue) {
                                                var buttons_ue = $("#plantillas .botonera_grilla_ues").clone();
                                                var btn_eliminar_ue = buttons_ue.find("#btn_eliminar_ue");
                                                btn_eliminar_ue.click(function () {
                                                    alert('test');
                                                });
                                                return buttons_ue;
                                            }
                                        }));
                                        _this.grilla_ue = new Grilla(columnas_ue);
                                        _this.grilla_ue.SetOnRowClickEventHandler(function (ues) { });
                                        _this.grilla_ue.CambiarEstiloCabecera("estilo_tabla_portal");
                                        _this.grilla_ue.CargarObjetos(model.UnidadesEvaluacion);
                                        _this.grilla_ue.DibujarEn(grilla_ue);


                                        /***
                                        GRILLA INTEGRANTES COMITE
                                        ******/

                                        var grilla_integrantes = ui.find("#tabla_integrantes");
                                        grilla_integrantes.empty();
                                        var columnas_integrantes = [];
                                        columnas_integrantes.push(new Columna("DNI", { generar: function (int) { return int.Dni; } }));
                                        columnas_integrantes.push(new Columna("Apellido", { generar: function (int) { return int.Apellido; } }));
                                        columnas_integrantes.push(new Columna("Nombre", { generar: function (int) { return int.Nombre; } }));

                                        columnas_integrantes.push(new Columna("Acciones", {
                                            generar: function (int) {
                                                /*var buttons_ue = $("#plantillas .botonera_grilla_ues").clone();
                                                var btn_eliminar_ue = buttons_ue.find("#btn_eliminar_ue");
                                                btn_eliminar_ue.click(function () {
                                                alert('test');
                                                });
                                                return buttons_ue;*/
                                            }
                                        }));


                                        _this.columnas_integrantes = new Grilla(columnas_integrantes);
                                        _this.columnas_integrantes.SetOnRowClickEventHandler(function (int) { });
                                        _this.columnas_integrantes.CambiarEstiloCabecera("estilo_tabla_portal");
                                        _this.columnas_integrantes.CargarObjetos(model.Integrantes);
                                        _this.columnas_integrantes.DibujarEn(grilla_integrantes);

                                        $vexContent.append(ui);
                                        ui.show();
                                    },
                                    css: {
                                        'padding-top': "4%",
                                        'padding-bottom': "0%",
                                        'background-color': "rgb(249, 248, 248)"
                                    },
                                    contentCSS: {
                                        width: "80%",
                                        height: "80%"
                                    }
                                });
                            });

                            btn_eliminar.click(function () {
                                _this.eliminar(un_comite);
                            });
                            return contenedorBtnAcciones;
                        }
                    }));

                    _this.Grilla = new Grilla(columnas);
                    _this.Grilla.SetOnRowClickEventHandler(function (model) { });
                    _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                    _this.Grilla.CargarObjetos(comites);
                    _this.Grilla.DibujarEn(divGrilla);
                    $('.table-hover').removeClass("table-hover");

                    spinner.stop();
                }
            ).onError(function (e) {
                spinner.stop();
            });
            });
        });
    </script>
</body>
</html>
