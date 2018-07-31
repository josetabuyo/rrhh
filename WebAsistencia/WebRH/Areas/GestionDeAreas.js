
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
                    buscadorPersonas.attr("id", "selector_usuario" + key);
                    //var buscador = buscadorPersonas.find('#buscador');
                    //buscador.removeAttr("id");
                    //buscador.attr("id", "buscador" + key);
                   
                    var selector_personas = new SelectorDePersonas({
                        ui: buscadorPersonas,
                        repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
                        placeholder: "nombre, apellido, documento o legajo"
                    });
                    selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
                        _this.mostrarPersona(la_persona_seleccionada.id);
                    };

                    var buscador = buscadorPersonas.find('#buscador');
                    buscador.removeAttr("id");
                    buscador.attr("id", "buscador" + key);
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

                        plantilla.find(".list").append(fila);
                    });

                    $('#ContenedorPersona').append(plantilla);

                });

            })
            .onError(function (e) {
                spinner.stop();
            });
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
