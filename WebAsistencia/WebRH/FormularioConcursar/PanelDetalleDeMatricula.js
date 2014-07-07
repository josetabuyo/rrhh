var PanelDetalleDeMatriculas = {
    mostrar: function (opciones) {
        //valores default
        var matricula = opciones.matricula || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeOtraCapacidad.htm", function () {
            _this.txt_numero = _this.ui.find("#txt_matricula_numero");
            _this.txt_numero.val(matricula.Numero);
            _this.txt_expedidaPor = _this.ui.find("#txt_matricula_expedida_por");
            _this.txt_expedidaPor.val(matricula.ExpedidoPor);
            _this.txt_fecha = _this.ui.find("#txt_matricula_fecha_inscripcion");
            _this.txt_fecha.val(matricula.FechaInscripcion);
            _this.txt_situacion = _this.ui.find("#txt_matricula_situacion");
            _this.txt_situacion.val(matricula.SituacionActual);



            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.matricula) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
             if (matricula.Id == "") {
                        matricula.Id = 0;
                    } 
                matricula.Numero = _this.txt_numero.val()
                matricula.ExpedidoPor = _this.txt_expedidaPor.val()
                matricula.FechaInscripcion = _this.txt_fecha.val();
                matricula.SituacionActual = __this.txt_situacion.val();

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "GuardarCVMatriculas",
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
        });
    }
}