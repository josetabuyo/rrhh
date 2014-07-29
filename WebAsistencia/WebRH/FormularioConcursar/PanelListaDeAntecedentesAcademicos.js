var PanelListaDeAntecedentesAcademicos = {
    armarGrilla: function (estudios) {

        var _this = this;

        _this.divGrilla = $('#tabla_antecedentes_academicos');
        _this.btn_agregar_otro_antecedente = $("#btn_agregar_antecedente_academico");

        _this.btn_agregar_otro_antecedente.click(function () {
            PanelDetalleDeAntecedenteAcademico.mostrar({
                alModificar: function (nuevo_antecedente) {
                    _this.GrillaAntecedentesAcademicos.BorrarContenido();
                    estudios.push(nuevo_antecedente);
                    _this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
                }
            });
        });

        var columnas = [];

        var columnas = [];

        //columnas.push(new Columna("Id", { generar: function (un_estudio) { return un_estudio.Id } }));
        columnas.push(new Columna("Título", { generar: function (un_estudio) { return un_estudio.Titulo } }));
        columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.Nivel } }));
        columnas.push(new Columna("Establecimiento", { generar: function (un_estudio) { return un_estudio.Establecimiento } }));
        //columnas.push(new Columna("Especialidad", { generar: function (un_estudio) { return un_estudio.Especialidad } }));
        //columnas.push(new Columna("FechaIngreso", { generar: function (un_estudio) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_estudio.FechaIngreso) } }));
        //columnas.push(new Columna("FechaEgreso", { generar: function (un_estudio) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_estudio.FechaEgreso) } }));
        //columnas.push(new Columna("Localidad", { generar: function (un_estudio) { return un_estudio.Localidad } }));
        //columnas.push(new Columna("Pais", { generar: function (un_estudio) { return un_estudio.Pais } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_estudio) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeAntecedenteAcademico.mostrar({
                        estudio: un_estudio,
                        alModificar: function (estudio_modificado) {
                            _this.GrillaAntecedentesAcademicos.BorrarContenido();
                            _this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_estudio);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaAntecedentesAcademicos = new Grilla(columnas);
        this.GrillaAntecedentesAcademicos.AgregarEstilo("table table-striped");
        this.GrillaAntecedentesAcademicos.SetOnRowClickEventHandler(function (un_estudio) {
        });

        this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
        this.GrillaAntecedentesAcademicos.DibujarEn(_this.divGrilla);

        this.estudios = estudios;
    },
    eliminar: function (un_estudio) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la capacidad?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVAntecedenteAcademico",
                    data: {
                        antecedentesAcademicos_borrar: un_estudio.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Antecedente eliminado correctamente");
                        _this.GrillaAntecedentesAcademicos.QuitarObjeto(_this.divGrilla, un_estudio);
                        var indice = _this.estudios.indexOf(un_estudio);
                        _this.estudios.splice(indice, 1);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar el antecedente");
                    }
                });
            } else {
                // user clicked "cancel"
                //alertify.error("No se pudo eliminar la capacidad");
            }
        });



    }
}
