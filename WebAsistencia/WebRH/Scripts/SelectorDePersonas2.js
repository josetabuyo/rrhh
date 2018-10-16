define(['jquery', 'select2'], function ($) {
    var SelectorDePersonas = function (opt) {
        $.extend(this, opt, true);
        this.start();
    };

    SelectorDePersonas.prototype.start = function () {
        var _this = this;
        this.buscador = this.ui.find("#buscador");
        this.plantilla_vista_persona = $("#plantillas .vista_persona_en_selector");
        this.buscador.select2({
            minimumInputLength: 3,
            width: 'resolve',
            placeholder: this.placeholder || 'ingrese nombre, apellido, documento o legajo',
            allowClear: true,
            query: function (query) {
                _this.repositorioDePersonas.BuscarPersonas(
                    query.term,
                    function (personas) {
                        var data = { results: personas };
                        _this.personasEncontradas = personas;
                        query.callback(data);
                    },
                    function () {
                        console.log('error al buscar personas');
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
    };

    SelectorDePersonas.prototype.generarVistaPersona = function (persona) {
        var ui = this.plantilla_vista_persona.clone();
        ui.find("#nombre").text(persona.nombre);
        ui.find("#apellido").text(persona.apellido);
        ui.find("#legajo").text(persona.legajo);
        ui.find("#documento").text(persona.documento);
        return ui;
    };

    SelectorDePersonas.prototype.mostrar = function () {
        this.ui.show();
    };

    SelectorDePersonas.prototype.ocultar = function () {
        this.ui.hide();
    };

    return SelectorDePersonas
})