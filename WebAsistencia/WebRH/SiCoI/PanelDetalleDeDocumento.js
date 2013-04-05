
var PanelDetalleDeDocumento = function (cfg) {
    this.cfg = cfg;
    cfg.botonCerrarDetalle.mouseenter(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s2.png');
    });

    cfg.botonCerrarDetalle.mouseleave(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s1.png');
    });
    var self = this;
    cfg.botonCerrarDetalle.click(function () {
        self.cerrar();
    });
    cfg.btnGuardarCambios.click(function () {
        var post_url = "../AjaxWS.asmx/GuardarCambiosEnDocumento";
        var post_data =  JSON.stringify({
            id_documento: self.documentoEnDetalle.id,
            id_area_destino: cfg.areaDestinoSeleccionadaEnDetalle.val(),
            comentario: cfg.txtComentariosEnDetalle.val()
        });       
        $.ajax({
            url: post_url,
            type: "POST",
            data: post_data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "guardarDocumento.ok") {
                    self._panel_documentos.refrescarGrilla();
                }
                if (respuesta.tipoDeRespuesta == "guardarDocumento.error") {
                    alert("Error al guardar cambios en documento: " + respuesta.error);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });                   
        self.cerrar();
    });
}
PanelDetalleDeDocumento.prototype = {
    setPanelAlta: function (panel) {
        this._panel_alta = panel;
    },
    setPanelFiltros: function (panel) {
        this._panel_filtros = panel;
    },
    setPanelDocumentos: function (panel) {
        this._panel_documentos = panel;
    },
    cerrar: function () {
        this._panel_documentos.desSeleccionarTodo();
        this.cfg.divPanelDetalle.fadeOut("fast");
        this._panel_documentos.desplegar();
    },
    mostrarDocumento: function (documento) {
        this.documentoEnDetalle = documento;
        this._panel_alta.contraer();
        this._panel_filtros.contraer();
        var fecha = new Date(documento.fecha);
        this.cfg.ExtractoDocumentoDetalle.text(documento.extracto);
        this.cfg.TipoDocumentoDetalle.text(documento.tipo.descripcion);
        this.cfg.NumeroDocumentoDetalle.text(documento.numero);
        this.cfg.FechaDocumentoDetalle.val(documento.fechaDeAlta);
        this.cfg.txtComentariosEnDetalle.val(documento.comentarios);
        this.cfg.AreaOrigenDocumentoDetalle.text(documento.areaCreadora.descripcion);

        this.crearHistorialDeTransiciones(documento);

        var selectorDeAreaDestinoEnDetalle = new InputAutocompletableDeAreas(this.cfg.selectorDeAreaDestinoEnDetalle, this.cfg.listaAreas, this.cfg.areaDestinoSeleccionadaEnDetalle);

        this.cfg.selectorDeAreaDestinoEnDetalle.val('');
        this.cfg.areaDestinoSeleccionadaEnDetalle.val('');
        if (documento.areaDestino != null) {
            this.cfg.selectorDeAreaDestinoEnDetalle.val(documento.areaDestino.descripcion);
            this.cfg.areaDestinoSeleccionadaEnDetalle.val(documento.areaDestino.id);
        }

        this.cfg.divPanelDetalle.fadeIn("fast");
        this._panel_documentos.contraer();
    },
    crearHistorialDeTransiciones: function (documento) {
        var contenedor = this.cfg.contenedor_historial_transiciones;
        contenedor.empty();
        for (var i = 0; i < documento.historial.length; i++) {
            var representacionTransicion = this.cfg.plantilla_transicion_documento.clone();
            representacionTransicion.attr('id', 'transicion' + i.toString());
            representacionTransicion.find('.fecha_transicion').text(documento.historial[i].fecha);
            representacionTransicion.find('.area_origen_transicion').text(documento.historial[i].areaOrigen);
            representacionTransicion.find('.area_destino_transicion').text(documento.historial[i].areaDestino);
            contenedor.append(representacionTransicion);
        }
    }

}
