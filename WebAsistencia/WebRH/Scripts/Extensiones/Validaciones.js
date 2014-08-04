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
                    $(control).opentip(mensaje.substring(2), {
                        target: true,
                        style: "alert",
                        showOn: "creation",
                        joint: "right"
                    });
                }
            });
            
            //$(control).attr("title", mensaje.substring(2));

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
