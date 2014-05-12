
var PanelDeDocumentos = function (cfg) {
    var self = this;
    this.lista_de_fichas = new ListaDeFichas(new FabricaDeFichasDeDocumento(cfg.plantillaFichaChica,
                                                                            cfg.plantillaFichaGrande,
                                                                            cfg.plantillaTransicion,
                                                                            cfg.areaDelUsuario,
                                                                            cfg.repositorioDeAreas),
                                                cfg.uiListaDeDocs,
                                                50, 
                                                "La búsqueda devolvió más de 50 documentos, por favor refine los filtros");
    var proveedor = {
        pedirDatos: function (callback) {
            WebService.getDocumentosFiltrados(self._panel_filtros.getFiltrosActivos(), callback);
        }
    };
    this.lista_de_fichas.setProveedorDeDatos(proveedor);
    this.lista_de_fichas.dibujarEn(cfg.divPanelDocumentos);
    this.btnOrdenarPorAreaActual = cfg.btnOrdenarPorAreaActual;
    this.btnOrdenarPorAreaActual.click(function () {
        self.ordenarPorAreaActual();
    });
    this.btnOrdenarPorTipo = cfg.btnOrdenarPorTipo;
    this.btnOrdenarPorTipo.click(function () {
        self.ordenarPorTipo();
    });
}

PanelDeDocumentos.prototype = {
    limpiarFlechasOrdenamiento: function () {
        this.btnOrdenarPorAreaActual.find("i").removeClass("icon-chevron-up");
        this.btnOrdenarPorAreaActual.find("i").removeClass("icon-chevron-down");
        this.btnOrdenarPorTipo.find("i").removeClass("icon-chevron-up");
        this.btnOrdenarPorTipo.find("i").removeClass("icon-chevron-down");
    },
    ordenarPorAreaActual: function () {
        var self = this;
        this.lista_de_fichas.ordenarPor(function (d) { return d.areaActual.descripcion; });
        this.limpiarFlechasOrdenamiento();
        this.btnOrdenarPorAreaActual.find("i").addClass("icon-chevron-down");
        this.btnOrdenarPorAreaActual.unbind("click");
        this.btnOrdenarPorAreaActual.click(function () {
            self.ordenarPorAreaActualEnFormaDescendente();
        });
    },
    ordenarPorAreaActualEnFormaDescendente: function () {
        var self = this;
        this.lista_de_fichas.ordenarDescendentementePor(function (d) { return d.areaActual.descripcion; });
        this.limpiarFlechasOrdenamiento();
        this.btnOrdenarPorAreaActual.find("i").addClass("icon-chevron-up");
        this.btnOrdenarPorAreaActual.unbind("click");
        this.btnOrdenarPorAreaActual.click(function () {
            self.ordenarPorAreaActual();
        });
    },
    ordenarPorTipo: function () {
        var self = this;
        this.lista_de_fichas.ordenarPor(function (d) { return d.tipo.descripcion; });
        this.limpiarFlechasOrdenamiento();
        this.btnOrdenarPorTipo.find("i").addClass("icon-chevron-down");
        this.btnOrdenarPorTipo.unbind("click");
        this.btnOrdenarPorTipo.click(function () {
            self.ordenarPorTipoEnFormaDescendente();
        });
    },
    ordenarPorTipoEnFormaDescendente: function () {
        var self = this;
        this.lista_de_fichas.ordenarDescendentementePor(function (d) { return d.tipo.descripcion; });
        this.limpiarFlechasOrdenamiento();
        this.btnOrdenarPorTipo.find("i").addClass("icon-chevron-up");
        this.btnOrdenarPorTipo.unbind("click");
        this.btnOrdenarPorTipo.click(function () {
            self.ordenarPorTipo();
        });
    },
    refrescarDocumentos: function () {
        this.limpiarFlechasOrdenamiento();
        this.lista_de_fichas.refrescar();
    },
    mostrarDocumentos: function (docs) {
        this.lista_de_fichas.borrarContenido();
        this.lista_de_fichas.cargarObjetos(docs);
    },
    setPanelDetalle: function (panel) {
        this._panel_detalle = panel;
    },
    setPanelFiltros: function (panel) {
        this._panel_filtros = panel;
        this.lista_de_fichas.refrescar();
    },
    desSeleccionarTodo: function () {
        this.lista_de_fichas.desSeleccionarTodo();
    }
}