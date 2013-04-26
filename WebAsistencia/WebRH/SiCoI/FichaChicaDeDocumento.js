var FichaChicaDeDocumento = function (documento, ui, fabrica_de_fichas) {
    this.ui = ui;
    this.fabrica_de_fichas = fabrica_de_fichas;
    this.documento = documento;
    this.start();
}
FichaChicaDeDocumento.prototype = {
    start: function () {
        this.ticket = this.ui.find("#ficha_chica_contenido_ticket");
        this.tipo = this.ui.find("#ficha_chica_contenido_tipo");
        this.categoria = this.ui.find("#ficha_chica_contenido_categoria");
        this.extracto = this.ui.find("#ficha_chica_contenido_extracto");
        this.area_actual = this.ui.find("#ficha_chica_contenido_area_actual");
        this.boton_desplegar = this.ui.find("#ficha_chica_boton_desplegar");
        var self = this;
        this.boton_desplegar.click(function () {
            self.toggleFichaGrande();
            self.boton_desplegar.toggleClass("icon-plus-sign");
            self.boton_desplegar.toggleClass("icon-minus-sign");
        });
        this.mostrarDocumento();
    },
    toggleFichaGrande: function () {
        if (this.ficha_grande === undefined) {
            this.ficha_grande = this.fabrica_de_fichas.crearFichaGrande(this.documento);
            this.ficha_grande.dibujarEn(this.ui);
            return;
        }
        this.ficha_grande.borrar();
        this.ficha_grande = undefined;
    },
    mostrarDocumento: function (documento) {
        this.ticket.text(this.documento.ticket);
        this.tipo.text(this.documento.tipo.descripcion);
        this.categoria.text(this.documento.categoria.descripcion);
        this.extracto.text(this.documento.extracto);
        this.area_actual.text(this.documento.areaActual.descripcion);
    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    },
    getAreaResumida: function (descripcion) {
        descripcion = descripcion.replace("Direccion", "Dir.");
        descripcion = descripcion.replace("Dirección", "Dir.");
        descripcion = descripcion.replace("dirección", "Dir.");
        descripcion = descripcion.replace("direccion", "Dir.");
        return this.getTextoresumido(descripcion);
    },
    getTextoresumido: function (texto) {
        if (texto.length < 20) return texto;
        var textoResumido = $("<div>");
        textoResumido.text(texto.substring(0, 20) + "...");
        textoResumido.attr("title", texto);
        return textoResumido;
    }
}