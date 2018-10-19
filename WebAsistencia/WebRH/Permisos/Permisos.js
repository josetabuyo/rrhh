var spinner;
var mes;
var idUsuario;

var Permisos = {
    init: function () {
       /* this.panel_datos_usuario = $('#panel_datos_usuario');
        this.lbl_nombre = $('#nombre');
        this.lbl_apellido = $('#apellido');
        this.lbl_documento = $('#documento');
        this.lbl_legajo = $('#legajo');
        this.lbl_email = $('#email');
        this.txt_nombre_usuario = $('#txt_nombre_usuario');
        this.btn_reset_password = $('#btn_reset_password');
        this.btn_modificar_mail = $('#btn_modificar_mail');*/

        var proveedor_ajax = new ProveedorAjax("../");
        this.autorizador = new Autorizador(proveedor_ajax);
        this.repositorioDeFuncionalidades = new RepositorioDeFuncionalidades(proveedor_ajax);
        this.repositorioDeUsuarios = new RepositorioDeUsuarios(proveedor_ajax);
        this.repositorioDePersonas = new RepositorioDePersonas(proveedor_ajax);
        this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);
    },

    getDatosFamiliares: function () {

        Backend.GetFamiliares()
            .onSuccess(function (familiaresJSON) {

                var familiares = JSON.parse(familiaresJSON);

                var _this = this;
                $("#tabla_familiar").empty();
                var divGrilla = $("#tabla_familiar");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Parentesco", { generar: function (un_familiar) { return un_familiar.Parentesco } }));
                columnas.push(new Columna("Apellido", { generar: function (un_familiar) { return un_familiar.Apellido } }));
                columnas.push(new Columna("Nombre", { generar: function (un_familiar) { return un_familiar.Nombre } }));
                columnas.push(new Columna("N doc", { generar: function (un_familiar) { return un_familiar.Documento } }));
                columnas.push(new Columna("Tipo DNI", { generar: function (un_familiar) { return un_familiar.TipoDNI } }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_familiar) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(familiares);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {

            });

    },
    iniciarConsultaRapida: function () {
        var _this = this;
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo"
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            _this.alSeleccionarUnaPersona(la_persona_seleccionada);
        };

    },
    alSeleccionarUnaPersona: function (la_persona_seleccionada) {
        var _this = this;
        $('#panel_datos_usuario').hide();
        _this.repositorioDeUsuarios.getUsuarioPorIdPersona(
            la_persona_seleccionada.id,
            function (usuario) {
                _this.cargarUsuario(usuario);
            },
            function (error) {
                if (error == "LA_PERSONA_NO_TIENE_USUARIO") {
                    Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_crear_usuario").onSuccess(function (tiene_permisos) {
                        if (tiene_permisos) {
                            alertify.confirm("",
                                la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido + " no tiene usuario, desea crear uno?",
                                function () {
                                    _this.repositorioDeUsuarios.crearUsuarioPara(la_persona_seleccionada.id,
                                        function (usuario) {
                                            alertify.success("Se ha creado un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                            _this.repositorioDeUsuarios.resetearPassword(usuario.Id, function (nueva_clave) {
                                                alertify.alert("", "El password para el usuario: " + usuario.Alias + " es: " + nueva_clave);
                                            });
                                            _this.cargarUsuario(usuario);
                                        },
                                        function (error) {
                                            alertify.error("Error al crear un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                        }
                                    );
                                },
                                function () {
                                    alertify.error("No se creó un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                }
                            );
                        } else {
                            alertify.alert("", la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido + " no tiene usuario.");
                        }
                    });

                }
            });
    },

    cargarUsuario: function (usuario) {
        console.log(usuario);

        var _this = this;
        _this.usuario = usuario;
        $("#panel_datos_usuario").show();
       /* Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_cambiar_permisos").onSuccess(function (tiene_permisos) {
            if (tiene_permisos) {
                _this.vista_permisos.setUsuario(usuario);
                _this.vista_areas.setUsuario(usuario);
            }
        });*/
        $("#nombre2").html(usuario.Owner.Nombre);
        $("#apellido2").html(usuario.Owner.Apellido);
        $("#documento2").html(usuario.Owner.Documento);
        $("#legajo2").html(usuario.Owner.Legajo);
        $("#email").html(usuario.MailRegistro);

        if (usuario.Owner.IdImagen >= 0) {
            var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario") });
            $("#foto_usuario").show();
            $("#foto_usuario_generica").hide();
        }
        else {
            $("#foto_usuario").hide();
            $("#foto_usuario_generica").show();
        }

        $("#usuario_verificado").hide();
        $("#usuario_no_verificado").hide();
        $("#btn_verificar_usuario").hide();
        $('#panel_personas_de_baja_con_permisos').insertAfter("#form1");
        $('#panel_usuarios_por_area').insertAfter("#form1");

        $('.dynatree-folder span.dynatree-checkbox').remove();

        if (usuario.Verificado) $("#usuario_verificado").show();
        else {
            $("#usuario_no_verificado").show();
            $("#btn_verificar_usuario").show();
        }
        $("#txt_nombre_usuario").html(usuario.Alias);

        $("#cambio_imagen_pendiente").hide();

        $("#btn_reset_password").click(function () {

            alertify.confirm('Modificar contraseña', '¿Está seguro de querer reinciar la contraseña', function () {
                Backend.ResetearPassword(_this.usuario.Id).onSuccess(
                        function (nueva_clave) {
                            alertify.alert("Se ha modificado la contraseña.", "La nueva contraseña para el usuario: "
                                                + _this.usuario.Alias + " es: " + nueva_clave);
                        });
                }
                ,function () {
                    alertify.alert("Modificación cancelada.");
                }
            );
        });

        $("#btn_modificar_mail").click(function () {
            alertify.prompt(' ', 'Ingrese el mail del usuario', '', function (evt, value) {
                   Backend.ModificarMailRegistro(_this.usuario.Id, value).onSuccess(function () {
                       alertify.success("Se ha modificado correctamente su mail");
                       alertify.prompt().close();
                       _this.lbl_email.text(value);
                   }).onError(function () {
                       alertify.error("Error al modificar el mail");
                       alertify.prompt().close();
                   });
               }, function () { });
        });



        $("#btn_verificar_usuario").click(function () {
            Backend.VerificarUsuario(_this.usuario.Id).onSuccess(function (verifico_ok) {
                if (verifico_ok) {
                    $("#usuario_no_verificado").hide();
                    $("#usuario_verificado").show();
                    $("#btn_verificar_usuario").hide();
                    if (_this.vista_permisos)
                        _this.vista_permisos.setUsuario(_this.usuario);
                }
            });
        });

    }

    /*AdministradorDeUsuarios.prototype.cargarUsuario = function (usuario) {
    var _this = this;
    this.usuario = usuario;
    this.panel_datos_usuario.show();
    Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_cambiar_permisos").onSuccess(function (tiene_permisos) {
        if (tiene_permisos) {
            _this.vista_permisos.setUsuario(usuario);
            _this.vista_areas.setUsuario(usuario);
        }
    });
    this.lbl_nombre.text(usuario.Owner.Nombre);
    this.lbl_apellido.text(usuario.Owner.Apellido);
    this.lbl_documento.text(usuario.Owner.Documento);
    this.lbl_legajo.text(usuario.Owner.Legajo);
    this.lbl_email.text(usuario.MailRegistro);

    if (usuario.Owner.IdImagen >= 0) {
        var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario") });
        $("#foto_usuario").show();
        $("#foto_usuario_generica").hide();
    }
    else {
        $("#foto_usuario").hide();
        $("#foto_usuario_generica").show();
    }

    $("#usuario_verificado").hide();
    $("#usuario_no_verificado").hide();
    $("#btn_verificar_usuario").hide();
    $('#panel_personas_de_baja_con_permisos').insertAfter("#form1");
    $('#panel_usuarios_por_area').insertAfter("#form1");

    $('.dynatree-folder span.dynatree-checkbox').remove();

    if (usuario.Verificado) $("#usuario_verificado").show();
    else {
        $("#usuario_no_verificado").show();
        $("#btn_verificar_usuario").show();
    }
    this.txt_nombre_usuario.text(usuario.Alias);

    $("#cambio_imagen_pendiente").hide();
    Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("impresion_credencial").onSuccess(function (tiene_permisos) {
        if (tiene_permisos) {
            Backend.GetSolicitudesDeCambioDeImagenPendientesPara(usuario.Id).onSuccess(function (solicitudes) {
                if (solicitudes.length > 0) {
                    $("#cambio_imagen_pendiente").off("click");

                    $("#cambio_imagen_pendiente").click(function () {

                        vex.defaultOptions.className = 'vex-theme-os';
                        vex.open({
                            afterOpen: function ($vexContent) {
                                var ui = $("#plantillas #pantalla_actualizacion_imagen").clone();
                                var ultima_solicitud = solicitudes[solicitudes.length - 1];

                                ui.find("#btn_aceptar_cambio_imagen")
                                    .off("click")
                                    .click(function () {
                                        Backend.AceptarCambioDeImagen(usuario.Id).onSuccess(function () {
                                            alertify.success('solicitud de cambio de imagen aceptada');
                                            vex.close();
                                        });
                                    });
                                ui.find("#btn_rechazar_cambio_imagen")
                                    .off("click")
                                    .click(function () {
                                        Backend.RechazarCambioDeImagen(usuario.Id).onSuccess(function () {
                                            alertify.success('solicitud de cambio de imagen rechazada');
                                            vex.close();
                                        });
                                    });

                                $vexContent.append(ui);
                                ui.show();

                                var vista_imagen_anterior = new VistaThumbnail({ id: ultima_solicitud.idImagenAnterior, contenedor: ui.find("#imagen_anterior") })
                                var vista_imagen_nueva = new VistaThumbnail({ id: ultima_solicitud.idImagenNueva, contenedor: ui.find("#imagen_nueva") })
                                return ui;
                            },
                            css: {
                                'padding-top': "4%",
                                'padding-bottom': "0%"
                            },
                            contentCSS: {
                                width: "70%",
                                height: "80%"
                            }
                        });
                    });

                    $("#cambio_imagen_pendiente").show();
                }
            });
        }
    });
};*/

}
