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
                                       function (legajo) {
                                           _this.o.vistaDeResultados.mostrarLegajo(legajo);
                                       },
                                       function (mensaje_error) {
                                           _this.aviso_legajo_no_encontrado.text(mensaje_error);                                            
                                           _this.aviso_legajo_no_encontrado.show();
                                       });
};
BuscadorDeLegajos.prototype.mostrandoAvisoDeLegajoNoEncontrado = function () {
    return this.aviso_legajo_no_encontrado.css('display') != 'none';
};
                                   

