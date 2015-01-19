var ComboConBusquedaYAgregado = function (opt) {
    var _this = this;
    var def = {
        propiedadId: "Id",
        propiedadLabel: "Descripcion",
        filtro: {}
    }
    $.extend(true, this, def, opt);

    this.objetosCargados = [];
    this.callbacks_change = [];

    this.select.select2({
        placeholder: this.placeHolder || 'seleccione',
        allowClear: true,
        width: 'resolve'
    });

    this.select.on("change", function (e) {
        var val_en_combo = _this.select.select2("val");
        if (val_en_combo == "") {
            _this.limpiarSeleccion();
            return;
        }
        var id_as_number = parseInt(val_en_combo);
        if (isNaN(id_as_number)) _this.idSeleccionado(val_en_combo);
        else _this.idSeleccionado(id_as_number);
    });

    if (this.dataProvider) {
        this.cargarComboDesdeProveedor();
    } else {
        this.cargarComboDesdeOpciones();
    }
};

ComboConBusquedaYAgregado.prototype.idSeleccionado = function (id_seleccionado) {
    if (id_seleccionado !== undefined) {
        this._id_seleccionado = id_seleccionado;
        if (this.objetosCargados.length > 0) {
            var criterio_busqueda = {};
            criterio_busqueda[this.propiedadId] = id_seleccionado;
            if (this.objetosCargados.find(criterio_busqueda)) this.select.select2("val", id_seleccionado);
            else {
                this.limpiarSeleccion();
                console.log("No hay cargado en la colección ningun elemento con el id:" + id_seleccionado)
            }
        }
        this.change();
    }
    return this._id_seleccionado;
};

ComboConBusquedaYAgregado.prototype.itemSeleccionado = function () {
    if (!this.idSeleccionado()) return undefined;
    return this.objetosCargados.find(JSON.parse("{\"" + this.propiedadId + "\":" + this.idSeleccionado() + "}"));
};

ComboConBusquedaYAgregado.prototype.limpiarSeleccion = function () {
    this._id_seleccionado = undefined;
    this.select.select2("val", "");
    this.change();
};

ComboConBusquedaYAgregado.prototype.change = function (callback) {
    if (callback) this.callbacks_change.push(callback);
    else {
        this.callbacks_change.forEach(function(cb){
            cb();
        });
    }
};

ComboConBusquedaYAgregado.prototype.cargarComboDesdeProveedor = function () {
    var _this = this;
    Repositorio.buscar(this.dataProvider, this.filtro, function (objetos) {
        _this.objetosCargados = objetos;
        _this.select.empty();
        _this.select.append($("<option>"));
        objetos.forEach(function (objeto) {
            var option = $("<option value='" + objeto[_this.propiedadId] + "'>" + objeto[_this.propiedadLabel] + "</option>");
            _this.select.append(option);
        });
        if (_this.idSeleccionado() === undefined) _this.limpiarSeleccion();
        else _this.idSeleccionado(_this.idSeleccionado());
    });
};

ComboConBusquedaYAgregado.prototype.cargarComboDesdeOpciones = function () {
    var _this = this;
    this.objetosCargados = [];
    this.select.find("option").each(function (i, opt) {
        var obj = {};
        obj[_this.propiedadId] = $(opt).val();
        obj[_this.propiedadLabel] = $(opt).text();
        _this.objetosCargados.push(obj);
    });
    if (_this.idSeleccionado() === undefined) _this.limpiarSeleccion();
    else _this.idSeleccionado(_this.idSeleccionado());
};

ComboConBusquedaYAgregado.prototype.filtrarPor = function (filtro) {
    this.filtro = filtro;
    this.cargarComboDesdeProveedor();
};