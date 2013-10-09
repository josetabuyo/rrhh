var SelectorDeUsuarios = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

SelectorDeUsuarios.prototype.start = function () {
    this.txt_buscador = this.ui.find("#txt_buscador");
    this.btn_buscar_usuario = this.ui.find("#btn_buscar_usuario");
    var _this = this;
    this.btn_buscar_usuario.click(function () {
        _this.alSeleccionarUnUsuario({ nombre: 'agus', apellido: 'calco', idInterna: 123456 });
    });
};