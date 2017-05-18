var SubidorDeImagenes = function () {
};

SubidorDeImagenes.prototype.subirImagenes = function (onImagenLista, recortar) {
    var _this = this;
    var fileInputImagenes = $('<input type="file" multiple />')[0];
    fileInputImagenes.addEventListener("change", function () {
        _this.colaDeSubida = fileInputImagenes.files;
        _this.indiceFileSubiendo = 0;
        _this.subirProximaImagen(onImagenLista);
    }, false);
    $(fileInputImagenes).click();
};

SubidorDeImagenes.prototype.subirImagen = function (onImagenLista, recortar) {
    var _this = this;

    var fileInputImagenes = $('<input type="file" />')[0];
    fileInputImagenes.addEventListener("change", function () {
        _this.colaDeSubida = fileInputImagenes.files;
        _this.indiceFileSubiendo = 0;
        _this.subirProximaImagen(onImagenLista, recortar);
    }, false);
    $(fileInputImagenes).click();
};

SubidorDeImagenes.prototype.subirProximaImagen = function (onImagenLista, recortar) {
    var _this = this;

    var file = _this.colaDeSubida[_this.indiceFileSubiendo];
    url = window.URL || window.webkitURL;
    src = url.createObjectURL(file);
    var canvas = document.createElement('CANVAS');
    var ctx = canvas.getContext('2d');
    var img = new Image;
    img.crossOrigin = 'Anonymous';
    img.src = src;
    img.onload = function () {
        canvas.height = img.height;
        canvas.width = img.width;
        ctx.drawImage(img, 0, 0);
        var bytes_imagen = canvas.toDataURL('image/jpg');
        bytes_imagen = bytes_imagen.replace(/^data:image\/(png|jpg);base64,/, "");

//        if (recortar) {
//            vex.defaultOptions.className = 'vex-theme-os';
//            vex.open({
//                afterOpen: function ($vexContent) {
//                    var ui = $("#plantillas_adm_cambio_imagen .confirmacion_recorte_imagen").clone();
//                    ui.find("#imagen_recortada").attr("src", "data:image/png;base64," + bytes_imagen_recortada);
//                    ui.find("#btn_aceptar_recorte").click(function () {
//                        Backend.SubirImagen(bytes_imagen_recortada).onSuccess(function (id_imagen_recortada) {
//                            Backend.AceptarCambioImagenConImagenRecortada(solicitud.usuario.Id, id_imagen_recortada).onSuccess(function (id_imagen_recortada) {
//                                alertify.success('solicitud de cambio de imagen aceptada');
//                                vex.close();
//                                vex.close();
//                                _this.alResolver();
//                            });
//                        });
//                    });
//                    ui.find("#btn_cancelar_recorte").click(function () {
//                        vex.close();
//                    });
//                    $vexContent.append(ui);
//                    ui.show();
//                    return ui;
//                }
//            })
//        }

        Backend.SubirImagen(bytes_imagen).onSuccess(function (id_imagen) {
            _this.indiceFileSubiendo += 1;

            onImagenLista(id_imagen, bytes_imagen);

            if (_this.indiceFileSubiendo >= _this.colaDeSubida.length) return;
            _this.subirProximaImagen(onImagenLista);
        });
    };
};