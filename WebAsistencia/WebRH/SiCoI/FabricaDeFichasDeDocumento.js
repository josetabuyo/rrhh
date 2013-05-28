
var FabricaDeFichasDeDocumento = function (plantilla_ficha_chica, plantilla_ficha_grande, plantilla_transicion, lista_areas, area_del_usuario) {
    this.plantilla_ficha_chica = plantilla_ficha_chica;
    this.plantilla_ficha_grande = plantilla_ficha_grande;
    this.plantilla_transicion = plantilla_transicion;
    this.area_del_usuario = area_del_usuario;
    this.lista_areas = lista_areas;
};
FabricaDeFichasDeDocumento.prototype = {
    crearFichaChica: function (doc) {
        return new FichaChicaDeDocumento(doc, this.plantilla_ficha_chica.clone(), this, this.area_del_usuario);
    },
    crearFichaGrande: function (doc, ficha_chica) {
        return new FichaGrandeDeDocumento(doc, this.plantilla_ficha_grande.clone(), this.plantilla_transicion, this.lista_areas, ficha_chica);
    }
};