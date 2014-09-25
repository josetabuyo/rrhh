var FormularioBindeado = function (opt) {
    var _this = this;
    this.html_form = opt.formulario;
    this.modelo = opt.modelo;

    this.html_form.find("[rh-control-type='combo']").each(function (i, e) {
        var select = $(e);
        var combo = new ComboConBusquedaYAgregado({
            select: select,
            dataProvider: select.attr('rh-data-provider')
        });
        _this[select.attr('Id')] = combo;
        combo.change(function () {
            _this.modelo.unwatch(select.attr('rh-modelo'));
            _this.modelo[select.attr('rh-modelo')] = combo.idSeleccionado();
            _this.modelo.watch(select.attr('rh-modelo'), function (prop, oldval, newval) {
                combo.idSeleccionado(newval);
            });
        });
        _this.modelo.watch(select.attr('rh-modelo'), function (prop, oldval, newval) {
            combo.idSeleccionado(newval);
        });
        combo.idSeleccionado(_this.modelo[select.attr('rh-modelo')]);
    });
};