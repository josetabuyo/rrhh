var spinner;
var idUsuario;

function calificacion(coleccion_opciones_elegidas, deficiente, regular, bueno, destacado, completando_formulario) {
    
    coleccion_opciones_elegidas = [2, 1, 3];
    var puntaje = 0;
    var alguna_incompleta = false;
    var alguna_respondida = false;
    
    for (i = 0; i < coleccion_opciones_elegidas.length; i++) {
        puntaje += coleccion_opciones_elegidas[i];
        if (coleccion_opciones_elegidas[i] == 0) {
            alguna_incompleta = true;
        } else {
            alguna_respondida = true;
        }
    }

    if (!completando_formulario) {
        if (alguna_incompleta && alguna_respondida) {
            return "Evaluacion Incompleta";
        }

        if (alguna_incompleta) {
            return "A Evaluar";
        }
    }

    if (puntaje > destacado) {
        return "Muy Destacado";
    }
    if (puntaje > bueno) {
        return "Destacado";
    }
    if (puntaje > regular) {
        return "Bueno";
    }
    if (puntaje > deficiente) {
        return "Regular";
    }

    return "Deficiente";
};

    var ListadoAgentes = {
        init: function () {

        },
        getEstudios: function () {
            var spinner = new Spinner({ scale: 2 });
            spinner.spin($("html")[0]);

            Backend.EvalGetAgentesEvaluables()
        .onSuccess(function (agentesJSON) {
            spinner.stop();
            var agentes = JSON.parse(agentesJSON);
            var _this = this;
            $("#tablaAgentes").empty();
            var divGrilla = $("#tablaAgentes");

            var columnas = [];

            columnas.push(new Columna("Dni", { generar: function (un_agente) { return un_agente.nro_documento } }));
            columnas.push(new Columna("Apellido", { generar: function (un_agente) { return un_agente.apellido } }));
            columnas.push(new Columna("Nombre", { generar: function (un_agente) { return un_agente.nombre } }));
            columnas.push(new Columna("Evaluacion", { generar: function (un_agente) {

                var coleccion_respuestas = []; //obtener estas opciones_elegidas desde un_agente.
                for (i = 0; i < un_agente.detalle_preguntas.length; i++) {
                    coleccion_respuestas.push(un_agente.detalle_preguntas[i].respuesta_elegida);
                }

                return calificacion(coleccion_respuestas, un_agente.deficiente, un_agente.regular, un_agente.bueno, un_agente.destacado, false);
            }
            }));
            columnas.push(new Columna('Accion', {
                generar: function (un_agente) {
                    var btn_accion = $('<a>');
                    var img = $('<img>');
                    img.attr('src', '../Imagenes/detalle.png');
                    img.attr('width', '15px');
                    img.attr('height', '15px');
                    btn_accion.append(img);
                    btn_accion.click(function () {
                        localStorage.setItem("idPeriodo", un_agente.id_periodo);
                        localStorage.setItem("idEvaluado", un_agente.id_evaluado);
                        localStorage.setItem("idEvaluacion", un_agente.id_evaluacion);
                        localStorage.setItem("apellido", un_agente.apellido);
                        localStorage.setItem("nombre", un_agente.nombre);
                        localStorage.setItem("apellido", un_agente.apellido);
                        localStorage.setItem("descripcionPeriodo", un_agente.descripcion_periodo);
                        localStorage.setItem("descripcionNivel", un_agente.descripcion_nivel);
                        localStorage.setItem("deficiente", un_agente.deficiente);
                        localStorage.setItem("regular", un_agente.regular);
                        localStorage.setItem("bueno", un_agente.bueno);
                        localStorage.setItem("destacado", un_agente.destacado);
                        /*si nunca fue evaluado, no sabemos que nivel tiene, 
                        hay que pedir al usuario que lo ingrese*/
                        if (un_agente.id_nivel == "0") {
                            vex.defaultOptions.className = 'vex-theme-os';
                            vex.open({
                                afterOpen: function ($vexContent) {
                                    var ui = $("#div_niveles").clone();
                                    $vexContent.append(ui);
                                    ui.find("#btn_nivel").click(function () {
                                        localStorage.setItem("idNivel", ui.find("#select_niveles").val());
                                        window.location.href = 'FormularioEvaluacion.aspx';
                                    });
                                    ui.show();
                                    return ui;
                                },
                                css: {
                                    'padding-top': "4%",
                                    'padding-bottom': "0%"
                                }
                            });
                        } else {
                            window.location.href = 'FormularioEvaluacion.aspx';
                        }
                    });
                    return btn_accion;
                }
            }));

            _this.Grilla = new Grilla(columnas);
            _this.Grilla.SetOnRowClickEventHandler(function (un_agente) { });
            _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
            _this.Grilla.CargarObjetos(agentes);
            _this.Grilla.DibujarEn(divGrilla);
            $('.table-hover').removeClass("table-hover");

        })
        .onError(function (e) {
            spinner.stop();
        });
        },
        getFormularioDeEvaluacion: function (idNivel, idEvaluacion, idEvaluado) {
            var spinner = new Spinner({ scale: 2 });
            spinner.spin($("html")[0]);

            var nombre = localStorage.getItem("apellido") + ', ' + localStorage.getItem("nombre");
            var descripcionNivel = localStorage.getItem("descripcionNivel");

            $('#nivel').html(descripcionNivel);
            $('#nombre_evaluado').html(nombre);

            Backend.GetFormularioDeEvaluacion(idNivel, idEvaluacion, idEvaluado)
        .onSuccess(function (formularioJSON) {
            spinner.stop();
            var form = JSON.parse(formularioJSON);

            $.each(form, function (key, value) {
                //alert(key + ": " + value);

                var plantilla = $('#plantilla').clone();
                plantilla.show();

                plantilla.find(".pregunta").text(value.Enunciado);
                plantilla.find(".pregunta").attr('data-identificador', value.idPregunta);
                plantilla.find(".rta1").text(value.Rta1);
                plantilla.find(".rta2").text(value.Rta2);
                plantilla.find(".rta3").text(value.Rta3);
                plantilla.find(".rta4").text(value.Rta4);
                plantilla.find(".rta5").text(value.Rta5);

                plantilla.find(".input_form").attr('name', value.idPregunta);


                if (value.OpcionElegida != 0) {
                    //chequear los radios elegidos
                    //var radios = plantilla.find('.input_form').data('opcion')
                    plantilla.find('[data-opcion=' + value.OpcionElegida + ']').attr('checked', true);
                }

                $('#contenedor').append(plantilla);
            });

            $('.btnGuardar').click(function () {
                var idNivel = localStorage.getItem("idNivel");
                var periodo = localStorage.getItem("idPeriodo");
                var idEvaluado = localStorage.getItem("idEvaluado");
                var evaluacion = localStorage.getItem("idEvaluacion");
                var estado = $(this).data("estado");

                // var plantillas = $('.plantilla');
                var radioButtonsChecked = $('.input_form:checked');
                var pregYRtas = [];

                $.each(radioButtonsChecked, function (key, value) {

                    pregYRtas.push(
                                { idPregunta: parseInt(value.parentElement.parentElement.previousElementSibling.dataset.identificador),
                                    idRespuesta: parseInt(value.dataset.opcion)
                                }
                            );
                });

                var jsonPregYRtas = JSON.stringify(pregYRtas);

                //cambiar el 2do idEvaluado por idEvaluador
                Backend.InsertarEvaluacion(idEvaluado, idNivel, periodo, evaluacion, jsonPregYRtas, estado)
                    .onSuccess(function (rto) {
                        spinner.stop();
                        alert('Se ha guardado con exito!');
                        //var form = JSON.parse(formularioJSON);
                    })
                .onError(function (e) {
                    spinner.stop();
                });
            });

        })
        .onError(function (e) {
            spinner.stop();
        });
        }
    }
