var BuscadorDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

BuscadorDeLegajos.prototype.start = function () {
    var _this = this;
    this.input_numero = this.o.ui.find('#input_numero');
    this.input_numero.keypress(function(event) {
        if ( event.which == 13 ) {
            _this.buscar();
        }      
    });
    this.aviso_legajo_no_encontrado = this.o.ui.find('#aviso_legajo_no_encontrado');
    this.aviso_legajo_no_encontrado.hide();
};
BuscadorDeLegajos.prototype.buscar = function () {
    var _this = this;
    this.aviso_legajo_no_encontrado.hide();
    this.mostrarBarraDeEspera();
    this.input_numero.prop('disabled', true);
    this.o.servicioDeLegajos.buscarLegajosParaDigitalizacion(this.input_numero.val(), //numero_legajo
                                       function (respuesta) {
                                           _this.o.vistaDeResultados.mostrarLegajo(respuesta.legajos[0]);
                                           _this.ocultarBarraDeEspera();
                                           _this.o.ui.dialog("close");
                                       },
                                       function () {
                                           _this.aviso_legajo_no_encontrado.text("Legajo no encontrado");
                                           _this.ocultarBarraDeEspera();
                                           _this.input_numero.prop('disabled', false);                              
                                           _this.aviso_legajo_no_encontrado.show();
                                       },
                                       function () {
                                           _this.aviso_legajo_no_encontrado.text("Error de comunicaciones");
                                           _this.ocultarBarraDeEspera();
                                           _this.input_numero.prop('disabled', false);
                                           _this.aviso_legajo_no_encontrado.show();
                                       });
};
BuscadorDeLegajos.prototype.mostrandoAvisoDeLegajoNoEncontrado = function () {
    return this.aviso_legajo_no_encontrado.css('display') != 'none';
};

BuscadorDeLegajos.prototype.mostrarModal = function () {
    var _this = this;
    this.input_numero.prop('disabled', false);
    this.input_numero.val("");
    this.o.ui.dialog({
        title: "Ingrese criterios de búsqueda",
        dialogClass: "no-close",
        modal: true,
        buttons: [
            {   text: "Buscar",
                click: function () {
                    _this.buscar();
                }
            }
        ],
        show: {
            effect: "fade",
            duration: 500
        }
    });
};

BuscadorDeLegajos.prototype.mostrarBarraDeEspera = function () {
    this.progress_bar = $('<div>');
    var progress_label = $("<div>");
    progress_label.css("float", "left");
    progress_label.css("margin-left", "25%");
    progress_label.css("margin-top", "5px");
    progress_label.css("font-weight", "bold");

    progress_label.text("Buscando legajo...");

    this.progress_bar.append(progress_label);

    this.progress_bar.progressbar({
        value: false
    });
    this.progress_bar.progressbar("option", "value", false);
    this.o.ui.dialog("widget").find(".ui-dialog-buttonset").hide();
    this.o.ui.dialog("widget").find(".ui-dialog-buttonpane").append(this.progress_bar);
    this.progress_bar.show();
};

BuscadorDeLegajos.prototype.ocultarBarraDeEspera = function () {
    this.progress_bar.remove();
    this.o.ui.dialog("widget").find(".ui-dialog-buttonset").show();
};                               

