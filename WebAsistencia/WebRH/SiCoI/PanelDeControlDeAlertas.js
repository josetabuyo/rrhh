
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

    this.lblEstado = this.o.ui.find("#lblEstado");
    this.refrescarEstado();
};

PanelDeControlDeAlertas.prototype.iniciarProceso = function () {
    var _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/IniciarServicioDeAlertas",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            _this.refrescarEstado();
        }
    });
};

PanelDeControlDeAlertas.prototype.detenerProceso = function () {
    var _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/DetenerServicioDeAlertas",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            _this.refrescarEstado();
        }
    });
};

PanelDeControlDeAlertas.prototype.refrescarEstado = function () {
    var _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/EstadoServicioDeAlertas",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            _this.lblEstado.text(data.d);
        }
    });
};