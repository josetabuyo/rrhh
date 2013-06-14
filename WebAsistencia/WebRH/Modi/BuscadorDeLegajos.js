var BuscadorDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

BuscadorDeLegajos.prototype.start = function () {
    this.input_numero = this.o.ui.find('#input_numero');
    this.boton_buscar = this.o.ui.find('#boton_buscar');
    this.aviso_legajo_no_encontrado = this.o.ui.find('#aviso_legajo_no_encontrado');
    this.aviso_legajo_no_encontrado.hide();
    var _this = this;
    this.boton_buscar.click(function () { _this.buscar(); });
};
BuscadorDeLegajos.prototype.buscar = function () {
    var _this = this;
    this.o.servicioDeLegajos.getLegajo(parseInt(this.input_numero.val()), //numero_legajo
                                       function (respuesta) {
                                           _this.aviso_legajo_no_encontrado.hide();
                                           _this.o.vistaDeResultados.mostrarLegajo(respuesta);
                                       },
                                       function () {
                                           _this.aviso_legajo_no_encontrado.text("Legajo no encontrado");                                            
                                           _this.aviso_legajo_no_encontrado.show();
                                       },
                                       function () {
                                           _this.aviso_legajo_no_encontrado.text("Error de comunicaciones");
                                           _this.aviso_legajo_no_encontrado.show();
                                       });
};
BuscadorDeLegajos.prototype.mostrandoAvisoDeLegajoNoEncontrado = function () {
    return this.aviso_legajo_no_encontrado.css('display') != 'none';
};
                                   

