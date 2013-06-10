var VistaDeResultadosDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeResultadosDeLegajos.prototype.start = function () {
    this.lbl_nombre = this.o.ui.find('#lbl_nombre');
    this.lbl_apellido = this.o.ui.find('#lbl_apellido');
    this.panel_documentos = this.o.ui.find('#panel_documentos');
};

VistaDeResultadosDeLegajos.prototype.mostrarLegajo = function (legajo) {
    this.lbl_nombre.text(legajo.nombre);
    this.lbl_apellido.text(legajo.apellido);
    for (var i = 0; i < legajo.documentos.length; i++) {
        this.panel_documentos.append(this.o.plantilla_vista_documento.clone());
    }
};

