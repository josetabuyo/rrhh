
var GestionDeAreas = {
    init: function () {

    },
    getAreasDelUsuario: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        var _this = this;
        Backend.GetAreasDelDirectorConPersonasRCA()
            .onSuccess(function (areas) {

                spinner.stop();

                //var areas = JSON.parse(areasJSON);

                

                var plantilla = $('.contenedorArea').clone();
                //var radioButtons = plantilla.find(".input_form");
                //var idPregunta = value.idPregunta;
                //var pregunta = plantilla.find(".pregunta");
                //

                plantilla.show();

                $.each(areas, function (key, valores) {
                    //pregunta.text(value.enunciado);
                    //pregunta.attr('data-identificador', value.id_pregunta);
                    //pregunta.addClass('pregunta-pendiente');
                    plantilla.find(".nombreArea").text(valores.Alias);
                    
                    $.each(valores.Responsables, function (key, value) {
                       
                        var fila = plantilla.find('.filaAgente').clone();
                        fila.attr('class', 'filaAgregado');
                        fila.find(".nombreAgente").text(value.Apellido + ', ' + value.Nombre);
                        fila.find(".documento").text(value.Documento);
                        var botonEliminar = fila.find(".miBoton");
                        //fila.find(".permiso").append(botonEliminar);

                        //radioButtons.attr('name', value.id_pregunta);
                        botonEliminar.attr('id', value.Id);
                        botonEliminar.on('click', function () { _this.eliminarPermiso(value.Id, valores.Id); });
                        // Genera dinámicamente un id para cada radio button y su respectiva label
                        /*$.each(radioButtons, function (key, value) {
                        var input = $(value);
                        var inputId = idPregunta + '_' + key;
                        input.attr('id', inputId);
                        input.next('label').attr('for', inputId);

                        input.on('click', _this.verificarPreguntaPendiente);
                        input.on('click', function () { _this.habilitarBotonGuardarDefinitivo(_this); });
                        });*/

                        //radioButton.prop('checked', false);

                        /*if (radioButton.parent().hasClass('radioSeleccionado')) {
                        radioButton.parent().removeClass('radioSeleccionado');
                        }*/

                        /*  radioButton.click(function () {
                        _this.calcularCalificacion();
                        radioButton.parent().removeClass('radioSeleccionado');
                        $(this).parent().addClass('radioSeleccionado');
                        });*/

                        /*if (value.opcion_elegida !== 0) {
                        //chequear los radios elegidos
                        var radio = plantilla.find('[data-opcion=' + value.opcion_elegida + ']');
                        radio.prop('checked', true);
                        radio.parent().addClass('radioSeleccionado');
                        // Pregunta respondida, elimina marca '(*)' de pendiente
                        _this.verificarPreguntaPendiente.call(radio);
                        }*/
                        plantilla.find(".list").append(fila);
                    });

                    $('#ContenedorPersona').append(plantilla);

                });

            })
            .onError(function (e) {
                spinner.stop();
            });


    },
    getRCADelArea: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetEstudios()
            .onSuccess(function (estudiosJSON) {

                spinner.stop();

                var estudios = JSON.parse(estudiosJSON);

                var _this = this;
                $("#ContenedorGrillaAreas").empty();
                var divGrilla = $("#ContenedorGrillaAreas");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Titulo", { generar: function (un_estudio) { return un_estudio.titulo } }));
                columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.nombreDeNivel } }));
                columnas.push(new Columna("Institución", { generar: function (un_estudio) { return un_estudio.nombreUniversidad } }));
                columnas.push(new Columna("F. Egreso", { generar: function (un_estudio) {
                    var fecha_sin_hora = un_estudio.fechaEgreso.split("T");
                    var fecha = fecha_sin_hora[0].split("-");
                    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                }
                }));

                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_estudio) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(estudios);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {
                spinner.stop();
            });
    },
    eliminarPermiso: function (idUsuario, idArea) {
        return idArea;
        Backend.eliminarPerfilRCA(idUsuario, idArea)
            .onSuccess(function (resultado) {




            })
            .onError(function (e) {
                spinner.stop();
            });

    }



}
