var FichaDeDocumento = function (documento, ui) {
    this.ui = ui;
    this.ticket = ui.find("#ficha_chica_contenido_ticket");
    this.tipo = ui.find("#ficha_chica_contenido_tipo");
    this.categoria = ui.find("#ficha_chica_contenido_categoria");
    this.extracto = ui.find("#ficha_chica_contenido_extracto");
    this.area_actual = ui.find("#ficha_chica_contenido_area_actual");

    this.ticket.text(documento.ticket);
    this.tipo.text(documento.tipo.descripcion);
    this.categoria.text(documento.categoria.descripcion);
    this.extracto.text(documento.extracto);
    this.area_actual.text(documento.areaActual.descripcion);
}
FichaDeDocumento.prototype = {
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

var FabricaDeFichasDeDocumento = function (plantilla_ficha) {
    this.plantilla_ficha = plantilla_ficha;
};
FabricaDeFichasDeDocumento.prototype = {
    crearFicha: function (doc) {
        return new FichaDeDocumento(doc, this.plantilla_ficha.clone());
    }
};