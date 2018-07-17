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
    <link rel="stylesheet" href="../FormularioConcursar/EstilosPostular.css" />
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div id="pantallaDetalleComite" class="">
        <div id="contenido_form_comite" class="fondo_form">
            <fieldset>
                <h4>
                    Datos de la Reunión</h4>
                <div>
                    <label for="fecha_1">
                        Fecha <em>*</em>
                    </label>
                    <input id="fecha_1" campo="fecha_1" type="text" placeholder="dd/mm/aaaa" style="flex-grow: 100;" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="hora">
                        Hora <em>*</em></label>
                    <input id="txt_hora" type="text" style="width: 160px;" maxlength="100" />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label for="lugar">
                        Lugar <em>*</em></label>
                    <input id="txt_lugar" type="text" style="width: 160px;" maxlength="100" />
                </div>
                <div id="integrantes" class="grupo_campos nueva_linea">
                    <!--<legend><a id="btn_agregar_ue" class="link">Agregar Unidad de Evaluacion</a></legend>-->
                    <h4>Integrantes</h4>
                    <div id="cmb_caracter" class="selector_personas grupo_campos nueva_linea">
                        <label for="lugar">
                            En Caracter De <em>*</em></label>
                        <select class="enCaracterDe" id="cmb_caracter">
                            <option>--Seleccione--</option>
                            <option value="1">Representante Gremial UPCN</option>
                            <option value="2">Representante Gremial ATE</option>
                            <option value="3">Coordinador del proceso de Selección</option>
                            <option value="4">Evaluador</option>
                        </select>
                    </div>
                    <div id="cmb_selector_integrantes" class="selector_personas grupo_campos nueva_linea">
                        <label for="buscador">
                            Integrante
                        </label>
                        <input id="buscador" type="hidden" class="buscarPersona" />
                        <input type="hidden" id="persona_buscada" />
                    </div>
                    <div class="selector_personas grupo_campos nueva_linea">
                        <input type="button" id="btn_agregar_integrante" value="Agregar" />
                    </div>
                    <div id="ContenedorPlanillaIntegrantes" runat="server" class="grupo_campos nueva_linea">
                        <table id="tabla_integrantes" class="table table-striped">
                        </table>
                    </div>
                    <div class="grupo_campos nueva_linea">
                        <label for="cmb_periodo">
                            Proceso Evaluatorio <em>*</em></label>
                        <select id="cmb_periodo" style="width: 280px;">
                        </select>
                    </div>
                    <div class="grupo_campos nueva_linea">
                        <!--<legend><a id="btn_agregar_ue" class="link">Agregar Unidad de Evaluacion</a></legend>-->
                        <h4>
                            Unidades de Evaluacion</h4>
                        <div id="ContenedorPlanillaUnidadesEvaluacion" runat="server">
                            <table id="tabla_unidades_evaluacion" class="table table-striped">
                            </table>
                        </div>
                    </div>
            </fieldset>
            <div class="btn-fld">
                <input type="button" class="btn btn-primary" id="btn_guardar" value="Siguiente" />
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
            <!--<select class="enCaracterDe" id="cmb_caracter">
                <option>--Seleccione--</option>
                <option value="1">Representante Gremial UPCN</option>
                <option value="2">Representante Gremial ATE</option>
                <option value="3">Coordinador del proceso de Selección</option>
                <option value="4">Evaluador</option>
            </select>-->
        </div>
        <div class="botonera_grilla_ues">
            <input class="cb_ue" type="checkbox" />
            <input type="hidden" class="hidden_model" />
        </div>
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
        Backend.start(function () {
            var PantallaDetalleComite = {
                start: function (model, ui) {
                    var _this = this;
                    this.ui = ui;
                    var creador_columnas = new CreadorColumnas();

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

                        var spinner = new Spinner({ scale: 2 })
                        spinner.spin($panel_integrantes[0]);


                        var integrante = JSON.parse($panel_integrantes.find("#persona_buscada").val())
                        integrante.IdEnCaracterDe = $panel_integrantes.find("#cmb_caracter.enCaracterDe").val()
                        var detalle_comite = JSON.parse(localStorage.getItem("detalleComite"))

                        Backend.EvalAddIntegranteComite(detalle_comite.Id, integrante)
                                            .onSuccess(function (res) {
                                                spinner.stop()
                                                if (res.DioError) {
                                                    alert(res.MensajeDeErrorAmigable)
                                                    return
                                                }

                                                detalle_comite.Integrantes.push(integrante);
                                                localStorage.setItem("detalleComite", JSON.stringify(detalle_comite))

                                                var grilla_integrantes = e.data
                                                grilla_integrantes.BorrarContenido()
                                                grilla_integrantes.CargarObjetos(detalle_comite.Integrantes)

                                            }).onError(function (err) {
                                                alert("se produjo un error en la comunicación")
                                                spinner.stop()
                                            })
                    }


                    var cargar_ues = function () {

                        /***
                        GRILLA: Unidades de Evaluacion
                        */
                        //
                        var grilla_ue = ui.find("#tabla_unidades_evaluacion");
                        grilla_ue.empty();

                        var columnas_ue = creador_columnas.triviales(["Codigo"]);
                        columnas_ue.push(creador_columnas.con_alias("UNIDAD EVAL", "NombreArea"))
                        columnas_ue = columnas_ue.concat(creador_columnas.con_submodelo("DetalleEvaluados",["Destacados", "Bueno", "Regular", "Deficiente", "Provisoria", "Pendiente"]))
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
                                    var spinner = new Spinner({ scale: 0.5, position: 'relative', left: '50%', top: '50%' })
                                    spinner.spin($(e.currentTarget).parent())
                                    var mcb = e.currentTarget
                                    var ue_id = $(e.currentTarget).parent().find(".hidden_model").first().val()
                                    var backend_call = function () { }
                                    if (mcb.checked) {
                                        backend_call = Backend.EvalAddUnidadEvaluacionAComite
                                    } else {
                                        backend_call = Backend.EvalRemoveUnidadEvaluacionAComite
                                    }

                                    backend_call(id_comite, ue_id)
                                            .onSuccess(function (res) {
                                                spinner.stop()
                                                if (res.DioError) {
                                                    alert(res.MensajeDeErrorAmigable)
                                                    mcb.checked = !mcb.checked
                                                    return
                                                }

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
                                                spinner.stop()
                                            })
                                })
                                return $buttons_ue
                            }
                        }))

                        var estadosEvaluaciones = JSON.parse(localStorage.getItem("estadosEvaluaciones"));
                        var id_periodo = ui.find("#cmb_periodo").val();

                        _this.grilla_ue = new Grilla(columnas_ue)
                        _this.grilla_ue.SetOnRowClickEventHandler(function (ues) { })
                        _this.grilla_ue.CambiarEstiloCabecera("estilo_tabla_portal")
                        _this.grilla_ue.CargarObjetos(estadosEvaluaciones.filter(function (i) { return i.IdPeriodo == id_periodo; }))
                        _this.grilla_ue.DibujarEn(grilla_ue)
                    }

                    Backend.GetPeriodosEvaluacion()
                        .onSuccess(function (periodos) {
                            _.forEach(periodos, function (periodo) {
                                var opt = $("<option>");
                                opt.text(periodo.descripcion_periodo);
                                opt.attr("value", periodo.Id);
                                ui.find("#cmb_periodo").append(opt);
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




                    var columnas_integrantes = creador_columnas.triviales(["Dni", "Apellido", "Nombre"])

                    columnas_integrantes.push(new Columna("En caracter de", { generar: function (int) {
                        var $celda = $("#plantillas .celda_en_caracter_de_grilla_participantes").clone();
                        $celda.find("#cmb_caracter").change(function (e) {
                            var spinner = new Spinner({ scale: 0.5, position: 'relative', left: '50%', top: '50%' })
                            spinner.spin($(e.currentTarget).parent())
                            var id_comite = JSON.parse(localStorage.getItem("detalleComite")).Id
                            var integrante =
                            {
                                Apellido: '',
                                Nombre: '',
                                IdEnCaracterDe: e.currentTarget.value,
                                IdPersona: int.IdPersona,
                                Dni: 0
                            }
                            Backend.EvalAddIntegranteComite(id_comite, integrante)
                            .onSuccess(function (res) {
                                spinner.stop()
                                if (res.DioError) {
                                    alert(res.MensajeDeErrorAmigable)
                                    mcb.checked = !mcb.checked
                                    return
                                }
                            }).onError(function (err) {
                                spinner.stop();
                                alert("se produjo un error en la comunicación")
                                mcb.checked = !mcb.checked
                                spinner.stop()
                            })
                        });

                        return $celda;
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

                                                            var spinner = new Spinner({ scale: 2 })
                                                            spinner.spin($panel_integrantes[0]);

                                                            Backend.EvalRemoverIntegranteComite(detalle_comite.Id, integrante_a_borrar)
                                                                .onSuccess(function (res) {
                                                                    spinner.stop()
                                                                    if (res.DioError) {
                                                                        alert(res.MensajeDeErrorAmigable)
                                                                        return
                                                                    }
                                                                    model.Integrantes = _.reject(model.Integrantes, function (item) { return item.Id == e.data });
                                                                    e.data.grilla.EliminarObjeto(e.data.integrante)
                                                                }).onError(function (err) {
                                                                    alert("se produjo un error en la comunicación")
                                                                    spinner.stop()
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
