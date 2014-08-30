var ComboPopuladoConRepoBuilder = function (repositorio) {
	if (repositorio == undefined) {
		throw "No se ha especificado un repositorio al momento de construir el builder de combos";
	};
	this.repositorio = repositorio;
};

ComboPopuladoConRepoBuilder.prototype.browseObject = function (obj, path_original, path_completo, combo) {
	var path = path_original.slice(0);
	var this_level_attr = path.shift();
	if (!obj.hasOwnProperty(this_level_attr)) {
		throw 'Error al intentar bindear el modelo "' + path_completo.join(".") + '" al combo "' + combo[0]['id'] + '"';
	}
	var this_level_value = obj[this_level_attr];
	if (path.length == 0) {
		return { obj_bindeable: obj, attr_bindeable: this_level_attr, attr_value: this_level_value };
	}
	return this.browseObject(obj[this_level_attr], path, path_completo, combo);
}

ComboPopuladoConRepoBuilder.prototype.setValorModeloBindeado = function(obj, path_original, event) {
	var path = path_original.slice(0);
	var this_level_attr = path.shift();
	if (path.length == 0) {
		//evito referencia circular de a bindeado a b, y b bindeado a a.
		obj.unwatch(this_level_attr);
		obj[this_level_attr] = event.target.value;
		obj.watch(this_level_attr, function(prop, oldval, newval) {
			super_combo.id_item_seleccionado = newval;
		});
	} else {
		this.setValorModeloBindeado(obj[this_level_attr], path, event);
	}
}

ComboPopuladoConRepoBuilder.prototype.cargarCombo = function(super_combo, objetos, campo_id, campo_descripcion) {
	super_combo.empty();
    objetos.forEach(function (item) {
        var option = $("<option value='" + item[campo_id] + "'>" + item[campo_descripcion] + "</option>");
        super_combo.append(option);
    });
}

ComboPopuladoConRepoBuilder.prototype.cargarBusqueda = function(super_combo, nombre_repositorio, filtro, campo_id, campo_descripcion) {
	var _this = this;
	if (super_combo.nombre_repositorio) {
		if(super_combo.dependencia == undefined || (super_combo.dependencia != undefined && filtro != undefined )) {
			super_combo.repositorio.buscar(nombre_repositorio, filtro, function (items) {
				_this.cargarCombo(super_combo, items, campo_id, campo_descripcion);
				super_combo.val(super_combo.id_item_seleccionado);
			});
		}
	}
}

ComboPopuladoConRepoBuilder.prototype.bindearCombo = function(control, modelo_bindeo, repo) {
	var builder = this;

	var super_combo = $(control);

	
	super_combo.campo_id = "Id";
	super_combo.campo_descripcion = "Descripcion";
	super_combo.nombre_repositorio = super_combo.attr("dataProvider");
	super_combo.campo_descripcion = super_combo.attr("label") || "Descripcion";
	super_combo.dependencia = super_combo.attr("dependeDe");
	super_combo.binding = modelo_bindeo;
	super_combo.repositorio = repo;
	
	if (repo == undefined) {
		throw 'No se ha especificado un repositorio al momento de construir el combo \"' + this[0]["id"] + '"';
	}
	
	this.cargarBusqueda(super_combo, super_combo.nombre_repositorio, super_combo.filtro, super_combo.campo_id, super_combo.campo_descripcion);

	if (modelo_bindeo != undefined) {
		var attr_name = super_combo.attr("modelo");
		if (attr_name != undefined) {
			var attr_path = attr_name.split('.');
			var attr_value = this.browseObject(modelo_bindeo, attr_path, attr_path, control).attr_value;
			super_combo.id_item_seleccionado = attr_value;
		}	
		super_combo.change(function(event) { 
			builder.setValorModeloBindeado(modelo_bindeo, attr_path, event); 
		});

		var binding_data = this.browseObject(modelo_bindeo, attr_path);
		var obj_bindeable = binding_data.obj_bindeable;
		var attr_bindeable = binding_data.attr_bindeable;
		
		obj_bindeable.watch(attr_bindeable, function(prop, oldval, newval) {
			super_combo.id_item_seleccionado = newval;
		});
	}
	return super_combo;
}

ComboPopuladoConRepoBuilder.prototype.agregarDependenciasEntreCombos = function(combos) {
	var _this = this;
	var combosDependientesDeOtro = $.grep(combos, function(combo){ 
		return combo.dependencia != undefined; 
	});
	
	combosDependientesDeOtro.forEach(function(combo) {
		var comboDelQueDepende = $.grep(combos, function(each_combo){ 
			return each_combo.attr("id") == combo.dependencia; 
		})[0];
		
		comboDelQueDepende.change(function() {
			var filtro = { provincia: comboDelQueDepende.id_item_seleccionado };
			_this.cargarBusqueda(combo, combo.nombre_repositorio, filtro, comboDelQueDepende.campo_id, comboDelQueDepende.campo_descripcion);
		});
	});
};

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom, modelo_bindeo) {

	var builder = this;
	
	var combos = $.map(dom.find('[dataProvider]'), function(each_combo) {
		return builder.bindearCombo($(each_combo), modelo_bindeo, builder.repositorio);
	});
	
	this.agregarDependenciasEntreCombos(combos);
	
	return combos;
};