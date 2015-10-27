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

    var _this = this;

    this.select.select2({
        minimumInputLength: 3,
        width: 'resolve',
        placeholder: this.placeholder || 'seleccione',
        query: function (query) {
            var filtro = $.extend({}, _this.filtro);
            filtro[_this.propiedadLabel] = "*" + query.term + "*";
            Repositorio.buscar(_this.dataProvider, filtro, function (objetos) {
                var data = { results: objetos };
                _this.objetosCargados = objetos;
                query.callback(data);

                //                _this.select.empty();
                //                _this.select.append($("<option>"));
                //                objetos.forEach(function (objeto) {
                //                    var option = $("<option value='" + objeto[_this.propiedadId] + "'>" + objeto[_this.propiedadLabel] + "</option>");
                //                    _this.select.append(option);
                //                });
                //                if (_this.idSeleccionado() === undefined) _this.limpiarSeleccion();
                //                else _this.idSeleccionado(_this.idSeleccionado());
            });
        },
        dropdownCssClass: "bigdrop",
        escapeMarkup: function (m) { return m; },
        formatResult: function (o) { return _this.generarVistaObjeto(o); },
        formatSelection: function (o) { return _this.generarVistaObjeto(o); }
    });
    this.select.on("select2-selecting", function (e) {
        _this.change();
    });

}
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

ComboConBusquedaYAgregado.prototype.generarVistaObjeto = function (obj) {
    return $("<div value='" + obj[this.propiedadId] + "'>" + obj[this.propiedadLabel] + "</div>");
};

ComboConBusquedaYAgregado.prototype.change = function (callback) {
    if (callback) this.callbacks_change.push(callback);
    else {
        this.callbacks_change.forEach(function (cb) {
            cb();
        });
    }
};