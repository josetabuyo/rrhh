var PublicacionesTrabajos = {
    mostrar: function (publicacion_trabajo_original, alModificar) {
        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PublicacionesTrabajos.htm", function () {
            _this.publicaciones_titulo = _this.ui.find("#txt_publicaciones_titulo");
            _this.publicaciones_titulo.val(publicacion_trabajo_original.Titulo);
            _this.publicaciones_editorial = _this.ui.find("#txt_publicaciones_editorial");
            _this.publicaciones_editorial.val(publicacion_trabajo_original.DatosEditorial);
            _this.publicaciones_fecha = _this.ui.find("#txt_publicaciones_fecha");
            _this.publicaciones_fecha.val(publicacion_trabajo_original.FechaPublicacion);
            _this.publicaciones_paginas = _this.ui.find("#txt_publicaciones_paginas");
            _this.publicaciones_paginas.val(publicacion_trabajo_original.CantidadHojas);
            _this.publicaciones_dispone_copia = _this.ui.find("#cmb_publicaciones_dispone_copia");
            _this.publicaciones_dispone_copia.val(publicacion_trabajo_original.DisponeCopia);


            //Bt agregar
            _this.add_publicacionesTrabajos = _this.ui.find("#add_publicacionesTrabajos");
            _this.add_publicacionesTrabajos.click(function () {
                publicacion_trabajo_original.Titulo = _this.publicaciones_titulo.val();
                publicacion_trabajo_original.Titulo = _this.publicaciones_editorial.val();
                publicacion_trabajo_original.FechaPublicacion = _this.publicaciones_fecha.val();
                publicacion_trabajo_original.FechaPublicacion = _this.publicaciones_paginas.val();
                publicacion_trabajo_original.DisponeCopia = _this.publicaciones_dispone_copia.val();
                


                var data_post = JSON.stringify({
                    "publicacionesTrabajos_nuevas": publicacion_trabajo_original,
                    "publicacionesTrabajos_originales": publicacion_trabajo_original
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarCvPublicacionesTrabajos",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

            $('#txt_publicaciones_fecha').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    },
    armarGrilla: function (publicaciones_trabajos) {
        var _this = this;

        contenedorPlanilla = $('#tabla_publicaciones_trabajos');

        var columnas = [];

    columnas.push(new Columna("Id", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.Id } }));
    columnas.push(new Columna("Título", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.Titulo } }));
    columnas.push(new Columna("Editorial", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.FechaPublicacion } }));
    columnas.push(new Columna("Fecha", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.CantidadHojas } }));
    columnas.push(new Columna("Páginas", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.CantidadHojas } }));
    columnas.push(new Columna("Dispone Copias", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.DisponeCopia } }));
    //columnas.push(new Columna("Copia", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo. } }));
    columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (una_publicacion_trabajo) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '25px');
        botonEditar.attr('height', '25px');

        botonEditar.click(function () {
            PublicacionesTrabajos.mostrar(una_publicacion_trabajo, function (publicacion_trabajo_modificada) {
                PlanillaCvPublicacionesTrabajos.BorrarContenido();
                PlanillaCvPublicacionesTrabajos.CargarObjetos(publucaciones_trabajos);
            });
        });

        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '25px');
        botonEliminar.attr('height', '25px');

        botonEliminar.click(function () {
            PublicacionesTrabajos.eliminar(una_publicacion_trabajo, function (publicacion_trabajo_eliminada) {
                PlanillaCvPublicacionesTrabajos.QuitarObjeto(contenedorPlanilla, publicacion_trabajo_eliminada);
            });
        });

        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


PlanillaCvPublicacionesTrabajos = new Grilla(columnas);
PlanillaCvPublicacionesTrabajos.AgregarEstilo("table table-striped");
PlanillaCvPublicacionesTrabajos.SetOnRowClickEventHandler(function (una_piblicacion_trabajo) {
            // panelAlumno.CompletarDatosAlumno(un_alumno);
        });

PlanillaCvPublicacionesTrabajos.CargarObjetos(publicaciones_trabajos);
PlanillaCvPublicacionesTrabajos.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (publicacion_trabajo_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "publicacionesTrabajos_borrar": publicacion_trabajo_a_eliminar
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarCVPublicacionesTrabajos",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alertify.success("Antecedente Academico eliminado correctamente");
                        //alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        //$(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se puedo eliminar el antecedente");
            }
        });



    }
}

FormatoFecha = function (fecha_string) {
    var fecha = new Date(fecha_string);
    return (fecha.getDate() + 1) + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear();
};