
var PanelDeControlDeAlertas = function (options) {
    this.o = options;
    this.start();
}

PanelDeControlDeAlertas.prototype.start = function () {
    var _this = this;
    this.btnStart = this.o.ui.find("#btnIniciarServicioDeAlertas");
    this.btnStart.click(function () {
        _this.iniciarProceso();
    });
    this.btnStop = this.o.ui.find("#btnDetenerServicioDeAlertas");
    this.btnStop.click(function () {
        _this.detenerProceso();
    });
};

PanelDeControlDeAlertas.prototype.iniciarProceso = function () {
    $.ajax({
        url: "../AjaxWS.asmx/IniciarServicioDeAlertas",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    });
};

PanelDeControlDeAlertas.prototype.detenerProceso = function () {
    $.ajax({
        url: "../AjaxWS.asmx/DetenerServicioDeAlertas",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    });
};

