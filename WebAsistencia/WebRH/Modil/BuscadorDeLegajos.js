var BuscadorDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

BuscadorDeLegajos.prototype.start = function () {
    this.input_numero = this.o.ui.find('#input_numero');
    this.boton_buscar = this.o.ui.find('#boton_buscar');
    var _this = this;
    this.boton_buscar.click(function () { _this.buscar(); });
};
BuscadorDeLegajos.prototype.buscar = function () {
    this.o.repositorioDeLegajos.getLegajo(parseInt(this.input_numero.val()));
};

