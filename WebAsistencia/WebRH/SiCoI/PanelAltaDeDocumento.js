
var PanelAltaDeDocumento = function (cfg) {
    this.cfg = cfg;
    this.selectorDeAreaOrigenEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnAlta, cfg.listaAreas);
    this.selectorDeAreaDestinoEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnAlta, cfg.listaAreas);

    cfg.cmbTipoDeDocumento.change(function (e) {
        var idSeleccionado = cfg.cmbTipoDeDocumento.find('option:selected').val();

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

    for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
        var tipo = cfg.tiposDeDocumento[i];
        var listItem = $('<option>');
        listItem.val(tipo.Id);
        listItem.text(tipo.descripcion);
        cfg.cmbTipoDeDocumento.append(listItem);
    }

    for (var i = 0; i < cfg.categoriasDeDocumento.length; i++) {
        var categoria = cfg.categoriasDeDocumento[i];
        var listItem = $('<option>');
        listItem.val(categoria.Id);
        listItem.text(categoria.descripcion);
        cfg.cmbCategoriaDocumento.append(listItem);
    }

    var self = this;
    this.selectorDeAreaOrigenEnAlta.change(function () { self.validarAltaDeDocumento(); });
    cfg.cmbTipoDeDocumento.change(function () { self.validarAltaDeDocumento(); });
    cfg.cmbCategoriaDocumento.change(function () { self.validarAltaDeDocumento(); });
    cfg.txtExtracto.keyup(function () { self.validarAltaDeDocumento(); });

    this.validarAltaDeDocumento();

    this.cfg.botonDesplegarPanelAlta.click(function (e) {
        self._panel_filtros.contraer();
        self.alternarDespliegue();
    });

    cfg.btnCrearDocumento.click(function () {
        var documento_dto = {
            extracto: cfg.txtExtracto.val(),
            tipo: cfg.cmbTipoDeDocumento.val(),
            categoria: cfg.cmbCategoriaDocumento.val(),
            id_area_origen: self.selectorDeAreaOrigenEnAlta.areaSeleccionada().id,
            id_area_destino: self.selectorDeAreaDestinoEnAlta.areaSeleccionada().id,
            id_area_actual: cfg.areaDelUsuario.id,
            numero: cfg.txtNumero.val(),
            comentarios: cfg.txtComentarios.val()
        };
        $.ajax({
            url: "../AjaxWS.asmx/CrearDocumento",
            type: "POST",
            data: "{'documento_dto' : '" + JSON.stringify(documento_dto) + "'}",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "altaDeDocumento.ok") {
                    var ticket = JSON.parse(respuestaJson.d).ticket;
                    self.contraer();
                    self.limpiarCampos();
                    self._panel_documentos.refrescarDocumentos();
                    alert("Se creó un documento con el número de ticket: " + ticket);
                }
                if (respuesta.tipoDeRespuesta == "altaDeDocumento.error") {
                    alert("Error al dar de alta el documento: " + respuesta.error);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    cfg.btnCancelar.click(function () {
        self.contraer();
        self.limpiarCampos();
    });
}

PanelAltaDeDocumento.prototype = {
    setPanelFiltros: function (panel) {
        this._panel_filtros = panel;
    },
    setPanelDocumentos: function (panel) {
        this._panel_documentos = panel;
    },
    limpiarCampos: function () {
        this.cfg.txtExtracto.val("");
        this.cfg.txtExtracto.blur();
        this.cfg.cmbTipoDeDocumento.val(-1);
        this.cfg.cmbTipoDeDocumento.blur();
        this.cfg.cmbCategoriaDocumento.val(-1);
        this.cfg.cmbCategoriaDocumento.blur();
        this.selectorDeAreaOrigenEnAlta.limpiar();
        this.selectorDeAreaOrigenEnAlta.blur();
        this.selectorDeAreaDestinoEnAlta.limpiar();
        this.selectorDeAreaDestinoEnAlta.blur();
        this.cfg.txtNumero.val("");
        this.cfg.txtNumero.blur();
        this.cfg.txtComentarios.val("");
        this.cfg.txtComentarios.blur();
    },
    alternarDespliegue: function () {
        this.cfg.divPanelAlta.slideToggle("fast");
        this.cfg.botonDesplegarPanelAlta.toggleClass("boton_que_abre_panel_desplegable_activo");
    },
    desplegar: function () {
        this.cfg.divPanelAlta.slideDown("fast");
        this.cfg.botonDesplegarPanelAlta.addClass("boton_que_abre_panel_desplegable_activo");
    },
    contraer: function () {
        this.cfg.divPanelAlta.slideUp("fast");
        this.cfg.botonDesplegarPanelAlta.removeClass("boton_que_abre_panel_desplegable_activo");
    },
    validarAltaDeDocumento: function () {
        if (this.selectorDeAreaOrigenEnAlta.areaSeleccionada().id == '') {
            this.cfg.selectorDeAreaOrigenEnAlta.css("background-color", 'rgb(255, 255, 235)');
        } else {
            this.cfg.selectorDeAreaOrigenEnAlta.css("background-color", 'rgb(255, 255, 255)');
        }

        if (this.cfg.cmbTipoDeDocumento.val() == '') {
            this.cfg.cmbTipoDeDocumento.css("background-color", 'rgb(255, 255, 235)');
        } else {
            this.cfg.cmbTipoDeDocumento.css("background-color", 'rgb(255, 255, 255)');
        }

        if (this.cfg.cmbCategoriaDocumento.val() == '') {
            this.cfg.cmbCategoriaDocumento.css("background-color", 'rgb(255, 255, 235)');
        } else {
            this.cfg.cmbCategoriaDocumento.css("background-color", 'rgb(255, 255, 255)');
        }

        if (this.cfg.txtExtracto.val() == '') {
            this.cfg.txtExtracto.css("background-color", 'rgb(255, 255, 235)');
        } else {
            this.cfg.txtExtracto.css("background-color", 'rgb(255, 255, 255)');
        }

        if (this.selectorDeAreaOrigenEnAlta.areaSeleccionada().id == '' ||
            this.cfg.cmbTipoDeDocumento.val() == '' ||
            this.cfg.cmbCategoriaDocumento.val() == '' ||
            this.cfg.txtExtracto.val() == '') {
            this.cfg.btnCrearDocumento.prop('disabled', true);
        } else {
            this.cfg.btnCrearDocumento.prop('disabled', false);
        }
    }
}