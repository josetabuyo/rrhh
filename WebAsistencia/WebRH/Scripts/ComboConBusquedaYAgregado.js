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
        if (val_en_combo == "") {
            _this.limpiarSeleccion();
            return;
        }
        var id_as_number = parseInt(val_en_combo);
        if (isNaN(id_as_number)) _this.idSeleccionado(val_en_combo);
        else _this.idSeleccionado(id_as_number);
    });

    if (this.dataProvider) {
        Repositorio.buscar(_this.dataProvider, _this.filtro, function (objetos) {
            _this.objetosCargados = objetos;
            _this.select.append($("<option>"));
            objetos.forEach(function (objeto) {
                var option = $("<option value='" + objeto[_this.campoId] + "'>" + objeto[_this.campoDescripcion] + "</option>");
                _this.select.append(option);
            });
            if (_this.idSeleccionado() === undefined) _this.limpiarSeleccion();
            else _this.idSeleccionado(_this.idSeleccionado());
        });
    }
};

ComboConBusquedaYAgregado.prototype.idSeleccionado = function (id_seleccionado) {
    if (id_seleccionado !== undefined) {
        this._id_seleccionado = id_seleccionado;
        if (this.objetosCargados.length > 0) {
            var criterio_busqueda = {};
            criterio_busqueda[this.campoId] = id_seleccionado;
            if (this.objetosCargados.find(criterio_busqueda)) this.select.select2("val", id_seleccionado);
            else {
                this.limpiarSeleccion();
                console.log("No hay cargado en la colección ningun elemento con el id:" + id_seleccionado)
            }
        }
    }
    return this._id_seleccionado;
};

ComboConBusquedaYAgregado.prototype.itemSeleccionado = function () {
    return this.objetosCargados.find(JSON.parse("{\"" + this.campoId + "\":" + this.idSeleccionado() + "}"));
};

ComboConBusquedaYAgregado.prototype.limpiarSeleccion = function () {
    this._id_seleccionado = undefined;
    this.select.select2("val", "");
};