
var PanelDeDocumentos = function (cfg) {
    this.cfg = cfg;
    var self = this;

    this._grilla_de_documentos = new Grilla(
                [new Columna('Tipo', { generar: function (doc) { return doc.tipo.descripcion } }),
                    new Columna('Categoría', { generar: function (doc) { return doc.categoria.descripcion } }),
                    new Columna('Número', { generar: function (doc) { return doc.numero } }),
                    new Columna('Ticket', { generar: function (doc) { return doc.ticket } }),
                    new Columna('Extracto', { generar: function (doc) { return doc.extracto } }),
                    new Columna('Fecha Alta', { generar: function (doc) { return doc.fechaDeAlta } }),
                    new Columna('Área Creadora', { generar: function (doc) { return doc.areaCreadora.descripcion } }),
                    new Columna('Área Actual', { generar: function (doc) { return doc.areaActual.descripcion } }),
                    new Columna('Hace', { generar: function (doc) { return doc.enAreaActualHace.dias + " días" } }),
                    new Columna('Área Destino', { generar: function (doc) { return doc.areaDestino.descripcion } }),
                    new Columna('Obs.', { generar: function (doc) {
                        var comentarios = "";
                        if (doc.comentarios != "") {
                            var comentarios = "*";
                        }
                        return comentarios
                    }
                    }),
                    new Columna('Acciones', { generar: function (doc) {
                        var contenedorAcciones = $('<div>');
                        if (doc.areaDestino.id > -1) {
                            var botonEnviar = $('<input>');
                            botonEnviar.attr('id', 'btnEnviarDocumentoEnGrilla');
                            botonEnviar.attr('type', 'button');
                            botonEnviar.addClass('btn');
                            botonEnviar.addClass('btn-primary');
                            botonEnviar.val('enviar');
                            botonEnviar.click(function () {
                                var post_url;
                                var post_data;
                                if (cfg.areaDelUsuario.id == doc.areaActual.id) {
                                    post_url = "../AjaxWS.asmx/TransicionarDocumento";
                                    post_data = JSON.stringify({
                                        id_documento: doc.id,
                                        id_area_origen: doc.areaActual.id,
                                        id_area_destino: doc.areaDestino.id
                                    });
                                } else {
                                    post_url = "../AjaxWS.asmx/TransicionarDocumentoConAreaIntermedia";
                                    post_data = JSON.stringify({
                                        id_documento: doc.id,
                                        id_area_origen: doc.areaActual.id,
                                        id_area_intermedia: cfg.areaDelUsuario.id,
                                        id_area_destino: doc.areaDestino.id
                                    });
                                }

                                $.ajax({
                                    url: post_url,
                                    type: "POST",
                                    data: post_data,
                                    dataType: "json",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (respuestaJson) {
                                        var respuesta = JSON.parse(respuestaJson.d);
                                        if (respuesta.tipoDeRespuesta == "envioDeDocumento.ok") {
                                            self.refrescarGrilla();
                                        }
                                        if (respuesta.tipoDeRespuesta == "envioDeDocumento.error") {
                                            alert("Error al enviar el documento: " + respuesta.error);
                                        }
                                    },
                                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                                        alert(errorThrown);
                                    }
                                });
                            });
                            contenedorAcciones.append(botonEnviar);
                        }
                        return contenedorAcciones;
                    }
                    })
                ]);

    this._grilla_de_documentos.SetOnRowClickEventHandler(function (doc) {
        self._panel_detalle.mostrarDocumento(doc);
    });

    var proveedor = {
        pedirDatos: function (callback) {
            WebService.getDocumentosFiltrados(self._panel_filtros.getFiltrosActivos(), callback);
        }
    };
    this._grilla_de_documentos.setProveedorDeDatos(proveedor);

    //CargarObjetos(cfg.listaDocumentos);
    this._grilla_de_documentos.DibujarEn(cfg.divPanelDocumentos);
}

PanelDeDocumentos.prototype = {
    refrescarGrilla: function () {
        this._grilla_de_documentos.refrescar();
    },
    mostrarDocumentos: function (docs) {
        this._grilla_de_documentos.BorrarContenido();
        this._grilla_de_documentos.CargarObjetos(docs);
    },
    setPanelDetalle: function (panel) {
        this._panel_detalle = panel;
    },
    setPanelFiltros: function (panel) {
        this._panel_filtros = panel;
        this._grilla_de_documentos.refrescar();
    },
    desSeleccionarTodo: function () {
        this._grilla_de_documentos.desSeleccionarTodo();
    },
    desplegar: function () {
        this.cfg.divPanelDocumentos.css('height', '90%');
    },
    contraer: function () {
        this.cfg.divPanelDocumentos.css('height', '50%');
    }
}