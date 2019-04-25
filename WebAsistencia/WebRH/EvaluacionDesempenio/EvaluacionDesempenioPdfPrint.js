define(['jquery', 'eval/EvaluacionDesempenioAppState', 'jquery-ui'],
    function ($, app_state) {

        var clicked_ver_eval = function (event) {
            event.preventDefault()
            var id_evaluacion = event.currentTarget.attributes.model_id.value;
            var asignacion = app_state.GetAsignacionEvaluadoEvaluador(id_evaluacion)
            asignacion.periodo = app_state.GetPeriodo(asignacion.periodo)
            asignacion.nivel = asignacion.evaluacion.nivel

            app_state.PrintPdfEvaluacionDesempenio(asignacion, (err, rpta) => {
                if (err) {
                    alert('se produjo un error al leer la evaluacion de desempeño')
                    console.log(err)
                }
                var string = 'data:application/pdf;base64,' + rpta;
                var iframe = "<iframe width='100%' height='100%' src='" + string + "'></iframe>"
                var x = window.open()
                x.document.open()
                x.document.write(iframe)
                x.document.close()
            })
        }

        var bind = function () {
            $(".ver_eval").click(clicked_ver_eval)
        }

        return {
            BindVerEvalButtons: bind
        }

    })