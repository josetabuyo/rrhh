var VistaDeAreaAdministrada = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDeAreaAdministrada.prototype.start = function () {
    this.ui = $("#plantillas").find(".area_administrada").clone();
    this.ui.find("#nombre_area").text(this.area.Nombre);
};

VistaDeAreaAdministrada.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};