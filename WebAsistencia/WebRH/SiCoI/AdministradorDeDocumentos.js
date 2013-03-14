var PanelDeFiltros = function (boton_alerta_filtros_activos, filtros) {
    this._filtros = filtros;
    this._boton_alerta_filtros_activos = boton_alerta_filtros_activos;
    for (var i = 0; i < this._filtros.length; i++) {
        this._filtros[i].setObservador(this);
    }
}

PanelDeFiltros.prototype = {
    cantidadDeFiltrosActivos: function () {
        return this.filtrosActivos().length;
    },
    filtrosActivos: function () {
        var filtros_activos = [];
        for (var i = 0; i < this._filtros.length; i++) {
            this._filtros[i].agregarFiltroAListaParaAplicar(filtros_activos);
        }
        return filtros_activos;
    },
    filtroActivado: function (filtro) {
        if (this.cantidadDeFiltrosActivos() == 1) {
            this._boton_alerta_filtros_activos.addClass('boton_que_abre_panel_desplegable_activo_con_filtros');
        }
    },
    filtroDesActivado: function (filtro) {
        if (this.cantidadDeFiltrosActivos() == 0) {
            this._boton_alerta_filtros_activos.removeClass('boton_que_abre_panel_desplegable_activo_con_filtros');
        }
    }
}

var Filtro = function (input, color_activo, color_inactivo) {
    var self = this;
    this._input = input;
    this._color_inactivo = color_inactivo;
    this._color_activo = color_activo;
    this._observador_activacion = {
        filtroActivado: function(){},
        filtroDesActivado: function(){}
    };
    this._input.change(function () {
        self.definirEstado();
    });
    this.definirEstado();
};

Filtro.prototype = {
    estaActivo: function () {
        return this._activo;
    },
    definirEstado: function () {            
        if ((this._input.val() == "") && (this._activo || this._activo === undefined)) this.desactivarFiltro();
        if ((this._input.val() != "") && (!this._activo || this._activo === undefined)) this.activarFiltro();
    },
    activarFiltro: function () {
        this._input.css('background-color', this._color_activo);
        this._activo = true;
        this.agregarFiltroAListaParaAplicar = function (lista) {
            lista.push(this.generarResumenFiltro());
        };
        this._observador_activacion.filtroActivado(this);
    },
    desactivarFiltro: function () {
        this._input.css('background-color', this._color_inactivo);
        this._activo = false;
        this.agregarFiltroAListaParaAplicar = function (lista) { };
        this._observador_activacion.filtroDesActivado(this);
    },
    setObservador: function(obs){
        this._observador_activacion = obs;
        if (this.estaActivo()) this._observador_activacion.filtroActivado(this);
        else this._observador_activacion.filtroDesActivado(this);
    }
};

var FiltroPorNumero = function (input, color_activo, color_inactivo) {
    Filtro.call(this, input, color_activo, color_inactivo);
};

FiltroPorNumero.prototype = $.extend(true, {}, Filtro.prototype);
FiltroPorNumero.prototype.constructor = FiltroPorNumero;   
FiltroPorNumero.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorNumero",
        numero: this._input.val()
    };
}

var FiltroPorExtracto = function (input, color_activo, color_inactivo) {
    Filtro.call(this, input, color_activo, color_inactivo);
};

FiltroPorExtracto.prototype = $.extend(true, {}, Filtro.prototype);
FiltroPorExtracto.prototype.constructor = FiltroPorNumero;
FiltroPorExtracto.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorExtracto",
        extracto: this._input.val()
    };
}


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

var InputAutocompletableDeAreas = function (input, listaAreas, inputAreaSeleccionada) {
    var selectorDeArea = new InputAutocompletable(input,
                                                    listaAreas,
                                                    function (a) { return a.id; },
                                                    function (a) { return a.descripcion; },
                                                    function (a) {
                                                        if (!(a === undefined)) inputAreaSeleccionada.val(a.id);
                                                        else inputAreaSeleccionada.val('');
                                                    }
                                                 );
    $.extend(true, this, selectorDeArea);
}

