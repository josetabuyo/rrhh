var ComboPopuladoConRepoBuilder = function (repositorio) {
	this.repositorio = repositorio;
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
	
	var combosDependientesDeOtro = $.grep(combos, function(combo){ return combo.dependencia != undefined; })
	combosDependientesDeOtro.forEach(function(combo) {
		var comboDelQueDepende = $.grep(combos, function(e){ return e.ui.attr("id") == combo.dependencia; })[0];
		comboDelQueDepende.ui.change(function() {
			var filtro= { provincia: comboDelQueDepende.idItemSeleccionado() };
			combo.cargarBusqueda(combo.nombre_repositorio, filtro, comboDelQueDepende.campo_id, comboDelQueDepende.campo_descripcion);
		});
	});
	return combos;
};