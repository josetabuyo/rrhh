var AdministradorDeUsuarios = function () {
    var _this = this;
    this.panel_datos_usuario = $('#panel_datos_usuario');
    this.lbl_nombre = $('#nombre');
    this.lbl_apellido = $('#apellido');
    this.lbl_documento = $('#documento');
    this.lbl_legajo = $('#legajo');
    this.txt_nombre_usuario = $('#txt_nombre_usuario');


    var proveedor_ajax = new ProveedorAjax("../");
    this.autorizador = new Autorizador(proveedor_ajax);
    this.repositorioDeFuncionalidades = new RepositorioDeFuncionalidades(proveedor_ajax);
    this.repositorioDeUsuarios = new RepositorioDeUsuarios(proveedor_ajax);
    this.repositorioDePersonas = new RepositorioDePersonas(proveedor_ajax);

    this.selector_usuario = new SelectorDePersonas({
        ui: $('#selector_usuario'),
        repositorioDePersonas: this.repositorioDePersonas,
        placeholder: "nombre, apellido, documento o legajo"
    });

    this.vista_permisos = new VistaDePermisosDeUnUsuario({
        ui: $('#vista_permisos'),
        repositorioDeFuncionalidades: this.repositorioDeFuncionalidades,
        autorizador: this.autorizador
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
                    alertify.confirm(la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido + " no tiene usuario, desea crear uno?", function (usuario_acepto) {
                        if (usuario_acepto) {
                            _this.repositorioDeUsuarios.crearUsuarioPara(la_persona_seleccionada.id,
                                function (usuario) {
                                    alertify.success("Se ha creado un usuario para " + la_persona_seleccionada.nombre + " " + la_persona_seleccionada.apellido);    
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
                }
            });
    };
};

AdministradorDeUsuarios.prototype.cargarUsuario = function(usuario) {
    this.panel_datos_usuario.show();
    this.vista_permisos.setUsuario(usuario);
    this.lbl_nombre.text(usuario.Owner.Nombre);
    this.lbl_apellido.text(usuario.Owner.Apellido);
    this.lbl_documento.text(usuario.Owner.Documento);
    this.lbl_legajo.text(usuario.Owner.Legajo);
    this.txt_nombre_usuario.val(usuario.Alias);
};