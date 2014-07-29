var PanelDetalleDeActividadDocente = {
    mostrar: function (opciones) {
        //valores default
        var docencia = opciones.docencia || {
            NivelEducativo: {Id:0},
            Pais: 9
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeActividadDocente.htm", function () {
            _this.txt_asignatura = _this.ui.find("#txt_actividad_docente_asignatura");
            _this.txt_asignatura.val(docencia.Asignatura);

            _this.cmb_nivel_educativo = new SuperCombo({
                ui: _this.ui.find("#cmb_actividad_docente_nivel_educativo"),
                nombre_repositorio: "NivelesDeDocencia",
                campo_id: "Id",
                campo_descripcion: "Descripcion",
                id_item_seleccionado: docencia.NivelEducativo
            });

            _this.tipo_actividad = _this.ui.find("#txt_actividad_docente_tipo_actividad");
            _this.tipo_actividad.val(docencia.TipoActividad);
            _this.categoria_docente = _this.ui.find("#txt_actividad_docente_categoria");
            _this.categoria_docente.val(docencia.CategoriaDocente);
            _this.caracter_designacion = _this.ui.find("#txt_actividad_docente_caracter_designacion");
            _this.caracter_designacion.val(docencia.CaracterDesignacion);
            _this.dedicacion_docente = _this.ui.find("#txt_actividad_docente_dedicacion");
            _this.dedicacion_docente.val(docencia.DedicacionDocente);
            _this.carga_horaria = _this.ui.find("#txt_actividad_docente_carga_horaria");
            _this.carga_horaria.val(docencia.CargaHoraria);

            _this.fecha_inicio = _this.ui.find("#txt_actividad_docente_fecha_inicio");
            _this.fecha_inicio.datepicker();
            _this.fecha_inicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.fecha_inicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(docencia.FechaInicio));

            _this.fecha_fin = _this.ui.find("#txt_actividad_docente_fecha_fin");
            _this.fecha_fin.datepicker();
            _this.fecha_fin.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.fecha_fin.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(docencia.FechaFinalizacion));

            _this.establecimiento = _this.ui.find("#txt_actividad_docente_establecimiento");
            _this.establecimiento.val(docencia.Establecimiento);
            _this.cmb_actividad_docente_localidad = _this.ui.find("#cmb_actividad_docente_localidad");
            _this.cmb_actividad_docente_localidad.val(docencia.Localidad);

            _this.cmb_actividad_docente_pais = new SuperCombo({
                ui: _this.ui.find("#cmb_actividad_docente_pais"),
                nombre_repositorio: "Paises",
                campo_id: "Id",
                campo_descripcion: "Descripcion",
                id_item_seleccionado: docencia.Pais
            });

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#add_actividadesDocentes");
            if (opciones.docencia) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                if (docencia.Id == "") {
                    docencia.Id = 0;
                }

                docencia.Asignatura = _this.txt_asignatura.val();
                docencia.NivelEducativo = _this.cmb_nivel_educativo.idItemSeleccionado();
                docencia.TipoActividad = _this.tipo_actividad.val();
                docencia.CategoriaDocente = _this.categoria_docente.val();
                docencia.CaracterDesignacion = _this.caracter_designacion.val();
                docencia.DedicacionDocente = _this.dedicacion_docente.val();
                docencia.CargaHoraria = _this.dedicacion_docente.val();
                docencia.FechaInicio = _this.fecha_inicio.datepicker('getDate').toISOString();
                docencia.FechaFinalizacion = _this.fecha_fin.datepicker('getDate').toISOString();
                docencia.Establecimiento = _this.establecimiento.val();
                docencia.Localidad = _this.cmb_actividad_docente_localidad.val();
                docencia.Pais = _this.cmb_actividad_docente_pais.idItemSeleccionado();

                var proveedor_ajax = new ProveedorAjax();


                proveedor_ajax.postearAUrl({ url: "GuardarCvActividadesDocentes",
                    data: {
                        docencia_nueva: docencia,
                        docencia_original: docencia
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}