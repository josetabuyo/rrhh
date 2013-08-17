var SelectorDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

SelectorDeLegajos.prototype.start = function () {
    this.ui = $("#plantilla_ui_selector_legajos").clone();
    this.panelLegajos = this.ui.find("#panel_legajos");
    for (var i = 0; i < this.o.legajos.length; i++) {
        var _this = this;
        var vista = new VistaLegajoFila({
            legajo: this.o.legajos[i],
            onLegajoSeleccionado: function (legajo) {
                _this.o.onLegajoSeleccionado(legajo);
                _this.ui.dialog("close");
            }
        });
        vista.dibujarEn(this.panelLegajos);
    }
};

SelectorDeLegajos.prototype.mostrarModal = function () {
    var _this = this;
    this.ui.dialog({
        title: "Seleccione el legajo que busca",
        dialogClass: "no-close",
        modal: true,
        show: {
            effect: "fade",
            duration: 500
        }
    });
};