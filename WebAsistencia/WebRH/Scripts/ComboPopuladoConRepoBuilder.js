var ComboPopuladoConRepoBuilder = function (repositorio, bindings) {
	this.repositorio = repositorio;
	this.bindings = bindings;
};

ComboPopuladoConRepoBuilder.prototype.include = function(arr,obj) {
    return (arr.indexOf(obj) != -1);
}

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom, bindings) {
	var repo = this.repositorio;
	var combos = [];
    dom.find('[dataProvider]').each(function () {
        var control = $(this);
		
		var parametros_constructor = {
            ui: control,
            nombre_repositorio: $(control).attr("dataProvider"),
			campo_descripcion: $(control).attr("label") || "Descripcion",
			dependencia: $(control).attr("dependeDe"),
            repositorio: repo
        };
		
		if (bindings != undefined) {
			var attr = bindings[$(control).attr("Id")];
			if (typeof attr !== typeof undefined && attr !== false) {
				parametros_constructor["id_item_seleccionado"] = attr;
			}
		}
		
		var super_combo = new SuperCombo(parametros_constructor);
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