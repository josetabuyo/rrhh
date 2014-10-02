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

    this.html_form.find("[rh-filter-combo]").each(function (i, e) {
        _this.asociarComboAOtro($(e));
    });
};

FormularioBindeado.prototype.crearYBindearTextBox = function (input) {
    this[input.attr('Id')] = input;

    var path_propiedad_modelo = input.attr('rh-model-property');
    var path_spliteado = path_propiedad_modelo.split('.');

    var tipo_del_dato = "texto";
    var validaciones = input.attr('data-validar');
    if (validaciones) {
        var validaciones_spliteadas = validaciones.split(' ');
        validaciones_spliteadas.forEach(function (v) {
            if (v == "esNumeroNatural" || v == "esNumeroNaturalSinCero") tipo_del_dato = "numero_entero";
        });
    }

    var objeto_a_bindear;
    var propiedad_a_bindear;
    if (path_spliteado.length == 1) {
        objeto_a_bindear = this.modelo;
        propiedad_a_bindear = path_spliteado[0];
    } else {
        objeto_a_bindear = this.modelo;
        for (var i = 0; i < path_spliteado.length - 1; i++) {
            objeto_a_bindear = objeto_a_bindear[path_spliteado[i]];
        }
        propiedad_a_bindear = path_spliteado[path_spliteado.length - 1];
    }

    input.change(function () {
        objeto_a_bindear.unwatch(propiedad_a_bindear);
        if (tipo_del_dato == "texto") {
            objeto_a_bindear[propiedad_a_bindear] = input.val();
        }
        if (tipo_del_dato == "numero_entero") {
            if (input.val()) {
                objeto_a_bindear[propiedad_a_bindear] = parseInt(input.val());
            } else {
                objeto_a_bindear[propiedad_a_bindear] = null;
            }
        }
        objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
            input.val(newval);
        });
    });

    objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
        input.val(newval);
    });

    input.val(objeto_a_bindear[propiedad_a_bindear]);
};

FormularioBindeado.prototype.crearYBindearDatePicker = function (input) {
    this[input.attr('Id')] = input;

    var path_propiedad_modelo = input.attr('rh-model-property');
    var path_spliteado = path_propiedad_modelo.split('.');

    var objeto_a_bindear;
    var propiedad_a_bindear;
    if (path_spliteado.length == 1) {
        objeto_a_bindear = this.modelo;
        propiedad_a_bindear = path_spliteado[0];
    } else {
        objeto_a_bindear = this.modelo;
        for (var i = 0; i < path_spliteado.length - 1; i++) {
            objeto_a_bindear = objeto_a_bindear[path_spliteado[i]];
        }
        propiedad_a_bindear = path_spliteado[path_spliteado.length - 1];
    }

    input.datepicker();
    input.datepicker('option', 'dateFormat', 'dd/mm/yy');

    input.change(function () {
        objeto_a_bindear.unwatch(propiedad_a_bindear);
        objeto_a_bindear[propiedad_a_bindear] = input.val();
        objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
            input.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(newval));
        });
    });

    objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
        input.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(newval));
    });

    input.val(objeto_a_bindear[propiedad_a_bindear]);
};

FormularioBindeado.prototype.crearYBindearCombo = function (select) {
    var opt_constructor = {
        select: select,
        dataProvider: select.attr('rh-data-provider')
    };
    var prop_label = select.attr("rh-propiedad-label");
    if (prop_label) opt_constructor.propiedadLabel = prop_label;

    var combo = new ComboConBusquedaYAgregado(opt_constructor);
    this[select.attr('Id')] = combo;

    var path_propiedad_modelo = select.attr('rh-model-property');
    var path_spliteado = path_propiedad_modelo.split('.');

    var objeto_a_bindear;
    var propiedad_a_bindear;
    if (path_spliteado.length == 1) {
        objeto_a_bindear = this.modelo;
        propiedad_a_bindear = path_spliteado[0];
    } else {
        objeto_a_bindear = this.modelo;
        for (var i = 0; i < path_spliteado.length - 1; i++) {
            objeto_a_bindear = objeto_a_bindear[path_spliteado[i]];
        }
        propiedad_a_bindear = path_spliteado[path_spliteado.length - 1];
    }

    combo.change(function () {
        objeto_a_bindear.unwatch(propiedad_a_bindear);
        objeto_a_bindear[propiedad_a_bindear] = combo.idSeleccionado();
        objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
            combo.idSeleccionado(newval);
        });
    });

    objeto_a_bindear.watch(propiedad_a_bindear, function (prop, oldval, newval) {
        combo.idSeleccionado(newval);
    });

    combo.idSeleccionado(objeto_a_bindear[propiedad_a_bindear]);
};

FormularioBindeado.prototype.asociarComboAOtro = function (select) {
    var combo_maestro = this[select.attr("rh-filter-combo")];
    var combo_esclavo = this[select.attr("Id")];
    this.setFiltroDependiente(combo_maestro, combo_esclavo, select.attr("rh-filter-prop"));
    var _this = this;
    combo_maestro.change(function () {
        _this.setFiltroDependiente(combo_maestro, combo_esclavo, select.attr("rh-filter-prop"));
    });
};

FormularioBindeado.prototype.setFiltroDependiente = function (combo_maestro, combo_esclavo, propiedad_filtro) {
    var filtro = {};
    filtro[propiedad_filtro] = combo_maestro.idSeleccionado();
    combo_esclavo.filtrarPor(filtro);
};