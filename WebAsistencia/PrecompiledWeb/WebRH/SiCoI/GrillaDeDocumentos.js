var GrillaDeDocumentos = function (cfg) {
    var grillaDocumentos = new Grilla(
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
                                cfg.divDocumentoAEnviar.val(JSON.stringify(doc));
                                if (cfg.areaDelUsuario.id == doc.areaActual.id)
                                    cfg.btnEnviarDocumento.click();
                                else cfg.btnEnviarDocumentoConAreaIntermedia.click();
                            });
                            contenedorAcciones.append(botonEnviar);
                        }
                        return contenedorAcciones;
                    }
                    })
                ]);

    grillaDocumentos.SetOnRowClickEventHandler(function (doc) {
        cfg.panelDetalle.mostrarDocumento(doc);
    });
    grillaDocumentos.CargarObjetos(cfg.listaDocumentos);
    //grillaDocumentos.DibujarEn(cfg.panelDocumentos);

    $.extend(true, this, grillaDocumentos);
}
