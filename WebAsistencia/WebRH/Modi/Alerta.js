var Alerta = function (mensaje) {
    this.mensaje = mensaje;
    this.start();
};

Alerta.prototype.start = function () {
    var _this = this;
    this.ui = $("#plantilla_alerta").clone();
    this.lbl_mensaje = this.ui.find("#lbl_mensaje");
    this.lbl_mensaje.text(this.mensaje);

    this.ui.dialog({
        title: "Error",
        modal: true,
        buttons: [
            { text: "Ok",
                click: function () {
                    _this.ui.dialog("close");
                }
            }
        ],
        show: {
            effect: "fade",
            duration: 300
        }
    });
};