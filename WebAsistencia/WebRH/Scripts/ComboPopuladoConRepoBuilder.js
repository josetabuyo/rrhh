

/*
 * object.watch polyfill
 *
 * 2012-04-03
 *
 * By Eli Grey, http://eligrey.com
 * Public Domain.
 * NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.
 */
 
// object.watch
if (!Object.prototype.watch) {
	Object.defineProperty(Object.prototype, "watch", {
		  enumerable: false
		, configurable: true
		, writable: false
		, value: function (prop, handler) {
			var
			  oldval = this[prop]
			, newval = oldval
			, getter = function () {
				return newval;
			}
			, setter = function (val) {
				oldval = newval;
				return newval = handler.call(this, prop, oldval, val);
			}
			;
			
			if (delete this[prop]) { // can't watch constants
				Object.defineProperty(this, prop, {
					  get: getter
					, set: setter
					, enumerable: true
					, configurable: true
				});
			}
		}
	});
}
 
// object.unwatch
if (!Object.prototype.unwatch) {
	Object.defineProperty(Object.prototype, "unwatch", {
		  enumerable: false
		, configurable: true
		, writable: false
		, value: function (prop) {
			var val = this[prop];
			delete this[prop]; // remove accessors
			this[prop] = val;
		}
	});
}

var ComboPopuladoConRepoBuilder = function (repositorio) {
	this.repositorio = repositorio;
};

ComboPopuladoConRepoBuilder.prototype.include = function(arr,obj) {
    return (arr.indexOf(obj) != -1);
}
ComboPopuladoConRepoBuilder.prototype.browseObject = function (obj, path) {
	var this_level_attr = path.shift();
	var this_level_value = obj[this_level_attr];
	if (path.length == 0) {
		return { obj_bindeable: obj, attr_bindeable: this_level_attr, attr_value: this_level_value };
	}
	return this.browseObject(obj[this_level_attr], path);
}

ComboPopuladoConRepoBuilder.prototype.construirCombosEn = function (dom, modelo_bindeo) {
	var repo = this.repositorio;
	var combos = [];
	var builder = this;
    dom.find('[dataProvider]').each(function () {
        var control = $(this);
		
		var parametros_constructor = {
            ui: control,
            nombre_repositorio: $(control).attr("dataProvider"),
			campo_descripcion: $(control).attr("label") || "Descripcion",
			dependencia: $(control).attr("dependeDe"),
			binding: modelo_bindeo,
            repositorio: repo
        };
		
		if (modelo_bindeo != undefined) {
			var attr_name = $(control).attr("modelo");
			if (attr_name != undefined) {
				var attr_path = attr_name.split('.');
				var attr_value = builder.browseObject(modelo_bindeo, attr_path).attr_value;
				parametros_constructor["id_item_seleccionado"] = attr_value;
			}
		}
		
		var super_combo = new SuperCombo(parametros_constructor);
		if (modelo_bindeo != undefined) {
			var attr_name = $(control).attr("modelo");
			var attr_path = attr_name.split('.');
			var binding_data = builder.browseObject(modelo_bindeo, attr_path);
			var obj_bindeable = binding_data.obj_bindeable;
			var attr_bindeable = binding_data.attr_bindeable;
			
			obj_bindeable.watch(attr_bindeable, function(prop, oldval, newval) {
				super_combo.id_item_seleccionado = newval;
			});
		}
		
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