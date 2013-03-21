
var PanelDetalle = function (cfg) {
    cfg.panelDetalle.cerrar = function () {
        cfg.grillaDocumentos.desSeleccionarTodo();
        cfg.panelDetalle.fadeOut("fast");
        cfg.panelDocumentos.css('height', '90%');
    }

    cfg.panelDetalle.mostrarDocumento = function (documento) {
        cfg.panelFiltros.slideUp("fast");
        cfg.botonDesplegarPanelFiltros.removeClass("boton_que_abre_panel_desplegable_activo");

        cfg.panelAlta.slideUp("fast");
        cfg.botonDesplegarPanelAlta.removeClass("boton_que_abre_panel_desplegable_activo");

        var fecha = new Date(documento.fecha);
        cfg.idDocumentoEnDetalle.val(documento.id);
        cfg.ExtractoDocumentoDetalle.text(documento.extracto);
        cfg.TipoDocumentoDetalle.text(documento.tipo.descripcion);
        cfg.NumeroDocumentoDetalle.text(documento.numero);
        cfg.FechaDocumentoDetalle.text(documento.fechaDeAlta);
        cfg.txtComentariosEnDetalle.text(documento.comentarios);
        cfg.AreaOrigenDocumentoDetalle.text(documento.areaCreadora.descripcion);

        crearHistorialDeTransiciones(documento);

        cfg.selectorDeAreaDestinoEnDetalle.val('');
        cfg.areaDestinoSeleccionadaEnDetalle.val('');
        if (documento.areaDestino != null) {
            cfg.selectorDeAreaDestinoEnDetalle.val(documento.areaDestino.descripcion);
            cfg.areaDestinoSeleccionadaEnDetalle.val(documento.areaDestino.id);
        }
        cfg.panelDetalle.fadeIn("fast");
        cfg.panelDocumentos.css('height', '50%');
    }
    $.extend(true, this, cfg.panelDetalle);
}
