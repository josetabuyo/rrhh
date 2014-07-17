var PanelDetalleDeMatriculas = {
    mostrar: function (opciones) {
        //valores default
        var matricula = opciones.matricula || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeMatricula.htm", function () {
            _this.txt_numero = _this.ui.find("#txt_matricula_numero");
            _this.txt_numero.val(matricula.Numero);
            _this.txt_expedidaPor = _this.ui.find("#txt_matricula_expedida_por");
            _this.txt_expedidaPor.val(matricula.ExpedidaPor);
            _this.txt_fecha = _this.ui.find("#txt_matricula_fecha_inscripcion");
            _this.txt_fecha.datepicker();
            _this.txt_fecha.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_fecha.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(matricula.FechaInscripcion));
            
            _this.txt_situacion = _this.ui.find("#txt_matricula_situacion");
            _this.txt_situacion.val(matricula.SituacionActual);


            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.matricula) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                matricula.Numero = _this.txt_numero.val();
                matricula.ExpedidaPor = _this.txt_expedidaPor.val();
                matricula.FechaInscripcion = _this.txt_fecha.datepicker('getDate').toISOString();
                matricula.SituacionActual = _this.txt_situacion.val();

                var proveedor_ajax = new ProveedorAjax();

                if (opciones.matricula) {
                    proveedor_ajax.postearAUrl({ url: "ActualizarCvMatricula",
                        data: {
                            una_matricula: matricula
                        },
                        success: function (respuesta) {
                            alertify.alert("La matrícula fue creada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al crear la matrícula.");
                        }
                    });

                    return;
                }
                proveedor_ajax.postearAUrl({ url: "GuardarCVMatricula",
                    data: {
                        matricula: matricula,
                        
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la matrícula.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

            
            $('#txt_matricula_fecha_inscripcion').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    }
}