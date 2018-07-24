
var GestionDeAreas = {
    init: function () {

    },
    getAreasDelUsuario: function () {


        var _this = this;
        this.traerAreasConRCA();


    },
    traerAreasConRCA: function () {
        var _this = this;
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);
        $('#ContenedorPersona').empty();

        Backend.GetAreasDelDirectorConPersonasRCA()
            .onSuccess(function (areas) {

                spinner.stop();

                //var areas = JSON.parse(areasJSON);











                $.each(areas, function (key, valores) {
                    var plantilla = $('.contenedorArea').clone();
                    //var radioButtons = plantilla.find(".input_form");
                    //var idPregunta = value.idPregunta;
                    //var pregunta = plantilla.find(".pregunta");
                    //
                    plantilla.removeClass("contenedorArea");
                    var buscadorPersonas = plantilla.find('#selector_usuario');
                     buscadorPersonas.removeAttr("id");
                    buscadorPersonas.attr("id","selector_usuario" + key);
                    var selector_personas = new SelectorDePersonas({
                        ui: buscadorPersonas,
                        repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
                        placeholder: "nombre, apellido, documento o legajo"
                    });
                    selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
                        _this.mostrarPersona(la_persona_seleccionada.id);
                    };

                    plantilla.show();
                    //pregunta.text(value.enunciado);
                    //pregunta.attr('data-identificador', value.id_pregunta);
                    //pregunta.addClass('pregunta-pendiente');
                    plantilla.find(".nombreArea").text(valores.Alias);

                    $.each(valores.Responsables, function (key, value) {

                        var fila = plantilla.find('.filaAgente').clone();
                        fila.show();
                        fila.attr('class', 'filaAgregado');
                        fila.find(".nombreAgente").text(value.Apellido + ', ' + value.Nombre);
                        fila.find(".documento").text(value.Documento);
                        var botonEliminar = fila.find(".miBoton");
                        //fila.find(".permiso").append(botonEliminar);

                        //radioButtons.attr('name', value.id_pregunta);
                        botonEliminar.attr('name', value.Id);
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

        /*Backend.GetEstudios()
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
        });*/
    },
    eliminarPermiso: function (idUsuario, idArea) {
        //return idArea;
        var _this = this;
        Backend.DenegarFuncionalidadA(idUsuario, 4) //Backend.eliminarPerfilRCA(idUsuario, idArea)
            .onSuccess(function (resultado) {

                //location.reload();
                _this.traerAreasConRCA();


            })
            .onError(function (e) {
                spinner.stop();
            });

    },
    mostrarPersona: function (id_persona) {
        //var _this = this;
        var _this = this;
        Backend.AgregarPermisoRCA(id_persona, 4) //Backend.eliminarPerfilRCA(idUsuario, idArea)
            .onSuccess(function (resultado) {

                //location.reload();
                _this.traerAreasConRCA();

            })
            .onError(function (e) {
                spinner.stop();
            });

    }



}
