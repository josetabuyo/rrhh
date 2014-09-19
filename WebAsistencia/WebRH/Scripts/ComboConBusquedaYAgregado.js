var ComboConBusquedaYAgregado = function (opt) {
    var _this = this;
    var def = {
        campoId: "Id",
        campoDescripcion: "Descripcion",
        filtro: {},
        objetosCargados: []
    }
    $.extend(true, this, def, opt);

    this.select.select2({
        placeholder: this.placeHolder || 'seleccione',
        allowClear: true,
        width: 'resolve'
    });

    this.select.on("change", function (e) {
        var nuevo_id = parseInt(e.val);
        if (nuevo_id === NaN) nuevo_id = e.val;
        _this.idSeleccionado(nuevo_id);
    });

    Repositorio.buscar(this.dataProvider, this.filtro, function (objetos) {
        _this.objetosCargados = objetos;
        objetos.forEach(function (objeto) {
            var option = $("<option value='" + objeto[_this.campoId] + "'>" + objeto[_this.campoDescripcion] + "</option>");
            _this.select.append(option);
        });
        _this.select.select2("val", _this.idSeleccionado());
    });
};

ComboConBusquedaYAgregado.prototype.idSeleccionado = function (id_seleccionado) {
    if (id_seleccionado) {
        this._id_seleccionado = id_seleccionado;
        this.select.select2("val", id_seleccionado);
    }
    else return this._id_seleccionado;
};

ComboConBusquedaYAgregado.prototype.itemSeleccionado = function () {
    return this.objetosCargados.find(JSON.parse("{\"" + this.campoId + "\":" + this.idSeleccionado() + "}"));
};