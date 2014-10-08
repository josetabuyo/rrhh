var FormularioBindeado = function (opt) {
    var _this = this;
    this.html_form = opt.formulario;
    this.modelo = opt.modelo;

    this.html_form.find("[rh-control-type='combo']").each(function (i, e) {
        _this.crearYBindearCombo($(e));
    });

    this.html_form.find("[rh-control-type='textbox']").each(function (i, e) {
        _this.crearYBindearTextBox($(e));
    });

    this.html_form.find("[rh-control-type='datepicker']").each(function (i, e) {
        _this.crearYBindearDatePicker($(e));
    });
};

FormularioBindeado.prototype.crearYBindearTextBox = function (input) {
    var _this = this;
    this[input.attr('Id')] = input;

    var path_propiedad_modelo = input.attr('rh-model-property');

    var tipo_del_dato = "texto";
    var validaciones = input.attr('data-validar');
    if (validaciones) {
        var validaciones_spliteadas = validaciones.split(' ');
        validaciones_spliteadas.forEach(function (v) {
            if (v == "esNumeroNatural" || v == "esNumeroNaturalSinCero") tipo_del_dato = "numero_entero";
        });
    }

    var handler = function (prop, oldval, newval) {
        input.val(newval);
    };
    input.change(function () {
        _this.modelo.unwatch(path_propiedad_modelo, handler);
        if (tipo_del_dato == "texto") {
            _this.modelo.setValorEnPath(path_propiedad_modelo, input.val());
        }
        if (tipo_del_dato == "numero_entero") {
            if (input.val()) {
                _this.modelo.setValorEnPath(path_propiedad_modelo, parseInt(input.val()));
            } else {
                _this.modelo.setValorEnPath(path_propiedad_modelo, null);
            }
        }
        _this.modelo.watch(path_propiedad_modelo, handler);
    });

    this.modelo.watch(path_propiedad_modelo, handler);
    input.val(this.modelo.getValorDePath(path_propiedad_modelo));
};

FormularioBindeado.prototype.crearYBindearDatePicker = function (input) {
    var _this = this;
    this[input.attr('Id')] = input;

    var path_propiedad_modelo = input.attr('rh-model-property');

    input.datepicker();
    input.datepicker('option', 'dateFormat', 'dd/mm/yy');

    var handler = function (prop, oldval, newval) {
        input.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(newval));
    };
    input.change(function () {
        _this.modelo.unwatch(path_propiedad_modelo, handler);
        _this.modelo.setValorEnPath(path_propiedad_modelo, input.val());
        _this.modelo.watch(path_propiedad_modelo, handler);
    });
    this.modelo.watch(path_propiedad_modelo, handler);
    input.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(this.modelo.getValorDePath(path_propiedad_modelo)));
};

FormularioBindeado.prototype.crearYBindearCombo = function (select) {
    var _this = this;
    var opt_constructor = {
        select: select,
        dataProvider: select.attr('rh-data-provider')
    };
    var prop_label = select.attr("rh-propiedad-label");
    if (prop_label) opt_constructor.propiedadLabel = prop_label;

    var filter_key = select.attr('rh-filter-key');
    var filter_path = select.attr('rh-filter-value');
    if (filter_key && filter_path) {
        opt_constructor.filtro = {};
        opt_constructor.filtro[filter_key] = this.modelo.getValorDePath(filter_path)
    }

    var combo = new ComboConBusquedaYAgregado(opt_constructor);
    this[select.attr('Id')] = combo;

    var path_propiedad_modelo = select.attr('rh-model-property');
    var handler = function (prop, oldval, newval) {
        combo.idSeleccionado(newval);
    };

    combo.change(function () {
        _this.modelo.unwatch(path_propiedad_modelo, handler);
        _this.modelo.setValorEnPath(path_propiedad_modelo, combo.idSeleccionado());
        _this.modelo.watch(path_propiedad_modelo, handler);
    });
    this.modelo.watch(path_propiedad_modelo, handler);
    combo.idSeleccionado(this.modelo.getValorDePath(path_propiedad_modelo));

    if (filter_key && filter_path) {
        this.modelo.watch(filter_path, function (prop, oldval, newval) {
            var filtro = {};
            filtro[filter_key] = newval
            combo.filtrarPor(filtro);
        });        
    }
};
