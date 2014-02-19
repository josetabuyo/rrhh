var SelectorDeAreas = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

SelectorDeAreas.prototype.start = function () {
    var _this = this;
    this.buscador = this.ui.find("#buscador");
    this.plantilla_vista_area = $("#plantillas .vista_area_en_selector");
    this.buscador.select2({
        minimumInputLength: 3,
        quietMillis: 1000, 
        width: 'resolve',
        placeholder: this.placeholder || 'ingrese parte del nombre del area',
        query: function (query) {
            _this.repositorioDeAreas.buscarAreas(
                query.term,
                function (areas) {                    
                    var data = { results: areas };
                    _this.areasEncontradas = areas;
                    query.callback(data);
                },
                function () {
                    console.log('error al buscar areas');
                });
        },
        dropdownCssClass: "bigdrop",
        escapeMarkup: function (m) { return m; },
        formatResult: function (area) { return _this.generarVistaArea(area); },
        formatSelection: function (area) { return _this.generarVistaArea(area); }
    });
    this.buscador.on("select2-selecting", function (e) {
        for (var i = 0; i < _this.areasEncontradas.length; i++) {
            if (_this.areasEncontradas[i].id == e.val) _this.areaSeleccionada = _this.areasEncontradas[i];
        }
        _this.alSeleccionarUnArea(_this.areaSeleccionada);
    });
};

SelectorDeAreas.prototype.generarVistaArea = function (area) {
    var ui = this.plantilla_vista_area.clone();
    ui.find("#nombre").text(area.nombre);
    return ui;
};

SelectorDeAreas.prototype.mostrar = function () {
    this.ui.show();
};

SelectorDeAreas.prototype.ocultar = function () {
    this.ui.hide();
};

SelectorDeAreas.prototype.limpiar = function () {
    this.buscador.select2('data', null)
};