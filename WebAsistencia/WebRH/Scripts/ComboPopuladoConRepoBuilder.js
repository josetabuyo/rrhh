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
				Object.watch(attr, function(watcher, prop, oldval, val) {
					alert(val);
				});
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