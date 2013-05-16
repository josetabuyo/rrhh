var ListaDeFichas = function (fabrica_de_fichas, ui, max_items, mensaje_de_cantidad_excedente) {
    this.ui = ui;
    this.fabrica_de_fichas = fabrica_de_fichas;
    this.start();
};

ListaDeFichas.prototype = {
    start: function () {
        this.objetos = [];
    },
    setProveedorDeDatos: function (proveedor) {
        this.proveedor_de_datos = proveedor;
    },
    refrescar: function () {
        this.borrarContenido();
        var self = this;
        this.proveedor_de_datos.pedirDatos(function (obj) { self.cargarObjetos(obj); });
    },
    cargarObjetos: function (objetos) {
        for (var i = 0; i < objetos.length; i++) {
            var obj = objetos[i];
            this.cargarObjeto(obj);
        }
    },
    ordenarPor: function (criterioOrdenamiento) {
        var objetosOrdenados = Enumerable.From(this.objetos)
                        .OrderBy(function (o) {
                            return criterioOrdenamiento(o) 
                        })
                        .ToArray();
        this.borrarContenido();
        this.cargarObjetos(objetosOrdenados);
    },
    ordenarDescendentementePor: function (criterioOrdenamiento) {
        var objetosOrdenados = Enumerable.From(this.objetos)
                        .OrderByDescending(function (o) {
                            return criterioOrdenamiento(o)
                        })
                        .ToArray();
        this.borrarContenido();
        this.cargarObjetos(objetosOrdenados);
    },
    cargarObjeto: function (obj) {
        var ficha = this.fabrica_de_fichas.crearFichaChica(obj);
        ficha.dibujarEn(this.ui);
        this.objetos.push(obj);
    },
    borrarContenido: function () {
        this.ui.empty();
        this.objetos = new Array();
    },
    desSeleccionarTodo: function () {

    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    }
};