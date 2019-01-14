define(['eval/EvaluacionDesempenioAppState', 'creadorDeGrillas', 'eval/ComitesPorPeriodo', 'eval/EvaluacionDesempenioPdfPrint', 'spa-tabs'],
    function (app_state, CreadorDeGrillas, ComitesPorPeriodo, pdf_printer, spa_tabs) {

        var on_tab_enter = function (idComite) {
            var comite = app_state.GetComite(idComite)
            var ues = comite.UnidadesEvaluacion

            var result = ComitesPorPeriodo.AgruparUnidadesEvaluacion(ues)
            CreadorDeGrillas('#tabla_resumen', result)

            dibujar_tabla_evaluaciones()

            app_state.OnStateChange(dibujar_tabla_evaluaciones)
            $('#btn_aprobar_evaluacion').click(aprobar_evaluacion)
        }

        var dibujar_tabla_evaluaciones = function () {
            var idComite = spa_tabs.getParams()
            var comite = app_state.GetComite(idComite)
            var ues = comite.UnidadesEvaluacion

            var evals = app_state.GetEvaluacionesUes(ues)

            var grid_rows = _.map(evals, e => {
                return {
                    Dni: e.dni_agente_evaluado,
                    Apellido: e.apellido_agente_evaluado,
                    Nombre: e.nombre_agente_evaluado,
                    Area: e.area,
                    Evaluacion: e.evaluacion.calificacion,
                    GDE: e.evaluacion.codigo_gde,
                    IdEvaluacion: e.evaluacion.id_evaluacion,
                    Accion: 'Acc',
                    AunNoAprobado: e.evaluacion.aprobacion_comite.IdComiteAprobador == 0
                }
            })
            grid_rows = _.chain(grid_rows).sortBy('Nombre').sortBy('Apellido').value()


            CreadorDeGrillas('#tabla_evaluaciones', grid_rows)

            $('[opcion_disponible="false"]').hide()
            $('[opcion_disponible]').click(event => event.preventDefault())
            $('.aprobador_evaluacion').click(show_popup_aprobar_evaluacion)
            $('.modificar_evaluacion').click(Reevaluar)
            
            pdf_printer.BindVerEvalButtons()
        }


        var Reevaluar = function (event) {
            var eval_id = $(event.currentTarget).attr('model_id')
            app_state.GetAsignacionEvaluacionCompleta(eval_id, setAgenteValuesToLocalStorage)
        }

        //se utiliza para llamar al formulario
        //codigo duplicado (en caso de modificar, modificar también en ListadoAgentes.js)
        var setAgenteValuesToLocalStorage = function (err, respuesta) {

            if (err) {
                alert('Se produjo un error, contacte al administrador del sistema')
                console.log(err)
            }

            var asignacion_evaluado_a_evaluador = respuesta.asignaciones[0]

            localStorage.setItem("id_agente_evaluador", asignacion_evaluado_a_evaluador.agente_evaluador.id)
            localStorage.setItem("idPeriodo", asignacion_evaluado_a_evaluador.id_periodo);
            localStorage.setItem("idEvaluado", asignacion_evaluado_a_evaluador.id_evaluado);
            localStorage.setItem("idEvaluacion", asignacion_evaluado_a_evaluador.id_evaluacion);
            localStorage.setItem("apellido", asignacion_evaluado_a_evaluador.apellido_evaluado);
            localStorage.setItem("nombre", asignacion_evaluado_a_evaluador.nombre_evaluado);
            localStorage.setItem("descripcionPeriodo", asignacion_evaluado_a_evaluador.descripcion_periodo);
            localStorage.setItem("idNivel", asignacion_evaluado_a_evaluador.id_nivel);
            localStorage.setItem("descripcionNivel", asignacion_evaluado_a_evaluador.descripcion_corta_nivel);
            localStorage.setItem("deficiente", asignacion_evaluado_a_evaluador.nivel.deficiente);
            localStorage.setItem("regular", asignacion_evaluado_a_evaluador.nivel.regular);
            localStorage.setItem("bueno", asignacion_evaluado_a_evaluador.nivel.bueno);
            localStorage.setItem("destacado", asignacion_evaluado_a_evaluador.nivel.destacado);
            localStorage.setItem("id_doc_electronico", asignacion_evaluado_a_evaluador.evaluacion.id_doc_electronico);

            window.open('FormularioEvaluacion.aspx', '_blank');
        }

        var aprobar_evaluacion = function (event) {
            var id_eval_a_aprobar = $(event.currentTarget).siblings('#id_evaluacion_a_aprobar').val()
            var id_comite = spa_tabs.getParams()
            app_state.AprobarEvaluacion(id_eval_a_aprobar, id_comite, (err, result) => {
                $('#AprobarEvaluacionModal').modal('hide')
                if (err) {
                    alert(r)
                } else {
                    if (result.DioError) {
                        alert(result.MensajeDeErrorAmigable)
                        console.log(result)
                    } else {
                        app_state.StateChanged()
                    }
                }
            })
        }

        var show_popup_aprobar_evaluacion = function (event) {
            var ventana_modal = $('#AprobarEvaluacionModal')
            id_evaluacion = $(event.currentTarget).attr('model_id')
            var asig = app_state.GetAsignacionEvaluadoEvaluador(id_evaluacion)
            ventana_modal.find('#span_evaluado_a_aprobar').text(asig.apellido_agente_evaluado + ', ' + asig.nombre_agente_evaluado)
            ventana_modal.find('#id_evaluacion_a_aprobar').val(id_evaluacion)
            ventana_modal.modal('show')
        }

        var setup_componentes = function () {
            //cargar combo de tipos de evaluacion
        }

        return {
            tab_name: '#scr_evaluaciones',
            on_tab_enter: on_tab_enter,
            init: setup_componentes
        }
    })