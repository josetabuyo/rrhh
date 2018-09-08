
$(function () {
    Backend.start(function () {
        var id_bien;
        vex.defaultOptions.className = 'vex-theme-os';
        var ui = $("#pantalla_edicion_bien");
        Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("1.alta_baja_asoc_bien").onSuccess(function (tiene_permisos_de_edicion) {
            $(".btnVerBien").click(function (e) {
                id_bien = $($(this).parent().parent().children()[0]).text();
                Backend.Mobi_GetBienPorId(id_bien).onSuccess(function (bien) {
                    ui.find("#ed_descripcion_bien").text(bien.Descripcion);
                    $("#ed_contenedor_imagenes").empty();
                    _.forEach(bien.Imagenes, function (id_imagen) {
                        var cont_imagen = $('<div class="imagen_bien"></div>');
                        var opt_vista = {
                            id: id_imagen,
                            contenedor: cont_imagen
                        };
                        if (tiene_permisos_de_edicion)
                            opt_vista.alEliminar = function () {
                                vex.dialog.confirm({
                                    message: 'Está seguro que desea eliminar esta imágen?',
                                    callback: function (value) {
                                        if (value) {
                                            Backend.Mobi_DesAsignarImagenABien(id_bien, id_imagen).onSuccess(function () {
                                                img.contenedor.remove();
                                            });
                                        }
                                    }
                                });
                            };
                        var img = new VistaThumbnail(opt_vista);
                        $("#ed_contenedor_imagenes").append(cont_imagen);
                    });
                });

                vex.open({
                    afterOpen: function ($vexContent) {
                        if (tiene_permisos_de_edicion) {
                            ui.find("#btn_add_imagen").show();
                            ui.find("#btn_add_imagen").click(function () {
                                var subidor = new SubidorDeImagenes();
                                subidor.subirImagen(function (id_imagen) {
                                    Backend.Mobi_AsignarImagenABien(id_bien, id_imagen).onSuccess(function () {
                                        var cont_imagen = $('<div class="imagen_bien"></div>');
                                        var img = new VistaThumbnail({
                                            id: id_imagen,
                                            contenedor: cont_imagen,
                                            alEliminar: function () {
                                                vex.dialog.confirm({
                                                    message: 'Está seguro que desea eliminar esta imágen?',
                                                    callback: function (value) {
                                                        if (value) {
                                                            Backend.Mobi_DesAsignarImagenABien(id_bien, id_imagen).onSuccess(function () {
                                                                img.contenedor.remove();
                                                            });
                                                        }
                                                    }
                                                });
                                            }
                                        });
                                        $("#ed_contenedor_imagenes").append(cont_imagen);
                                    });
                                });
                            });
                        }
                        return $vexContent.append(ui);
                    },
                    css: {
                        'padding-top': "4%",
                        'padding-bottom': "0%"
                    },
                    contentCSS: {
                        width: "80%",
                        height: "80%"
                    }
                });
            });
        });
    });
});