var AdministradorDeDocumentos = function (cfg) {
    cfg.grillaDocumentos.DibujarEn(cfg.panelDocumentos);
    var listaAreas = JSON.parse(cfg.listaAreas.val());
    var selectorDeAreaOrigenEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnAlta, listaAreas, cfg.areaOrigenSeleccionadaEnAlta);
    var selectorDeAreaDestinoEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnAlta, listaAreas, cfg.areaDestinoSeleccionadaEnAlta);
    var selectorDeAreaDestinoEnDetalle = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnDetalle, listaAreas, cfg.areaDestinoSeleccionadaEnDetalle);
    var selectorDeAreaActualEnfiltro = new InputAutocompletableDeAreas(cfg.selectorDeAreaActualEnfiltro, listaAreas, cfg.areaActualSeleccionadaEnFiltro);
    var selectorDeAreaOrigenEnfiltro = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnfiltro, listaAreas, cfg.areaOrigenSeleccionadaEnFiltro);

    //placeholdearCombos();

    var setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario = function () {
        if (cfg.chkFiltroSoloDocsEnMiArea.is(':checked')) {
            cfg.selectorDeAreaActualEnfiltro.hide();
            cfg.titulo_filtro_area_actual.hide();
        } else {
            cfg.selectorDeAreaActualEnfiltro.show();
            cfg.titulo_filtro_area_actual.show();
        }
    }
    setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario();
    cfg.chkFiltroSoloDocsEnMiArea.click(setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario);

    //despliegue panel alta
    cfg.botonDesplegarPanelAlta.click(function (e) {
        cfg.panelFiltros.slideUp("fast");
        cfg.botonDesplegarPanelFiltros.removeClass("boton_que_abre_panel_desplegable_activo");

        cfg.panelAlta.slideToggle("fast");
        cfg.botonDesplegarPanelAlta.toggleClass("boton_que_abre_panel_desplegable_activo");
        cfg.panelDetalle.cerrar();
    });

    //despliegue panel filtros
    cfg.botonDesplegarPanelFiltros.click(function (e) {
        cfg.panelAlta.slideUp("fast");
        cfg.botonDesplegarPanelAlta.removeClass("boton_que_abre_panel_desplegable_activo");

        cfg.panelFiltros.slideToggle("fast");
        cfg.botonDesplegarPanelFiltros.toggleClass("boton_que_abre_panel_desplegable_activo");
        cfg.panelDetalle.cerrar();
    });

    cfg.botonCerrarDetalle.mouseenter(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s2.png');
    });

    cfg.botonCerrarDetalle.mouseleave(function () {
        cfg.botonCerrarDetalle.attr('src', '../Imagenes/Botones/Botones Sicoi/cerrar_s1.png');
    });

    cfg.botonCerrarDetalle.click(function () {
        cfg.panelDetalle.cerrar();
    });

    cfg.filtroFechaDesde.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) { cfg.filtroFechaDesde.blur(); }
    });
    cfg.filtroFechaHasta.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) { cfg.filtroFechaHasta.blur(); } 
    });

    cfg.idTipoDeDocumentoSeleccionadoEnAlta.val("");

    for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
        var tipo = cfg.tiposDeDocumento[i];
        var listItem = $('<option>');
        listItem.val(tipo.Id);
        listItem.text(tipo.descripcion);
        cfg.cmbTipoDeDocumento.append(listItem);
        cfg.cmbFiltroPorTipoDeDocumento.append(listItem.clone());
    }

    //cfg.txtNumero.before(cfg.lblLetrasDelTipoDeDocumento);
    cfg.cmbTipoDeDocumento.change(function (e) {
        var idSeleccionado = cfg.cmbTipoDeDocumento.find('option:selected').val();
        cfg.idTipoDeDocumentoSeleccionadoEnAlta.val(idSeleccionado);

        var tipoSeleccionado;
        for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
            var tipo = cfg.tiposDeDocumento[i];
            if (tipo.Id == idSeleccionado) tipoSeleccionado = tipo;
        }
        if (tipoSeleccionado !== undefined) {
            cfg.lblLetrasDelTipoDeDocumento.text(tipoSeleccionado.sigla);
            cfg.txtNumero.parent().width(250 - cfg.lblLetrasDelTipoDeDocumento.width());
        }
        else {
            cfg.lblLetrasDelTipoDeDocumento.text('');
            cfg.txtNumero.parent().width('250px');
        }
    });

}

