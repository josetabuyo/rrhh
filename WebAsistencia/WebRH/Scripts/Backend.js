var Backend = {
    start: function () {
        var _this = this;
        this.proveedor = new ProveedorAjax();
        this.proveedor.postearAUrl({
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
    agregarMetodo: function (nombre_metodo) {
        var _this = this;
        this[nombre_metodo] = function (args, success, error) {
            _this.ejecutar(nombre_metodo, args, success, error);
        }
    },
    ejecutar: function (nombre_metodo, args, success, error) {
        var argumentos_json = [];
        for (var i = 0; i < args.length; i++) {
            argumentos_json.push(JSON.stringify(args[i]));
        }
        this.proveedor.postearAUrl({
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