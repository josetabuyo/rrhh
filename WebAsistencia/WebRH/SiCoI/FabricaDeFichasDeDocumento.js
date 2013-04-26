
var FabricaDeFichasDeDocumento = function (plantilla_ficha_chica, plantilla_ficha_grande) {
    this.plantilla_ficha_chica = plantilla_ficha_chica;
    this.plantilla_ficha_grande = plantilla_ficha_grande;
};
FabricaDeFichasDeDocumento.prototype = {
    crearFichaChica: function (doc) {
        return new FichaChicaDeDocumento(doc, this.plantilla_ficha_chica.clone(), this);
    },
    crearFichaGrande: function (doc) {
        return new FichaGrandeDeDocumento(doc, this.plantilla_ficha_grande.clone());
    }
};