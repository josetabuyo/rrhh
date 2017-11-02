var GestionDeTareas = {
    init: function () {

    },

    ObtenerTareasSeleccionadas: function () {
        var id_tareas = [];
        var tareas_seleccionadas = $($("#tablaTareas").find(".fondo_verde"));
        for (var i = 0; i < tareas_seleccionadas.length; i++) {
            id_tareas.push(parseInt($($(tareas_seleccionadas[i]).find("td")[1]).text()));
        }
        return id_tareas;
    },
    DerivarTareas: function (persona) {
        var _this_original = this;
        var id_tareas = this.ObtenerTareasSeleccionadas();
        Backend.DerivarTareas(persona, id_tareas)
                    .onSuccess(function (tareas) {
                        _this_original.getTareasParaGestion();
                    })
                    .onError(function (e) {
                        alert("No se pudo derivar las tareas")
                    });
    },
    getTareasParaGestion: function () {
        var _this_original = this;
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre y apellido"
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            _this_original.DerivarTareas(la_persona_seleccionada);
            //alert("aa");
            //_this.mostrarPersona(la_persona_seleccionada.id);
        };

        Backend.getTicketsPorFuncionalidad()
                    .onSuccess(function (tareas) {

                        tareas = _.sortBy(tareas, 'id').reverse();
                        var _this = this;

                        $("#tablaTareas").empty();

                        var divGrilla_tareas = $("#tablaTareas");

                        var columnas_tareas = [];
                        columnas_tareas.push(new Columna('Seleccionar', {
                            generar: function (una_tarea) {
                                var btn_accion = $('<a><input type="checkbox" name="selector_tarea" id="sel_' + una_tarea.id + '"></a>');
                                btn_accion.change(function () {
                                    _this_original.SeleccionarTarea($(this), una_tarea);
                                });
                                return btn_accion;
                            }
                        }));
                        columnas_tareas.push(new Columna("#", { generar: function (una_tarea) { return una_tarea.id } }));
                        columnas_tareas.push(new Columna("Fecha Creación", { generar: function (una_tarea) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_tarea.fechaCreacion) } }));
                        //columnas_tareas.push(new Columna("Titulo", { generar: function (una_tarea) { return una_tarea.tipoAlerta.titulo } }));
                        columnas_tareas.push(new Columna("Descripcion", { generar: function (una_tarea) { return una_tarea.tipoTicket.descripcion } }));
                        columnas_tareas.push(new Columna("Creador", { generar: function (una_tarea) { return una_tarea.usuarioCreador.Owner.Apellido + ', ' + una_tarea.usuarioCreador.Owner.Nombre } }));
                        //columnas_tareas.push(new Columna("Tipo de Tarea", { generar: function (una_tarea) { return una_tarea.tipoTarea.descripcion } }));
                        //columnas_tareas.push(new Columna("Estado", { generar: function (una_tarea) { return una_tarea.estado } }));
                        columnas_tareas.push(new Columna('Detalle', {
                            generar: function (una_tarea) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeTarea(una_tarea);
                                });
                                return btn_accion;
                            }
                        }));

                        _this.divGrilla_tareas = new Grilla(columnas_tareas);
                        _this.divGrilla_tareas.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_tareas.SetOnRowClickEventHandler(function (una_tarea) { });
                        _this.divGrilla_tareas.CargarObjetos(tareas);
                        _this.divGrilla_tareas.DibujarEn(divGrilla_tareas);

                        $('.table-hover').removeClass("table-hover");

                        var options = {
                            valueNames: ['Titulo', 'Descripcion', 'Creador']
                        };

                        var featureList = new List('tareas', options);
                    })
                    .onError(function (e) {

                    });
    },
    SeleccionarTarea: function (check, tarea) {
        if ($(check.find("[type=checkbox]")).is(":checked")) {
            $("#sel_" + tarea.id).parent().parent().parent().addClass("fondo_verde");
        } else {
            $("#sel_" + tarea.id).parent().parent().parent().removeClass("fondo_verde");
        }
    },
    MostrarDetalleDeTarea: function (tarea) {
        var _this = this;

        vex.defaultOptions.className = 'vex-theme-os';
        vex.open({
            afterOpen: function ($vexContent) {
                $vexContent.load(window.location.origin + '/' + tarea.tipoTicket.urlComponente, function () {
                    Componente.start(tarea, $vexContent);
                });

                return $vexContent;
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

    }


}