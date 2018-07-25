var Backend = {
    start: function (on_ready, options) {
        this.options = options || { spin_options: { config: { scale: 3 }, container: $("html")[0]} };
        var _this = this;
        this.proveedor().postearAUrl({
            url: "MetodosDelBackend",
            success: function (objetos) {
                for (var i = 0; i < objetos.length; i++) {
                    _this.agregarMetodo(objetos[i].nombre);
                }
                if (on_ready) on_ready();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("error al obtener métodos del backend")
            }
        });
    },
    spinerEn: function (tmpContainer, tmpConfig) {
        if (!tmpConfig) tmpConfig = { scale: 0.5, position: 'relative', left: '50%', top: '50%' };
        if (this.options && this.options.spin_options) {
            this.options.spin_options.tmpContainer = tmpContainer[0];
            this.options.spin_options.tmpConfig = tmpConfig;
        }
        return this;
    },
    setSpinOptions: function (spin_options) {
        this.options.spin_options = spin_options
    },
    spin: function () {
        if (this.options && this.options.spin_options) {
            if (this.options.spin_options.tmpContainer) {
                this.options.spin_options.tempSpinner = new Spinner(this.options.spin_options.tmpConfig)
                this.options.spin_options.tempSpinner.spin(this.options.spin_options.tmpContainer)
            } else {
                if (!this.options.spin_options.spinner) this.options.spin_options.spinner = new Spinner(this.options.spin_options.config)
                this.options.spin_options.spinner.spin(this.options.spin_options.container)
            }
        }
    },
    stopSpin: function () {
        if (this.options && this.options.spin_options) {
            if (this.options.spin_options.tempSpinner) {
                this.options.spin_options.tempSpinner.stop()
                delete this.options.spin_options.tmpContainer
                delete this.options.spin_options.tmpConfig
                delete this.options.spin_options.tempSpinner
            } else {
                this.options.spin_options.spinner.stop()
            }
        }
    },
    sync: {},
    proveedor: function () {
        this._proveedor = this._proveedor || new ProveedorAjax();
        return this._proveedor;
    },
    onBackendSuccessCallback: function (promesa) {
        _this = this;
        return function (data) {
            _this.stopSpin()
            if (data.hasOwnProperty("DioError")) {
                if (data.DioError) {
                    if (promesa._on_error_callback) promesa.error(null, 'error', data.MensajeDeErrorAmigable)
                    else _this.defaultErrorHandler(null, 'error', data.MensajeDeErrorAmigable)
                    return
                }
            }
            promesa.success(data)
        }
    },
    onBackendErrorCallback: function (promesa) {
        var _this = this
        return function (XMLHttpRequest, textStatus, errorThrown) {
            _this.stopSpin()
            if (promesa._on_error_callback) promesa.error(XMLHttpRequest, textStatus, errorThrown)
            else _this.defaultErrorHandler(XMLHttpRequest, textStatus, errorThrown)
        }
    },
    defaultErrorHandler: function (XMLHttpRequest, textStatus, errorThrown) {
        alert(errorThrown)
    },
    agregarMetodo: function (nombre_metodo) {
        var _this = this;
        this[nombre_metodo] = function () {
            var promesa = new Promesa();
            _this.ejecutar(nombre_metodo, arguments, _this.onBackendSuccessCallback(promesa), _this.onBackendErrorCallback(promesa))
            return promesa;
        };
        this.sync[nombre_metodo] = function () {
            return _this.ejecutarSincronico(nombre_metodo, arguments)
        };
    },
    ejecutar: function (nombre_metodo, args, success, error) {
        var argumentos_json = [];
        for (var i = 0; i < args.length; i++) {
            if (typeof args[i] == "string") argumentos_json.push(args[i]);
            else argumentos_json.push(JSON.stringify(args[i]));
        }
        this.spin();
        this.proveedor().postearAUrl({
            url: "EjecutarEnBackend",
            data: {
                nombre_metodo: nombre_metodo,
                argumentos_json: argumentos_json
            },
            success: success,
            error: error
        });
    },
    ejecutarSincronico: function (nombre_metodo, args, on_error) {
        var argumentos_json = [];
        for (var i = 0; i < args.length; i++) {
            if (typeof args[i] == "string") argumentos_json.push(args[i]);
            else argumentos_json.push(JSON.stringify(args[i]));
        }
        var respuesta;
        this.proveedor().postearAUrl({
            url: "EjecutarEnBackend",
            data: {
                nombre_metodo: nombre_metodo,
                argumentos_json: argumentos_json
            },
            async: false,
            success: function (r) {
                respuesta = r;
            },
            error: function (error) {
                if (on_error) on_error(error);
            }
        });
        return respuesta;
    }
};