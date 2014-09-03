var PanelListaDeActividadesCapacitacion = {
    armarGrilla: function (actividades_capacitacion) {
        var _this = this;

        _this.divGrilla = $('#tabla_actividades_capacitacion');
        _this.btn_agregar_actividad_capacitacion = $("#btn_agregar_actividad_capacitacion");

        _this.btn_agregar_actividad_capacitacion.click(function () {
            PanelDetalleDeActividadCapacitacion.mostrar({
                alModificar: function (nueva_actividad_capacitacion) {
                    _this.GrillaActividadesCapacitacion.BorrarContenido();
                    actividades_capacitacion.push(nueva_actividad_capacitacion);
                    _this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Diploma/Certificación", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.DiplomaDeCertificacion } }));
        columnas.push(new Columna("Duración", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Duracion } }));
        //columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaInicio) } }));
        //columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaFinalizacion) } }));
        columnas.push(new Columna("Especialidad", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Especialidad } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_actividad_capacitacion) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeActividadCapacitacion.mostrar({
                        actividad_capacitacion: una_actividad_capacitacion,
                        alModificar: function (actividad_capacitacion_modificada) {
                            _this.GrillaActividadesCapacitacion.BorrarContenido();
                            _this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_actividad_capacitacion);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaActividadesCapacitacion = new Grilla(columnas);
        this.GrillaActividadesCapacitacion.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaActividadesCapacitacion.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaActividadesCapacitacion.SetOnRowClickEventHandler(function (una_actividad_capacitacion) {
        });

        this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
        this.GrillaActividadesCapacitacion.DibujarEn(_this.divGrilla);

        this.actividades = actividades_capacitacion;
    },
    eliminar: function (una_actividad_capacitacion) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la actividad?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVActividadCapacitacion",
                    data: {
                        id_actividad_capacitacion: una_actividad_capacitacion.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Actividad eliminada correctamente");
                        _this.GrillaActividadesCapacitacion.QuitarObjeto(_this.divGrilla, una_actividad_capacitacion);
                        var indice = _this.actividades.indexOf(una_actividad_capacitacion);
                        _this.actividades.splice(indice, 1);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la actividad");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar la actividad");
            }
        });



    }
}
