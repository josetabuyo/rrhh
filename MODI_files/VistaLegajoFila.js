var VistaLegajoFila = function (opt) {
    this.o = opt;
    this.start();
};

VistaLegajoFila.prototype.start = function () {
    this.ui = $("#plantilla_ui_vista_legajo_fila").clone();
    this.lbl_nombre = this.ui.find("#lbl_nombre");
    this.lbl_apellido = this.ui.find("#lbl_apellido");
    this.lbl_cuil = this.ui.find("#lbl_cuil");
    this.lbl_id_interna = this.ui.find("#lbl_id_interna");

    this.lbl_nombre.text(this.o.legajo.nombre);
    this.lbl_apellido.text(this.o.legajo.apellido);
    this.lbl_cuil.text(this.o.legajo.cuil);
    this.lbl_id_interna.text(this.o.legajo.id_interna);

    var _this = this;
    this.ui.click(function () {        
        _this.o.onLegajoSeleccionado(_this.o.legajo);        
    });
};

VistaLegajoFila.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};