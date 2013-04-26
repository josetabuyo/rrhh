var FichaChicaDeDocumento = function (documento, ui, fabrica_de_fichas) {
    this.ui = ui;
    this.ticket = ui.find("#ficha_chica_contenido_ticket");
    this.tipo = ui.find("#ficha_chica_contenido_tipo");
    this.categoria = ui.find("#ficha_chica_contenido_categoria");
    this.extracto = ui.find("#ficha_chica_contenido_extracto");
    this.area_actual = ui.find("#ficha_chica_contenido_area_actual");
    this.boton_desplegar = ui.find("#ficha_chica_boton_desplegar");

    this.ticket.text(documento.ticket);
    this.tipo.text(documento.tipo.descripcion);
    this.categoria.text(documento.categoria.descripcion);
    this.extracto.text(documento.extracto);
    this.area_actual.text(documento.areaActual.descripcion);
}
FichaChicaDeDocumento.prototype = {
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