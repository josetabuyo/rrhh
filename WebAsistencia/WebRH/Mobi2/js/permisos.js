var spinner;
var usuarioEncontrado;/**es un objeto que contiene al idUsuario  usuarioEncontrado.Id*/
var idPersonaActual;


/*de esta forma se exporta todas las funciones*/
var Permisos = {
    init: function (funcionExtraOK) {
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
        usuarioEncontrado = { Id: 0 };
        funcionExtraOK();

    },
    iniciarConsultaRapida: function (funcionExtraOK, funcionExtraNOK) {
        var _this = this;
        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo"
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            _this.alSeleccionarUnaPersona(la_persona_seleccionada, funcionExtraOK, funcionExtraNOK);
        };

    },
    alSeleccionarUnaPersona: function (la_persona_seleccionada, funcionExtraOK, funcionExtraNOK) {
        var _this = this;
        idPersonaActual = la_persona_seleccionada.id;
        $('#panel_datos_usuario').hide();
        _this.repositorioDeUsuarios.getUsuarioPorIdPersona(
            la_persona_seleccionada.id,
            function (usuario) {
                //se encontro a la persona con id, entonces cargo los datos correspondientes
                //_this.cargarUsuario(usuario);
                //dejo el radio buton seteado por default a los recibos actuales

                //realizo las operaciones propias de la pagina actual
                funcionExtraOK();

                _this.cargarUsuario(usuario, la_persona_seleccionada.id);
            },
            function (error) {
                //si no tiene usuario se le permite crear uno
                funcionExtraNOK();

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
    cargarUsuario: function (usuario, idPersona) {
        usuarioEncontrado = usuario;
        //console.log(usuario);
        //sessionStorage.setItem("nombre", usuario.Owner.Nombre);
        //sessionStorage.setItem("apellido", usuario.Owner.Apellido);
        //sessionStorage.setItem("idUsuario", usuario.Id);
        //sessionStorage.setItem("idImagen", usuario.Owner.IdImagen);
        //this.completarDatosDeLaSesion();

//        var _this = this;
//        _this.usuario = usuario;

        /*$("#panel_datos_usuario").show();
        $("#caja_permisos_actuales").show();
        _this.getPerfilesDelUsuario();
        _this.getFuncionalidadesDelUsuario();

        Backend.getAreaDeUnaPersona(usuario.Owner.Documento).onSuccess(function (descripcionArea) {
            var resp = JSON.parse(descripcionArea);

            $("#areaActual").html(resp.Alias);
        });

        agenteActual = usuario.Owner.Apellido + " " + usuario.Owner.Nombre;

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
*/
        /*obtengo los recibos de la personas seleccionada,recientes o hisoricas dependiendo de la seleccion
         por default el modo es 0, osea solo obtener recibos recientes*/
 /*       this.getRecibos(idPersona, 0);

*/
 /*       $("#btn_verificar_usuario").click(function () {
            Backend.VerificarUsuario(_this.usuario.Id).onSuccess(function (verifico_ok) {
                if (verifico_ok) {
                    $("#usuario_no_verificado").hide();
                    $("#usuario_verificado").show();
                    $("#btn_verificar_usuario").hide();
                    if (_this.vista_permisos)
                        _this.vista_permisos.setUsuario(_this.usuario);
                }
            });
        });*/

    }

}





