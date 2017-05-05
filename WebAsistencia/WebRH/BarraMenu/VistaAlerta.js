var VistaAlerta = function (alerta) {
    var _this = this;
    this.alerta = alerta;
    this.ui = $("#plantillas_barra_menu .ui_mensaje_alerta").clone();
    this.ui.find(".titulo_mensaje_alerta").text(alerta.Titulo);
    this.ui.find(".contenido_mensaje_alerta").text(alerta.Descripcion);
    this.ui.find("#btn_ok").click(function () {
        Backend.MarcarAlertaComoLeida(alerta.Id).onSuccess(function () {
            _this.ui.remove();
            _this.alQuitar();
        });
    });
};

VistaAlerta.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};
