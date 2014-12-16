﻿var PanelDetalleGenerico = function (opciones) {
    //valores default
    var modelo = opciones.modelo || opciones.defaults;
    var alModificar = opciones.alModificar || function () { };

    var _this = this;
    this.ui = $("#un_div_modal");
    this.ui.find("#contenido_modal").load(opciones.path_html, function () {
        var rh_form = new FormularioBindeado({
            formulario: _this.ui,
            modelo: modelo
        });

        //Bt cerrar
        _this.btn_cerrar = _this.ui.find(".modal_close_concursar");
        _this.btn_cerrar.click(function () {                
            _this.ui.limpiarValidaciones();
        });

        //Bt agregar
        _this.btn_guardar = _this.ui.find("#btn_guardar");
        if (opciones.modelo) _this.btn_guardar.val("Guardar Cambios");

        _this.btn_guardar.click(function () {
            if (_this.ui.esValido()) {
                Backend.ejecutar(opciones.metodoDeGuardado, [modelo],
                    function (respuesta) {
                        alertify.alert(opciones.mensajeDeGuardadoExitoso);
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    function (error, as, asd) {
                        alertify.alert(opciones.mensajeDeGuardadoErroneo);
                    });    
            }
        });

        var link_trucho = $("<a href='#un_div_modal'></a>");
        link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
        link_trucho.click();
    });
};