function crearHistorialDeTransiciones(documento) {
    var contenedor = $("#contenedor_historial_documento_detalle");
    contenedor.empty();
    for (var i = 0; i < documento.historial.length; i++) {
        var representacionTransicion = $('#proto_transicion_de_documento_historial').clone();
        representacionTransicion.attr('id', 'transicion' + i.toString());
        representacionTransicion.find('.fecha_transicion').text(documento.historial[i].fecha);
        representacionTransicion.find('.area_origen_transicion').text(documento.historial[i].areaOrigen);
        representacionTransicion.find('.area_destino_transicion').text(documento.historial[i].areaDestino);
        contenedor.append(representacionTransicion);
    }
}

function DeshabilitarControl(control) {
    if (control.prop('disabled') == false) {
        control.prop('disabled', true);
    }

}


function HabilitarControl(control) {
    if (control.prop('disabled') == true) {
        control.prop('disabled', false);
    }

}



function ValidadorComponenteVacio(ArrayDeTextBox) {

    for (x = 0; x < ArrayDeTextBox.length; x++) {

        if (ArrayDeTextBox[x].val() == "") {
            ArrayDeTextBox[x].css("background-color", '#ffffeb');
        }
        else {
            ArrayDeTextBox[x].css("background-color", '#ffffff');
        }
    }
}


function ValidadorDeAltaDeDocumento(ArrayDeControles) {
    var hayVacios = false;
    for (x = 0; x < ArrayDeControles.length; x++) {
        var atributo = ArrayDeControles[x].attr("type");
        var nombreTag = ArrayDeControles[x][0].tagName;

        if (ArrayDeControles[x].val() == "" && (atributo == "text" || nombreTag == "SELECT")) {


            //ArrayDeControles[x].css("background-color", '#ffffeb');
            ArrayDeControles[x].css("background-color", 'rgb(255, 255, 235)');

            for (y = 0; y < ArrayDeControles.length; y++) {
                if (ArrayDeControles[y].attr("type") == "submit") {

                    DeshabilitarControl(ArrayDeControles[y]);
                    hayVacios = true;
                }
            }
        }
        else {

            if (atributo == "text" || nombreTag == "SELECT") {
                ArrayDeControles[x].css("background-color", 'rgb(255, 255, 255)');
            }
        }
    }
    if (!hayVacios) {
        for (y = 0; y < ArrayDeControles.length; y++) {
            if (ArrayDeControles[y].attr("type") == "submit") {

                HabilitarControl(ArrayDeControles[y]);
                hayVacios = true;
            }

        }
    }
}


function ValidadorDeFiltrosDeDocumento(ArrayDeControles) {
    
    for (x = 0; x < ArrayDeControles.length; x++) {
        var atributo = ArrayDeControles[x].attr("type");
        var nombreTag = ArrayDeControles[x][0].tagName;

        if (atributo == "checkbox" && ArrayDeControles[x].attr("checked") == "checked") {

            $('#titulo_filtro_solo_docs_en_mi_area').css("background-color", 'rgb(255, 255, 150)');
            //  alert(ArrayDeControles[x].attr("checked"));
        }

        if ((ArrayDeControles[x].val() == "" && (atributo == "text") || (nombreTag == "SELECT" && ArrayDeControles[x].val() == "-1"))) {
            $('#titulo_filtro_solo_docs_en_mi_area').css("background-color", 'rgb(255,255, 255)');
            ArrayDeControles[x].css("background-color", 'rgb(255, 255, 255)');
        }
        else {
            if (atributo == "text" || nombreTag == "SELECT") {
                ArrayDeControles[x].css("background-color", 'rgb(255, 255, 150)');
            }
        }
    }


}





