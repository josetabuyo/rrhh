var AdministradorDeUsuarios = function () {
    var _this = this;
    this.panel_datos_usuario = $('#panel_datos_usuario');
    this.panel_datos_usuario.hide();
    this.lbl_nombre = $('#nombre');
    this.lbl_apellido = $('#apellido');
    this.lbl_documento = $('#documento');
    this.lbl_legajo = $('#legajo');
    this.txt_nombre_usuario = $('#txt_nombre_usuario');

    this.panel_datos_usuario.show(); //borrar

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
        repositorioDeFuncionalidades: this.repositorioDeFuncionalidades
    });

    this.selector_usuario.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
        _this.repositorioDeUsuarios.getUsuarioPorIdPersona(
            la_persona_seleccionada.id,
            function (usuario) {
                _this.panel_datos_usuario.show();
                _this.vista_permisos.setUsuario(usuario);
                _this.lbl_nombre.text(usuario.nombre);
                _this.lbl_apellido.text(usuario.apellido);
                _this.lbl_documento.text(usuario.documento);
                _this.lbl_legajo.text(usuario.legajo);
                _this.txt_nombre_usuario.val(usuario.alias);
            },
            function () {
                alert('error al obtener el usuario');
            });        
    };
};