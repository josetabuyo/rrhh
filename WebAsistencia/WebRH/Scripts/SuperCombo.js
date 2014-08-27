var SuperCombo = function (opt) {
    this.al_seleccionar = function () {
    };
    this.objetos = [];
    var def = {
        campo_id: "Id",
        campo_descripcion: "Descripcion"
    };
    $.extend(true, this, def, opt);
    this.start();
};

SuperCombo.prototype.start = function () {
    var _this = this;
    this.ui.change(function () {
        if (_this.ui.val() != "") _this.idItemSeleccionado(parseInt(_this.ui.val()));
    });
	
	this.ui.change(this.onchange_callback);
    
    this.cargarBusqueda(this.nombre_repositorio, this.filtro, this.campo_id, this.campo_descripcion);
    this.idItemSeleccionado(this.id_item_seleccionado);
};

SuperCombo.prototype.idItemSeleccionado = function (id) {
    if (id === undefined) {
        if(this.id_item_seleccionado) return this.id_item_seleccionado;
        if(this.objetos.length > 0) return this.objetos[0][this.campo_id];
    }
    this.id_item_seleccionado = id;
    this.ui.val(id);
    this.al_seleccionar(this.id_item_seleccionado);
};

SuperCombo.prototype.itemSeleccionado = function (item) {
    if (item === undefined) {
        var filtro = {};
        filtro[this.campo_id] = this.id_item_seleccionado;
        return this.objetos.find(filtro);
    }
    this.idItemSeleccionado(item[this.campo_id]);
};

SuperCombo.prototype.cargarCombo = function (objetos, campo_id, campo_descripcion) {
    var _this = this;
    this.objetos = objetos;
    this.campo_id = campo_id;
    this.campo_descripcion = campo_descripcion;

    _this.ui.empty();
    objetos.forEach(function (item) {
        var option = $("<option value='" + item[campo_id] + "'>" + item[campo_descripcion] + "</option>");
        _this.ui.append(option);
    });
};

SuperCombo.prototype.cargarBusqueda = function (nombre_repositorio, filtro, campo_id, campo_descripcion) {
    var _this = this;
	if (this.nombre_repositorio) {
		if(_this.dependencia == undefined || (_this.dependencia != undefined && filtro != undefined )) {
			_this.repositorio.buscar(nombre_repositorio, filtro, function (items) {
				_this.cargarCombo(items, campo_id, campo_descripcion);
				_this.idItemSeleccionado(_this.idItemSeleccionado());
			});
		}
	}
};

SuperCombo.prototype.cambiarFiltro = function (filtro) {
    this.filtro = filtro;
    this.cargarBusqueda(this.nombre_repositorio, this.filtro, this.campo_id, this.campo_descripcion);
};

SuperCombo.prototype.desactivar = function () {
    this.ui[0].disabled = true;
};
