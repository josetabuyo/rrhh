<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PantallaDetalleComite.aspx.cs"
    Inherits="EvaluacionDesempenio_PantallaDetalleComite" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle comité</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css" />
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css" />
    <style>
        .bottom_menu
        {
            height: 70px;
        }
        .bottom_menu_content
        {
            padding: 10px 10px 30px 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div id="pantallaDetalleComite" class="container-fluid">
        <div class="row-fluid">
            <div class="span8 offset2 well well-large">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>
                            Datos de la Reunión</h4>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <hr />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span2">
                        <label for="fecha_1">
                            Fecha <em>*</em></label>
                    </div>
                    <div class="span10">
                        <input id="fecha_1" campo="fecha_1" type="text" placeholder="dd/mm/aaaa" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span2">
                        <label for="hora">
                            Hora <em>*</em></label>
                    </div>
                    <div class="span10">
                        <input id="txt_hora" type="text" style="width: 160px;" maxlength="100" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span2">
                        <label for="lugar">
                            Lugar <em>*</em></label></div>
                    <div class="span10">
                        <input id="txt_lugar" type="text" style="width: 160px;" maxlength="100" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row-fluid"  id="integrantes">
            <div class="span8 offset2 well well-large">
                <div class="row-fluid">
                    <div class="span12">
                        <h4>Integrantes</h4>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <hr />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span2">
                        <label for="enCaracterDe">En Caracter De <em>*</em></label>
                    </div>
                    <div class="span10">
                        <select class="enCaracterDe" id="Select1">
                            <option>--Seleccione--</option>
                            <option value="1">Representante Gremial UPCN</option>
                            <option value="2">Representante Gremial ATE</option>
                            <option value="3">Coordinador del proceso de Selección</option>
                            <option value="4">Evaluador</option>
                        </select>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span2">
                        <label for="buscador">
                            Integrante
                        </label>
                    </div>
                    <div id="cmb_selector_integrantes" class="span8">
                        <input id="buscador" type="hidden" class="buscarPersona" />
                        <input type="hidden" id="persona_buscada" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="selector_personas">
                            <input type="button" id="btn_agregar_integrante" value="Agregar" />
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div id="ContenedorPlanillaIntegrantes" runat="server" class="span12">
                        <table id="tabla_integrantes" class="table table-striped">
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row well well-large">
        <label for="cmb_periodo">
            Proceso Evaluatorio <em>*</em></label>
        <select id="cmb_periodo" style="width: 280px;">
        </select>
        <h4>Unidades de Evaluacion</h4>
        <div id="ContenedorPlanillaUnidadesEvaluacion" runat="server">
            <table id="tabla_unidades_evaluacion" class="table table-striped">
            </table>
        </div>
    </div>
    </div>
    <div class="btn-fld navbar-fixed-bottom">
        <div class="container">
            <div class="offset-4 span-4 grupo_campos nueva_linea row-fluid bottom_menu text-center">
                <div class="bottom_menu_content" style="background-color: #1c2431;">
                    <input type="button" class="btn " id="btn_cancel" value="Cancelar" />
                    <input type="button" class="btn btn-primary" id="btn_guardar" value="Guardar" />
                </div>
            </div>
        </div>
    </div>
    <div id="plantillas" syle="display: hidden">
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
        <div class="botonera_grilla_participantes">
            <input type="button" class="btn_del" value="eliminar" />
        </div>
        <div class="celda_en_caracter_de_grilla_participantes">
        </div>
        <div class="botonera_grilla_ues">
            <input class="cb_ue" type="checkbox" />
            <input type="hidden" class="hidden_model" />
        </div>
    </form>
</body>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $("#btn_cancel").click(function () {
            window.location.href = "ABMComites.aspx";
        })

        Backend.start(function () {
            var PantallaDetalleComite = {
                start: function (model, ui) {
                    var _this = this;
                    this.ui = ui;
                    var cc = new CreadorColumnas();

                    ui.find('#fecha_1').datepicker({
                        dateFormat: "dd/mm/yy",
                        onSelect: function (date) {
                            //ui.find('#fecha_clone_id').text('test');
                        }
                    });
                    ui.find('#fecha_1').datepicker("setDate", new Date(model.Fecha));
                    ui.find('#txt_lugar').val(model.Lugar);
                    ui.find('#txt_hora').val(model.Hora);


                    var addIntegranteAGrilla = function (e) {
                        var _this = $(this)
                        var $panel_integrantes = _this.closest("#integrantes")

                        var integrante = JSON.parse($panel_integrantes.find("#persona_buscada").val())
                        integrante.IdEnCaracterDe = $panel_integrantes.find("#cmb_caracter.enCaracterDe").val()
                        var detalle_comite = JSON.parse(localStorage.getItem("detalleComite"))

                        Backend.EvalAddIntegranteComite(detalle_comite.Id, integrante)
                                            .onSuccess(function (res) {
                                                detalle_comite.Integrantes.push(integrante);
                                                localStorage.setItem("detalleComite", JSON.stringify(detalle_comite))

                                                var grilla_integrantes = e.data
                                                grilla_integrantes.BorrarContenido()
                                                grilla_integrantes.CargarObjetos(detalle_comite.Integrantes)
                                            })
                    }


                    var cargar_ues = function () {
                        /***
                        GRILLA: Unidades de Evaluacion
                        */
                        //
                        var tabla_ue = $("#tabla_unidades_evaluacion");
                        tabla_ue.empty();

                        var columnas_ue = cc.triviales(["Codigo"]);
                        columnas_ue.push(cc.con_alias("UNIDAD EVAL", "NombreArea"))
                        columnas_ue = columnas_ue.concat(cc.con_submodelo("DetalleEvaluados", ["Destacados", "Bueno", "Regular", "Deficiente", "Provisoria", "Pendiente"]))
                        columnas_ue.splice(6, 0, new Columna("Total Evaluados", { generar: function (ue) { return ue.DetalleEvaluados.Destacados + ue.DetalleEvaluados.Bueno + ue.DetalleEvaluados.Regular + ue.DetalleEvaluados.Deficiente; } }))
                        columnas_ue.push(new Columna("Total General", { generar: function (ue) { return ue.DetalleEvaluados.Destacados + ue.DetalleEvaluados.Bueno + ue.DetalleEvaluados.Regular + ue.DetalleEvaluados.Deficiente + ue.DetalleEvaluados.Provisoria + ue.DetalleEvaluados.Pendiente; } }));
                        columnas_ue.push(new Columna("", {
                            generar: function (ue) {
                                var $buttons_ue = $("#plantillas .botonera_grilla_ues").clone()
                                var $cb = $buttons_ue.find('.cb_ue')
                                var comite = JSON.parse(localStorage.getItem("detalleComite"))
                                var id_comite = comite.Id
                                var found = comite.UnidadesEvaluacion.filter(function (u) { return u.Id == ue.Id })
                                $buttons_ue.find('.hidden_model').first().val(ue.Id);

                                if (found.length != 0) {
                                    $cb.attr('checked', 'true');
                                }

                                $cb.click(function (e) {
                                    var mcb = e.currentTarget
                                    var $spin_panel = $(e.currentTarget).parent()

                                    var ue_id = $(e.currentTarget).parent().find(".hidden_model").first().val()

                                    var backend_call = function () { }
                                    if (mcb.checked) {
                                        backend_call = Backend.EvalAddUnidadEvaluacionAComite
                                    } else {
                                        backend_call = Backend.EvalRemoveUnidadEvaluacionAComite
                                    }

                                    backend_call(id_comite, ue_id)
                                            .onSuccess(function (res) {
                                                if (res.Accion == "EvalRemoveUnidadEvaluacionAComite") {
                                                    var detalleComite = JSON.parse(localStorage.getItem("detalleComite"))
                                                    detalleComite.UnidadesEvaluacion = detalleComite.UnidadesEvaluacion.filter(function (ue) { return ue.Id != res.IdUE });
                                                    localStorage.setItem("detalleComite", JSON.stringify(detalleComite))
                                                } else {
                                                    //res.Accion == "EvalAddUnidadEvaluacionAComite"
                                                    var detalleComite = JSON.parse(localStorage.getItem("detalleComite"))
                                                    var ues = JSON.parse(localStorage.getItem("estadosEvaluaciones"))
                                                    var ue_agregada = _.find(ues, function (ue) {
                                                        return ue.Id == res.IdUE
                                                    })
                                                    detalleComite.UnidadesEvaluacion.push(ue_agregada)
                                                    localStorage.setItem("detalleComite", JSON.stringify(detalleComite))
                                                }
                                            }).onError(function (err) {
                                                alert("se produjo un error en la comunicación")
                                                mcb.checked = !mcb.checked
                                            })
                                })
                                return $buttons_ue
                            }
                        }))

                        var estadosEvaluaciones = JSON.parse(localStorage.getItem("estadosEvaluaciones"));
                        var id_periodo = $("#cmb_periodo").val();

                        _this.grilla_ue = new Grilla(columnas_ue)
                        _this.grilla_ue.SetOnRowClickEventHandler(function (ues) { })
                        _this.grilla_ue.CambiarEstiloCabecera("estilo_tabla_portal")
                        _this.grilla_ue.CargarObjetos(estadosEvaluaciones.filter(function (i) { return i.IdPeriodo == id_periodo; }))
                        _this.grilla_ue.DibujarEn(tabla_ue)
                    }

                    Backend.GetPeriodosEvaluacion()
                        .onSuccess(function (periodos) {
                            _.forEach(periodos, function (periodo) {
                                var opt = $("<option>");
                                opt.text(periodo.descripcion_periodo);
                                opt.attr("value", periodo.Id);
                                $("#cmb_periodo").append(opt);
                            });
                            cargar_ues();
                        });

                    ui.find("#cmb_periodo").unbind("change");
                    ui.find("#cmb_periodo").change(cargar_ues);

                    /******
                    GRILLA INTEGRANTES COMITE
                    ******/

                    var tabla_grilla_integrantes = ui.find("#tabla_integrantes");
                    tabla_grilla_integrantes.empty();

                    var columnas_integrantes = cc.triviales(["Dni", "Apellido", "Nombre"])

                    columnas_integrantes.push(new Columna("En caracter de", { generar: function (int) {
                        //var $celda = $("#plantillas .celda_en_caracter_de_grilla_participantes").clone();
                        return $('#cmb_caracter option[value="' + int.IdEnCaracterDe + '"]').text()
                        //return $celda;
                    }
                    }));
                    columnas_integrantes.push(new Columna("Acciones", {
                        generar: function (int) {
                            var buttons_integrantes = $("#plantillas .botonera_grilla_participantes")
                                                        .clone()
                                                        .find(".btn_del")
                                                        .on('click', { integrante: int, grilla: _this.grilla_integrantes }, function (e) {

                                                            var _this = $(this)
                                                            var $panel_integrantes = _this.closest("#integrantes")
                                                            var detalle_comite = JSON.parse(localStorage.getItem("detalleComite"))
                                                            var integrante_a_borrar = e.data.integrante.IdPersona

                                                            Backend.EvalRemoverIntegranteComite(detalle_comite.Id, integrante_a_borrar)
                                                                .onSuccess(function (res) {
                                                                    e.data.grilla.EliminarObjeto(e.data.integrante)
                                                                    detalle_comite.Integrantes = _.reject(detalle_comite.Integrantes, function (item) { return item.IdPersona == e.data.integrante.IdPersona });
                                                                    localStorage.setItem("detalleComite", JSON.stringify(detalle_comite))
                                                                })
                                                        })
                            return buttons_integrantes;
                        }
                    }));

                    _this.grilla_integrantes = new Grilla(columnas_integrantes);
                    _this.grilla_integrantes.SetOnRowClickEventHandler(function (int) { });
                    _this.grilla_integrantes.CambiarEstiloCabecera("estilo_tabla_portal");
                    _this.grilla_integrantes.CargarObjetos(model.Integrantes);
                    _this.grilla_integrantes.DibujarEn(tabla_grilla_integrantes);

                    ui.find("#btn_agregar_integrante").on('click', _this.grilla_integrantes, addIntegranteAGrilla);

                    var proveedor_ajax = new ProveedorAjax("../");
                    var repositorioDePersonas = new RepositorioDePersonas(proveedor_ajax);
                    var selector_integrantes = new SelectorDePersonas({
                        ui: $('#cmb_selector_integrantes'),
                        repositorioDePersonas: repositorioDePersonas,
                        placeholder: "nombre, apellido, documento o legajo"
                    });
                    selector_integrantes.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
                        var persona = {
                            Dni: la_persona_seleccionada.documento,
                            Apellido: la_persona_seleccionada.apellido,
                            Nombre: la_persona_seleccionada.nombre,
                            IdPersona: la_persona_seleccionada.id
                        }
                        $("#persona_buscada").val(JSON.stringify(persona))
                    };
                }
            }
            PantallaDetalleComite.start(JSON.parse(localStorage.getItem('detalleComite')), $("#pantallaDetalleComite"));
        });
    });
</script>
</html>
