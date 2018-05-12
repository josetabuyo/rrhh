var tab_actual = 0;
var tareas_total = [];
var usuario_logueado = -1;
var usuario_a_derivar = 0;
var filtro = true;
var GestionDeTareas = {

    init: function () {
        var numero_filtro = parseInt($(".content-current").attr("numero_tab"));
        //Agrego filtro por tipo (hecho por Javi)
        if (tab_actual != numero_filtro) {
            tab_actual = numero_filtro;
        }
        var _this = this;
        var tareas_filtradas = [];
        $("#section-shape-1").html("");
        $("#section-shape-2").html("");
        $("#section-shape-3").html("");
        var mostrar_asignado = false;
        switch (tab_actual) {
            case 1: //MIS TAREAS
                tareas_filtradas = $.grep(tareas_total, function (tarea) { return tarea.usuarioAsignado.Id == usuario_logueado });
                $("#section-shape-1").html('<div id="tablaTareas" class="table table-striped table-bordered table-condensed"></div>');
                break;
            case 2: //TAREAS SIN ASIGNACIÓN
                tareas_filtradas = $.grep(tareas_total, function (tarea) { return tarea.usuarioAsignado.Id == 0 });
                $("#section-shape-2").html('<div id="tablaTareas" class="table table-striped table-bordered table-condensed"></div>');
                break;
            case 3: //TAREAS ASIGNADAS A OTROS
                mostrar_asignado = true;
                tareas_filtradas = $.grep(tareas_total, function (tarea) { return tarea.usuarioAsignado.Id != usuario_logueado && tarea.usuarioAsignado.Id != 0 });
                $("#section-shape-3").html('<div id="tablaTareas" class="table table-striped table-bordered table-condensed"></div>');
                break;
            default:
        }

        this.DibujarTabla(tareas_filtradas, mostrar_asignado);

    },

    ObtenerUsuarioLogueado: function () {
        Backend.GetUsuarioLogueado()
        .onSuccess(function (usuario) {
            usuario_logueado = usuario.Id;
        })
        .onError(function (e) {
        });
    },

    ObtenerTareasSeleccionadas: function () {
        var id_tareas = [];
        var tareas_seleccionadas = $($("#tablaTareas").find(".fondo_verde"));
        for (var i = 0; i < tareas_seleccionadas.length; i++) {
            id_tareas.push(parseInt($($(tareas_seleccionadas[i]).find("td")[1]).text()));
        }
        return id_tareas;
    },

    DibujarTabla: function (tareas, mostrar_asignado) {
        tareas = _.sortBy(tareas, 'id').reverse();
        var _this = this;

        $("#tablaTareas").empty();

        var divGrilla_tareas = $("#tablaTareas");

        var columnas_tareas = [];

        columnas_tareas.push(new Columna('Derivar', {
            generar: function (una_tarea) {
                var btn_accion = $(' <input type="checkbox">');
                btn_accion.change(function () {
                    _this.SeleccionarTarea($(this));
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
        if (mostrar_asignado) {
            columnas_tareas.push(new Columna("Asignado a", { generar: function (una_tarea) { return una_tarea.usuarioAsignado.Owner.Apellido + ", " + una_tarea.usuarioAsignado.Owner.Nombre } }));
        }
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
                    _this.MostrarDetalleDeTarea(una_tarea);
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

        if (filtro) {
            var options = { valueNames: ['Descripcion', 'Creador'] };
            var featureList = new List('tareas', options);
            $('#search').val(localStorage.getItem('filtroTickets'));
            featureList.search(localStorage.getItem('filtroTickets'));
            filtro = false;
        }
    },

    DerivarTareas: function () {
        var _this = this;
        var id_tareas = this.ObtenerTareasSeleccionadas();
        Backend.DerivarTareas(usuario_a_derivar, id_tareas)
                    .onSuccess(function (tareas) {
                        _this.getTareasParaGestion();
                        _this.init();
                    })
                    .onError(function (e) {
                        alert("No se pudo derivar las tareas")
                    });
    },
    TienePermisoDeDerivacion: function () {
        var _this = this;

        Backend.TienePermisoDeDerivacionDeTareas()
                    .onSuccess(function (respuesta) {
                        if (respuesta) {
                            $(".gestion_de_derivacion_de_tareas").show();
                            $(".solapa_derivaciones").parent().show();

                        } else {
                            $(".gestion_de_derivacion_de_tareas").hide();
                            $(".solapa_derivaciones").parent().hide();
                        }

                        return respuesta;
                    })
                    .onError(function (e) {
                        alert("No se pudo determinar los permisos para la derivación de tareas")
                        return false;
                    });
    },

    buscadorDePersonas: function () {
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre y apellido"
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            Backend.PersonaTieneUsuarioWeb(la_persona_seleccionada.documento).onSuccess(function (tiene_usuario) {
                if (tiene_usuario) {
                    usuario_a_derivar = la_persona_seleccionada;
                } else {
                    alert("la persona seleccionada no tiene usuario web")
                }
            })
                    .onError(function (e) {
                        alert("error al consultar si la persona tiene usuario web")
                    });


        };
    },
    getTareasParaGestion: function () {
        var _this_original = this;
        Backend.getTicketsPorFuncionalidad()
                    .onSuccess(function (tareas) {

                        //<<<<<<< HEAD
                        tareas_total = _.sortBy(tareas, 'id').reverse();
                        GestionDeTareas.init();
                        //=======
                        //                        tareas = _.sortBy(tareas, 'id').reverse();
                        //                        var _this = this;

                        //                        $("#tablaTareas").empty();

                        //                        var divGrilla_tareas = $("#tablaTareas");

                        //                        var columnas_tareas = [];

                        //                        columnas_tareas.push(new Columna("#", { generar: function (una_tarea) { return una_tarea.id } }));
                        //                        columnas_tareas.push(new Columna("Fecha Creación", { generar: function (una_tarea) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_tarea.fechaCreacion) } }));
                        //                        //columnas_tareas.push(new Columna("Titulo", { generar: function (una_tarea) { return una_tarea.tipoAlerta.titulo } }));
                        //                        columnas_tareas.push(new Columna("Descripcion", { generar: function (una_tarea) { return una_tarea.tipoTicket.descripcion } }));
                        //                        columnas_tareas.push(new Columna("Creador", { generar: function (una_tarea) { return una_tarea.usuarioCreador.Owner.Apellido + ', ' + una_tarea.usuarioCreador.Owner.Nombre } }));
                        //                        //columnas_tareas.push(new Columna("Tipo de Tarea", { generar: function (una_tarea) { return una_tarea.tipoTarea.descripcion } }));
                        //                        //columnas_tareas.push(new Columna("Estado", { generar: function (una_tarea) { return una_tarea.estado } }));
                        //                        columnas_tareas.push(new Columna('Detalle', {
                        //                            generar: function (una_tarea) {
                        //                                var btn_accion = $('<a>');
                        //                                var img = $('<img>');
                        //                                img.attr('src', '../Imagenes/detalle.png');
                        //                                img.attr('width', '15px');
                        //                                img.attr('height', '15px');
                        //                                btn_accion.append(img);
                        //                                btn_accion.click(function () {
                        //                                    _this_original.MostrarDetalleDeTarea(una_tarea);
                        //                                });
                        //                                return btn_accion;
                        //                            }
                        //                        }));

                        //                        _this.divGrilla_tareas = new Grilla(columnas_tareas);
                        //                        _this.divGrilla_tareas.CambiarEstiloCabecera("estilo_tabla_portal");
                        //                        _this.divGrilla_tareas.SetOnRowClickEventHandler(function (una_tarea) { });
                        //                        _this.divGrilla_tareas.CargarObjetos(tareas);
                        //                        _this.divGrilla_tareas.DibujarEn(divGrilla_tareas);

                        //                        $('.table-hover').removeClass("table-hover");

                        //                        var options = {
                        //                            valueNames: ['Titulo', 'Descripcion', 'Creador']
                        //                        };

                        //                        var featureList = new List('tareas', options);

                        //                        featureList.search(localStorage.getItem('filtroTickets'));
                        //                        $('#search').val(localStorage.getItem('filtroTickets'));
                        //                        //>>>>>>> 6d1c9538163359c2d92f93b9471a5a12d724fbaa
                    })
                    .onError(function (e) {

                    });
    },
    SeleccionarTarea: function (check, tarea) {
        if (check.is(":checked")) {
            check.parent().parent().addClass("fondo_verde");
        } else {
            check.parent().parent().removeClass("fondo_verde");
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