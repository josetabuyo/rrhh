var PantallaRegistro = {
    abrir: function () {
        var _this = this;
        this.ui = $("#registrarse_dialog");

        this.ui.load("RegistroPostular/PantallaRegistro.htm", function () {
            _this.panel_paso_1 = $("#panel_paso_1");
            _this.panel_paso_2 = $("#panel_paso_2");
            _this.abrir = function () {
                _this.mostrar();
            };
            _this.mostrar();
        });


        this.proveedor_ajax = new ProveedorAjax();
    },
    mostrar: function () {
        vex.dialog.open({
            message: "Ingrese su DNI",
            input: this.ui,
            buttons: [
                ]
        });
        this.ui.limpiarValidaciones();
        this.paso1();
    },
    paso1: function () {
        var _this = this;
        this.btn_validar = $("#btn_validar");
        this.txt_numero_documento = $("#txt_numero_documento");
        this.txt_numero_documento.val("");
        this.panel_paso_1.show();
        this.panel_paso_2.hide();
        this.btn_validar.click(function () {
            if (_this.panel_paso_1.esValido()) {
                _this.proveedor_ajax.postearAUrl({ url: "BuscarPersonas",
                    data: { 
                        criterio: JSON.stringify({
                                        Documento: parseInt(_this.txt_numero_documento.val()),
                                        ConLegajo: true
                                    })
                    },
                    success: function (personas) {
                        if (personas.length > 0) {
                            alertify.alert("El documento ingresado ya está registrado, inicie sesión o comuníquese con Recursos Humanos.");
                            return;
                        }
                        _this.paso2();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {

                    }
                });
            } else {
                alertify.error("Hay campos inválidos");
            }
        });
    },
    paso2: function () {
        var _this = this;
        this.panel_paso_1.hide();
        this.panel_paso_2.show();

        $(".vex-dialog-message").text("Complete sus datos");
        this.lbl_numero_documento = $("#lbl_numero_documento");
        this.lbl_numero_documento.text("");
        this.txt_nombre = $("#txt_nombre");
        this.txt_nombre.val("");
        this.txt_apellido = $("#txt_apellido");
        this.txt_apellido.val("");
        this.txt_email = $("#txt_email");
        this.txt_email.val("");
        this.btn_registrarse = $("#btn_registrarse");

        this.lbl_numero_documento.text(this.txt_numero_documento.val());

        this.btn_registrarse.click(function () {
            var controles_ = true;

            if (_this.panel_paso_2.esValido()) {
                _this.proveedor_ajax.postearAUrl({ url: "RegistrarNuevoUsuario",
                    data: {
                        aspirante: {
                            Documento: _this.txt_numero_documento.val(),
                            Nombre: _this.txt_nombre.val(),
                            Apellido: _this.txt_apellido.val(),
                            Email: _this.txt_email.val()
                        }
                    },
                    success: function () {
                        alertify.alert("Se le ha enviado un mail con su nombre de usuario y contraseña", function(){
                            vex.closeAll();
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al registrar el usuario, inténtelo nuevamente.");
                    }
                });
            }
            else {
                alertify.error("Hay campos inválidos");
            }
        });
    }
};


$.fn.extend({
    validaciones: {
        esEmailValido: {
            evaluar: function (control) {
                return control.val().length > 0 && (/^([\w\-\.]+@([\w\-]+\.)+[\w\-]{2,6})?$/).test(control.val());
            },
            mensaje: "No es un email válido"
        },
        esNumeroNatural: {
            evaluar: function (control) {
                return (/^\d+$/).test(control.val());
            },
            mensaje: "No es un número natural"
        },
        esNoBlanco: {
            evaluar: function (control) {
                return control.val().toString().length > 0;
            },
            mensaje: "Es un campo vacío"
        }
    },
    esValido: function () {
        var _this = this;
        var esValido = true;
        this.find("[data-validar]").each(function () {
            var control = this;
            var v = $(this).attr("data-validar").split(",");
            var mensaje = "";
            $.each(v, function (indice, valor) {
                var res = _this.validaciones[valor].evaluar($(control));
                if (res) {
                    $(control).removeClass("control-invalido");
                }
                else {
                    $(control).addClass("control-invalido");
                    mensaje += ", " + _this.validaciones[valor].mensaje;
                    esValido = res;
                }
            });
            $(control).attr("title", mensaje.substring(2));

        });
        return esValido;
    },
    limpiarValidaciones: function () {
        this.find("[data-validar]").each(function () {
            var control = this;
            $(control).removeClass("control-invalido");
        });
    }
});
