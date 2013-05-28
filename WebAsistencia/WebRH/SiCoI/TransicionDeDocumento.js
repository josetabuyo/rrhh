var TransicionDeDocumento = function (ui, transicion) {
    this.ui = ui;
    this.transicion = transicion;
    this.start();
}
TransicionDeDocumento.prototype = {
    start: function () {
        this.fecha_de_ingreso = this.ui.find("#transicion_documento_fecha_de_ingreso");
        this.area_destino = this.ui.find("#transicion_documento_area_destino");

        this.fecha_de_ingreso.text(this.transicion.fecha);
        this.area_destino.text(this.transicion.areaDestino);
    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    }
}
