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
        .onSuccess(function (agentes) {
            spinner.stop();

            if (!agentes[0].hasOwnProperty('agente_evaluado')) return;
            todas_las_evaluaciones = agentes;
            _this.DibujarTabla(agentes);

            // Habilita filtros si hay uno o más agentes
            if (agentes.length) { // 0 == false
                var $barraBuscador = $("#Text1");
                $barraBuscador.attr("disabled", false);
                $("#id_estado").attr("disabled", false);

                $barraBuscador.keypress(function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                    }
                });
            }
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
    DibujarTabla: function (evaluacion) {
        var _this = this;
        $("#tablaAgentes").empty();
        var divGrilla = $("#tablaAgentes");
        var columnas = [];
        columnas.push(new Columna("Dni", { generar: function (evaluacion) { return evaluacion.agente_evaluado.nro_documento } }));
        columnas.push(new Columna("Apellido", { generar: function (evaluacion) { return evaluacion.agente_evaluado.apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (evaluacion) { return evaluacion.agente_evaluado.nombre } }));
        columnas.push(new Columna("Evaluacion", { generar: function (evaluacion) {
            var coleccion_respuestas = _this.getRespuestasDelForm(evaluacion);
            return _this.calificacion(coleccion_respuestas, evaluacion.nivel.deficiente, evaluacion.nivel.regular, evaluacion.nivel.bueno, evaluacion.nivel.destacado, false);
        }
        }));
        columnas.push(new Columna('Accion', {
            generar: function (evaluacion) {
                if (!_this.PuedeImprimir(evaluacion)) {
                    return _this.getBotonIrAFormulario(evaluacion);
                }
                if (evaluacion.estado == 1) {
                    return _this.getBotonImprimir(evaluacion);
                }
                return _this.getDosBotones(evaluacion);
            }
        }));
        columnas.push(new Columna("GDE", { generar: function (evaluacion) {
            if (evaluacion.codigo_gde == '' && _this.PuedeImprimir(evaluacion)) {
                return _this.getLinkCargarGDE(evaluacion.id_evaluacion);
            }
            return evaluacion.codigo_gde;
        }
        }));
        _this.Grilla = new Grilla(columnas);
        _this.Grilla.SetOnRowClickEventHandler(function (evaluacion) { });
        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
        _this.Grilla.CargarObjetos(evaluacion);
        _this.Grilla.DibujarEn(divGrilla);
        $('.table-hover').removeClass("table-hover");
        _this.BuscadorDeTabla();
    },
    PuedeImprimir: function (evaluacion) {
        var coleccion_respuestas = this.getRespuestasDelForm(evaluacion);
        var calificacion = this.calificacion(coleccion_respuestas, evaluacion.nivel.deficiente, evaluacion.nivel.regular, evaluacion.nivel.bueno, evaluacion.nivel.destacado, false);
        return !(calificacion == 'A Evaluar' || calificacion == 'Evaluacion Incompleta');
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

    getRespuestasDelForm: function (evaluacion) {
        return coleccion_respuestas = this.getRespuestasDesdeLasPreguntas(evaluacion.detalle_preguntas);
    },
    getRespuestasDesdeLasPreguntas: function (preguntas) {
        var coleccion_respuestas = []; //obtener estas opciones_elegidas desde un_agente.
        for (i = 0; i < preguntas.length; i++) {
            coleccion_respuestas.push(preguntas[i].opcion_elegida);
        }
        return coleccion_respuestas;
    },
    setAgenteValuesToLocalStorage: function (evaluacion) {
        localStorage.setItem("idPeriodo", evaluacion.periodo.id_periodo);
        localStorage.setItem("idEvaluado", evaluacion.agente_evaluado.id_evaluado);
        localStorage.setItem("idEvaluacion", evaluacion.id_evaluacion);
        localStorage.setItem("apellido", evaluacion.agente_evaluado.apellido);
        localStorage.setItem("nombre", evaluacion.agente_evaluado.nombre);
        localStorage.setItem("apellido", evaluacion.agente_evaluado.apellido);
        localStorage.setItem("descripcionPeriodo", evaluacion.periodo.descripcion_periodo);
        localStorage.setItem("idNivel", evaluacion.nivel.id_nivel);
        localStorage.setItem("descripcionNivel", evaluacion.nivel.descripcion_corta);
        localStorage.setItem("deficiente", evaluacion.nivel.deficiente);
        localStorage.setItem("regular", evaluacion.nivel.regular);
        localStorage.setItem("bueno", evaluacion.nivel.bueno);
        localStorage.setItem("destacado", evaluacion.nivel.destacado);
    },
    getLinkCargarGDE: function (id_evaluacion) {
        var _this = this;
        var btn_accion = $('<a>');
        btn_accion.html("Ingresar Codigo GDE");
        btn_accion.attr('id_eval', id_evaluacion);
        btn_accion.click(function () {
            _this.abrirPopUp('#div_codigo_gde', "#btn_codigo_gde", _this.guardarCodigoGde, "#lnk_cancelar");
            var id_eval = this["attributes"]["id_eval"].value;
            $("#hid_doc").val(id_eval);
        });
        return btn_accion;
    },
    guardarCodigoGde: function (ui) {
        //alert('testttt');
        var doc = $("#hid_doc").val();
        var codigo = ui.find('#codigo_gde').val();
        Backend.EvalGuardarCodigoGDE(doc, codigo);
    },
    getImgIcono: function (nombre_img, title) {
        var btn_accion = $('<a>');
        var img = $('<img>');
        var _this = this;
        img.attr('src', '../Imagenes/iconos/' + nombre_img);
        img.attr('width', '25px');
        img.attr('data-toggle', 'tooltip');
        img.attr('title', title);
        img.attr('height', '25px');
        btn_accion.append(img);
        return btn_accion;
    },
    getBotonImprimir: function (evaluacion) {
        var btn_accion = this.getImgIcono('icono-imprimir.png', 'Imprimir');
        var _this = this;
        btn_accion.click(function () {
            Backend.PrintPdfEvaluacionDesempenio(evaluacion)
            .onSuccess(function (rpta) {
                window.open("data:application/pdf;base64," + rpta, '_blank');
            });

        });
        return btn_accion;
    },
    abrirPopUp: function (nombre_div_formulario, nombre_boton_accion, accion, nombre_boton_cancel) {
        var _this = this;
        vex.defaultOptions.className = 'vex-theme-os';
        vex.open({
            afterOpen: function ($vexContent) {
                var ui = $(nombre_div_formulario).clone();
                $vexContent.append(ui);
                ui.find(nombre_boton_accion).click(function () { accion(ui); });
                var cancel = ui.find(nombre_boton_cancel)
                if (cancel) {
                    cancel.click(_this.cancelPopup);
                }
                ui.show();
                return ui;
            },
            css: {
                'padding-top': "4%",
                'padding-bottom': "0%"
            }
        });
    },
    cancelPopup: function () {
        vex.closeAll();
    },
    getBotonIrAFormulario: function (evaluacion) {
        var btn_accion = this.getImgIcono('estudios.png', 'Estudios');
        var _this = this;
        btn_accion.click(function () {
            _this.setAgenteValuesToLocalStorage(evaluacion);
            /*si nunca fue evaluado, no sabemos que nivel tiene, 
            hay que pedir al usuario que lo ingrese*/
            if (evaluacion.id_nivel == "0") {
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
    getDosBotones: function (evaluacion) {
        var boton_imprimir = this.getBotonImprimir(evaluacion);
        var boton_ir_a_form = this.getBotonIrAFormulario(evaluacion);
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
        .onSuccess(function (form) {

            //HTML CABECERA
            var respuestas = _this.getRespuestasDesdeLasPreguntas(form);
            var calificacion = _this.calificacion(respuestas, localStorage.getItem("deficiente"), localStorage.getItem("regular"), localStorage.getItem("bueno"), localStorage.getItem("destacado"), false);

            $('#div_contenido_impresion').append('<p style="float:right;font-size: x-small;font-family:ShelleyAllegro BT">' + leyenda + '</p> <p style="margin: 10px; margin-left: 150px;margin-top:50px;"><span>Agente: ' + nombre + '</span></p> <p style="margin: 10px; margin-left: 150px;">Nivel: <span>' + descripcionNivel + '</span> </p>')
            $('#div_contenido_impresion').append('<div id="der" class="" style="width:20%; float:right; border:1px solid; text-align:center; margin-top: -125px;;"><h2>Puntaje</h2><h2 id="puntaje">' + calificacion + '</h2></div>');
            //_this.calcularCalificacion();

            $.each(form, function (key, value) {
                var respuesta = "";
                switch (value.opcion_elegida) {
                    case 1:
                        respuesta = value.rpta1;
                        break;
                    case 2:
                        respuesta = value.rpta2;
                        break;
                    case 3:
                        respuesta = value.rpta3;
                        break;
                    case 4:
                        respuesta = value.rpta4;
                        break;
                    case 5:
                        respuesta = value.rpta5;
                        break;
                    default:
                        respuesta = 'No se ha podido encontrar la respuesta correspondiente.';
                }

                //HTML DETALLE
                $('#div_contenido_impresion').append('<h3>' + value.enunciado + '</h3><p style="margin-left:15px;">' + respuesta + '</p>');

            });
            $('#div_contenido_impresion').append('<div><div style="border: 1px solid #000;"><h3 style="text-align: center; border: 1px dotted #000;">SUPERIOR DIRECTO</h3><p>Certifico que el agente evaluado si/no (tachar lo que nocorresponda) ha tenido sanciones disciplinarias durante el período evaluado</p><p>Observaciones: .....................................................................................................................................................................................................................................</p><p>Fecha: ...../...../..........</p><br /><br /><p style="text-align: right; margin-right: 15px;">FIRMA ACLARACIÓN</p></div><div style="border: 1px solid #000;"><h3 style="text-align: center; border: 1px dotted #000;">APROBACIÓN DEL COMITÉ DE EVALUACIÓN</h3><p>Fecha: ...../...../..........</p><p style="text-align: right; margin-right: 15px;">FIRMA ACLARACIÓN de los integrantes</p><p>.....................................................................................................................................................................................................................................</p><p>.....................................................................................................................................................................................................................................</p><p>.....................................................................................................................................................................................................................................</p></div><div style="border: 1px solid #000;"><h3 style="text-align: center; border: 1px dotted #000;">NOTIFICACIÓN DEL AGENTE</h3><p>En el día de la fecha me notifico de mi calificación final por el desempeño durante el período correspondiente.</p><p>Fecha: ...../...../..........</p><p style="text-align: right; margin-right: 150px;">FIRMA</p><p style="font-size: 13px;">Contra la calificación notificada en este acto, podrá interponerse recurso de reconsideración dentro del término de DIES (10) días hábiles a resolver por la misma autoridad evaluadora (Artículo 84 y siguientes del Reglamento de Procedimientos Administrativos aprobado por el Decreto N° 1759/72 (t.o 1991), o bien interponer directamente recurso jerárquico a resolver según el Artículo 902 del citado Reglamento, dentro del término de QUINCE (15) días hábiles de esta notificación</p><br /><br /></div> </div>');
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
        .onSuccess(function (form) {
            spinner.stop();

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

                pregunta.text(value.enunciado);
                pregunta.attr('data-identificador', value.id_pregunta);
                pregunta.addClass('pregunta-pendiente');
                plantilla.find(".rta1").text(value.rpta1);
                plantilla.find(".rta2").text(value.rpta2);
                plantilla.find(".rta3").text(value.rpta3);
                plantilla.find(".rta4").text(value.rpta4);
                plantilla.find(".rta5").text(value.rpta5);

                radioButtons.attr('name', value.id_pregunta);

                // Genera dinámicamente un id para cada radio button y su respectiva label
                $.each(radioButtons, function (key, value) {
                    var input = $(value);
                    var inputId = idPregunta + '_' + key;
                    input.attr('id', inputId);
                    input.next('label').attr('for', inputId);

                    input.on('click', _this.verificarPreguntaPendiente);
                    input.on('click', _this.habilitarBotonGuardarDefinitivo);
                });

                radioButton.prop('checked', false);

                if (radioButton.parent().hasClass('radioSeleccionado')) {
                    radioButton.parent().removeClass('radioSeleccionado');
                }

                radioButton.click(function () {
                    _this.calcularCalificacion();
                    radioButton.parent().removeClass('radioSeleccionado');
                    $(this).parent().addClass('radioSeleccionado');
                });

                if (value.opcion_elegida !== 0) {
                    //chequear los radios elegidos
                    var radio = plantilla.find('[data-opcion=' + value.opcion_elegida + ']');
                    radio.prop('checked', true);
                    radio.parent().addClass('radioSeleccionado');
                    // Pregunta respondida, elimina marca '(*)' de pendiente
                    _this.verificarPreguntaPendiente.call(radio);
                }

                $('#contenedor').append(plantilla);
            });


            var idPersona = localStorage.getItem("idEvaluado");
            var documento = localStorage.getItem("documento");
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

            Backend.GetConsultaRapida(documento).onSuccess(function (datos) {
                var data = $.parseJSON(datos);
                if (!$.isEmptyObject(data)) {

                    if (data.FechaBaja != "") {
                        $('#baja').html("BAJA a partir del " + data.FechaBaja);
                    } else {
                        $('#baja').html("Activo");
                    }


                    if (data.CargoGremial != "") {
                        $('#cargo_gremial').html(data.CargoGremial);
                        $('#cargo_gremial').parent().show();
                    } else {
                        $('#cargo_gremial').parent().hide();
                    }
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

        //por cuestiones de diseño, esta lógica se encuentra duplicada, 
        //del lado del backend , en la clase NivelEvaluacionDesempeño
        //si se modifica, debe ser cambiada también ahí.

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
