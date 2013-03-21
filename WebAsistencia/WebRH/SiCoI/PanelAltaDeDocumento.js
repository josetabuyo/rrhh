
var PanelAltaDeDocumento = function (cfg) {
    this.cfg = cfg;
    var selectorDeAreaOrigenEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaOrigenEnAlta, cfg.listaAreas, cfg.areaOrigenSeleccionadaEnAlta);
    var selectorDeAreaDestinoEnAlta = new InputAutocompletableDeAreas(cfg.selectorDeAreaDestinoEnAlta, cfg.listaAreas, cfg.areaDestinoSeleccionadaEnAlta);

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

    cfg.idTipoDeDocumentoSeleccionadoEnAlta.val("");

    for (var i = 0; i < cfg.tiposDeDocumento.length; i++) {
        var tipo = cfg.tiposDeDocumento[i];
        var listItem = $('<option>');
        listItem.val(tipo.Id);
        listItem.text(tipo.descripcion);
        cfg.cmbTipoDeDocumento.append(listItem);
    }

    var self = this;
    cfg.areaOrigenSeleccionadaEnAlta.change(function () { self.validarAltaDeDocumento(); });
    cfg.cmbTipoDeDocumento.change(function () { self.validarAltaDeDocumento(); });
    cfg.cmbCategoriaDocumento.change(function () { self.validarAltaDeDocumento(); });
    cfg.txtExtracto.keyup(function () { self.validarAltaDeDocumento(); });

    this.validarAltaDeDocumento();

    this.cfg.botonDesplegarPanelAlta.click(function (e) {
        self._panel_filtros.contraer();
        self.alternarDespliegue();
        self._panel_detalle.cerrar();
    });
}

PanelAltaDeDocumento.prototype = {
    setPanelDetalle: function (panel) {
        this._panel_detalle = panel;
    },
    setPanelFiltros: function (panel) {
        this._panel_filtros = panel;
    },
    alternarDespliegue: function () {
        this.cfg.divPanelAlta.slideToggle("fast");
        this.cfg.botonDesplegarPanelAlta.toggleClass("boton_que_abre_panel_desplegable_activo");
    },
    desplegar: function(){
        this.cfg.divPanelAlta.slideDown("fast");
        this.cfg.botonDesplegarPanelAlta.addClass("boton_que_abre_panel_desplegable_activo");
    },
    contraer: function () {
        this.cfg.divPanelAlta.slideUp("fast");
        this.cfg.botonDesplegarPanelAlta.removeClass("boton_que_abre_panel_desplegable_activo");
    },
    validarAltaDeDocumento: function () {
        if (this.cfg.areaOrigenSeleccionadaEnAlta.val() == '') {
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

        if (this.cfg.areaOrigenSeleccionadaEnAlta.val() == '' ||
            this.cfg.cmbTipoDeDocumento.val() == '' ||
            this.cfg.cmbCategoriaDocumento.val() == '' ||
            this.cfg.txtExtracto.val() == '') {
                this.cfg.btnCrearDocumento.prop('disabled', true);
        } else {
                this.cfg.btnCrearDocumento.prop('disabled', false);
        }
    }
}