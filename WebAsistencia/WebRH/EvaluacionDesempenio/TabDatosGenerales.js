define(['jquery', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'jquery-ui'], function ($, app_state, spa_tabs) {

    //cuando se hace click en "siguiente" (datos generales)
    var on_next = function (show_next_tab, params) {
        //params['IdPeriodo']<--todo, varios parametros con nombre

        app_state.AddComite($("#descripcion").val(),
            $("#fecha").val(),
            $("#hora").val(),
            $("#lugar").val(),
            $("#id_periodo_seleccionado").val(),
            (err, comite_agregado) => {
                if (err) {
                    alert('Error al agregar comite')
                    console.log(err)
                } else {
                    show_next_tab(comite_agregado.Id)
                    app_state.StateChanged()
                    //load_grid_periodos()
                }
            })
    }

    //cuando se muestra la pantalla de datos generales
    var on_tab_enter = function () {

        var id_comite = spa_tabs.getParam()
        if (id_comite) {
            var comite = app_state.GetComite(id_comite)
            var fh_formateada = app_state.FormatDate(comite.Fecha)
            var periodo = comite.Periodo

            $("#fecha").val(fh_formateada)
            $("#hora").val(comite.Hora)
            $("#lugar").val(comite.Lugar)
            $("#descripcion").val(comite.Descripcion)
            $("#id_periodo_seleccionado").val(periodo.id_periodo)
            $("#desc_periodo").text(periodo.descripcion_periodo)

        } else {
            var id_periodo = $("#id_periodo_seleccionado").val()
            if (id_periodo == "") {
                alert("Debe seleccionar un período")
                spa_tabs.goHome()
                return
            }
            $("#desc_periodo").text(app_state.GetPeriodo(id_periodo).descripcion_periodo)
        }
    }

    var form_validations = function () {
        return {
            rules: {
                fecha: {
                    dateITA: true
                }
            },
            messages: {
                fecha: {
                    required: 'Debe especificar la fecha de reunión',
                    dateITA: 'El formato de la fecha debe ser dd/mm/aaaa',
                },
                hora: {
                    minlength: 'La hora debe tener el formato hh:mm (eg: 18:30)',
                    maxlength: 'La hora debe tener el formato hh:mm (eg: 18:30)'
                },
                lugar: {
                    required: 'Debe especificar un lugar',
                    minlength: 'El lugar debe contener al menos {0} caracteres'
                },
                descripcion: {
                    required: 'Debe especificar una descripción',
                    minlength: 'La descripción es muy corta'
                }
            },
            submitHandler: function (form, event) {
                spa_tabs.formSubmitted(event)
            }
        }
    }

    var setup_componentes = function () {

        $('#fecha').datepicker({
            dateFormat: "dd/mm/yy",
            yearRange: '2015:2040',
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

        $("#frm_datos_generales").validate(form_validations())
    }

    return {
        tab_name: '#scr_datos_generales',
        init: setup_componentes,
        on_tab_enter: on_tab_enter,
        on_next: on_next
    }
});