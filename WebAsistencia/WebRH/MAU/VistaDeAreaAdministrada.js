var VistaDeAreaAdministrada = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDeAreaAdministrada.prototype.start = function () {
    this.ui = $("#plantillas").find(".area_administrada").clone();
    this.ui.find("#nombre_area").text(this.area.nombre);
    var _this = this;
    this.ui.find("#btn_quitar_area").click(function () {
        _this.autorizador.desAsignarAreaAUnUsuario(_this.usuario.Id, _this.area.id,
            function () { //on success
                _this.ui.remove();
            },
            function () { //on error
                alertify.error("Error al quitar el área");
            });
    });
};

VistaDeAreaAdministrada.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};