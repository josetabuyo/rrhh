var PanelListaDeCompetenciasInformaticas = {
    armarGrilla: function (competencias_informaticas) {
        var _this = this;

        _this.divGrilla = $('#tabla_competencias_informaticas');
        _this.btn_agregar_competencia_informatica = $("#btn_agregar_competencia_informatica");

        _this.btn_agregar_competencia_informatica.click(function () {
            PanelDetalleDeCompetenciaInformatica.mostrar({
                alModificar: function (nueva_competencia_informatica) {
                    _this.GrillaCompetenciasInformaticas.BorrarContenido();
                    competencias_informaticas.push(nueva_competencia_informatica);
                    _this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Diploma/Certificación", { generar: function (una_competencia_informatica) { return una_competencia_informatica.Diploma } }));
        columnas.push(new Columna("Fecha Obtención", { generar: function (una_competencia_informatica) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_competencia_informatica.FechaObtencion) } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_competencia_informatica) { return una_competencia_informatica.Establecimiento } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_competencia_informatica) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeCompetenciaInformatica.mostrar({
                        competencia_informatica: una_competencia_informatica,
                        alModificar: function (competencia_informatica_modificada) {
                            _this.GrillaCompetenciasInformaticas.BorrarContenido();
                            _this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_competencia_informatica);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaCompetenciasInformaticas = new Grilla(columnas);
        this.GrillaCompetenciasInformaticas.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaCompetenciasInformaticas.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaCompetenciasInformaticas.SetOnRowClickEventHandler(function (una_competencia_informatica) {
        });

        this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
        this.GrillaCompetenciasInformaticas.DibujarEn(_this.divGrilla);
        this.competencias = competencias_informaticas;

    },
    eliminar: function (una_competencia_informatica) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la competencia informática?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVCompetenciaInformatica",
                    data: {
                        id_competencia_informatica: una_competencia_informatica.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Competencia informática eliminada correctamente");
                        _this.GrillaCompetenciasInformaticas.QuitarObjeto(_this.divGrilla, una_competencia_informatica);
                        var indice = _this.competencias.indexOf(una_competencia_informatica);
                        _this.competencias.splice(indice, 1);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la competencia informática");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar la competencia informática");
            }
        });

    }
}
