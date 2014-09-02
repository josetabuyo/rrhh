var ComboPopuladoConRepoBuilder = function (repositorio) {
	if (repositorio == undefined) {
		throw "No se ha especificado un repositorio al momento de construir el builder de combos";
	};
	this.repositorio = repositorio;
};

ComboPopuladoConRepoBuilder.prototype.browseObject = function (obj_modelo, path_original, path_completo, combo) {
	var path = path_original.slice(0);
	var this_level_attr = path.shift();
	if (!obj_modelo.hasOwnProperty(this_level_attr)) {
		throw 'Error al intentar bindear el modelo "' + path_completo.join(".") + '" al combo "' + combo[0]['id'] + '"';
	}
	var this_level_value = obj_modelo[this_level_attr];
	if (path.length == 0) {
		return { obj_bindeable: obj_modelo, attr_bindeable: this_level_attr, attr_value: this_level_value };
	}
	return this.browseObject(obj_modelo[this_level_attr], path, path_completo, combo);
}

ComboPopuladoConRepoBuilder.prototype.setValorModeloBindeado = function(obj_modelo, path_original, event) {
	var path = path_original.slice(0);
	var this_level_attr = path.shift();
	if (path.length == 0) {
		//evito referencia circular de a bindeado a b, y b bindeado a a.
		obj_modelo.unwatch(this_level_attr);
		obj_modelo[this_level_attr] = event.target.value;
		obj_modelo.watch(this_level_attr, function(prop, oldval, newval) {
			super_combo.id_item_seleccionado = newval;
		});
	} else {
		this.setValorModeloBindeado(obj_modelo[this_level_attr], path, event);
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
	if (nombre_repositorio) {
		if(this.campoDependenciaDe(super_combo) == undefined || (this.campoDependenciaDe(super_combo) != undefined && filtro != undefined )) {
			_this.repositorio.buscar(nombre_repositorio, filtro, function (items) {
				_this.cargarCombo(super_combo, items, campo_id, campo_descripcion);
				super_combo.val(super_combo.id_item_seleccionado);
			});
		}
	}
}

ComboPopuladoConRepoBuilder.prototype.campoDescripcionDe = function(combo) {
	return combo.attr("label") || "Descripcion";
};

ComboPopuladoConRepoBuilder.prototype.campoDependenciaDe = function(combo) {
	return combo.attr("dependeDe");
};

ComboPopuladoConRepoBuilder.prototype.bindearComboAModelo = function(combo, modelo) {
	var _this = this;
	var attr_name = combo.attr("modelo");
	if (attr_name != undefined) {
		var attr_path = attr_name.split('.');
		var attr_value = this.browseObject(modelo, attr_path, attr_path, combo).attr_value;
		combo.id_item_seleccionado = attr_value;
	}	
	combo.change(function(event) { 
		combo.id_item_seleccionado =  event.target.value; //agregar un test que falle si remuevo esta linea
		_this.setValorModeloBindeado(modelo, attr_path, event);
	});

	var binding_data = this.browseObject(modelo, attr_path);
	var obj_bindeable = binding_data.obj_bindeable;
	var attr_bindeable = binding_data.attr_bindeable;
	
	obj_bindeable.watch(attr_bindeable, function(prop, oldval, newval) {
		combo.id_item_seleccionado = newval;
	});
};

ComboPopuladoConRepoBuilder.prototype.bindearCombo = function(control, modelo_bindeo) {
	var combo = $(control);
	var default_id = "Id"
	combo.campo_id = default_id;
	combo.binding = modelo_bindeo;

	if (modelo_bindeo != undefined) {
		this.bindearComboAModelo(combo, modelo_bindeo);
	}
	this.cargarBusqueda(combo, combo.attr("dataProvider"), combo.filtro, default_id, this.campoDescripcionDe(combo));
	return combo;
}

ComboPopuladoConRepoBuilder.prototype.agregarDependenciasEntreCombos = function(combos) {
	var _this = this;
	var combosDependientesDeOtro = $.grep(combos, function(combo){ 
		return _this.campoDependenciaDe(combo) != undefined; 
	});
	
	combosDependientesDeOtro.forEach(function(combo) {
		var comboDelQueDepende = $.grep(combos, function(each_combo){ 
			return each_combo.attr("id") == _this.campoDependenciaDe(combo); 
		})[0];

		if(comboDelQueDepende.attr("modelo") == undefined) {
			throw '"' + comboDelQueDepende.attr("id") + '" debe especificar el atributo modelo="ALGO", puesto que "' + combo.attr("id") + '" depende de él, y requiere dicho modelo para poder filtrar.';
		}
		
		comboDelQueDepende.change(function() {
			var filtro = { };
			filtro[combo.attr("filtradoPor")] = parseInt(comboDelQueDepende.id_item_seleccionado);
			_this.cargarBusqueda(combo, combo.attr("dataProvider"), filtro, comboDelQueDepende.campo_id, _this.campoDescripcionDe(comboDelQueDepende));
		});
	});
};

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom, modelo_bindeo) {
	var builder = this;
	var combos = $.map(dom.find('[dataProvider]'), function(each_combo) {
		return builder.bindearCombo($(each_combo), modelo_bindeo);
	});
	this.agregarDependenciasEntreCombos(combos);
	return combos;
};