var PanelDeFiltros = function (filtros) {
    this._filtros = filtros;
    this._observadores_activacion = [];
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
            for (var i = 0; i < this._observadores_activacion.length; i++) {
                this._observadores_activacion[i].algunFiltroActivado();
            }
        }
        this.cambiaronLosFiltros();
    },
    filtroDesactivado: function (filtro) {
        if (this.cantidadDeFiltrosActivos() == 0) {
            for (var i = 0; i < this._observadores_activacion.length; i++) {
                this._observadores_activacion[i].ningunFiltroActivado();
            }
        }
        this.cambiaronLosFiltros();
    },
    cambiaronLosFiltros: function (filtro) {
        for (var i = 0; i < this._observadores_activacion.length; i++) {
            this._observadores_activacion[i].cambiaronLosFiltros();
        }
    },
    setObservador: function (obs) {
        this._observadores_activacion.push(obs);
        if (this.cantidadDeFiltrosActivos() > 0) { obs.algunFiltroActivado(); }
        if (this.cantidadDeFiltrosActivos() == 0) { obs.ningunFiltroActivado(); }
        this.cambiaronLosFiltros();
    }
}

//////////////

var FiltroDeDocumentos = function (input) {
    var self = this;
    this._input = input;
    this._observadores_activacion = [];
    this._input.change(function () {
        self.definirEstado();
    });
    this._input.keyup(function () {
        self.definirEstado();
    });
    this.definirEstado();
    this._habilitado = true;
};

FiltroDeDocumentos.prototype = {
    estaActivo: function () {
        return this._activo;
    },
    
//    && (this._activo || this._activo === undefined)
//    && (!this._activo || this._activo === undefined)
    
    definirEstado: function () {
        if ((this._input.val() == "")) this.desactivarFiltro();
        if ((this._input.val() != "")) this.activarFiltro();
    },
    activarFiltro: function () {
        this._activo = true;
        this.agregarFiltroAListaParaAplicar = function (lista) {
            if(this._habilitado) lista.push(this.generarResumenFiltro());
        };
        for (var i = 0; i < this._observadores_activacion.length; i++) {
            this._observadores_activacion[i].filtroActivado(this);
        }
    },
    desactivarFiltro: function () {
        this._activo = false;
        this.agregarFiltroAListaParaAplicar = function (lista) { };
        for (var i = 0; i < this._observadores_activacion.length; i++) {
            this._observadores_activacion[i].filtroDesactivado(this);
        }
    },
    setObservador: function (obs) {
        this._observadores_activacion.push(obs);
        this._activo = undefined;
        this.definirEstado();
    },
    habilitarFiltro: function () {
        this._habilitado = true;
        this.definirEstado();
    },
    desHabilitarFiltro: function () {
        this._habilitado = false;
        this.desactivarFiltro();
    }
};

///////////

var FiltroDeDocumentosQuePintaInput = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentos.call(this, input);
    this.setObservador(
                {
                    filtroActivado: function (filtro) {
                        input.css('background-color', color_activo);
                    },
                    filtroDesactivado: function (filtro) {
                        input.css('background-color', color_inactivo);
                    }
                }
            );
};

FiltroDeDocumentosQuePintaInput.prototype = $.extend(true, {}, FiltroDeDocumentos.prototype);
FiltroDeDocumentosQuePintaInput.prototype.constructor = FiltroDeDocumentosQuePintaInput;


////////////
var FiltroDeDocumentosPorNumero = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorNumero.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorNumero.prototype.constructor = FiltroDeDocumentosPorNumero;
FiltroDeDocumentosPorNumero.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorNumero",
        numero: this._input.val()
    };
};

///////////////

var FiltroDeDocumentosPorExtracto = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorExtracto.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorExtracto.prototype.constructor = FiltroDeDocumentosPorExtracto;
FiltroDeDocumentosPorExtracto.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorExtracto",
        extracto: this._input.val()
    };
}

///////////

var FiltroDeDocumentosSoloEnAreaUsuario = function (checkbox, idAreaUsuario) {
    this._idAreaUsuario = idAreaUsuario;
    FiltroDeDocumentos.call(this, checkbox);
};

FiltroDeDocumentosSoloEnAreaUsuario.prototype = $.extend(true, {}, FiltroDeDocumentos.prototype);
FiltroDeDocumentosSoloEnAreaUsuario.prototype.constructor = FiltroDeDocumentosSoloEnAreaUsuario;
FiltroDeDocumentosSoloEnAreaUsuario.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorAreaActual",
        idArea: this._idAreaUsuario
    };
};
FiltroDeDocumentosSoloEnAreaUsuario.prototype.definirEstado = function () {
    if ((!this._input.is(":checked")) && (this._activo || this._activo === undefined)) this.desactivarFiltro();
    if ((this._input.is(":checked")) && (!this._activo || this._activo === undefined)) this.activarFiltro();
};

///////////

