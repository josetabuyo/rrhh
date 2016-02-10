var AdministradorDeUsuarios = function () {
    var _this = this;
    this.panel_datos_usuario = $('#panel_datos_usuario');
    this.lbl_nombre = $('#nombre');
    this.lbl_apellido = $('#apellido');
    this.lbl_documento = $('#documento');
    this.lbl_legajo = $('#legajo');
    this.txt_nombre_usuario = $('#txt_nombre_usuario');
    this.btn_reset_password = $('#btn_reset_password');

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
                            alertify.confirm(la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido + " no tiene usuario, desea crear uno?", function (usuario_acepto) {
                                if (usuario_acepto) {
                                    _this.repositorioDeUsuarios.crearUsuarioPara(la_persona_seleccionada.id,
                                function (usuario) {
                                    alertify.success("Se ha creado un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                    _this.repositorioDeUsuarios.resetearPassword(usuario.Id, function (nueva_clave) {
                                        alertify.alert("El password para el usuario: " + usuario.Alias + " es: " + nueva_clave);
                                    });
                                    _this.cargarUsuario(usuario);
                                },
                                function (error) {
                                    alertify.error("Error al crear un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                }
                            );
                                } else {
                                    alertify.error("No se creó un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);
                                }
                            });
                        } else {
                            alertify.alert(la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido + " no tiene usuario.");
                        }
                    });

                }
            });
    };

    this.btn_reset_password.click(function () {
        Backend.ResetearPassword(_this.usuario.Id).onSuccess(function (nueva_clave) {
            alertify.alert("El nuevo password para el usuario: " + _this.usuario.Alias + " es: " + nueva_clave);
        });
    });

    $("#btn_verificar_usuario").click(function () {
        Backend.VerificarUsuario(_this.usuario.Id).onSuccess(function (verifico_ok) {
            if (verifico_ok) {
                $("#usuario_no_verificado").hide();
                $("#usuario_verificado").show();
                $("#btn_verificar_usuario").hide();
            }
        });
    });

    //CONSULTAR PERSONAS DE BAJA CON PERMISOS
    $("#btn_buscar_personas_de_baja").click(function () {
        Backend.BuscarPersonaDeBajaConPermisos().onSuccess(function (data) {
            armarTabla(data);
            console.log(data);
        });
    });

    function armarTabla(data) {
        var tabla = $('#tabla_personas_de_baja');
        var columnas = [];

        columnas.push(new Columna("Nombre", { generar: function (un_usuario) { return un_usuario.Owner.Nombre + ', ' + un_usuario.Owner.Apellido } }));
        columnas.push(new Columna("Documento", { generar: function (un_usuario) { return un_usuario.Owner.Documento } }));
        columnas.push(new Columna("Usuario", { generar: function (un_usuario) { return un_usuario.Alias } }));

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
        this.GrillaDeUsuarios.AgregarEstilo("cuerpo_tabla_usuarios tr td");
        this.GrillaDeUsuarios.CambiarEstiloCabecera("cabecera_tabla_usuarios");
        this.GrillaDeUsuarios.SetOnRowClickEventHandler(function (un_usuario) {
            $('#selector_usuario').val(un_usuario.Owner.Documento);
        });
        this.GrillaDeUsuarios.CargarObjetos(data);
        this.GrillaDeUsuarios.DibujarEn(tabla);
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
    $("#usuario_verificado").hide();
    $("#usuario_no_verificado").hide();
    $("#btn_verificar_usuario").hide();
    if (usuario.Verificado) $("#usuario_verificado").show();
    else {
        $("#usuario_no_verificado").show();
        $("#btn_verificar_usuario").show();
    }
    this.txt_nombre_usuario.text(usuario.Alias);

};