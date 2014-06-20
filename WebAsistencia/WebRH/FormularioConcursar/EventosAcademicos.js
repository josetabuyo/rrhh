var EventosAcademicos = {
    mostrar: function (evento_academico_original, alModificar) {
        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("EventosAcademicos.htm", function () {
            _this.denominacion = _this.ui.find("#txt_evento_academico_denominacion");
            _this.denominacion.val(evento_academico_original.Denominacion);
            _this.tipo_evento = _this.ui.find("#txt_evento_academico_tipo_evento");
            _this.tipo_evento.val(evento_academico_original.TipoDeEvento);
            _this.caracter_participacion = _this.ui.find("#txt_evento_academico_caracter_participacion");
            _this.caracter_participacion.val(evento_academico_original.CaracterDeParticipacion);
            _this.fecha_inicio = _this.ui.find("#txt_evento_academico_fecha_inicio");
            _this.fecha_inicio.val(evento_academico_original.FechaInicio);
            _this.fecha_fin = _this.ui.find("#txt_evento_academico_fecha_fin");
            _this.fecha_fin.val(evento_academico_original.FechaFinalizacion);
            _this.institucion = _this.ui.find("#txt_evento_academico_institucion");
            _this.institucion.val(evento_academico_original.Institucion);
            _this.duracion = _this.ui.find("#txt_evento_academico_duracion");
            _this.duracion.val(evento_academico_original.Duracion);
            _this.evento_academico_localidad = _this.ui.find("#txt_evento_academico_localidad");
            _this.evento_academico_localidad.val(evento_academico_original.Localidad);
            _this.cmb_evento_academico_pais = _this.ui.find("#cmb_evento_academico_pais");
            _this.cmb_evento_academico_pais.val(evento_academico_original.Pais);


            //Bt agregar
            _this.add_eventosAcademicos = _this.ui.find("#add_eventosAcademicos");
            _this.add_eventosAcademicos.click(function () {
                //var estudio_modificado = $.extend(true, estudio_original);
                evento_academico_original.Denominacion = _this.denominacion.val();
                evento_academico_original.TipoDeEvento = _this.tipo_evento.val();
                evento_academico_original.CaracterDeParticipacion = _this.caracter_participacion.val();
                evento_academico_original.Institucion = _this.institucion.val();
                evento_academico_original.Duracion = _this.duracion.val();
                evento_academico_original.FechaInicio = _this.fecha_inicio.val();
                evento_academico_original.FechaFinalizacion = _this.fecha_fin.val();
                evento_academico_original.Localidad = _this.evento_academico_localidad.val();
                evento_academico_original.Pais = _this.cmb_evento_academico_pais.val();


                var data_post = JSON.stringify({
                    "eventosAcademicos_nuevos": evento_academico_original,
                    "eventosAcademicos_originales": evento_academico_original
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarCvEventoAcademico",
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

            $('#txt_evento_academico_fecha_inicio').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#txt_evento_academico_fecha_fin').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    },
    armarGrilla: function (eventos_academicos) {
        var _this = this;

        contenedorPlanilla = $('#tabla_eventos_academicos');

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (un_evento_academico) { return un_evento_academico.Id } }));
        columnas.push(new Columna("Denominación", { generar: function (un_evento_academico) { return un_evento_academico.Denominacion } }));
        columnas.push(new Columna("Tipo de Evento", { generar: function (un_evento_academico) { return un_evento_academico.TipoDeEvento } }));
        columnas.push(new Columna("Institución", { generar: function (un_evento_academico) { return un_evento_academico.Institucion } }));
        columnas.push(new Columna("Duración", { generar: function (un_evento_academico) { return un_evento_academico.CaracterDeParticipacion } }));
        //columnas.push(new Columna("Caracter de Participación", { generar: function (un_evento_academico) { return un_evento_academico.Establecimiento } }));
        //columnas.push(new Columna("Fecha Inicio", { generar: function (un_evento_academico) { return un_evento_academico.FechaInicio } }));
        //columnas.push(new Columna("Fecha Fin", { generar: function (un_evento_academico) { return un_evento_academico.FechaFinalizacion } }));
        //columnas.push(new Columna("Localidad", { generar: function (un_evento_academico) { return un_evento_academico.Localidad } }));
        //columnas.push(new Columna("Pais", { generar: function (un_evento_academico) { return un_evento_academico.Pais } }));
        columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (un_evento_academico) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '25px');
        botonEditar.attr('height', '25px');

        botonEditar.click(function () {
            EventosAcademicos.mostrar(un_evento_academico, function (evento_academico_modificada) {
                PlanillaCvEventosAcademicos.BorrarContenido();
                PlanillaCvEventosAcademicos.CargarObjetos(eventos_academicos);
            });
        });

        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '25px');
        botonEliminar.attr('height', '25px');

        botonEliminar.click(function () {
            EventosAcademicos.eliminar(un_evento_academico, function (evento_academico_eliminada) {
                PlanillaCvEventosAcademicos.QuitarObjeto(contenedorPlanilla, evento_academico_eliminada);
            });
        });

        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


PlanillaCvEventosAcademicos = new Grilla(columnas);
PlanillaCvEventosAcademicos.AgregarEstilo("table table-striped");
PlanillaCvEventosAcademicos.SetOnRowClickEventHandler(function (un_evento_academico) {
            // panelAlumno.CompletarDatosAlumno(un_alumno);
        });

PlanillaCvEventosAcademicos.CargarObjetos(eventos_academicos);
PlanillaCvEventosAcademicos.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (evento_academico_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "eventosAcademicos_borrar": evento_academico_a_eliminar
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarCVEventosAcademicos",
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