var tab_actual = 0;
var tareas_total = [];
var GestionDeTareas = {
    init: function () {
        var numero_filtro = $(".content-current").attr("numero_tab")
        if (tab_actual != numero_filtro) {
            alert(numero_filtro)
            tab_actual = numero_filtro;
        }

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
        alert("voy a la base");
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

                        tareas_total = _.sortBy(tareas, 'id').reverse();
                        
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