var FiltroDeDocumentosPorTransicion = function (input, idAreaUsuario) {
    this._idAreaUsuario = idAreaUsuario;
    FiltroDeDocumentos.call(this, input);
};

FiltroDeDocumentosPorTransicion.prototype = $.extend(true, {}, FiltroDeDocumentos.prototype);
FiltroDeDocumentosPorTransicion.prototype.constructor = FiltroDeDocumentosPorTransicion;
FiltroDeDocumentosPorTransicion.prototype.generarResumenFiltro = function () {
    return { tipoDeFiltro: "FiltroDeDocumentosPorTransicion",
        idAreaOrigen : this._input.val(),
        idAreaDestino : this._idAreaUsuario
    };
};

///////////

var FiltroDeDocumentosPorAreaActual = function (input) {
    FiltroDeDocumentos.call(this, input);
};

FiltroDeDocumentosPorAreaActual.prototype = $.extend(true, {}, FiltroDeDocumentos.prototype);
FiltroDeDocumentosPorAreaActual.prototype.constructor = FiltroDeDocumentosPorAreaActual;
FiltroDeDocumentosPorAreaActual.prototype.generarResumenFiltro = function () {
    return { 
        tipoDeFiltro: "FiltroDeDocumentosPorAreaActual",
        idArea: this._input.val()
    };
};

///////////

var FiltroDeDocumentosPorFechaDesde = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorFechaDesde.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorFechaDesde.prototype.constructor = FiltroDeDocumentosPorFechaDesde;
FiltroDeDocumentosPorFechaDesde.prototype.generarResumenFiltro = function () {
    return {
        tipoDeFiltro : "FiltroDeDocumentosPorFechaDesde",
        fechaDesde : this._input.val()
    };
};

///////////

var FiltroDeDocumentosPorFechaHasta = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorFechaHasta.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorFechaHasta.prototype.constructor = FiltroDeDocumentosPorFechaHasta;
FiltroDeDocumentosPorFechaHasta.prototype.generarResumenFiltro = function () {
    return {
        tipoDeFiltro: "FiltroDeDocumentosPorFechaHasta",
        fechaHasta: this._input.val()
    };
};

///////////

var FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA.prototype.constructor = FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA;
FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA.prototype.generarResumenFiltro = function () {
    return {
        tipoDeFiltro: "FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA",
        dias: this._input.val()
    };
};

///////////

var FiltroDeDocumentosPorTipoDocumento = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorTipoDocumento.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorTipoDocumento.prototype.constructor = FiltroDeDocumentosPorTipoDocumento;
FiltroDeDocumentosPorTipoDocumento.prototype.generarResumenFiltro = function () {
    return {
        tipoDeFiltro: "FiltroDeDocumentosPorTipoDocumento",
        idTipo: this._input.val()
    };
};
FiltroDeDocumentosPorTipoDocumento.prototype.definirEstado = function () {
    if ((this._input.val() == "-1") && (this._activo || this._activo === undefined)) this.desactivarFiltro();
    if ((this._input.val() != "-1") && (!this._activo || this._activo === undefined)) this.activarFiltro();
};
///////////

var FiltroDeDocumentosPorCategoria = function (input, color_activo, color_inactivo) {
    FiltroDeDocumentosQuePintaInput.call(this, input, color_activo, color_inactivo);
};

FiltroDeDocumentosPorCategoria.prototype = $.extend(true, {}, FiltroDeDocumentosQuePintaInput.prototype);
FiltroDeDocumentosPorCategoria.prototype.constructor = FiltroDeDocumentosPorCategoria;
FiltroDeDocumentosPorCategoria.prototype.generarResumenFiltro = function () {
    return {
        tipoDeFiltro: "FiltroDeDocumentosPorCategoria",
        idCategoria: this._input.val()
    };
};
FiltroDeDocumentosPorCategoria.prototype.definirEstado = function () {
    if ((this._input.val() == "-1") && (this._activo || this._activo === undefined)) this.desactivarFiltro();
    if ((this._input.val() != "-1") && (!this._activo || this._activo === undefined)) this.activarFiltro();
};


