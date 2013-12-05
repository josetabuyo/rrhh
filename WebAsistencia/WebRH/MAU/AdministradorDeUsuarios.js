var AdministradorDeUsuarios = function () {
    var _this = this;
    this.panel_datos_usuario = $('#panel_datos_usuario');
    this.panel_datos_usuario.hide();
    this.lbl_nombre = $('#nombre');
    this.lbl_apellido = $('#apellido');
    this.lbl_documento = $('#documento');
    this.lbl_legajo = $('#legajo');

    this.selector_usuario = new SelectorDePersonas({
        ui: $('#selector_usuario'),
        servicioDePersonas: new ServicioDePersonas(new ProveedorAjax()),
        placeholder: "nombre, apellido, documento o legajo"
    });

    this.vista_permisos = new VistaDePermisosDeUnUsuario({
        ui: $('#vista_permisos'),
        servicioDeSeguridad: new ServicioDeSeguridad(new ProveedorAjax())
    });

    this.selector_usuario.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
        _this.panel_datos_usuario.show();
        _this.vista_permisos.setUsuario(la_persona_seleccionada);
        _this.lbl_nombre.text(la_persona_seleccionada.nombre);
        _this.lbl_apellido.text(la_persona_seleccionada.apellido);
        _this.lbl_documento.text(la_persona_seleccionada.documento);
        _this.lbl_legajo.text(la_persona_seleccionada.legajo);
    };
};