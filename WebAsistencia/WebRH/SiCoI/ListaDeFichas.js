var ListaDeFichas = function (fabrica_de_fichas, ui, max_items, mensaje_de_cantidad_excedente) {
    this.ui = ui;
    this.fabrica_de_fichas = fabrica_de_fichas;
    this.max_items = max_items;
    this.mensaje_de_cantidad_excedente = mensaje_de_cantidad_excedente;
    this.start();
};

ListaDeFichas.prototype = {
    start: function () {
        this.mensaje_maxima_cantidad_de_items_superada = this.ui.find("#mensaje_maxima_cantidad_de_items_superada");
        this.panel_fichas = this.ui.find("#panel_fichas");
        this.mensaje_maxima_cantidad_de_items_superada.text(this.mensaje_de_cantidad_excedente);
        this.objetos = [];
    },
    setProveedorDeDatos: function (proveedor) {
        this.proveedor_de_datos = proveedor;
    },
    refrescar: function () {
        this.mensaje_maxima_cantidad_de_items_superada.hide();
        this.borrarContenido();
        var self = this;
        this.proveedor_de_datos.pedirDatos(function (obj) { self.cargarObjetos(obj); });
    },
    cargarObjetos: function (objetos) {
        if (objetos.length > this.max_items) {
            objetos = objetos.slice(0, this.max_items - 1);
            this.mensaje_maxima_cantidad_de_items_superada.show();
        } else {
            this.mensaje_maxima_cantidad_de_items_superada.hide();
        }
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
        ficha.dibujarEn(this.panel_fichas);
        this.objetos.push(obj);
    },
    borrarContenido: function () {
        this.panel_fichas.empty();
        this.objetos = new Array();
    },
    desSeleccionarTodo: function () {

    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    }
};