var RH_FORMS = (function (rh_forms, $) {

	var _repositorio;
    function browseObject(obj_modelo, path_original, path_completo, combo) {
        var path = path_original.slice(0);
        var this_level_attr = path.shift();
        if (!obj_modelo.hasOwnProperty(this_level_attr)) {
            throw 'Error al intentar bindear el modelo "' + path_completo.join(".") + '" al combo "' + combo[0]['id'] + '"';
        }
        var this_level_value = obj_modelo[this_level_attr];
        if (path.length == 0) {
            return { obj_bindeable: obj_modelo, attr_bindeable: this_level_attr, attr_value: this_level_value };
        }
        return browseObject(obj_modelo[this_level_attr], path, path_completo, combo);
    }

    function setValorModeloBindeado(obj_modelo, path_original, event) {
        var path = path_original.slice(0);
        var this_level_attr = path.shift();
        if (path.length == 0) {
            //evito referencia circular de a bindeado a b, y b bindeado a a.
            obj_modelo.unwatch(this_level_attr);
            obj_modelo[this_level_attr] = event.target.value;
            obj_modelo.watch(this_level_attr, function (prop, oldval, newval) {
                super_combo.id_item_seleccionado = newval;
            });
        } else {
            setValorModeloBindeado(obj_modelo[this_level_attr], path, event);
        }
    }

    function cargarCombo(super_combo, objetos, campo_id, campo_descripcion) {
        super_combo.empty();
        objetos.forEach(function (item) {
            var option = $("<option value='" + item[campo_id] + "'>" + item[campo_descripcion] + "</option>");
            super_combo.append(option);
        });
    }

    function cargarBusqueda(super_combo, nombre_repositorio, filtro, campo_id, campo_descripcion) {
        
        if (nombre_repositorio) {
            if (campoDependenciaDe(super_combo) == undefined || (campoDependenciaDe(super_combo) != undefined && filtro != undefined)) {
                _repositorio.buscar(nombre_repositorio, filtro, function (items) {
                    cargarCombo(super_combo, items, campo_id, campo_descripcion);
                    super_combo.val(super_combo.id_item_seleccionado);
					super_combo.change();
                });
            }
        }
    }

    function campoDescripcionDe(combo) {
        return combo.attr("label") || "Descripcion";
    };

    function campoDependenciaDe(combo) {
        return combo.attr("dependeDe");
    };

    function bindearComboAModelo(combo, modelo) {
        var attr_name = combo.attr("modelo");
        if (attr_name != undefined) {
            var attr_path = attr_name.split('.');
            var attr_value = browseObject(modelo, attr_path, attr_path, combo).attr_value;
            combo.id_item_seleccionado = attr_value;
        }
        combo.change(function (event) {
            combo.id_item_seleccionado = event.target.value; //agregar un test que falle si remuevo esta linea
            setValorModeloBindeado(modelo, attr_path, event);
        });

        var binding_data = browseObject(modelo, attr_path);
        var obj_bindeable = binding_data.obj_bindeable;
        var attr_bindeable = binding_data.attr_bindeable;

        obj_bindeable.watch(attr_bindeable, function (prop, oldval, newval) {
            combo.id_item_seleccionado = newval;
        });
    };

    function bindearCombo(control, modelo_bindeo) {
        var combo = $(control);
        var default_id = "Id"
        combo.campo_id = default_id;
        combo.binding = modelo_bindeo;

        if (modelo_bindeo != undefined) {
            bindearComboAModelo(combo, modelo_bindeo);
        }
        cargarBusqueda(combo, combo.attr("dataProvider"), combo.filtro, default_id, campoDescripcionDe(combo));
        return combo;
    }

    function agregarDependenciasEntreCombos(combos) {
        var combosDependientesDeOtro = $.grep(combos, function (combo) {
            return campoDependenciaDe(combo) != undefined;
        });

        combosDependientesDeOtro.forEach(function (combo) {
            var comboDelQueDepende = $.grep(combos, function (each_combo) {
                return each_combo.attr("id") == campoDependenciaDe(combo);
            })[0];

			if (comboDelQueDepende == undefined) {
				throw 'El combo "' + combo.attr("id") + '" depenDe el combo "' + campoDependenciaDe(combo) + '" que no existe o no fué encontrado.';
			}

            comboDelQueDepende.change(function () {
                var filtro = {};
                filtro[combo.attr("filtradoPor")] = parseInt(comboDelQueDepende.id_item_seleccionado);
                cargarBusqueda(combo, combo.attr("dataProvider"), filtro, comboDelQueDepende.campo_id, campoDescripcionDe(comboDelQueDepende));
            });
        });
    };


    rh_forms.bindear = function (dom, repositorio, modelo_bindeo) {
        
		if(dom == undefined) {
			throw "No se ha especificado un DOM al intentar bindear con RH_FORMS"
		}
		
		if(!(typeof dom.find === "function")) {
			throw 'El dom especificado al bindear con RH_FORMS es inválido, no entiende el mensaje "find"';
		};
		
        if (repositorio == undefined) {
            throw "No se ha especificado un repositorio al momento de construir el builder de combos";
        };
		
        _repositorio = repositorio;

        var combos = $.map(dom.find('[dataProvider]'), function (each_combo) {
            return bindearCombo($(each_combo), modelo_bindeo);
        });
		
        agregarDependenciasEntreCombos(combos);
        return combos;
    };

    return rh_forms;
} (RH_FORMS || {}, $));