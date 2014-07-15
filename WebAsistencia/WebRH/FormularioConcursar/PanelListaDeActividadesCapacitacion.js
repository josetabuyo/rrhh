var PanelListaDeOtrasCapacidades = {
    armarGrilla: function (capacitaciones) {
        var _this = this;

        _this.divGrilla = $('#tabla_actividades_capacitacion');
        _this.btn_agregar_otra_actividad = $("#btn_agregar_actividades_capacitacion");

        _this.btn_agregar_otra_actividad.click(function () {
            PanelDetalleDeActividadDeCapacitacion.mostrar({
                alModificar: function (nueva_capacitacion) {
                    _this.GrillaActividadesDeCapacitacion.BorrarContenido();
                    capacitaciones.push(nueva_capacitacion);
                    _this.GrillaActividadesDeCapacitacion.CargarObjetos(capacitaciones);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Id } }));
        columnas.push(new Columna("Diploma De Certificacion", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.DiplomaDeCertificacion } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Establecimiento } }));
        columnas.push(new Columna("Especialidad", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Especialidad } }));
        columnas.push(new Columna("Duracion", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Duracion } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaInicio) } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaFinalizacion) } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Establecimiento } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_actividad_capacitacion) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeActividadDeCapacitacion.mostrar({
                        actividad: una_actividad_capacitacion,
                        alModificar: function (una_actividad_modificada) {
                            _this.GrillaActividadesDeCapacitacion.BorrarContenido();
                            _this.GrillaActividadesDeCapacitacion.CargarObjetos(capacitaciones);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_capacidad);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaActividadesDeCapacitacion = new Grilla(columnas);
        this.GrillaActividadesDeCapacitacion.AgregarEstilo("table table-striped");
        this.GrillaActividadesDeCapacitacion.SetOnRowClickEventHandler(function (una_actividad_capacitacion) {
        });

        this.GrillaActividadesDeCapacitacion.CargarObjetos(capacitaciones);
        this.GrillaActividadesDeCapacitacion.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_actividad_capacitacion) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la actividad?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVActividadDeCapacitacion",
                    data: {
                        una_capacidad: una_actividad_capacitacion.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Actividad eliminada correctamente");
                        _this.GrillaActividadesDeCapacitacion.QuitarObjeto(_this.divGrilla, una_capacidad);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la actividad");
                    }
                });
            } else {
                // user clicked "cancel"
                //alertify.error("No se pudo eliminar la capacidad");
            }
        });



    }
}
