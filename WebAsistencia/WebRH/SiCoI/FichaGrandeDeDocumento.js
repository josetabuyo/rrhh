
var FichaGrandeDeDocumento = function (documento, ui) {
    this.ui = ui;
    this.documento = documento;
    this.tipo_de_documento = this.ui.find("#ficha_grande_contenido_tipo_de_documento");
    this.numero_de_documento = this.ui.find("#ficha_grande_contenido_numero_de_documento");
    this.mostrarDocumento(documento);
};
FichaGrandeDeDocumento.prototype = {
    mostrarDocumento: function (documento) {
        this.tipo_de_documento.text(documento.tipo.descripcion);
        this.numero_de_documento.text(documento.numero);   
    }
};