//////////////////
var PanelDeFiltrosDeDocumentos = function (inputFiltroExtractoDocumento,
                                            inputFiltroNumeroDocumento,
                                            inputFiltroFechaDesde,
                                            inputFiltroFechaHasta,
                                            inputFiltroAreaActual,
                                            areaActualSeleccionadaEnFiltro,
                                            inputFiltroAreaOrigen,
                                            areaOrigenSeleccionadaEnFiltro,
                                            inputFiltroDetenidoMasDeTantosDias,
                                            inputFiltroTipoDeDocumento,
                                            inputFiltroCategoriaDocumentoFiltro,
                                            inputFiltroCheckDocumentosEnMiArea,
                                            tituloFiltroCheckDocumentosEnMiArea,
                                            divFiltrosActivos,
                                            areaDelUsuario,
                                            botonDesplegarPanelFiltros,
                                            tituloFiltroAreaActual) {
    var blanco = 'rgb(255, 255, 255)';
    var amarillo = 'rgb(255, 255, 200)';

    inputFiltroFechaDesde.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) { inputFiltroFechaDesde.change(); }
    });
    inputFiltroFechaHasta.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) { inputFiltroFechaHasta.change(); }
    });

    var filtroPorExtracto = new FiltroDeDocumentosPorExtracto(inputFiltroExtractoDocumento, amarillo, blanco);
    var filtroPorNumero = new FiltroDeDocumentosPorNumero(inputFiltroNumeroDocumento, amarillo, blanco);
    var filtroPorFechaDesde = new FiltroDeDocumentosPorFechaDesde(inputFiltroFechaDesde, amarillo, blanco);
    var filtroPorFechaHasta = new FiltroDeDocumentosPorFechaHasta(inputFiltroFechaHasta, amarillo, blanco);
    var filtroPorAreaActual = new FiltroDeDocumentosPorAreaActual(areaActualSeleccionadaEnFiltro);
    filtroPorAreaActual.setObservador(
                {
                    filtroActivado: function (filtro) {
                        inputFiltroAreaActual.css('background-color', amarillo);
                    },
                    filtroDesactivado: function (filtro) {
                        inputFiltroAreaActual.css('background-color', blanco);
                    }
                }
            );
    var filtroPorAreaOrigen = new FiltroDeDocumentosPorTransicion(areaOrigenSeleccionadaEnFiltro, areaDelUsuario.id.toString());
                filtroPorAreaOrigen.setObservador(
                {
                    filtroActivado: function (filtro) {
                        inputFiltroAreaOrigen.css('background-color', amarillo);
                    },
                    filtroDesactivado: function (filtro) {
                        inputFiltroAreaOrigen.css('background-color', blanco);
                    }
                }
            );
    var filtroPorDetenidoMasDeTantosDias = new FiltroDeDocumentosPorTiempoEnUltimaAreaMayorOIgualA(inputFiltroDetenidoMasDeTantosDias, amarillo, blanco);
    var filtroPorTipoDeDocumento = new FiltroDeDocumentosPorTipoDocumento(inputFiltroTipoDeDocumento, amarillo, blanco);
    var filtroPorCategoriaDeDocumento = new FiltroDeDocumentosPorCategoria(inputFiltroCategoriaDocumentoFiltro, amarillo, blanco);
    var filtroPorSoloEnAreaUsuario = new FiltroDeDocumentosSoloEnAreaUsuario(inputFiltroCheckDocumentosEnMiArea, areaDelUsuario.id.toString());
    filtroPorSoloEnAreaUsuario.setObservador(
                {
                    filtroActivado: function (filtro) {
                        tituloFiltroCheckDocumentosEnMiArea.css('background-color', amarillo);
                        filtroPorAreaActual.desHabilitarFiltro();
                    },
                    filtroDesactivado: function (filtro) {
                        tituloFiltroCheckDocumentosEnMiArea.css('background-color', blanco);
                        filtroPorAreaActual.habilitarFiltro();
                    }
                }
            );

    divFiltrosActivos.val('[]');
    PanelDeFiltros.call(this, [filtroPorExtracto,
                                    filtroPorNumero,
                                    filtroPorFechaDesde,
                                    filtroPorFechaHasta,
                                    filtroPorAreaActual,
                                    filtroPorAreaOrigen,
                                    filtroPorDetenidoMasDeTantosDias,
                                    filtroPorTipoDeDocumento,
                                    filtroPorCategoriaDeDocumento,
                                    filtroPorSoloEnAreaUsuario]);


    var self = this;
    this.setObservador({
                    algunFiltroActivado: function () {
                        botonDesplegarPanelFiltros.addClass('boton_que_abre_panel_desplegable_activo_con_filtros');
                    },
                    ningunFiltroActivado: function () {
                        botonDesplegarPanelFiltros.removeClass('boton_que_abre_panel_desplegable_activo_con_filtros');
                    },
                    cambiaronLosFiltros: function () {
                        divFiltrosActivos.val(JSON.stringify(self.filtrosActivos()));
                    }
                });

    var setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario = function () {
        if (inputFiltroCheckDocumentosEnMiArea.is(':checked')) {
            inputFiltroAreaActual.hide();
            tituloFiltroAreaActual.hide();
        } else {
            inputFiltroAreaActual.show();
            tituloFiltroAreaActual.show();
        }
    }
    setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario();
    inputFiltroCheckDocumentosEnMiArea.click(setearVisibilidadFiltroAreaActualSegunChkEnAreaDelUsuario);
}

PanelDeFiltrosDeDocumentos.prototype = $.extend(true, {}, PanelDeFiltros.prototype);
PanelDeFiltrosDeDocumentos.prototype.constructor = PanelDeFiltrosDeDocumentos;