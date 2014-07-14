var PanelDetalleDeAntecedenteAcademico = {
    mostrar: function (opciones) {
        //valores default
        var estudio = opciones.estudio || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeAntecedenteAcademico.htm", function () {
            //_this.txt_antecedentes_id = _this.ui.find("#txt_AntecedenteAcademico_id");
            //_this.txt_antecedentes_id.val(estudio.Id);
            _this.txt_antecedentes_titulo = _this.ui.find("#txt_antecedentes_titulo");
            _this.txt_antecedentes_titulo.val(estudio.Titulo);
            _this.cmb_antecedentes_nivel = _this.ui.find("#cmb_antecedentes_nivel");
            _this.cmb_antecedentes_nivel.val(estudio.Nivel);
            _this.txt_establecimiento = _this.ui.find("#txt_antecedentes_establecimiento");
            _this.txt_establecimiento.val(estudio.Establecimiento);
            _this.txt_antecedentes_especialidad = _this.ui.find("#txt_antecedentes_especialidad");
            _this.txt_antecedentes_especialidad.val(estudio.Especialidad);
            _this.txt_antecedentes_ingreso = _this.ui.find("#txt_antecedentes_ingreso");
            _this.txt_antecedentes_ingreso.val(estudio.FechaIngreso);
            _this.txt_antecedentes_egreso = _this.ui.find("#txt_antecedentes_egreso");
            _this.txt_antecedentes_egreso.val(estudio.FechaEgreso);
            _this.txt_antecedentes_localidad = _this.ui.find("#txt_antecedentes_localidad");
            _this.txt_antecedentes_localidad.val(estudio.Localidad);
            _this.cmb_antecedentes_pais = _this.ui.find("#cmb_antecedentes_pais");
            _this.cmb_antecedentes_pais.val(estudio.Pais);

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#add_antecedentesAcademicos");
            if (opciones.estudio) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                estudio.Titulo = _this.txt_antecedentes_titulo.val();
                estudio.Nivel = _this.cmb_antecedentes_nivel.val();
                estudio.Establecimiento = _this.txt_establecimiento.val();
                estudio.Especialidad = _this.txt_antecedentes_especialidad.val();
                estudio.FechaIngreso = _this.txt_antecedentes_ingreso.val();
                estudio.FechaEgreso = _this.txt_antecedentes_egreso.val();
                estudio.Localidad = _this.txt_antecedentes_localidad.val();
                estudio.Pais = _this.cmb_antecedentes_pais.val();

                var proveedor_ajax = new ProveedorAjax();
                if (opciones.estudio) {
                    proveedor_ajax.postearAUrl({ url: "ActualizarCvAntecedenteAcademico",
                        data: {
                            un_estudio: estudio
                        },
                        success: function (respuesta) {
                            alertify.alert("Los capacidad fue creada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al crear la capacidad.");
                        }
                    });

                    return;
                }
                proveedor_ajax.postearAUrl({ url: "GuardarCVAntecedenteAcademico",
                    data: {
                        antecedentesAcademicos_nuevos: estudio
                        
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar el antecedente.");
                    }
                });

            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

            $('#txt_antecedentes_ingreso').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#txt_antecedentes_egreso').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    }
}