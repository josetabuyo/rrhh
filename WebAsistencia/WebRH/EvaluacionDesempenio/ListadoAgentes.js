var spinner;
var idUsuario;
var todas_las_evaluaciones;
var ListadoAgentes = {
    init: function () {

    },
    FiltrarRegistros: function (modo) {
        var _this = this;
        if (modo == 'Verificador') {
            _this.DibujarTablaVerificaciones(todas_las_evaluaciones);
        } else {
            _this.DibujarTablaEvaluaciones(todas_las_evaluaciones);
        }
        _this.FiltrarPorEstado(parseInt($("#id_estado").val()));
        _this.FiltrarPorDNIApellidoONombre($("#srch_agente").val());
        _this.FiltrarPorPeriodo($("#select_periodo").val());
    },
    completarFiltroPeriodo: function (respuesta) {
        var select_periodo = $("#select_periodo");
        select_periodo.empty();
        select_periodo.append($("<option></option>")
                             .attr("value", -1)
                             .text("Todos"));

        $.each(respuesta, function (index, value) {
            select_periodo.append($("<option></option>")
                                 .attr("value", value.id_periodo)
                                 .text(value.descripcion_periodo));
        });
    },
    getPeriodosEvaluacion: function () {
        var _this = this;
        Backend.GetPeriodosEvaluacion()
        .onSuccess(function (respuesta) {
            _this.completarFiltroPeriodo(respuesta);
        })
        .onError(function (respuesta) {
            alert("se produjo un error al intentar obtener los periodos de evaluación del filtro");
        });
    },
    getEvaluaciones: function (modo) {
        var _this = this;
        $("#id_estado").change(function () {
            _this.FiltrarRegistros(modo);
        });

        $("#srch_agente").keyup(function () {
            _this.FiltrarRegistros(modo);
        });

        $("#select_periodo").change(function () {
            _this.FiltrarRegistros(modo);
        });

        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);
        _this.spinner = spinner;

        var calificacion;

        if (modo == 'Verificador') {
            Backend.GetAgentesEvaluablesParaVerificarGDE()
            .onSuccess(function (respuesta) {
                _this.spinner.stop();
                _this.GetAgentesSuccess(respuesta);
            })
            .onError(function (e) {
                _this.spinner.stop();
            });
        } else {
            Backend.EvalGetAgentesEvaluables()
            .onSuccess(function (respuesta) {
                _this.spinner.stop();
                _this.GetAgentesSuccess(respuesta);
            })
            .onError(function (e) {
                _this.spinner.stop();
            });
        }

        var d = new Date();
        Backend.GetLeyendaAnio(d.getFullYear())
        .onSuccess(function (respuesta) {
            localStorage.setItem("leyenda", respuesta);
        })
        .onError(function (error, as, asd) {
            localStorage.setItem("leyenda", "");
        });
    },
    GetAgentesSuccess: function (respuesta) {
        _this = this;
        localStorage.setItem("usuario_logueado", JSON.stringify(respuesta.UsuarioRequest));
        var asignacion_evaluado_a_evaluador = respuesta.asignaciones;
        if (asignacion_evaluado_a_evaluador.length == 0) return;
        if (!asignacion_evaluado_a_evaluador[0].hasOwnProperty('agente_evaluado')) return;
        todas_las_evaluaciones = asignacion_evaluado_a_evaluador;
        if (respuesta.EsAgenteVerificador) {
            _this.DibujarTablaVerificaciones(asignacion_evaluado_a_evaluador);
        } else {
            _this.DibujarTablaEvaluaciones(asignacion_evaluado_a_evaluador);
            // Habilita filtros si hay uno o más agentes
            if (asignacion_evaluado_a_evaluador.length) { // 0 == false
                var $barraBuscador = $("#Text1");
                $barraBuscador.attr("disabled", false);
                $("#id_estado").attr("disabled", false);

                $barraBuscador.keypress(function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                    }
                });
            }
        }
    },
    GetterDocEvaluado: function (asignacion_evaluado_a_evaluador) { return asignacion_evaluado_a_evaluador.agente_evaluado.nro_documento; },
    GetterApellidoEvaluado: function (asignacion_evaluado_a_evaluador) { return asignacion_evaluado_a_evaluador.agente_evaluado.apellido },
    GetterNombreEvaluado: function (asignacion_evaluado_a_evaluador) { return asignacion_evaluado_a_evaluador.agente_evaluado.nombre },
    GetterArea: function (asignacion_evaluado_a_evaluador) { return asignacion_evaluado_a_evaluador.agente_evaluado.area.nombre_area /*return asignacion_evaluado_a_evaluador.codigo_unidad_eval */ },
    GetterPeriodoEvaluacion: function (asignacion_evaluado_a_evaluador) { return asignacion_evaluado_a_evaluador.periodo.descripcion_periodo },
    GetterEvaluacion: function (asignacion_evaluado_a_evaluador) {
        var coleccion_respuestas = this.getRespuestasDelForm(asignacion_evaluado_a_evaluador.evaluacion);
        return this.calificacion(coleccion_respuestas, asignacion_evaluado_a_evaluador.nivel.deficiente, asignacion_evaluado_a_evaluador.nivel.regular, asignacion_evaluado_a_evaluador.nivel.bueno, asignacion_evaluado_a_evaluador.nivel.destacado, false);
    },
    GetterAccionesEvaluado: function (asignacion_evaluado_a_evaluador) {
        if (!(asignacion_evaluado_a_evaluador.evaluacion.estado_evaluacion == 1)) {
            return this.getBotonIrAFormulario(asignacion_evaluado_a_evaluador);
        }
        if (this.EvaluacionCompleta(asignacion_evaluado_a_evaluador)) {
            return this.getBotonImprimir(asignacion_evaluado_a_evaluador);
        } else {
            //deberia ser imposible que este como definitiva una evaluacion incompleta
            return this.getBotonIrAFormulario(asignacion_evaluado_a_evaluador);
        }
    },
    GetterGDEVerificador: function (asignacion_evaluado_a_evaluador) {
        if (asignacion_evaluado_a_evaluador.evaluacion.verificacion_gde.PersonaVerificadora == "") {
            var btn_gde_verificado = this.getLinkMarcarGDEVerificado(asignacion_evaluado_a_evaluador.id_evaluacion, asignacion_evaluado_a_evaluador.evaluacion.codigo_gde, asignacion_evaluado_a_evaluador.agente_evaluado.apellido + ", " + asignacion_evaluado_a_evaluador.agente_evaluado.nombre);
            var btn_modificar_gde = this.getLinkCargarGDE(asignacion_evaluado_a_evaluador.id_evaluacion, "Corregir Codigo", _this.corregirCodigoGde);
            return this.getDosBotones(btn_gde_verificado, btn_modificar_gde);
        } else {
            return asignacion_evaluado_a_evaluador.codigo_gde;
        }
    },
    GetterGDEEvaluador: function (asignacion_evaluado_a_evaluador) {
        if (asignacion_evaluado_a_evaluador.evaluacion.codigo_gde == '' && asignacion_evaluado_a_evaluador.evaluacion.estado_evaluacion == 1) {
            return this.getLinkCargarGDE(asignacion_evaluado_a_evaluador.id_evaluacion, "Ingresar Codigo GDE", _this.guardarCodigoGde);
        }
        if (asignacion_evaluado_a_evaluador.evaluacion.codigo_gde != '') {
            return asignacion_evaluado_a_evaluador.evaluacion.codigo_gde;
        }
        return asignacion_evaluado_a_evaluador.codigo_gde;
    },
    ColumnasEvaluado: function (columnas) {
        var _this = this;
        if (columnas == undefined) {
            columnas = [];
        }
        var columnas_evaluado = [
                { nombre_columna: "Dni", value_getter: this.GetterDocEvaluado },
                { nombre_columna: "Apellido", value_getter: this.GetterApellidoEvaluado },
                { nombre_columna: "Nombre", value_getter: this.GetterNombreEvaluado },
                { nombre_columna: "Area", value_getter: this.GetterArea },
                { nombre_columna: "Periodo", value_getter: this.GetterPeriodoEvaluacion },
                { nombre_columna: "Evaluacion", value_getter: function (x) { return _this.GetterEvaluacion.call(_this, x); } }
            ];
        return columnas.concat(columnas_evaluado);
    },
    DibujarTablaVerificaciones: function (asignacion_evaluado_a_evaluador) {
        var _this = this;
        var definicion_columnas = this.ColumnasEvaluado().concat([
            { nombre_columna: "GDE", value_getter: function (x) { return x.evaluacion.codigo_gde; } },
            { nombre_columna: "Accion", value_getter: function (x) { return _this.GetterGDEVerificador.call(_this, x); } }
        ]);
        var grilla = new GrillaV2("tablaAgentes", definicion_columnas, asignacion_evaluado_a_evaluador);
    },
    DibujarTablaEvaluaciones: function (asignacion_evaluado_a_evaluador) {
        var _this = this;
        var definicion_columnas = this.ColumnasEvaluado().concat([
            { nombre_columna: "Accion", value_getter: function (x) { return _this.GetterAccionesEvaluado.call(_this, x); } },
            { nombre_columna: "GDE", value_getter: function (x) { return _this.GetterGDEEvaluador.call(_this, x); } }
        ]);

        var grilla = new GrillaV2("tablaAgentes", definicion_columnas, asignacion_evaluado_a_evaluador);
    },
    EvaluacionCompleta: function (asignacion_evaluado_a_evaluador) {
        if (asignacion_evaluado_a_evaluador.id_evaluacion == 0) return false;
        var coleccion_respuestas = this.getRespuestasDelForm(asignacion_evaluado_a_evaluador.evaluacion);
        var calificacion = this.calificacion(coleccion_respuestas, asignacion_evaluado_a_evaluador.nivel.deficiente, asignacion_evaluado_a_evaluador.nivel.regular, asignacion_evaluado_a_evaluador.nivel.bueno, asignacion_evaluado_a_evaluador.nivel.destacado, false);
        return !(calificacion == 'A Evaluar' || calificacion == 'Evaluacion Incompleta');
    },
    /*FiltrarPorPeriodo: function (periodo_busqueda) {
    var _this = this;
    if (periodo_busqueda != "") {
    $('#select_periodo option[value="' + clave + '"]').html()
    }
    },*/
    FiltrarPorDNIApellidoONombre: function (txt_busqueda) {
        var _this = this;
        if (txt_busqueda != "") {
            $("#tablaAgentes tbody tr").find("td[class=Apellido]").each(function () {
                if ($(this).text().toUpperCase().indexOf(txt_busqueda.toUpperCase()) < 0) {
                    $(this).parent().remove();
                };
            })
        }
    },
    FiltrarPorPeriodo: function (clave) {
        if (clave != -1) {
            $("#tablaAgentes tbody tr").find("td[class=Periodo]").each(function () {
                if ($(this).text() != $('#select_periodo option[value="' + clave + '"]').html()) {
                    $(this).parent().remove();
                };
            })
        }
    },
    FiltrarPorEstado: function (estado) {
        var _this = this;
        var clave = "";
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

            $("#tablaAgentes tbody tr").find("td[class=Evaluacion]").each(function () {
                if ($(this).text() != clave) {
                    $(this).parent().remove();
                };
            })
        }
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
    setAgenteValuesToLocalStorage: function (asignacion_evaluado_a_evaluador) {
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
    },
    getLinkMarcarGDEVerificado: function (id_evaluacion, codigo_gde, agente) {
        var _this = this;
        var btn_accion = $('<a>');
        btn_accion.html("Marcar cod. GDE Verificado");
        btn_accion.attr('id_eval', id_evaluacion);
        btn_accion.attr('codigo_gde', codigo_gde);
        btn_accion.attr('agente', agente);
        btn_accion.click(function () {
            var id_eval = this["attributes"]["id_eval"].value;
            var codigo_gde = this["attributes"]["codigo_gde"].value;
            var agente = this["attributes"]["agente"].value;
            $("#div_codigo_gde_a_verificar").html(codigo_gde);
            $("#div_agente_a_verificar").html(agente);
            $("#hid_id_eval").val(id_eval);
            _this.abrirPopUp('#div_verificar_codigo_gde', "#btn_verificar_codigo_gde", _this.verificarCodigoGde, "#lnk_cancelar_verificacion");
        });
        return btn_accion;
    },
    getLinkCargarGDE: function (id_evaluacion, titulo, btn_guardar) {
        var _this = this;
        var btn_accion = $('<a>');
        btn_accion.html(titulo);
        btn_accion.attr('id_eval', id_evaluacion);
        btn_accion.click(function () {
            _this.abrirPopUp('#div_codigo_gde', "#btn_codigo_gde", btn_guardar, "#lnk_cancelar");
            var id_eval = this["attributes"]["id_eval"].value;
            $("#hid_id_eval").val(id_eval);
        });
        return btn_accion;
    },
    verificarCodigoGdeCorregido: function (ui) {
        var id_eval = parseInt($("#hid_id_eval").val());
        var codigo_gde = ui.find('#div_codigo_gde_a_verificar').html();
        Backend.EvalCorregirCodigoGDE(id_eval, codigo_gde)
        .onSuccess(function (rpta) {
            var td = $("a[id_eval*='" + id_eval + "']").parent();
            td.empty();
            td.html(codigo);
        }).onError(function (error, as, asd) {
            alert("Se produjo un error al verificar el código GDE.");
        });

        vex.closeAll();
    },
    verificarCodigoGde: function (ui) {
        var id_eval = parseInt($("#hid_id_eval").val());
        var codigo_gde = ui.find('#div_codigo_gde_a_verificar').html();
        Backend.EvalVerificarCodigoGDE(id_eval, codigo_gde)
        .onSuccess(function (rpta) {
            var td = $("a[id_eval*='" + id_eval + "']").parent();
            td.empty();
            td.html(codigo);
        }).onError(function (error, as, asd) {
            alert("Se produjo un error al verificar el código GDE.");
        });

        vex.closeAll();
    },
    corregirCodigoGde: function (ui) {
        //EvalCorregirCodigoGDE
        //alert("ok");
        var id_eval = parseInt($("#hid_id_eval").val());
        var codigo_gde = ui.find('#codigo_gde').val();
        var agente = ui.find('#nombre_agente').val();

        $("#div_codigo_gde_a_verificar").html(codigo_gde);
        $("#div_agente_a_verificar").html(agente);
        $("#hid_id_eval").val(id_eval);
        _this.abrirPopUp('#div_verificar_codigo_gde', "#btn_verificar_codigo_gde", _this.verificarCodigoGdeCorregido, "#lnk_cancelar_verificacion");
    },
    guardarCodigoGde: function (ui) {
        var id_eval = parseInt($("#hid_id_eval").val());
        var codigo = ui.find('#codigo_gde').val();
        Backend.EvalGuardarCodigoGDE(id_eval, codigo)
        .onSuccess(function (rpta) {
            var td = $("a[id_eval*='" + id_eval + "']").parent();
            td.empty();
            td.html(codigo);
        }).onError(function (error, as, asd) {
            alert("Se produjo un error al guardar el código GDE.");
        });
        vex.closeAll();
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
    getBotonImprimir: function (asignacion_evaluado_a_evaluador) {
        var btn_accion = this.getImgIcono('icono-imprimir.png', 'Imprimir');
        var _this = this;
        btn_accion.click(function () {
            Backend.PrintPdfEvaluacionDesempenio(asignacion_evaluado_a_evaluador)
            .onSuccess(function (rpta) {

                //window.open("data:application/pdf;base64," + rpta, '_blank');
                var string = 'data:application/pdf;base64,' + rpta;
                var iframe = "<iframe width='100%' height='100%' src='" + string + "'></iframe>"
                var x = window.open();
                x.document.open();
                x.document.write(iframe);
                x.document.close();
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
    getBotonIrAFormulario: function (asignacion_evaluado_a_evaluador) {
        var btn_accion = this.getImgIcono('estudios.png', 'Estudios');
        var _this = this;
        btn_accion.click(function () {
            _this.setAgenteValuesToLocalStorage(asignacion_evaluado_a_evaluador);
            /*si nunca fue evaluado, no sabemos que nivel tiene, 
            hay que pedir al usuario que lo ingrese*/
            if (asignacion_evaluado_a_evaluador.id_nivel == "0") {
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
    getDosBotones: function (boton1, boton2) {
        //var boton_imprimir = this.getBotonImprimir(asignacion_evaluado_a_evaluador);
        //var boton_ir_a_form = this.getBotonIrAFormulario(asignacion_evaluado_a_evaluador);
        var div = $('<div>');
        var ul = $('<ul>');
        var li1 = $('<li>');
        var li2 = $('<li>');
        li1.append(boton1);
        li2.append(boton2);
        ul.append(li1);
        ul.append(li2);
        div.append(ul);

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
                    input.on('click', function () { _this.habilitarBotonGuardarDefinitivo(_this); });
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
            _this.habilitarBotonGuardarDefinitivo(_this);

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
                var id_doc_electronico = localStorage.getItem("id_doc_electronico");
                if (id_doc_electronico == null) { id_doc_electronico = "" };
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

                Backend.InsertarEvaluacion(idEvaluado, idNivel, periodo, evaluacion, jsonPregYRtas, estado, id_doc_electronico)
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
    puntajeActual: function (coleccion_opciones_elegidas) {
        var puntaje = 0;
        for (i = 0; i < coleccion_opciones_elegidas.length; i++) {
            puntaje += 5 - (coleccion_opciones_elegidas[i]);
        }
        return puntaje;
    },
    calificacion: function (coleccion_opciones_elegidas, deficiente, regular, bueno, destacado, completando_formulario) {

        //por cuestiones de diseño, esta lógica se encuentra duplicada, 
        //del lado del backend , en la clase NivelEvaluacionDesempeño
        //si se modifica, debe ser cambiada también ahí.


        var alguna_incompleta = false;
        var alguna_respondida = false;

        var puntaje = this.puntajeActual(coleccion_opciones_elegidas);

        if (coleccion_opciones_elegidas.length == 0) {
            alguna_incompleta = true;
            alguna_respondida = false;
        } else {
            for (i = 0; i < coleccion_opciones_elegidas.length; i++) {
                if (coleccion_opciones_elegidas[i] == 0) {
                    alguna_incompleta = true;
                } else {
                    alguna_respondida = true;
                }
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
    respuestasDelForm: function () {
        var respuestas = [];
        var radioButtonsChecked = $('.input_form:checked');
        var _this = this;

        $.each(radioButtonsChecked, function (key, value) {
            respuestas.push(parseInt(value.dataset.opcion));
        });

        return respuestas;
    },
    calcularCalificacion: function () {
        var _this = this;
        var respuestas = this.respuestasDelForm();
        var puntaje = _this.calificacion(respuestas, localStorage.getItem("deficiente"), localStorage.getItem("regular"), localStorage.getItem("bueno"), localStorage.getItem("destacado"), true);

        $('#puntaje').html(puntaje);
    },
    verificarPreguntaPendiente: function () {
        var pregunta = $(this).parents('#plantilla').find('.pregunta');
        if (pregunta.hasClass('pregunta-pendiente')) {
            pregunta.removeClass('pregunta-pendiente');
        }
    },
    completarPuntaje: function () {
        var elementoTotalPuntaje = $('.puntaje-actual');
        var coleccion_opciones_elegidas = this.respuestasDelForm(); // this.getRespuestasDelForm(asignacion_evaluado_a_evaluador.evaluacion);
        var puntaje = this.puntajeActual(coleccion_opciones_elegidas);
        elementoTotalPuntaje.text(' ' + puntaje);
    },
    habilitarBotonGuardarDefinitivo: function (_this) {
        var id_usuario_logueado = JSON.parse(localStorage.getItem("usuario_logueado")).Owner.Id;
        var id_agente_evaluador = JSON.parse(localStorage.getItem("id_agente_evaluador"))
        var es_evaluador_primario = (id_usuario_logueado == id_agente_evaluador);
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
        _this.completarPuntaje();

        if (totalPreguntasPendientes === 0 && es_evaluador_primario) {
            btnGuardarDefinitivo.prop('disabled', false);
        } else {
            btnGuardarDefinitivo.prop('disabled', true);
        }
    }
}
