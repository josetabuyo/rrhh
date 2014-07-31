var ComboPopuladoConRepoBuilder = function (repositorio) {
	this.repositorio = repositorio
};

ComboPopuladoConRepoBuilder.prototype.include = function(arr,obj) {
    return (arr.indexOf(obj) != -1);
}

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom) {
	repo = this.repositorio;
	var combos = [];
    dom.find('[dataProvider]').each(function () {
        var control = $(this);

		var super_combo = new SuperCombo({
            ui: control,
            nombre_repositorio: $(control).attr("dataProvider"),
			campo_descripcion: $(control).attr("label") || "Descripcion",
			dependencia: $(control).attr("dependeDe"),
            repositorio: repo
        });
		combos.push(super_combo);
    });
	
	$.grep(combos, function(combo){ return combo.dependencia != undefined; }).each {
		var comboFiltro = $.grep(combos, function(e){ return e.id == $(control).attr("dependeDe"); });
			var filtro= { provincia: comboFiltro.idItemSeleccionado() };

			comboFiltro.change(function() {
				super_combo.cargarBusqueda($(control).attr("dataProvider"), filtro, comboFiltro.campo_id, comboFiltro.campo_descripcion);
			});
	};

	return combos;
};