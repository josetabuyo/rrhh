var PanelDetalleDeEventoAcademico = {
    mostrar: function (opciones) {
        //valores default
        var evento = opciones.evento || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeEventoAcademico.htm", function () {
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
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.evento) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                evento.Denominacion = _this.txt_evento_denominacion.val();
                evento.TipoEvento = _this.txt_evento_academico_tipo_evento.val();
                evento.CaracterParticipacion = _this.txt_evento_academico_caracter_participacion.val();
                evento.FechaInicio = _this.txt_evento_academico_fecha_inicio.val();
                evento.FechaFin = _this.txt_evento_academico_fecha_fin.val();
                evento.Duracion = _this.txt_evento_academico_duracion.val();
                evento.Institucion = _this.txt_evento_academico_institucion.val();
                evento.Localidad = _this.txt_evento_academico_localidad.val();
                evento.Pais = _this.cmb_evento_academico_pais.val();

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "GuardarCvEventoAcademico",
                    data: {
                        eventoAcademico: evento
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar el evento académico.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}