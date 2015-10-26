var ComboConBusquedaYAgregado = function (opt) {
    var _this = this;
    var def = {
        propiedadId: "Id",
        propiedadLabel: "Descripcion",
        filtro: {}
    }
    $.extend(true, this, def, opt);

    var _this = this;

    this.select.select2({
        minimumInputLength: 3,
        width: 'resolve',
        placeholder: this.placeholder || 'seleccione',
        query: function (query) {
            var filtro = $.extend({}, _this.filtro, {$busqueda: query});
            Repositorio.buscar(_this.dataProvider, filtro, function (objetos) {
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
        },
        dropdownCssClass: "bigdrop",
        escapeMarkup: function (m) { return m; },
        formatResult: function (persona) { return _this.generarVistaPersona(persona); },
        formatSelection: function (persona) { return _this.generarVistaPersona(persona); }
    });
    this.buscador.on("select2-selecting", function (e) {
        for (var i = 0; i < _this.personasEncontradas.length; i++) {
            if (_this.personasEncontradas[i].id == e.val) _this.personaSeleccionada = _this.personasEncontradas[i];
        }
        _this.alSeleccionarUnaPersona(_this.personaSeleccionada);
    });

}

