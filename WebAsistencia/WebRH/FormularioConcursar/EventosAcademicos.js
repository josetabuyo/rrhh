var EventosAcademicos = {
    mostrar: function (evento, alModificar) {
        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("EventosAcademicos.htm", function () {
            _this.txt_evento_denominacion = _this.ui.find("#txt_evento_denominacion");
            _this.txt_evento_denominacion.val(evento.Denominacion);

            _this.txt_evento_academico_tipo_evento = _this.ui.find("#evento_academico_tipo_evento");
            _this.txt_evento_academico_tipo_evento.val(evento.EventoTipo);

            _this.txt_evento_academico_caracter_participacion = _this.ui.find("#txt_evento_academico_caracter_participacion");
            _this.txt_evento_academico_caracter_participacion.val(evento.Especialidad);

            _this.txt_evento_academico_fecha_inicio = _this.ui.find("#txt_evento_academico_fecha_inicio");
            _this.txt_evento_academico_fecha_inicio.val(evento.FechaIngreso);

            _this.txt_evento_academico_fecha_fin = _this.ui.find("#txt_evento_academico_fecha_fin");
            _this.txt_evento_academico_fecha_fin.val(evento.FechaEgreso);

            _this.txt_evento_academico_duracion = _this.ui.find("#txt_evento_academico_duracion");
            _this.txt_evento_academico_duracion.val(evento.Duracion);

            _this.txt_evento_academico_institucion = _this.ui.find("#txt_evento_academico_institucion");
            _this.txt_evento_academico_institucion.val(evento.Localidad);

            _this.txt_evento_academico_localidad = _this.ui.find("#txt_evento_academico_localidad");
            _this.txt_evento_academico_localidad.val(evento.Pais);

            _this.cmb_evento_academico_pais = _this.ui.find("#cmb_evento_academico_pais");
            _this.cmb_evento_academico_pais.val(evento.Pais);

            //Bt agregar
            _this.add_antecedentesAcademicos = _this.ui.find("#add_evento_academico");
            _this.add_antecedentesAcademicos.click(function () {
                var evento_nuevo = {};

                evento_nuevo.Denominacion = _this.txt_evento_denominacion.val();
                evento_nuevo.TipoEvento = _this.txt_evento_academico_tipo_evento.val();
                evento_nuevo.CaracterParticipacion = _this.txt_evento_academico_caracter_participacion.val();
                evento_nuevo.FechaInicio = _this.txt_evento_academico_fecha_inicio.val();
                evento_nuevo.FechaFin = _this.txt_evento_academico_fecha_fin.val();
                evento_nuevo.Duracion = _this.txt_evento_academico_duracion.val();
                evento_nuevo.Institucion = _this.txt_evento_academico_institucion.val();
                evento_nuevo.Localidad = _this.txt_evento_academico_localidad.val();
                evento_nuevo.Pais = _this.cmb_evento_academico_pais.val();

                var data_post = JSON.stringify({
                    "eventosAcademicos_nuevos": evento_nuevo,
                    "eventosAcademicos_originales": evento
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarCVEventoAcademico",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                        alertify.success("Los datos fueron guardados correctamente");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            });

            //Activar datePicker para el modal de AntecedentesAcademicos
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

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();


        });
    },
    armarGrilla: function (eventos) {
        var _this = this;
        
        contenedorPlanilla = $('#tabla_eventos_academicos');

        var columnas = [];
        columnas.push(new Columna("Id", { generar: function (un_evento) { return un_evento.Id } }));
        columnas.push(new Columna("Tipo", { generar: function (un_evento) { return un_evento.Titulo } }));
        columnas.push(new Columna("Carácter", { generar: function (un_evento) { return un_evento.Establecimiento } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (un_evento) { return un_evento.FechaInicio } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (un_evento) { return un_evento.FechaFin } }));
        columnas.push(new Columna("Duración", { generar: function (un_evento) { return un_evento.Duración } }));
        columnas.push(new Columna("Institución", { generar: function (un_evento) { return un_evento.Institución } }));
        columnas.push(new Columna("Localidad", { generar: function (un_evento) { return un_evento.Localidad } }));
        columnas.push(new Columna("País", { generar: function (un_evento) { return un_evento.Pais } }));
        columnas.push(new Columna("&nbsp", { generar: function (un_evento) {
            var contenedorBtnAcciones = $('<div>');
            var botonEditar = $('<img>');
            botonEditar.addClass('edit-item-btn');
            botonEditar.attr('src', '../Imagenes/edit.png');
            botonEditar.attr('style', 'padding-right:5px;');
            botonEditar.attr('width', '25px');
            botonEditar.attr('height', '25px');

            botonEditar.click(function () {
                EventosAcademicos.mostrar(un_evento, function (eventos_actualizados) {
                    PlanillaCvEventos.BorrarContenido();
                    PlanillaCvEventos.CargarObjetos(eventos_actualizados);
                });
            });

            contenedorBtnAcciones.append(botonEditar);

            var botonEliminar = $('<img>');
            botonEliminar.addClass('remove-item-btn');
            botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
            botonEliminar.attr('width', '25px');
            botonEliminar.attr('height', '25px');

            botonEliminar.click(function () {
                EventosAcademicos.eliminar(un_evento, function (evento_eliminado) {
                    PlanillaCvEventos.QuitarObjeto(contenedorPlanilla, evento_eliminado);
                });
            });

            contenedorBtnAcciones.append(botonEliminar);

            return contenedorBtnAcciones;
        }
        }));


        PlanillaCvEventosAcademicos = new Grilla(columnas);
        PlanillaCvEventosAcademicos.AgregarEstilo("table table-striped");
        PlanillaCvEventosAcademicos.SetOnRowClickEventHandler(function (un_evento) {
            return true;
        });

        PlanillaCvEventos.CargarObjetos(eventos);
        PlanillaCvEventos.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (evento_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "eventosAcademicos_borrar": evento_a_eliminar
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarCvEventosAcademicos",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alertify.success("Evento Académico eliminado correctamente");
                        alModificar(respuesta);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                        alertify.error("No se pudo eliminar el evento");
                    }
                });
            } else {
                // user clicked "cancel"

            }
        });



    }
}