var VistaDeArea = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeArea.prototype.start = function () {
    this.ui = $("#plantilla_vista_area").clone();
    this.div_datos_area = this.ui.find("#datos_area");
    this.div_datos_area.text(JSON.stringify(this.o.area));
    this.ui.dialog({
        title: this.o.area.Nombre,
        height: 300,
        width: 1020,
        modal: true,
        show: {
            effect: "fade",
            duration: 500
        }
    });
};