
var FichaGrandeDeDocumento = function (documento, ui, lista_areas) {
    this.ui = ui;
    this.documento = documento;
    this.lista_areas = lista_areas;
    this.start();
};
FichaGrandeDeDocumento.prototype = {
    start: function () {
        this.area_creadora = this.ui.find("#ficha_grande_contenido_area_creadora");
        this.tiempo_en_area_actual = this.ui.find("#ficha_grande_contenido_tiempo_en_area_actual");
        this.comentarios = this.ui.find("#ficha_grande_contenido_comentarios");
        this.div_area_destino = this.ui.find("#ficha_grande_contenido_area_destino");

        this.mostrarDocumento();
    },
    mostrarDocumento: function () {
        this.area_creadora.text(this.documento.areaCreadora.descripcion);
        this.tiempo_en_area_actual.text(this.documento.enAreaActualHace.dias + " dias");
        this.comentarios.val(this.documento.comentarios);

        this.selector_de_area_destino = new InputAutocompletableDeAreas(this.div_area_destino, this.lista_areas);

        if (this.documento.areaDestino == null) this.selector_de_area_destino.limpiar();
        else this.selector_de_area_destino.setAreaSeleccionada(this.documento.areaDestino);
    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    },
    borrar: function () {
        this.ui.remove();
    }
};
