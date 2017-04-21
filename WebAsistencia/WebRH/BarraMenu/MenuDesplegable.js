
var MenuDesplegable = function (nombre_boton, elemento_desplegable, expandir_siempre) {
    var _this = this;
    this.expandirSiempre = expandir_siempre;
    _this.boton = $("#" + nombre_boton);
    _this.elemento_desplegable = $("#" + elemento_desplegable);

    _this.boton.click(function () {
        if (_this.cant_elementos_dibujados == 0 && !_this.expandirSiempre) _this.contraer();
        else _this.elemento_desplegable.toggle();
    });

    $(document).mouseup(function (e) {

        if (!_this.elemento_desplegable.is(e.target) && _this.elemento_desplegable.has(e.target).length === 0 && !_this.boton.is(e.target) && _this.boton.has(e.target).length === 0) {
            _this.elemento_desplegable.hide();
        }
    });
    this.cant_elementos_dibujados = 0;
};

MenuDesplegable.prototype.contraer = function () {
    this.elemento_desplegable.hide();
};

MenuDesplegable.prototype.agregar = function (elemento_dibujable) {
    var _this = this;
    this.cant_elementos_dibujados += 1;
    elemento_dibujable.dibujarEn(this.elemento_desplegable);
    elemento_dibujable.alQuitar = function () {
        _this.cant_elementos_dibujados -= 1;
        if (_this.cant_elementos_dibujados == 0 && !_this.expandirSiempre) _this.contraer();
    };
};