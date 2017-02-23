var ServicioDeDigitalizacionDeLegajos = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
    this.spinner = new Spinner({ scale: 3 });
};

ServicioDeDigitalizacionDeLegajos.prototype.buscarLegajosParaDigitalizacion = function (criterio, on_legajo_encontrado, on_legajo_no_encontrado, on_error_de_comunicaciones) {
    var diccionario = {};
    diccionario['OK'] = on_legajo_encontrado;
    diccionario['LEGAJO_NO_ENCONTRADO'] = on_legajo_no_encontrado;

    this.proveedor_ajax.postearAUrl({ url: "BuscarLegajosParaDigitalizacion",
        data: { criterio: criterio },
        success: function (respuestaAPedidoDeLegajo) {
            diccionario[respuestaAPedidoDeLegajo.codigoDeResultado](respuestaAPedidoDeLegajo);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            on_error_de_comunicaciones();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.asignarCategoriaADocumento = function (id_categoria, tabla, id_documento) {
    this.proveedor_ajax.postearAUrl({ url: "AsignarCategoriaADocumento",
        data: {
            id_categoria: id_categoria,
            tabla: tabla,
            id_documento: id_documento
        },
        success: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.getThumbnailPorId = function (id_imagen, alto, ancho, on_imagen_encontrada) {
    var _this = this;
    $.ajax({
        url: "http://localhost:43414/AjaxWS.asmx/GetThumbnailPorId",
        type: "POST",
        data: JSON.stringify({
            id_imagen: id_imagen,
            alto: alto,
            ancho: ancho
        }),
        async: true,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var imagen;
            if (respuestaJson.hasOwnProperty('d')) {
                imagen = JSON.parse(respuestaJson.d);
            } else {
                imagen = respuestaJson;
            }
            if (!imagen.bytesImagen) {
                setTimeout(function () { _this.getThumbnailPorId(id_imagen, alto, ancho, on_imagen_encontrada); }, 100);
            } else {
                on_imagen_encontrada(imagen);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error al postear a url:", XMLHttpRequest, textStatus, errorThrown);

        }
    });


    //    this.proveedor_ajax.postearAUrl({ url: "GetThumbnailPorId",
    //        data: {
    //            id_imagen: id_imagen,
    //            alto: alto,
    //            ancho: ancho
    //        },
    //        success: function (imagen) {
    //            on_imagen_encontrada(imagen);
    //        },
    //        error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        }
    //    });
};

ServicioDeDigitalizacionDeLegajos.prototype.getImagenPorId = function (id_imagen, on_imagen_encontrada) {
    this.proveedor_ajax.postearAUrl({ url: "GetImagenPorId",
        data: {
            id_imagen: id_imagen
        },
        success: function (imagen) {
            on_imagen_encontrada(imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.asignarImagenAFolioDeLegajo = function (id_imagen, nro_folio, onSuccess) {
    var _this = this;
    this.spinner.spin($("html")[0]);
    PageHelper.deshabilitarInput();
    this.proveedor_ajax.postearAUrl({ url: "AsignarImagenAFolioDeLegajo",
        data: {
            id_imagen: id_imagen,
            nro_folio: nro_folio
        },
        success: function (orden) {
            _this.spinner.stop();
            PageHelper.habilitarInput();
            onSuccess(orden);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.error("error al asignar imágen");
            _this.spinner.stop();
            PageHelper.habilitarInput();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.asignarImagenAFolioDeLegajoPasandoPagina = function (id_imagen, nro_folio, pagina, onSuccess) {
    var _this = this;
    this.spinner.spin($("html")[0]);
    PageHelper.deshabilitarInput();
    this.proveedor_ajax.postearAUrl({ url: "AsignarImagenAFolioDeLegajoPasandoPagina",
        data: {
            id_imagen: id_imagen,
            nro_folio: nro_folio,
            pagina: pagina
        },
        success: function () {
            _this.spinner.stop();
            PageHelper.habilitarInput();
            onSuccess();
        },
        error: function (error) {
            alertify.error("error al asignar imágen");
            _this.spinner.stop();
            PageHelper.habilitarInput();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.desAsignarImagen = function (id_imagen, onSuccess) {
    var _this = this;
    this.spinner.spin($("html")[0]);
    PageHelper.deshabilitarInput();
    this.proveedor_ajax.postearAUrl({ url: "DesAsignarImagen",
        data: {
            id_imagen: id_imagen
        },
        success: function (imagen) {
            _this.spinner.stop();
            PageHelper.habilitarInput();
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.error("error al des asignar imágen");
            _this.spinner.stop();
            PageHelper.habilitarInput();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.agregarImagenSinAsignarAUnLegajo = function (id_interna, nombre_imagen, bytes_imagen, onSuccess) {
    var _this = this;
    this.spinner.spin($("html")[0]);
    PageHelper.deshabilitarInput();
    this.proveedor_ajax.postearAUrl({ url: "AgregarImagenSinAsignarAUnLegajo",
        data: {
            id_interna: id_interna,
            nombre_imagen: nombre_imagen,
            bytes_imagen: bytes_imagen
        },
        success: function (id_imagen) {
            _this.spinner.stop();
            PageHelper.habilitarInput();
            onSuccess(id_imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.error("error al agregar imágen");
            _this.spinner.stop();
            PageHelper.habilitarInput();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.agregarImagenAUnFolioDeUnLegajo = function (id_interna, numero_folio, nombre_imagen, bytes_imagen, onSuccess) {
    var _this = this;
    this.spinner.spin($("html")[0]);
    PageHelper.deshabilitarInput();
    this.proveedor_ajax.postearAUrl({ url: "AgregarImagenAUnFolioDeUnLegajo",
        data: {
            id_interna: id_interna,
            nombre_imagen: nombre_imagen,
            bytes_imagen: bytes_imagen,
            numero_folio: numero_folio
        },
        success: function (id_imagen) {
            _this.spinner.stop();
            PageHelper.habilitarInput();
            onSuccess(id_imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.error("error al agregar imágen");
            _this.spinner.stop();
            PageHelper.habilitarInput();
        }
    });
};

var recibir = function (obje) { console.log(obje) };