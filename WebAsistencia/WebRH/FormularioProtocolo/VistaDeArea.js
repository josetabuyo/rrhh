var VistaDeArea = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeArea.prototype.start = function () {
    this.ui = $("#plantilla_vista_area").clone();
    this.ui.find("#nombre_area").text(this.o.area.nombre());
    this.ui.find("#responsable").text(this.o.area.responsable());
    this.ui.find("#direccion").text(this.o.area.direccion());
    this.ui.find("#telefono").text(this.o.area.telefonos());
    this.ui.find("#fax").text(this.o.area.faxes());
    this.ui.find("#mail").text(this.o.area.mails());
    for (var i = 0; i < this.o.area.asistentes.length; i++) {
        var div_titulo = $("<div class='titulo'>");
        var div_valor = $("<div class='valor'>");
        div_titulo.text(this.o.area.asistentes[i].cargo);
        div_valor.text(this.o.area.asistentes[i].resumen);
        this.ui.append(div_titulo);
        this.ui.append(div_valor);
    }
    var _this = this;
    this.ui.dialog({
        title:_this.o.area.nombre(),
        height: 300,
        width: 1020,
        modal: true,
        show: {
            effect: "puff",
            duration: 300,
            direction:'left'
        },
        hide: {
            effect: "puff",
            duration: 300,
            direction: 'right'
        },
        dialogClass: "dialog_vista_area"
    });
};