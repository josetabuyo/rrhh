define(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'selector-personas', 'jquery-ui'], function ($, _, app_state, spa_tabs, CreadorDeGrillas, SelectorDePersonas) {

    var on_tab_enter = function (idComite) {

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

    var remover_integrante = function (id_integrante, idComite) {
        app_state.DelIntegrante(id_integrante, idComite, i => {
            crear_grilla_integrantes()
        })
    }


    var setup_componentes = function () {

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
    }

    return {
        init: setup_componentes,
        on_tab_enter: on_tab_enter
    }
})