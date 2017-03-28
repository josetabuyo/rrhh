var spinner;
var idUsuario;
var todas_las_evaluaciones;
var ListadoAgentes = {
    init: function () {

    },
    getEvaluaciones: function () {
        var _this = this;
        $("#id_estado").change(function () {
            _this.FiltrarPorEstado(parseInt($(this).val()));
        });

        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        var calificacion;
        Backend.EvalGetAgentesEvaluables()
        .onSuccess(function (agentesJSON) {
            spinner.stop();
            var agentes = JSON.parse(agentesJSON);
            todas_las_evaluaciones = agentes;
            _this.DibujarTabla(agentes);

        })
        .onError(function (e) {
            spinner.stop();
        });

        var d = new Date();
        Backend.GetLeyendaAnio(d.getFullYear())
        .onSuccess(function (respuesta) {
            localStorage.setItem("leyenda", respuesta);
        })
        .onError(function (error, as, asd) {
            localStorage.setItem("leyenda", "");
        });
    },
    DibujarTabla: function (agentes) {
        var _this = this;
        $("#tablaAgentes").empty();
        var divGrilla = $("#tablaAgentes");
        var columnas = [];
        columnas.push(new Columna("Dni", { generar: function (un_agente) { return un_agente.nro_documento } }));
        columnas.push(new Columna("Apellido", { generar: function (un_agente) { return un_agente.apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_agente) { return un_agente.nombre } }));
        columnas.push(new Columna("Evaluacion", { generar: function (un_agente) {
            var coleccion_respuestas = _this.getRespuestasDelForm(un_agente);
            return _this.calificacion(coleccion_respuestas, un_agente.deficiente, un_agente.regular, un_agente.bueno, un_agente.destacado, false);
        }
        }));
        columnas.push(new Columna('Accion', {
            generar: function (un_agente) {
                var coleccion_respuestas = _this.getRespuestasDelForm(un_agente);
                var calificacion = _this.calificacion(coleccion_respuestas, un_agente.deficiente, un_agente.regular, un_agente.bueno, un_agente.destacado, false);
                if (calificacion == 'A Evaluar' || calificacion == 'Evaluacion Incompleta') {
                    return _this.getBotonIrAFormulario(un_agente);
                }
                if (un_agente.estado == 1) {
                    return _this.getBotonImprimir(un_agente);
                }
                return _this.getDosBotones(un_agente);
            }
        }));

        _this.Grilla = new Grilla(columnas);
        _this.Grilla.SetOnRowClickEventHandler(function (un_agente) { });
        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
        _this.Grilla.CargarObjetos(agentes);
        _this.Grilla.DibujarEn(divGrilla);
        $('.table-hover').removeClass("table-hover");
        _this.BuscadorDeTabla();
    },
    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['Dni', 'Apellido', 'Nombre']
        };

        var featureList = new List('contenedorTabla', options);
    },
    FiltrarPorEstado: function (estado) {
        var _this = this;
        var clave = "";
        _this.DibujarTabla(todas_las_evaluaciones);
        switch (estado) {
            case 0:
                clave = ""
                break;
            case 1:
                clave = "Evaluacion Incompleta"
                break;
            case 2:
                clave = "A Evaluar"
                break;
            case 3:
                clave = "Muy Destacado"
                break;
            case 4:
                clave = "Destacado"
                break;
            case 5:
                clave = "Bueno"
                break;
            case 6:
                clave = "Regular"
                break;
            case 7:
                clave = "Deficiente"
                break;
        }
        if (clave != "") {
            _this.FiltrarRegistros($("#tablaAgentes tbody tr"), clave);
        }

    },

    FiltrarRegistros: function (registro, clave) {
        registro.find("td[class=Evaluacion]").each(function () {
            if ($(this).text() != clave) {
                $(this).parent().remove();
            };
        })
    },

    getRespuestasDelForm: function (un_agente) {
        return coleccion_respuestas = this.getRespuestasDesdeLasPreguntas(un_agente.detalle_preguntas);
    },
    getRespuestasDesdeLasPreguntas: function (preguntas) {
        var coleccion_respuestas = []; //obtener estas opciones_elegidas desde un_agente.
        for (i = 0; i < preguntas.length; i++) {
            coleccion_respuestas.push(preguntas[i].OpcionElegida);
        }
        return coleccion_respuestas;
    },
    getBotonImprimir: function (un_agente) {
        var btn_accion = $('<a>');
        var img = $('<img>');
        img.attr('src', '../Imagenes/iconos/icono-imprimir.png');
        img.attr('width', '25px');
        img.attr('data-toggle', 'tooltip');
        img.attr('title', 'Impresora');
        img.attr('height', '25px');
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
                            window.open('ImpresionEvaluacion.html', '_blank');

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
                window.open('ImpresionEvaluacion.html', '_blank');
            }
        });
        return btn_accion;
    },
    getBotonIrAFormulario: function (un_agente) {
        var btn_accion = $('<a>');
        var img = $('<img>');
        img.attr('src', '../Imagenes/portal/estudios.png');
        img.attr('width', '25px');
        img.attr('data-toggle', 'tooltip');
        img.attr('title', 'Impresora');s
        img.attr('height', '25px');
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
                            var nivel = ui.find("#select_niveles").val()
                            localStorage.setItem("idNivel", nivel);
                            Backend.EvalGetNivelesFormulario(nivel)
                            .onSuccess(function (rpta) {
                                var respuesta = JSON.parse(rpta);
                                localStorage.setItem("idNivel", nivel);
                                localStorage.setItem("descripcionNivel", respuesta.descripcion_nivel);
                                localStorage.setItem("deficiente", respuesta.deficiente);
                                localStorage.setItem("regular", respuesta.regular);
                                localStorage.setItem("bueno", respuesta.bueno);
                                localStorage.setItem("destacado", respuesta.destacado);
                                window.location.href = 'FormularioEvaluacion.aspx';
                            });
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
    },
    getDosBotones: function (un_agente) {
        var boton_imprimir = this.getBotonImprimir(un_agente);
        var boton_ir_a_form = this.getBotonIrAFormulario(un_agente);
        var div = $('<div>');
        div.append(boton_ir_a_form);
        div.append(boton_imprimir);
        return div;
    },
    imprimirFormularioEvaluacion: function (idNivel, idEvaluacion, idEvaluado) {
        var _this = this;
        var leyenda = localStorage.getItem("leyenda")
        var nombre = localStorage.getItem("apellido") + ', ' + localStorage.getItem("nombre");
        var descripcionNivel = localStorage.getItem("descripcionNivel");

        $('#div_contenido_impresion').append('<img src="../../Imagenes/EscudoMDS.png" width="150px" height="60px" alt="">');
        Backend.GetFormularioDeEvaluacion(idNivel, idEvaluacion, idEvaluado)
        .onSuccess(function (formularioJSON) {
            var form = JSON.parse(formularioJSON);
            //HTML CABECERA
            var respuestas = _this.getRespuestasDesdeLasPreguntas(form);
            var calificacion = _this.calificacion(respuestas, localStorage.getItem("deficiente"), localStorage.getItem("regular"), localStorage.getItem("bueno"), localStorage.getItem("destacado"), false);

            $('#div_contenido_impresion').append('<p style="float:right;font-size: x-small;font-family:ShelleyAllegro BT">' + leyenda + '</p> <p style="margin: 10px; margin-left: 150px;margin-top:50px;"><span>Agente: ' + nombre + '</span></p> <p style="margin: 10px; margin-left: 150px;">Nivel: <span>' + descripcionNivel + '</span> </p>')
            $('#div_contenido_impresion').append('<div id="der" class="" style="width:20%; float:right; border:1px solid; text-align:center; margin-top: -125px;;"><h2>Puntaje</h2><h2 id="puntaje">' + calificacion + '</h2></div>');
            //_this.calcularCalificacion();

            $.each(form, function (key, value) {
                var respuesta = "";
                switch (value.OpcionElegida) {
                    case 1:
                        respuesta = value.Rta1;
                        break;
                    case 2:
                        respuesta = value.Rta2;
                        break;
                    case 3:
                        respuesta = value.Rta3;
                        break;
                    case 4:
                        respuesta = value.Rta4;
                        break;
                    case 5:
                        respuesta = value.Rta5;
                        break;
                    default:
                        respuesta = 'No se ha podido encontrar la respuesta correspondiente.';
                }

                //HTML DETALLE
                $('#div_contenido_impresion').append('<h3>' + value.Enunciado + '</h3><p style="margin-left:15px;">' + respuesta + '</p>');

            });
            var divToPrint = document.getElementById('div_contenido_impresion');
            var newWin = window.open('', 'Print-Window');
            newWin.document.write('<html><head></head><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
            newWin.document.close();

        })
        .onError(function (e) {
            spinner.stop();
        });


    },

    getFormularioDeEvaluacion: function (idNivel, idEvaluacion, idEvaluado) {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        var _this = this;

        var nombre = localStorage.getItem("apellido") + ', ' + localStorage.getItem("nombre");
        var descripcionNivel = localStorage.getItem("descripcionNivel");

        $('#nivel').html(descripcionNivel);
        $('#nombre_evaluado').html(nombre);

        Backend.GetFormularioDeEvaluacion(idNivel, idEvaluacion, idEvaluado)
        .onSuccess(function (formularioJSON) {
            spinner.stop();
            var form = JSON.parse(formularioJSON);
            var respuestas = _this.getRespuestasDesdeLasPreguntas(form);
            var calificacion = _this.calificacion(respuestas, localStorage.getItem("deficiente"), localStorage.getItem("regular"), localStorage.getItem("bueno"), localStorage.getItem("destacado"), true);
            $("#puntaje").text(calificacion);
            $.each(form, function (key, value) {
                var plantilla = $('#plantilla').clone();
                var radioButtons = plantilla.find(".input_form");
                var idPregunta = value.idPregunta;
                var pregunta = plantilla.find(".pregunta");
                var radioButton = plantilla.find("input[type='radio']");

                plantilla.show();

                pregunta.text(value.Enunciado);
                pregunta.attr('data-identificador', value.idPregunta);
                pregunta.addClass('pregunta-pendiente');
                plantilla.find(".rta1").text(value.Rta1);
                plantilla.find(".rta2").text(value.Rta2);
                plantilla.find(".rta3").text(value.Rta3);
                plantilla.find(".rta4").text(value.Rta4);
                plantilla.find(".rta5").text(value.Rta5);

                radioButtons.attr('name', value.idPregunta);

                // Genera dinámicamente un id para cada radio button y su respectiva label
                $.each(radioButtons, function (key, value) {
                    var input = $(value);
                    var inputId = idPregunta + '_' + key;
                    input.attr('id', inputId);
                    input.next('label').attr('for', inputId);

                    input.on('click', _this.verificarPreguntaPendiente);
                    input.on('click', _this.habilitarBotonGuardarDefinitivo);
                });

                radioButton.attr('checked', false);
                radioButton.click(function () {
                    _this.calcularCalificacion();
                    radioButton.parent().removeClass('radioSeleccionado');
                    $(this).parent().addClass('radioSeleccionado');
                });

                if (value.OpcionElegida != 0) {
                    //chequear los radios elegidos
                    var radio = plantilla.find('[data-opcion=' + value.OpcionElegida + ']');
                    radio.attr('checked', true);
                    radio.parent().addClass('radioSeleccionado');
                    // Pregunta respondida, elimina marca '(*)' de pendiente
                    _this.verificarPreguntaPendiente.call(radio);
                }



                $('#contenedor').append(plantilla);
            });


            var idPersona = localStorage.getItem("idEvaluado");
            _this.habilitarBotonGuardarDefinitivo();

            Backend.GetUsuarioPorIdPersona(idPersona)
                    .onSuccess(function (usuario) {
                        if (usuario.Id != 0) {
                            if (usuario.Owner.IdImagen >= 0) {
                                var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario") });
                                $("#foto_usuario").show();
                                $("#foto_usuario_generica").hide();
                            }
                            else {
                                $("#foto_usuario").hide();
                                $("#foto_usuario_generica").show();
                            }
                        } else {
                            $("#foto_usuario").hide();
                            $("#foto_usuario_generica").show();
                        }
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

                Backend.InsertarEvaluacion(idEvaluado, idNivel, periodo, evaluacion, jsonPregYRtas, estado)
                    .onSuccess(function (rto) {
                        spinner.stop();
                        alert('Se ha guardado con exito!');
                        window.location.href = "ListadoAgentes.aspx";
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
    },
    calificacion: function (coleccion_opciones_elegidas, deficiente, regular, bueno, destacado, completando_formulario) {
        //coleccion_opciones_elegidas = [2, 1, 3];
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

    },
    calcularCalificacion: function () {
        var radioButtonsChecked = $('.input_form:checked');
        var respuestas = [];
        var _this = this;

        $.each(radioButtonsChecked, function (key, value) {

            respuestas.push(parseInt(value.dataset.opcion));
        });

        //var respuestas = [1, 2, 3];
        var puntaje = _this.calificacion(respuestas, localStorage.getItem("deficiente"), localStorage.getItem("regular"), localStorage.getItem("bueno"), localStorage.getItem("destacado"), true);

        $('#puntaje').html(puntaje);
    },
    verificarPreguntaPendiente: function () {
        var pregunta = $(this).parents('#plantilla').find('.pregunta');
        if (pregunta.hasClass('pregunta-pendiente')) {
            pregunta.removeClass('pregunta-pendiente');
        }
    },
    habilitarBotonGuardarDefinitivo: function () {
        var preguntas = $('.pregunta');
        var totalPreguntasPendientes = 0;
        var totalPreguntas = preguntas.length - 1; // Se resta 1 porque hay una plantilla oculta con la clase pregunta
        var btnGuardarDefinitivo = $('#btnGuardarDefinitivo');
        var elementoTotalPreguntasPendientes = $('.total-preguntas-pendiente');

        $.each(preguntas, function (key, value) {
            var $value = $(value);
            if ($value.hasClass('pregunta-pendiente')) {
                totalPreguntasPendientes++;
            }
        });

        elementoTotalPreguntasPendientes.text(" (" + totalPreguntasPendientes + " de " + totalPreguntas + ") ");

        if (totalPreguntasPendientes === 0) {
            btnGuardarDefinitivo.prop('disabled', false);
        } else {
            btnGuardarDefinitivo.prop('disabled', true);
        }
    }
}
