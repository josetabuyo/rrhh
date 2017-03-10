var spinner;
var idUsuario;

var ListadoAgentes = {
    init: function () {

    },
    getEvaluaciones: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);
        var _this = this;
        var calificacion;
        Backend.EvalGetAgentesEvaluables()
        .onSuccess(function (agentesJSON) {
            spinner.stop();
            var agentes = JSON.parse(agentesJSON);

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
                    return _this.getBotonImprimir(un_agente);
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
    getRespuestasDelForm: function (un_agente) {
        var coleccion_respuestas = []; //obtener estas opciones_elegidas desde un_agente.
        for (i = 0; i < un_agente.detalle_preguntas.length; i++) {
            coleccion_respuestas.push(un_agente.detalle_preguntas[i].respuesta_elegida);
        }
        return coleccion_respuestas;
    },
    getBotonImprimir: function (un_agente) {
        var btn_accion = $('<a>');
        var img = $('<img>');
        img.attr('src', '../Imagenes/iconos/icono-imprimir.png');
        img.attr('width', '25px');
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
    },
    imprimirFormularioEvaluacion: function (idNivel, idEvaluacion, idEvaluado) {
        var _this = this;
        var nombre = localStorage.getItem("apellido") + ', ' + localStorage.getItem("nombre");
        var descripcionNivel = localStorage.getItem("descripcionNivel");
        var leyenda = "";
        $('#div_contenido_impresion').append('<img src="../../Imagenes/EscudoMDS.png" width="150px" height="60px" alt="">');
        var d = new Date();
        Backend.GetLeyendaAnio(d.getFullYear())
        .onSuccess(function (respuesta) {
            leyenda = respuesta;
        })
        .onError(function (error, as, asd) {
            alertify.alert("", "error al obtener leyenda del año");
        });

        Backend.GetFormularioDeEvaluacion(idNivel, idEvaluacion, idEvaluado)
        .onSuccess(function (formularioJSON) {
            var form = JSON.parse(formularioJSON);
            //HTML CABECERA
            $('#div_contenido_impresion').append('<p style="float:right;font-size: x-small;font-family:ShelleyAllegro BT">' + leyenda + '</p> <p style="margin: 10px; margin-left: 150px;margin-top:50px;"><span>Agente: ' + nombre + '</span></p> <p style="margin: 10px; margin-left: 150px;">Nivel: <span>' + descripcionNivel + '</span> </p>')

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

                plantilla.find("input[type='radio']").attr('checked', false);
                plantilla.find("input[type='radio']").click(function () {
                    _this.calcularCalificacion();
                    plantilla.find("input[type='radio']").parent().removeClass('radioSeleccionado');
                    $(this).parent().addClass('radioSeleccionado');
                });

                if (value.OpcionElegida != 0) {
                    //chequear los radios elegidos
                    //var radios = plantilla.find('.input_form').data('opcion')
                    var radio = plantilla.find('[data-opcion=' + value.OpcionElegida + ']');
                    radio.attr('checked', true);
                    radio.parent().addClass('radioSeleccionado');

                }

                $('#contenedor').append(plantilla);
            });

            var idPersona = localStorage.getItem("idEvaluado");

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

                /*var cajas = $(".plantilla_form");//
                //if (estado != 0) {
                    $.each(cajas, function (key, value) {
                        var radios = value.find(".input_form:checked");
                        if (radios.length > 0) {
                            alert('tildado');
                            return;
                        }
                        else {
                            alert('no se tildaron todos');
                            return; ;
                        }
                     });*/
                // }

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
    }
}
