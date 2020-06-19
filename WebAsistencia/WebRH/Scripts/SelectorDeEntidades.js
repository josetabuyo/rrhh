var SelectorDeEntidades = function (opt) {
    this.alSeleccionarUnaEntidad = function (entidad) {
    };
    $.extend(this, opt, true);
    this.start();
};

SelectorDeEntidades.prototype.start = function () {
    var _this = this;
    this.entidadSeleccionada = {
        id: '',
        nombre: ''
    };
    this.buscador = this.ui.find("#buscadorEntidades");
    this.plantilla_vista_entidad = $("#plantillas .vista_entidad_en_selector");
    this.buscador.select2({
        minimumInputLength: 3,
        width: 'resolve',
        placeholder: this.placeholder || 'ingrese parte del nombre de la entidad',
        allowClear: true,
        query: function (query) {
            _this.repositorioDeEntidades.buscarEntidades(
                query.term,
                function (entidades) {
                    var data = { results: entidades };
                    _this.entidadesEncontradas = entidades;
                    query.callback(data);
                },
                function () {
                    console.log('error al buscar areas');
                });
        },
        dropdownCssClass: "bigdrop",
        escapeMarkup: function (m) { return m; },
        formatResult: function (entidad) { return _this.generarVistaEntidad(entidad); },
        formatSelection: function (entidad) { return _this.generarVistaEntidad(entidad); }
    });
    this.buscador.on("select2-selecting", function (e) {
        for (var i = 0; i < _this.entidadesEncontradas.length; i++) {
            if (_this.entidadesEncontradas[i].id == e.val) _this.entidadSeleccionada = _this.entidadesEncontradas[i];
        }
        _this.alSeleccionarUnaEntidad(_this.entidadSeleccionada);
    });

    this.buscador.on("select2-removed", function (e) {
        _this.entidadSeleccionada = {
            id: '',
            nombre: ''
        };
        _this.alSeleccionarUnaEntidad(_this.entidadSeleccionada);
    });
};

SelectorDeEntidades.prototype.generarVistaEntidad = function (entidad) {
    var ui = this.plantilla_vista_entidad.clone();
    ui.find("#nombre").text(entidad.nombre);
    return ui;
};

SelectorDeEntidades.prototype.mostrar = function () {
    this.ui.show();
};

SelectorDeEntidades.prototype.ocultar = function () {
    this.ui.hide();
};

SelectorDeEntidades.prototype.limpiar = function () {
    this.buscador.select2('data', null)
};

SelectorDeEntidades.prototype.setEntidadSeleccionada = function (entidad) {
    this.entidadSeleccionada = entidad;
    this.buscador.select2('data', entidad);
};