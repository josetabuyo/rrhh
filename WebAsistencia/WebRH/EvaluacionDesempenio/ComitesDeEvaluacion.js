requirejs(['../common'], function (common) {
    requirejs(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'selector-personas', 'barramenu2', 'jquery-ui', 'jquery-timepicker'], function ($, _, app_state, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo, SelectorDePersonas) {

        //window.localStorage.clear()

        var on_integrantes_enter = function (idComite) {

            var periodo = app_state.PeriodoDe(idComite)
            spa_tabs.setNextParameter(idComite)

            $("#desc_periodo_int").text(periodo.descripcion_periodo)

            crear_grilla_integrantes()
        }

        var crear_grilla_integrantes = function () {

            var idComite = spa_tabs.getParam()
            var comite = app_state.GetComite(idComite)

            //cargo la descripcion de "en caracter de" a partir del id para mostrarlo en la grilla
            _.each(comite.Integrantes, i => i.EnCaracterDe = app_state.GetEnCaracterDe(i.IdEnCaracterDe))

            CreadorDeGrillas('#tabla_integrantes', comite.Integrantes)
            $(".delete-integrante").click(e => {
                e.preventDefault()
                remover_integrante(e.currentTarget.attributes.integrante.value, idComite)
            })
        }

        //cuando se muestra la pantalla de datos generales
        var on_datos_generales_enter = function (idPeriodo) {
            $("#desc_periodo").text(app_state.GetPeriodo(idPeriodo).descripcion_periodo)
        }

        //cuando se hace click en "siguiente" (datos generales)
        var on_datos_generales_next = function (show_next_tab, params) {
            //params['IdPeriodo']<--todo, varios parametros con nombre

            app_state.AddComite($("#descripcion").val(),
                $("#fecha").val(),
                $("#hora").val(),
                $("#lugar").val(),
                params,
                (err, comite_agregado) => {
                    if (err) {
                        alert('Error al agregar comite')
                        console.log(err)
                    }
                    show_next_tab(comite_agregado.Id)
                    load_grid_periodos()
                })
        }

        var ue_clicked = function (event) {

            var id_ue = event.currentTarget.attributes.model_id.value
            var idComite = spa_tabs.getParam()
            var checked = event.currentTarget.checked
            event.currentTarget.checked = !event.currentTarget.checked

            if (checked) {
                app_state.EvalAddUnidadEvaluacionAComite(idComite, id_ue, (err, r) => {
                    if (err) {
                        event.currentTarget.checked = false
                        alert(err)
                    } else {
                        event.currentTarget.checked = true
                    }
                })
            } else {
                app_state.EvalRemoveUnidadEvaluacionAComite(idComite, id_ue, (err, r) => {
                    if (err) {
                        event.currentTarget.checked = true
                        alert(err)
                    } else {
                        event.currentTarget.checked = false
                    }
                })
            }
        }

        var crear_grilla_unidades = function () {

            var idComite = spa_tabs.getParam()
            var periodo = app_state.PeriodoDe(idComite)
            var comite = app_state.GetComite(idComite)
            var all_ues = app_state.GetUnidadesEvaluacion(idComite)
            var ues_periodo = _.filter(all_ues, ue => ue.IdPeriodo == periodo.Id)

            //si el comite tiene a la ue, entonces tiene que estar checked (Selected)
            _.each(ues_periodo, ue => ue.Selected = _.some(comite.UnidadesEvaluacion, cue => cue.Id == ue.Id) ? "checked" : "" )

            CreadorDeGrillas('#tabla_unidades', ues_periodo)

            $('[type=checkbox]').click(ue_clicked)
        }

        var on_scr_unidades_enter = function (idComite) {

            var periodo = app_state.PeriodoDe(idComite)
            spa_tabs.setNextParameter(idComite)

            $("#desc_periodo_ues").text(periodo.descripcion_periodo)

            crear_grilla_unidades()
        }

        //config para la Single Page App con Tabs
        var tabs_events = [{
                tab_name: '#scr_datos_generales',
                on_next: on_datos_generales_next,
                on_enter: on_datos_generales_enter
            }, {
                tab_name: '#scr_integrantes',
                on_enter: on_integrantes_enter
            }, {
                tab_name: '#scr_unidades',
                on_enter: on_scr_unidades_enter
            }]

        var load_grid_periodos = function() {
            app_state.GetDataGridPeriodos(data => {
                var comites = data.GetAllComites
                var ues = data.GetEstadosEvaluacionesPeriodosActivos
                var evals = data.GetAgentesEvaluablesParaComites
                var periodos = data.GetPeriodosEvaluacion

                var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
                CreadorDeGrillas('#tabla_periodos', agrupados)

                spa_tabs.createTabs(tabs_events)

                //activo los tooltips
                $('#tabla_periodos [data-toggle="tooltip"]').tooltip()
                $('[btnIdPeriodo]').click(set_id_periodo_seleccionado)
            })
        }

        var set_id_periodo_seleccionado = function (e) {
            $("id_periodo_seleccionado").val(e.currentTarget.attributes.btnIdPeriodo.value)
        }

        var remover_integrante = function (id_integrante, idComite) {
            app_state.DelIntegrante(id_integrante, idComite, i => {
                crear_grilla_integrantes()
            })
        }

        var agregar_integrante = function () {
            var idComite = spa_tabs.getParam()
            var persona = JSON.parse($('#persona_buscada').val())
            var caracter = $('#cmb_en_caracter_de').val()

            var integrante = {
                IdPersona: persona.IdPersona,
                Apellido: persona.Apellido,
                Nombre: persona.Nombre,
                Dni: persona.Dni,
                IdEnCaracterDe: caracter
            }

            app_state.AddIntegrante(integrante, idComite, (err) => {
                if (err) {
                    alert(err)
                    return
                }
                crear_grilla_integrantes()
            })
        }

        var setup_componentes = function () {

            $('#fecha').datepicker({
                dateFormat: "dd/mm/yy"
            })

            $('.timepicker').timepicker({
                timeFormat: 'HH:mm',
                interval: 60,
                minTime: '10',
                maxTime: '6:00pm',
                defaultTime: '11',
                startTime: '10:00',
                dynamic: false,
                dropdown: true,
                scrollbar: true
            })

            $("#btn_agregar_integrante").click(e => agregar_integrante())

            var selector_integrantes = new SelectorDePersonas({
                ui: $('#cmb_selector_integrantes'),
                repositorioDePersonas: app_state,
                placeholder: "nombre, apellido, documento o legajo"
            })

            selector_integrantes.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
                var persona = {
                    Dni: la_persona_seleccionada.documento,
                    Apellido: la_persona_seleccionada.apellido,
                    Nombre: la_persona_seleccionada.nombre,
                    IdPersona: la_persona_seleccionada.id
                }
                $("#persona_buscada").val(JSON.stringify(persona))
            }
            load_grid_periodos()
        }
        setup_componentes()
    })
})