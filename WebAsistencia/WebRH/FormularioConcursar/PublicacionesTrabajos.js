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
                //var estudio_modificado = $.extend(true, estudio_original);
                publicacion_trabajo_original.Titulo = _this.publicaciones_titulo.val();
                publicacion_trabajo_original.Titulo = _this.publicaciones_editorial.val();
                publicacion_trabajo_original.FechaPublicacion = _this.publicaciones_fecha.val();
                publicacion_trabajo_original.FechaPublicacion = _this.publicaciones_paginas.val();
                publicacion_trabajo_original.DisponeCopia = _this.publicaciones_dispone_copia.val();
                


                var data_post = JSON.stringify({
                    "docencias_nuevas": actividad_docente_original,
                    "docencias_originales": actividad_docente_original
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

            $('#txt_actividad_docente_fecha_inicio').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#txt_actividad_docente_fecha_fin').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    },
    armarGrilla: function (actividades_docentes) {
        var _this = this;

        //var actividades_docentes = JSON.parse(actividades_docentes);

        contenedorPlanilla = $('#tabla_actividades_docentes');

        var columnas = [];

    columnas.push(new Columna("Id", { generar: function (una_actividad_docente) { return una_actividad_docente.Id } }));
    columnas.push(new Columna("Asignatura", { generar: function (una_actividad_docente) { return una_actividad_docente.Asignatura } }));
    columnas.push(new Columna("Nivel Educativo", { generar: function (una_actividad_docente) { return una_actividad_docente.NivelEducativo } }));
    columnas.push(new Columna("Tipo de Actividad", { generar: function (una_actividad_docente) { return una_actividad_docente.TipoActividad } }));
    columnas.push(new Columna("Categoría Docente", { generar: function (una_actividad_docente) { return una_actividad_docente.CategoriaDocente } }));
    //columnas.push(new Columna("Caracter de Designación", { generar: function (una_actividad_docente) { return una_actividad_docente.CaracterDesignación } }));
    //columnas.push(new Columna("Dedicación Docente", { generar: function (una_actividad_docente) { return una_actividad_docente.DedicacionDocente } }));
    //columnas.push(new Columna("Carga Horaria", { generar: function (una_actividad_docente) { return una_actividad_docente.CargaHoraria } }));
    columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_docente) { return una_actividad_docente.FechaInicio } }));
    columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_docente) { return una_actividad_docente.FechaFinalizacion } }));
    columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_docente) { return una_actividad_docente.Establecimiento } }));
    //columnas.push(new Columna("Localidad", { generar: function (una_actividad_docente) { return una_actividad_docente.Localidad } }));
    //columnas.push(new Columna("Pais", { generar: function (una_actividad_docente) { return una_actividad_docente.Pais } }));
    columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (una_actividad_docente) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '25px');
        botonEditar.attr('height', '25px');

        botonEditar.click(function () {
            PublicacionesTrabajos.mostrar(una_actividad_docente, function (actididad_docente_modificada) {
                PlanillaCvPublicacionesTrabajos.BorrarContenido();
                PlanillaCvPublicacionesTrabajos.CargarObjetos(actividades_docentes);
            });
        });

        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '25px');
        botonEliminar.attr('height', '25px');

        botonEliminar.click(function () {
            PublicacionesTrabajos.eliminar(una_actividad_docente, function (actividad_docente_eliminada) {
                PlanillaCvPublicacionesTrabajos.QuitarObjeto(contenedorPlanilla, actividad_docente_eliminada);
            });
        });

        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


PlanillaCvPublicacionesTrabajos = new Grilla(columnas);
PlanillaCvPublicacionesTrabajos.AgregarEstilo("table table-striped");
PlanillaCvPublicacionesTrabajos.SetOnRowClickEventHandler(function (un_estudio) {
            // panelAlumno.CompletarDatosAlumno(un_alumno);
        });

PlanillaCvPublicacionesTrabajos.CargarObjetos(actividades_docentes);
PlanillaCvPublicacionesTrabajos.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (actividad_docente_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "publicacionesTrabajos_borrar": actividad_docente_a_eliminar
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