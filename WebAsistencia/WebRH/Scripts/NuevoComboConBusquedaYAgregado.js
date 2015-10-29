var ComboConBusquedaYAgregado = function (opt) {
    var _this = this;
    var def = {
        propiedadId: "Id",
        propiedadLabel: "Descripcion",
        filtro: {}
    }
    $.extend(true, this, def, opt);

    this.objetosCargados = [];
    this.callbacks_change = [];

    var _this = this;

    var opciones_select2 = {
        minimumInputLength: 3,
        width: 'resolve',
        allowClear: true,
        placeholder: this.placeholder || 'seleccione',
        query: function (query) {
            var filtro = $.extend({}, _this.filtro);
            filtro[_this.propiedadLabel] = "*" + query.term + "*";
            Repositorio.buscar(_this.dataProvider, filtro, function (objetos) {
                var data = { results: objetos };
                _this.objetosCargados = objetos;
                query.callback(data);
                //                _this.select.empty();
                //                _this.select.append($("<option>"));
                //                objetos.forEach(function (objeto) {
                //                    var option = $("<option value='" + objeto[_this.propiedadId] + "'>" + objeto[_this.propiedadLabel] + "</option>");
                //                    _this.select.append(option);
                //                });
                //                if (_this.idSeleccionado() === undefined) _this.limpiarSeleccion();
                //                else _this.idSeleccionado(_this.idSeleccionado());
            });
        },
        dropdownCssClass: "bigdrop",
        id: function (obj) {
            return obj[_this.propiedadId];
        },
        escapeMarkup: function (m) { return m; },
        formatResult: function (o) { return _this.generarVistaObjeto(o); },
        formatSelection: function (o) { return _this.generarVistaObjeto(o); }
    };

    if (this.permiteAgregar) {
//        opciones_select2.formatNoMatches = function (str_ingresado) {
//            if (!_this.nombre_funcion_global_agregado) _this.nombre_funcion_global_agregado = _this.nombreFuncionRandom();
//            window[_this.nombre_funcion_global_agregado] = function () {
//                alertify.confirm("¿Está seguro que desea agregar el elemento: " + str_ingresado + "?",
//                    function (respuesta) {
//                        if (!respuesta) {
//                            _this.select.select2("close");
//                            return;
//                        }
//                        if (_this.filtro) {
//                            var parametros = [str_ingresado];
//                            for (var key in _this.filtro) {
//                                parametros.push(_this.filtro[key]);
//                            }

//                            Repositorio.agregarConMasDatos(_this.dataProvider, parametros, function (objeto) {
//                                _this.objetosCargados.push(objeto);
//                                var option = $("<option value='" + objeto[_this.propiedadId] + "'>" + objeto[_this.propiedadLabel] + "</option>");
//                                _this.select.append(option);
//                                _this.idSeleccionado(objeto.Id);
//                                window[_this.nombre_funcion_global_agregado] = undefined;
//                                _this.select.select2("close");
//                                alertify.success('Elemento agregado');
//                            }, function () {
//                                alertify.error('Error al agregar elemento');
//                                _this.select.select2("close");
//                            });
//                        }
//                        else {
//                            Repositorio.agregar(_this.dataProvider, str_ingresado, function (objeto) {
//                                _this.objetosCargados.push(objeto);
//                                var option = $("<option value='" + objeto[_this.propiedadId] + "'>" + objeto[_this.propiedadLabel] + "</option>");
//                                _this.select.append(option);
//                                _this.idSeleccionado(objeto.Id);
//                                window[_this.nombre_funcion_global_agregado] = undefined;
//                                _this.select.select2("close");
//                                alertify.success('Elemento agregado');
//                            }, function () {
//                                alertify.error('Error al agregar elemento');
//                                _this.select.select2("close");
//                            });
//                        }
//                    },
//                    function () {
//                        _this.select.select2("close");
//                    }
//                );
//            };
        }
        this.select.select2(opciones_select2);
        this.select.on("select2-selecting", function (e) {
            _this.change();
        });

}

ComboConBusquedaYAgregado.prototype.nombreFuncionRandom = function () {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
};


ComboConBusquedaYAgregado.prototype.idSeleccionado = function (id_seleccionado) {
    if (id_seleccionado !== undefined) {
        this._id_seleccionado = id_seleccionado;
        if (this.objetosCargados.length > 0) {
            var criterio_busqueda = {};
            criterio_busqueda[this.propiedadId] = id_seleccionado;
            if (this.objetosCargados.find(criterio_busqueda)) this.select.select2("val", id_seleccionado);
            else {
                this.limpiarSeleccion();
                console.log("No hay cargado en la colección ningun elemento con el id:" + id_seleccionado)
            }
        }
        this.change();
    }
    return this._id_seleccionado;
};
ComboConBusquedaYAgregado.prototype.itemSeleccionado = function () {
    if (!this.idSeleccionado()) return undefined;
    return this.objetosCargados.find(JSON.parse("{\"" + this.propiedadId + "\":" + this.idSeleccionado() + "}"));
};

ComboConBusquedaYAgregado.prototype.limpiarSeleccion = function () {
    this._id_seleccionado = undefined;
    this.select.select2("val", "");
    this.change();
};

ComboConBusquedaYAgregado.prototype.generarVistaObjeto = function (obj) {
    return $("<div value='" + obj[this.propiedadId] + "'>" + obj[this.propiedadLabel] + "</div>");
};

ComboConBusquedaYAgregado.prototype.change = function (callback) {
    if (callback) this.callbacks_change.push(callback);
    else {
        this.callbacks_change.forEach(function (cb) {
            cb();
        });
    }
};