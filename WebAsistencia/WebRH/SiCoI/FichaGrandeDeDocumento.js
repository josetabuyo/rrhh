
var FichaGrandeDeDocumento = function (documento, ui) {
    this.ui = ui;
    this.documento = documento;
    this.start();
};
FichaGrandeDeDocumento.prototype = {
    start: function () {
        this.area_creadora = this.ui.find("#ficha_grande_contenido_area_creadora");
        this.tiempo_en_area_actual = this.ui.find("#ficha_grande_contenido_tiempo_en_area_actual");
        this.comentarios = this.ui.find("#ficha_grande_contenido_comentarios");
        this.area_destino = this.ui.find("#ficha_grande_contenido_area_destino");

        this.mostrarDocumento();
    },
    mostrarDocumento: function () {
        this.area_creadora.text(this.documento.areaDestino.descripcion);
        this.tiempo_en_area_actual.text(this.documento.enAreaActualHace);
        this.comentarios.val(this.documento.comentarios);
        this.area_destino.val(this.documento.areaDestino.descripcion);
    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    },
    borrar: function () {
        this.ui.remove();
    }
};
