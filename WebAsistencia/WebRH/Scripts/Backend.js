var Backend = {
    start: function () {
        var _this = this;
        this.proveedor().postearAUrl({
            url: "MetodosDelBackend",
            success: function (objetos) {
                for (var i = 0; i < objetos.length; i++) {
                    _this.agregarMetodo(objetos[i].nombre);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("error al obtener métodos del backend")
            }
        });
    },
    proveedor: function () {
        this._proveedor = this._proveedor || new ProveedorAjax();
        return this._proveedor;
    },
    agregarMetodo: function (nombre_metodo) {
        var _this = this;
        this[nombre_metodo] = function () {
            var promesa = new Promesa();
            _this.ejecutar(nombre_metodo, arguments, function (data) { promesa.success(data) }, function (data) { promesa.error(data) });
            return promesa;
        }
    },
    ejecutar: function (nombre_metodo, args, success, error) {
        var argumentos_json = [];
        for (var i = 0; i < args.length; i++) {
            argumentos_json.push(JSON.stringify(args[i]));
        }
        this.proveedor().postearAUrl({
            url: "EjecutarEnBackend",
            data: {
                nombre_metodo: nombre_metodo,
                argumentos_json: argumentos_json
            },
            success: success,
            error: error
        });
    }
};