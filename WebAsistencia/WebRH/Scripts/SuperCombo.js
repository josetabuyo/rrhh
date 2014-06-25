var SuperCombo = function (opt) {
    this.al_seleccionar = function () {
    };
    this.id_item_seleccionado = -1;
    this.objetos = [];
    $.extend(this, opt, true);
    this.start();
};

SuperCombo.prototype.start = function () {
    var _this = this;
    this.ui.change(function () {
        if (_this.ui.val() != "") _this.idItemSeleccionado(parseInt(_this.ui.val()));
    });
    if (this.nombre_repositorio) {
        this.cargarBusqueda(this.nombre_repositorio, this.filtro, this.str_val, this.str_descripcion);
    };
    this.idItemSeleccionado(this.id_item_seleccionado);
};

SuperCombo.prototype.idItemSeleccionado = function (id) {
    if (id === undefined) return this.id_item_seleccionado;
    this.id_item_seleccionado = id;
    this.ui.val(id);
    this.al_seleccionar(this.id_item_seleccionado);
};

SuperCombo.prototype.itemSeleccionado = function (item) {
    if (item === undefined) {
        var filtro = {};
        filtro[this.str_val] = this.id_item_seleccionado;
        return this.objetos.find(filtro);
    }
    this.idItemSeleccionado(item[this.str_val]);
};

SuperCombo.prototype.cargarCombo = function (objetos, str_val, str_descripcion) {
    var _this = this;
    this.objetos = objetos;
    this.str_val = str_val;
    this.str_descripcion = str_descripcion;

    _this.ui.empty();
    objetos.forEach(function (item) {
        var option = $("<option value='" + item[str_val] + "'>" + item[str_descripcion] + "</option>");
        _this.ui.append(option);
    });
};

SuperCombo.prototype.cargarBusqueda = function (nombre_repositorio, filtro, str_val, str_descripcion) {
    var _this = this;
    Repositorio.buscar(nombre_repositorio, filtro, function (items) {
        _this.cargarCombo(items, str_val, str_descripcion);
        _this.idItemSeleccionado(_this.idItemSeleccionado());
    });
};

SuperCombo.prototype.cambiarFiltro = function (filtro) {
    this.filtro = filtro;
    this.cargarBusqueda(this.nombre_repositorio, this.filtro, this.str_val, this.str_descripcion);
};

SuperCombo.prototype.desactivar = function () {
    this.ui[0].disabled = true;
};
