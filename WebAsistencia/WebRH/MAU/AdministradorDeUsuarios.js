var AdministradorDeUsuarios = function () {
    var _this = this;

    this.panel_datos_usuario = $('#panel_datos_usuario');
    this.lbl_nombre = $('#nombre');
    this.lbl_apellido = $('#apellido');
    this.lbl_documento = $('#documento');
    this.lbl_legajo = $('#legajo');
    this.lbl_email = $('#email');
    this.txt_nombre_usuario = $('#txt_nombre_usuario');
    this.btn_reset_password = $('#btn_reset_password');
    this.btn_modificar_mail = $('#btn_modificar_mail');

    var proveedor_ajax = new ProveedorAjax("../");
    this.autorizador = new Autorizador(proveedor_ajax);
    this.repositorioDeFuncionalidades = new RepositorioDeFuncionalidades(proveedor_ajax);
    this.repositorioDeUsuarios = new RepositorioDeUsuarios(proveedor_ajax);
    this.repositorioDePersonas = new RepositorioDePersonas(proveedor_ajax);
    this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);

    this.selector_usuario = new SelectorDePersonas({
        ui: $('#selector_usuario'),
        repositorioDePersonas: this.repositorioDePersonas,
        placeholder: "nombre, apellido, documento o legajo"
    });

    Backend.ElUsuarioLogueadoTienePermisosPara(24).onSuccess(function (tiene_permisos) {
        if (tiene_permisos) {
            _this.vista_permisos = new VistaDePermisosDeUnUsuario({
                ui: $('#vista_permisos'),
                repositorioDeFuncionalidades: _this.repositorioDeFuncionalidades,
                autorizador: _this.autorizador
            });
        }
    });
    this.vista_areas = new VistaDeAreasAdministradas({
        ui: $('#panel_areas_administradas'),
        autorizador: this.autorizador,
        repositorioDeAreas: this.repositorioDeAreas
    });

    $("#foto_usuario, #foto_usuario_generica").click(function () {
        vex.defaultOptions.className = 'vex-theme-os';
        var subidor = new SubidorDeImagenes();
        subidor.subirImagen(function (id_imagen) {
            Backend.SolicitarCambioDeImagenPara(_this.usuario.Id, id_imagen)
                .onSuccess(function () {
                    alertify.success("Cambio de imagen realizado con éxito");
                })
                .onError(function () {
                    alertify.error("Error al cambiar imagen");
                });
        }, true, 500);
    });

    $('#btn_credencial_usuario').click(function () {
        var div = $("<div>");
        div.load(window.location.origin + '/Componentes/CredencialVigente.htm', function () {
            Componente.start(false, div, _this.usuario);
        });
    });

    this.selector_usuario.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
        _this.panel_datos_usuario.hide();
        _this.repositorioDeUsuarios.getUsuarioPorIdPersona(
            la_persona_seleccionada.id,
            function (usuario) {
                _this.cargarUsuario(usuario);
            },
            function (error) {
                if (error == "LA_PERSONA_NO_TIENE_USUARIO") {
                    Backend.ElUsuarioLogueadoTienePermisosPara(26).onSuccess(function (tiene_permisos) {
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
    };

    this.btn_reset_password.click(function () {

        alertify.confirm('Modificar contraseña', '¿Está seguro de querer reinciar la contraseña', function () {
            Backend.ResetearPassword(_this.usuario.Id).onSuccess(
                        function (nueva_clave) {
                            alertify.alert("Se ha modificado la contraseña.", "La nueva contraseña para el usuario: "
                                                + _this.usuario.Alias + " es: " + nueva_clave);
                        });
        }

        , function () {
            alertify.alert("Modificación cancelada.");
        }
        );
    });

    this.btn_modificar_mail.click(function () {
        alertify.prompt(' ', 'Ingrese el mail del usuario', ''
               , function (evt, value) {
                   Backend.ModificarMailRegistro(_this.usuario.Id, value).onSuccess(function () {
                       alertify.success("Se ha modificado correctamente su mail");
                       alertify.prompt().close();
                       _this.lbl_email.text(value);
                   }).onError(function () {
                       alertify.error("Error al modificar el mail");
                       alertify.prompt().close();
                   });
               }
               , function () { });
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

    //CONSULTAR PERSONAS DE BAJA CON PERMISOS
    $("#btn_buscar_personas_de_baja").click(function () {
        Backend.BuscarPersonaDeBajaConPermisos().onSuccess(function (data) {
            _this.ArmarTabla($('#tabla_personas_de_baja'), data, _this);
            $("#btn_buscar_personas_de_baja")[0].disabled = true;
            console.log(data);
        });
    });


    var objetoURL = getVarsUrl();
    if (objetoURL.hasOwnProperty("Nombre")) {
        var nombre_area = objetoURL.Nombre.replace(/\%20/g, ' ');
        this.BackendBuscarUsuariosPorArea(this, nombre_area);
    }

    //CONSULTAR USUARIOS POR AREA
    _this.BuscadorUsuariosPorArea(_this)

    function getVarsUrl() {
        var url = location.search.replace("?", "");
        var arrUrl = url.split("&");
        var urlObj = {};
        for (var i = 0; i < arrUrl.length; i++) {
            var x = arrUrl[i].split("=");
            urlObj[x[0]] = decodeURIComponent(x[1])
        }
        return urlObj;
    }
};

AdministradorDeUsuarios.prototype.cargarUsuario = function (usuario) {
    var _this = this;
    this.usuario = usuario;
    this.panel_datos_usuario.show();
    Backend.ElUsuarioLogueadoTienePermisosPara(24).onSuccess(function (tiene_permisos) {
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
    Backend.ElUsuarioLogueadoTienePermisosPara(50).onSuccess(function (tiene_permisos) {
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
};
AdministradorDeUsuarios.prototype.BuscadorUsuariosPorArea = function (contexto) {
    this.div_lista_areas = $("#lista_areas_para_consultar");


    this.selector_de_areas = new SelectorDeAreas({
        ui: $("#selector_area_usuarios"),
        repositorioDeAreas: this.repositorioDeAreas,
        placeholder: "ingrese el área que desea buscar",
        alSeleccionarUnArea: function (area) {
            $("#tabla_usuarios_por_area").html("");
            contexto.BackendBuscarUsuariosPorArea(contexto, area.nombre);
        }
    });
};

AdministradorDeUsuarios.prototype.BackendBuscarUsuariosPorArea = function (contexto, nombre_area) {
    $("body").addClass("loading");
    Backend.BuscarUsuariosPorArea(nombre_area).onSuccess(function (data) {
        $("body").removeClass("loading");
        $("#p_nombre_area").html("Área: " + nombre_area);
        contexto.ArmarTabla($('#tabla_usuarios_por_area'), data, contexto);                
        });
}


AdministradorDeUsuarios.prototype.ArmarTabla = function (tabla, data, contexto_para_row_click) {

    var columnas = [];
    //VW_Desglose_Area
    columnas.push(new Columna("Apellido", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Apellido } }));
    columnas.push(new Columna("Nombre", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Nombre  } }));
    columnas.push(new Columna("Documento", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Documento } }));
    columnas.push(new Columna("Usuario", { generar: function (un_usuario) { return un_usuario.Alias } }));
    columnas.push(new Columna("Área", { generar: function (un_usuario) { return un_usuario.Owner.Area.Nombre } }));

    //columnas.push(new Columna("Funcionalidades", { generar: function (un_usuario) { return un_usuario.Fun } }));

    var generador_de_celda_funcionalidades = {
        generar: function (un_usuario) {

            var funcionalidades = "";
            for (var i = 0; i < un_usuario.Funcionalidades.length; i++) {
                funcionalidades += un_usuario.Funcionalidades[i].Nombre + ' | ';
            }

            return funcionalidades;
        }
    };

    columnas.push(new Columna('Permisos Asignados', generador_de_celda_funcionalidades));

    this.GrillaDeUsuarios = new Grilla(columnas);
    //this.GrillaDeUsuarios.AgregarEstilo("cuerpo_tabla_usuarios tr td");
    //this.GrillaDeUsuarios.AgregarEstilo("celda_seleccionada");
    this.GrillaDeUsuarios.AgregarEstilo("cuerpo_tabla_usuarios");

    this.GrillaDeUsuarios.CambiarEstiloCabecera("cabecera_tabla_usuarios");
    this.GrillaDeUsuarios.SetOnRowClickEventHandler(function (un_usuario) {
        //$('#selector_usuario').val(un_usuario.Owner.Documento);
        var persona_seleccionada = {};
        persona_seleccionada.apellido = un_usuario.Owner.Apellido;
        persona_seleccionada.nombre = un_usuario.Owner.Nombre;
        persona_seleccionada.documento = un_usuario.Owner.Documento;
        persona_seleccionada.id = un_usuario.Owner.Id;

        //para subir al tope de la pantalla
        $('html,body').animate({
            scrollTop: $("#instrucciones_de_uso").offset().top
        }, 1000);

        $('.select2-chosen').html("");
        contexto_para_row_click.selector_usuario.alSeleccionarUnaPersona(persona_seleccionada);
    });
    this.GrillaDeUsuarios.CargarObjetos(data);
    this.GrillaDeUsuarios.DibujarEn(tabla);
};

