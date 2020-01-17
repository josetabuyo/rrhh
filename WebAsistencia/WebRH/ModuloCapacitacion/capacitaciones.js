var spinner;
var mes;
var idUsuario;
var usuarioEncontrado;

var Capacitaciones = {
    init: function () {

        var proveedor_ajax = new ProveedorAjax("../");
        //this.autorizador = new Autorizador(proveedor_ajax);
        //this.repositorioDeFuncionalidades = new RepositorioDeFuncionalidades(proveedor_ajax);
        this.repositorioDeUsuarios = new RepositorioDeUsuarios(proveedor_ajax);
        this.repositorioDePersonas = new RepositorioDePersonas(proveedor_ajax);
        this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);
        usuarioEncontrado = { Id: 0 };

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
                    alertify.error('La persona no tiene usuario');

                }
            });
    },
    //FC: cuando seleccione una persona del buscador de Personas
    cargarUsuario: function (usuario) {
        usuarioEncontrado = usuario;
        console.log(usuario);


        var _this = this;
        _this.usuario = usuario;

        $("#cajaSelectorDocumentos").show();
        $("#caja_documentos_cargados").show();


        $("#nombre_empleado").html(usuario.Owner.Nombre);
        $("#apellido_empleado").html(usuario.Owner.Apellido);
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


        $("#txt_nombre_usuario").html(usuario.Alias);

    },
   
    buscadorUsuariosPorArea: function () {
        var _this = this;
        this.div_lista_areas = $("#lista_areas_para_consultar");


        this.selector_de_areas = new SelectorDeAreas({
            ui: $("#selector_area_usuarios"),
            repositorioDeAreas: this.repositorioDeAreas,
            placeholder: "ingrese el área que desea buscar",
            alSeleccionarUnArea: function (area) {
                $("#tabla_usuarios_por_area").html("");
                _this.backendBuscarUsuariosPorArea(_this, area.nombre);
            }
        });
    }
    
   

}
