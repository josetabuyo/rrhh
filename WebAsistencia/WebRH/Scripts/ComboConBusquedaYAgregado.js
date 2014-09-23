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
        width: 'resolve'//,
        //        minimumInputLength: 0,
        //        query: function (query) {
        //            var data = { results: [] };
        //            query.callback(data);
        //        }
    });

    this.select.on("change", function (e) {
        var val_en_combo = _this.select.select2("val");
        var nuevo_id = parseInt(val_en_combo);
        if (nuevo_id === NaN) nuevo_id = val_en_combo;
        _this.idSeleccionado(nuevo_id);
    });

    this.select.on("select2-removed", function (e) {
        _this.idSeleccionado(null);
    });

    if (this.dataProvider) {
        Repositorio.buscar(this.dataProvider, this.filtro, function (objetos) {
            _this.objetosCargados = objetos;
            _this.select.append($("<option>"));
            objetos.forEach(function (objeto) {
                var option = $("<option value='" + objeto[_this.campoId] + "'>" + objeto[_this.campoDescripcion] + "</option>");
                _this.select.append(option);
            });
            _this.select.select2("val", _this.idSeleccionado());
        });
    }
};

ComboConBusquedaYAgregado.prototype.idSeleccionado = function (id_seleccionado) {
    if (id_seleccionado !== undefined) {
        if (id_seleccionado === null) {
            this._id_seleccionado = undefined;
            this.select.select2("val", "");
        } else {
            this._id_seleccionado = id_seleccionado;
            this.select.select2("val", id_seleccionado);
        }
    }
    else {
        return this._id_seleccionado;
    }
};

ComboConBusquedaYAgregado.prototype.itemSeleccionado = function () {
    return this.objetosCargados.find(JSON.parse("{\"" + this.campoId + "\":" + this.idSeleccionado() + "}"));
};