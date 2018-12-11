define(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'creadorDeGrillas', 'spa-tabs', 'jquery-ui'],
    function ($, _, app_state, CreadorDeGrillas, spa_tabs) {

        var init = function (idPeriodo) {
            //alert(idPeriodo)
        }

        var resumen_integrantes = function (integrantes) {
            var big_str = _.reduce(integrantes, (str, i) => {
                return str + i.Apellido + ', ' // + i.Nombre + ' - '
            }, '')

            var max_len = 35

            big_str = big_str.substring(0, big_str.length - 2)

            if (big_str.length > max_len) {
                return big_str.substring(0, max_len-3) + '...'
            } else {
                return big_str
            }
        }

        var on_tab_enter = function (params) {
            var id_periodo = params[0]
            var periodo = app_state.GetPeriodo(id_periodo)
            var comites = app_state.GetComitesPeriodo(id_periodo)

            var rows = _.map(comites, c => {
                return {
                    Fecha: app_state.FormatDate(c.Fecha),
                    Lugar: c.Lugar,
                    Periodo: c.Periodo.descripcion_periodo,
                    Integrantes: resumen_integrantes(c.Integrantes),
                    IdComite: c.Id
                }
            })
            $("#desc_periodo").text(periodo.descripcion_periodo)
            CreadorDeGrillas("#tabla_reuniones", rows)

            spa_tabs.appendTabsTo("#tabla_reuniones")
        }

        return {
            tab_name: '#scr_reuniones_comites',
            init: init,
            on_tab_enter: on_tab_enter,
        }
    })