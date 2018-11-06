define(['jquery', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'jquery-ui'], function ($, app_state, spa_tabs, CreadorDeGrillas) {
    var checkbox_ue_clicked = function (event) {

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
                    calcular_totales_ue()
                }
            })
        } else {
            app_state.EvalRemoveUnidadEvaluacionAComite(idComite, id_ue, (err, r) => {
                if (err) {
                    event.currentTarget.checked = true
                    alert(err)
                } else {
                    event.currentTarget.checked = false
                    calcular_totales_ue()
                }
            })
        }
    }

    var intFromTableCell = function (row, index) {
        return parseInt(row.children[index].innerText)
    }

    var calcular_totales_ue = function () {
        var selected_rows = $("#tabla_unidades input:checked").closest("tr")

        var destacados = 0
        var bueno = 0
        var regular = 0
        var deficiente = 0
        var provisoria = 0
        var pendiente = 0

        _.each(selected_rows, row => {
            destacados += intFromTableCell(row, 2)
            bueno += intFromTableCell(row, 3)
            regular += intFromTableCell(row, 4)
            deficiente += intFromTableCell(row, 5)
            provisoria += intFromTableCell(row, 7)
            pendiente += intFromTableCell(row, 8)
        })

        var totalEvaluados = destacados + bueno + regular + deficiente
        var totalGeneral = totalEvaluados + provisoria + pendiente

        construir_ue_footer(destacados, bueno, regular, deficiente, provisoria, pendiente, totalEvaluados, totalGeneral, selected_rows.length)
    }

    var construir_ue_footer = function (destacados, bueno, regular, deficiente, provisoria, pendiente, totalEvaluados, totalGeneral, cont) {
        $(".totalizador").remove()
        var tr = $('<tr class="totalizador bg-info text-white"><td colspan="2">Total para las UE Seleccionadas:</td><td>' + destacados + '</td><td>' + bueno + '</td><td>' + regular + '</td><td>' + deficiente + '</td><td>' + totalEvaluados + '</td><td>' + provisoria + '</td><td>' + pendiente + '</td><td>' + totalGeneral + '</td><td>' + cont + '</td>')
        tr.children().addClass('text-right')
        $("#tabla_unidades > tbody").append(tr)

    }

    var crear_grilla_unidades = function () {

        var idComite = spa_tabs.getParam()
        var periodo = app_state.PeriodoDe(idComite)
        var comite = app_state.GetComite(idComite)
        var all_ues = app_state.GetUnidadesEvaluacion(idComite)
        var ues_periodo = _.filter(all_ues, ue => ue.IdPeriodo == periodo.Id)

        //si el comite tiene a la ue, entonces tiene que estar checked (Selected)
        _.each(ues_periodo, ue => {
            ue.Selected = _.some(comite.UnidadesEvaluacion, cue => cue.Id == ue.Id) ? "checked" : ""
            $.extend(ue, ue.DetalleEvaluados) //flatten
            ue.TotalEvaluados = ue.Destacados + ue.Bueno + ue.Regular + ue.Deficiente
            ue.TotalGeneral = ue.TotalEvaluados + ue.Provisoria + ue.Pendiente
        })

        CreadorDeGrillas('#tabla_unidades', ues_periodo)

        $('[type=checkbox]').click(checkbox_ue_clicked)
    }

    var on_tab_enter = function (idComite) {

        var periodo = app_state.PeriodoDe(idComite)
        spa_tabs.setNextParameter(idComite)

        $("#desc_periodo_ues").text(periodo.descripcion_periodo)

        crear_grilla_unidades()
    }

    var setup_componentes = function () {

    }

    return {
        init: setup_componentes,
        on_tab_enter: on_tab_enter,
        //on_next: on_next
    }
})