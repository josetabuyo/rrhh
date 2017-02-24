var spinner;
var idUsuario;

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
            columnas.push(new Columna("Evaluacion", { generar: function (un_agente) { return "A Evaluar" } }));
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
                        localStorage.setItem("idEvaluacion", 7);

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
                    plantilla.find('data-opcion=' + value.OpcionElegida).checked = true;
                }

                $('#contenedor').append(plantilla);
            });

            $('#btnGuardarFormulario').click(function () {
                var nivel = localStorage.getItem("idNivel");
                var periodo = localStorage.getItem("idPeriodo");
                var evaluado = localStorage.getItem("idEvaluado");
                var evaluacion = localStorage.getItem("idEvaluacion");

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

                console.log(pregYRtas);
                /*
                var pregYRtas = [
                { idPregunta: 1, idRespuesta: 1 },
                { idPregunta: 2, idRespuesta: 3 },
                { idPregunta: 3, idRespuesta: 5 },
                { idPregunta: 4, idRespuesta: 5 }
                ];
                */



                var jsonPregYRtas = JSON.stringify(pregYRtas);
                //cambiar el 2do idEvaluado por idEvaluador
                Backend.InsertarEvaluacion(idEvaluado, idEvaluado, idNivel, periodo, jsonPregYRtas)
                    .onSuccess(function (rto) {
                        spinner.stop();
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
