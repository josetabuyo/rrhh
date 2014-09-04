var PanelListaDeMatriculas = {
    armarGrilla: function (matriculas) {
        var _this = this;

        _this.divGrilla = $('#tabla_matriculas');
        _this.btn_agregar_otra_matricula = $("#btn_agregar_matricula");

        _this.btn_agregar_otra_matricula.click(function () {
            PanelDetalleDeMatriculas.mostrar({
                alModificar: function (nueva_matricula) {
                    _this.GrillaMatriculas.BorrarContenido();
                    matriculas.push(nueva_matricula);
                    _this.GrillaMatriculas.CargarObjetos(matriculas);
                }
            });
        });

        var columnas = [];

        //columnas.push(new Columna("Id", { generar: function (una_matricula) { return una_matricula.Id } }));
        columnas.push(new Columna("Número", { generar: function (una_matricula) { return una_matricula.Numero } }));
        columnas.push(new Columna("Expedida Por", { generar: function (una_matricula) { return una_matricula.ExpedidaPor } }));
        //columnas.push(new Columna("Situación Actual", { generar: function (una_matricula) { return una_matricula.SituacionActual } }));
        columnas.push(new Columna("Fecha", { generar: function (una_matricula) {  return ConversorDeFechas.deIsoAFechaEnCriollo(una_matricula.FechaInscripcion)} })); 
        columnas.push(new Columna('Acciones', {
            generar: function (una_matricula) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeMatriculas.mostrar({
                        matricula: una_matricula,
                        alModificar: function (matricula_modificada) {
                            _this.GrillaMatriculas.BorrarContenido();
                            _this.GrillaMatriculas.CargarObjetos(matriculas);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_matricula);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaMatriculas = new Grilla(columnas);
        this.GrillaMatriculas.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaMatriculas.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaMatriculas.SetOnRowClickEventHandler(function (una_matricula) {
        });

        this.GrillaMatriculas.CargarObjetos(matriculas);
        this.GrillaMatriculas.DibujarEn(_this.divGrilla);

        this.matriculas = matriculas;
    },
    eliminar: function (una_matricula) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la matrícula?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCvMatricula",
                    data: {
                        id_matricula: una_matricula.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Matrícula eliminada correctamente");
                        _this.GrillaMatriculas.QuitarObjeto(_this.divGrilla, una_matricula);
                        var indice = _this.matriculas.indexOf(una_matricula);
                        _this.matriculas.splice(indice, 1);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la matrícula");
                    }
                });
            } else {
                // user clicked "cancel"
                //alertify.error("No se pudo eliminar la capacidad");
            }
        });



    }
}
