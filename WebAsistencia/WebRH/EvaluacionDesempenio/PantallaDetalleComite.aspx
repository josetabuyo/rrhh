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
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div id="pantallaDetalleComite" class="">
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
                <div id="cmb_selector_integrantes" class="selector_personas">
                    <input id="buscador" type="hidden" class="buscarPersona" />
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
                <input type="button" class="btn btn-primary" id="btn_guardar" value="Siguiente" />
            </div>
            <input type="hidden" id="txt_AntecedenteAcademico_id" />
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
            <input type="button" id="btn_eliminar_participante" value="eliminar" />
        </div>
        <div class="celda_en_caracter_de_grilla_participantes">
            <select class="enCaracterDe">
                <option>Representante Gremial UPCN</option>
                <option>Representante Gremial ATE</option>
                <option>Coordinador del proceso de Selección</option>
                <option>Evaluador</option>
            </select>
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
                    //var ui = $("#pantallaDetalleComites").clone();


                    //fix del datepicker cuando haces .clone() de la plantilla, quedan dos componentes
                    //con el mismo id, y jquery datepicker funciona mal.
                    //ui.find('#fecha_1').attr("id", "fecha_clone_id");

                    ui.find('#fecha_1').datepicker({
                        dateFormat: "dd/mm/yy",
                        onSelect: function (date) {
                            //ui.find('#fecha_clone_id').text('test');
                        }
                    });
                    ui.find('#fecha_clone_id').datepicker("setDate", new Date(model.Fecha));
                    ui.find('#txt_lugar').val(model.Lugar);

                    var cargar_ues = function () {

                        /***
                        GRILLA: Unidades de Evaluacion
                        */
                        //
                        var grilla_ue = ui.find("#tabla_unidades_evaluacion");
                        grilla_ue.empty();

                        var columnas_ue = [];
                        columnas_ue.push(new Columna("Codigo", { generar: function (ue) { return ue.Codigo; } }));
                        columnas_ue.push(new Columna("Unidad Eval.", { generar: function (ue) { return ue.NombreArea; } }));
                        columnas_ue.push(new Columna("Destacados.", { generar: function (ue) { return ue.DetalleEvaluados.Destacados; } }));
                        columnas_ue.push(new Columna("Bueno", { generar: function (ue) { return ue.DetalleEvaluados.Bueno; } }));
                        columnas_ue.push(new Columna("Regular", { generar: function (ue) { return ue.DetalleEvaluados.Regular; } }));
                        columnas_ue.push(new Columna("Deficiente", { generar: function (ue) { return ue.DetalleEvaluados.Deficiente; } }));
                        columnas_ue.push(new Columna("Total Evaluados", { generar: function (ue) { return ue.DetalleEvaluados.Destacados + ue.DetalleEvaluados.Bueno + ue.DetalleEvaluados.Regular + ue.DetalleEvaluados.Deficiente; } }));
                        columnas_ue.push(new Columna("Provisoria", { generar: function (ue) { ue.DetalleEvaluados.Provisoria; } }));
                        columnas_ue.push(new Columna("Pendiente", { generar: function (ue) { ue.DetalleEvaluados.Pendiente; } }));
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
                                    if (mcb.checked) {

                                        Backend.EvalAddUnidadEvaluacionAComite(id_comite, ue_id)
                                            .onSuccess(function (res) {
                                                    if (res.DioError) {
                                                        alert(res.MensajeDeErrorAmigable)
                                                        mcb.checked = !mcb.checked
                                                    }
                                                    spinner.stop()
                                            }).onError(function (err) {
                                                alert("se produjo un error en la comunicación")
                                                spinner.stop()
                                            })
                                    }
                                })
                              return $buttons_ue  
                            }
                            
                        }))

                        var estadosEvaluaciones = JSON.parse(localStorage.getItem("estadosEvaluaciones"));
                        var id_periodo = ui.find("#cmb_periodo").val();

                        _this.grilla_ue = new Grilla(columnas_ue);
                        _this.grilla_ue.SetOnRowClickEventHandler(function (ues) { });
                        _this.grilla_ue.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.grilla_ue.CargarObjetos(estadosEvaluaciones.filter(function (i) { return i.IdPeriodo == id_periodo; }));
                        _this.grilla_ue.DibujarEn(grilla_ue);
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

                    /***
                    GRILLA INTEGRANTES COMITE
                    ******/

                    var tabla_grilla_integrantes = ui.find("#tabla_integrantes");
                    tabla_grilla_integrantes.empty();

                    var columnas_integrantes = [];
                    columnas_integrantes.push(new Columna("DNI", { generar: function (int) { return int.Dni; } }));
                    columnas_integrantes.push(new Columna("Apellido", { generar: function (int) { return int.Apellido; } }));
                    columnas_integrantes.push(new Columna("Nombre", { generar: function (int) { return int.Nombre; } }));
                    columnas_integrantes.push(new Columna("En caracter de", { generar: function (int) {
                        var celda = $("#plantillas .celda_en_caracter_de_grilla_participantes").clone();
                        return celda;
                    }
                    }));
                    columnas_integrantes.push(new Columna("Acciones", {
                        generar: function (int) {
                            var buttons_integrantes = $("#plantillas .botonera_grilla_participantes").clone();
                            var btn_eliminar_participante = buttons_integrantes.find("#btn_eliminar_participante");
                            btn_eliminar_participante.click(function () {
                                model.Integrantes = _.reject(model.Integrantes, function (item) {
                                    return item.Id === int.Id;
                                });
                                _this.grilla_integrantes.EliminarObjeto(int);
                            });
                            return buttons_integrantes;
                        }
                    }));


                    _this.grilla_integrantes = new Grilla(columnas_integrantes);
                    _this.grilla_integrantes.SetOnRowClickEventHandler(function (int) { });
                    _this.grilla_integrantes.CambiarEstiloCabecera("estilo_tabla_portal");
                    _this.grilla_integrantes.CargarObjetos(model.Integrantes);
                    _this.grilla_integrantes.DibujarEn(tabla_grilla_integrantes);


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
                            Id: la_persona_seleccionada.id
                        }
                        model.Integrantes.push(persona);
                        _this.grilla_integrantes.BorrarContenido();
                        _this.grilla_integrantes.CargarObjetos(model.Integrantes);
                    };
                }
            };

            PantallaDetalleComite.start(JSON.parse(localStorage.getItem('detalleComite')), $("#pantallaDetalleComite"));
        });
    });
   
</script>
</html>
