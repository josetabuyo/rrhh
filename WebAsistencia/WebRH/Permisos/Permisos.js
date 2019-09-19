var spinner;
var mes;
var idUsuario;
var usuarioEncontrado;

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
        usuarioEncontrado = { Id: 0 };

    },

    getPerfilesDelUsuario: function () {

        var _this = this;
        //this.completarDatosDeLaSesion();
       /* if (!sessionStorage.getItem("idUsuario")) {
            alert("Debe seleccionar un usuario antes de proseguir");
            window.location.replace("DefinicionDeUsuario.aspx");
        }*/

        if (!_this.validarUsuarioCargado())
            return;
        

        //var idUsuario = sessionStorage.getItem("idUsuario");
        Backend.GetPerfilesActuales(usuarioEncontrado.Id)
            .onSuccess(function (perfiles) {

                //var perfiles = JSON.parse(perfilesJSON);


                $("#tabla_permisos").empty();
                var divGrilla = $("#tabla_permisos");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Perfiles", { generar: function (un_permiso) { return un_permiso.Nombre } }));
                columnas.push(new Columna("Areas", { generar: function (un_permiso) { return un_permiso.Areas[0].Nombre } }));
                columnas.push(new Columna("Incluye Dep.", { generar: function (un_permiso) { if (un_permiso.Areas[0].IncluyeDependencias) return 'Si'; return 'No' } }));
                //columnas.push(new Columna("Desde", { generar: function (un_permiso) { return '01/01/2018' } }));
                columnas.push(new Columna('Accion', {
                    generar: function (un_permiso) {
                        var btn_accion = $('<a>');
                        var img = $('<img>');
                        img.attr('src', '../Imagenes/eliminar.jpg');
                        img.attr('width', '20px');
                        img.attr('height', '20px');
                        btn_accion.append(img);
                        btn_accion.click(function () {
                            _this.eliminarPerfil(un_permiso);
                        });
                        return btn_accion;
                    }
                }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_permiso) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(perfiles);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {

            });


        //this.getFuncionalidadesPerfilesAreas();

    },
    getFuncionalidadesDelUsuario: function () {

        var _this = this;
        /*if (!sessionStorage.getItem("idUsuario")) {
            alert("Debe seleccionar un usuario antes de proseguir");
            window.location.replace("DefinicionDeUsuario.aspx");
        }*/

        if (!_this.validarUsuarioCargado())
            return;

        //var idUsuario = sessionStorage.getItem("idUsuario");
        Backend.GetFuncionalidadesActuales(usuarioEncontrado.Id)
            .onSuccess(function (funcionalidades) {

                //var perfiles = JSON.parse(perfilesJSON);


                $("#tabla_funcionalidades").empty();
                var divGrilla = $("#tabla_funcionalidades");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Funciones", { generar: function (un_permiso) { return un_permiso.Nombre } }));
                columnas.push(new Columna("Areas", { generar: function (un_permiso) { if (un_permiso.Areas.length > 0) return un_permiso.Areas[0].Nombre; return 'Sin Area'; } }));
                columnas.push(new Columna("Incluye Dep.", { generar: function (un_permiso) { if (un_permiso.Areas.length > 0) { if (un_permiso.Areas[0].IncluyeDependencias) return 'Si'; return 'No' } else { return '' } } }));
                //columnas.push(new Columna("Desde", { generar: function (un_permiso) { return '01/01/2018' } }));
                columnas.push(new Columna('Accion', {
                    generar: function (un_permiso) {
                        var btn_accion = $('<a>');
                        var img = $('<img>');
                        img.attr('src', '../Imagenes/eliminar.jpg');
                        img.attr('width', '20px');
                        img.attr('height', '20px');
                        btn_accion.append(img);
                        btn_accion.click(function () {
                            _this.eliminarFuncionalidad(un_permiso);
                        });
                        return btn_accion;
                    }
                }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_permiso) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(funcionalidades);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");

                var options = {
                    valueNames: ['Funciones', 'Areas']
                };
                var featureList = new List('caja_funcionalidades', options);

            })
            .onError(function (e) {

            });

    },
    eliminarPerfil: function (perfil) {
        var _this = this;
        var r = confirm("¿Está seguro de eliminar el Perfil?");
        if (r == true) {
            //var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");

            var idArea = perfil.Areas[0].Id;
            Backend.desasignarPerfiles(perfil.Id, idArea, usuarioEncontrado.Id).onSuccess(function (rto) {
                if (rto == 'ok') {
                    //window.location.reload();
                    alertify.success("Se ha eliminado correctamente");
                    _this.getPerfilesDelUsuario();
                } else {
                    alertify.error(rto);
                }

                console.log(rto);
            });
        } else {
            txt = "Cancelar";
        }

    },
    eliminarFuncionalidad: function (funcionalidad) {
        var _this = this;
        var idArea = funcionalidad.Areas[0].Id;
        var r = confirm("¿Está seguro de eliminar la Funcionalidad?");
        if (r == true) {
            //var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");
            Backend.desasignarFuncionaldiad(funcionalidad.Id, idArea, usuarioEncontrado.Id).onSuccess(function (rto) {
                if (rto == 'ok') {
                    //window.location.reload();
                    alertify.success("Se ha eliminado correctamente");
                    _this.getFuncionalidadesDelUsuario();
                } else {
                    alertify.error(rto);
                }
                console.log(rto);
            });
        } else {
            txt = "Cancelar";
        }

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
    //FC: cuando seleccione una persona del buscador de Personas
    cargarUsuario: function (usuario) {
        usuarioEncontrado = usuario;
        console.log(usuario);
        //sessionStorage.setItem("nombre", usuario.Owner.Nombre);
        //sessionStorage.setItem("apellido", usuario.Owner.Apellido);
        //sessionStorage.setItem("idUsuario", usuario.Id);
        //sessionStorage.setItem("idImagen", usuario.Owner.IdImagen);
        //this.completarDatosDeLaSesion();

        var _this = this;
        _this.usuario = usuario;
        $("#panel_datos_usuario").show();
        $("#caja_permisos_actuales").show();
        _this.getPerfilesDelUsuario();
        _this.getFuncionalidadesDelUsuario();
        /* Backend.ElUsuarioLogueadoTienePermisosParaFuncionalidadPorNombre("mau_cambiar_permisos").onSuccess(function (tiene_permisos) {
        if (tiene_permisos) {
        _this.vista_permisos.setUsuario(usuario);
        _this.vista_areas.setUsuario(usuario);
        }
        });*/
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

        $("#btn_reset_password").click(function () {

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

    },
    iniciarPantallaAsignacionPerfiles: function () {
        var _this = this;
        //this.completarDatosDeLaSesion();
        /*if (!sessionStorage.getItem("idUsuario")) {
            alert("Debe seleccionar un usuario antes de proseguir");
            window.location.replace("DefinicionDeUsuario.aspx");
        }*/

        if (!_this.validarUsuarioCargado())
            return;

        var proveedor_ajax = new ProveedorAjax("../");
        this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);

        this.div_lista_areas = $("#lista_areas_para_consultar");

        Backend.GetPerfilesConFuncionalidades()
            .onSuccess(function (perfiles) {

                $("#comboPerfiles").empty();
                $("#comboPerfiles").append("<option value='0'>Seleccionar Perfil</option>");
                var contenedorDialogo = $("#cajaContenedoraDelDialogo");

                $.each(perfiles, function (key, value) {

                    $("#comboPerfiles").append("<option value=" + value.Id + ">" + value.Nombre + "</option>");


                    contenedorDialogo.append("<p class='dialogNombrePerfil'>" + value.Nombre + "</p>");
                    contenedorDialogo.append("<ul class='dialogListaFunc'>");
                    $.each(value.Funcionalidades, function (keyFunc, value) {
                        contenedorDialogo.append("<li>" + value.Nombre + "</li>");
                   
                    });
                    contenedorDialogo.append("</ul>");
                    contenedorDialogo.append("<hr />");

                    /*
                     * <p class="dialogNombrePerfil" >Responsable de RCA</p>
                        <ul class="dialogListaFunc">
                            <li>Control Acceso</li>
                            <li>Control Asistencia</li>
                            <li>Carga Licencias</li>
                            <li>Control Planilla</li>
                        </ul>
                        <hr />
                        */


                });

            })
            .onError(function (e) {

            });


        $("#comboPerfiles").change(function (e) {
            //alert($(this).val());
            var plantillaPerfiles = $("#plantillaPerfilSeleccionado").clone();

            plantillaPerfiles.find(".nombrePerfil").html($("select option:selected").text());

            plantillaPerfiles.attr('id', $(this).val());
            plantillaPerfiles.attr('class', 'perfilesSeleccionados');

            plantillaPerfiles.find(".quitar").click(function () {
                //plantillaPerfiles.find("#" + $(this).attr('class')).remove();
                plantillaPerfiles.remove();
            });

            //plantillaPerfiles.find(".quitar").attr("class", $(this).val());
            plantillaPerfiles.show();
            $("#perfilesSeleccionado").append(plantillaPerfiles);

        });

        this.selector_de_areas = new SelectorDeAreas({
            ui: $("#selector_area_usuarios"),
            repositorioDeAreas: this.repositorioDeAreas,
            placeholder: "ingrese el área que desea buscar",
            alSeleccionarUnArea: function (area) {

                //alert(area.nombre);

                var plantilla = $("#plantillaArea").clone();
                plantilla.show();
                plantilla.find("#areaSeleccionada").html(area.nombre);
                plantilla.find("#checkIncluyeDependencias").attr('class', 'checksIncluyeDependencia');
                plantilla.find(".quitar").click(function () {
                    plantilla.remove();
                });

                plantilla[0].id = area.id;
                plantilla.attr('class', 'areasSeleccionadas');

                $("#listadoAreasElegidas").append(plantilla);
            }
        });


        $("#btnAsignarPerfilConAreas").click(function (e) {
            //alert($(this).val());
            var perfilesSeleccionados = $('.perfilesSeleccionados').map(function () {
                return $(this).attr('id');
            }).get();


            var areasSeleccionadas = $('.areasSeleccionadas').map(function () {
                var valor = 0;
                if ($(this)[0].children[1].checked)
                    valor = 1;
                return { Id: $(this).attr('id'), IncluyeDependencias: valor };
            }).get();

            /* var dependencias = $('.checksIncluyeDependencia').map(function () {
            return $(this)[0].checked;
            }).get();*/

            //var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");

            Backend.asignarPerfiles(JSON.stringify(perfilesSeleccionados), areasSeleccionadas, usuarioEncontrado.Id)
            .onSuccess(function (rto) {
                //window.location.reload();
                if (rto == 'ok') {
                    alertify.success("Se ha agregado el perfil correctamente");
                    _this.getPerfilesDelUsuario();
                    $("#perfilesSeleccionado").empty();
                    $("#listadoAreasElegidas").empty();
                } else {
                    alertify.error(rto);
                }


            })
            .onError(function (e) {

            });

        });

    },
    iniciarPantallaAsignacionFuncionalidad: function () {
        var _this = this;
       /* this.completarDatosDeLaSesion();
        if (!sessionStorage.getItem("idUsuario")) {
            alert("Debe seleccionar un usuario antes de proseguir");
            window.location.replace("DefinicionDeUsuario.aspx");
        }*/
        if (!_this.validarUsuarioCargado())
            return;
        

        var proveedor_ajax = new ProveedorAjax("../");
        this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);

        this.div_lista_areas = $("#lista_areas_para_consultar");


        Backend.TodasLasFuncionalidades()
            .onSuccess(function (funcionalidades) {

                $("#comboFuncionalidades").empty();
                $("#comboFuncionalidades").append("<option value='0'>Seleccionar Funcionalidad</option>");

                var grupo = '';
                $.each(funcionalidades, function (key, value) {
                    if (grupo != value.Grupo) {
                        grupo = value.Grupo;
                        $("#comboFuncionalidades").append("</optgroup>");
                        $("#comboFuncionalidades").append("<optgroup label='" + grupo + "'>");
                    }

                    $("#comboFuncionalidades").append("<option value=" + value.Id + ">" + value.Nombre + "</option>");

                });

            })
            .onError(function (e) {

            });


        $("#comboFuncionalidades").change(function (e) {
            //alert($(this).val());

            var plantillaFuncionalidad = $('#plantillaFuncionalidadSeleccionada').clone();

            plantillaFuncionalidad.find(".nombreFuncionalidad").html($("select option:selected").text());

            plantillaFuncionalidad.attr('id', $(this).val());
            plantillaFuncionalidad.attr('class', 'funcionalidadesSeleccionadas');

            plantillaFuncionalidad.find(".quitar").click(function () {
                plantillaFuncionalidad.remove();
            });

            //plantillaPerfiles.find(".quitar").attr("class", $(this).val());
            plantillaFuncionalidad.show();
            $("#funcionalidadesSeleccionadas").append(plantillaFuncionalidad);


        });

        this.selector_de_areas = new SelectorDeAreas({
            ui: $("#selector_area_usuarios"),
            repositorioDeAreas: this.repositorioDeAreas,
            placeholder: "ingrese el área que desea buscar",
            alSeleccionarUnArea: function (area) {

                //alert(area.nombre);

                var plantilla = $("#plantillaArea").clone();
                plantilla.show();
                plantilla.find("#areaSeleccionada").html(area.nombre);
                plantilla.find("#checkIncluyeDependencias").attr('class', 'checksIncluyeDependencia');
                plantilla.find(".quitar").click(function () {
                    plantilla.remove();
                });

                plantilla[0].id = area.id;
                plantilla.attr('class', 'areasSeleccionadas');


                $("#listadoAreasElegidas").append(plantilla);
            }
        });

        $("#btnAsignarFuncionalidadConAreas").click(function (e) {
            //alert($(this).val());

            var funcionalidadesSeleccionados = $('.funcionalidadesSeleccionadas').map(function () {
                return $(this).attr('id');
            }).get();


            var areasSeleccionadas = $('.areasSeleccionadas').map(function () {
                return { id: $(this).attr('id'), IncluyeDependencias: $(this)[0].children[1].checked };
            }).get();

            var areasSeleccionadas = $('.areasSeleccionadas').map(function () {
                var valor = 0;
                if ($(this)[0].children[1].checked)
                    valor = 1;
                return { Id: $(this).attr('id'), IncluyeDependencias: valor };
            }).get();

            /*$.each(areasSeleccionadas, function (key, value) {               
                if (value.IncluyeDependencias) {
                    value.IncluyeDependencias = 1;
                }
            });*/
            /* var dependencias = $('.checksIncluyeDependencia').map(function () {
            return $(this)[0].checked;
            }).get();*/

            //var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");

            Backend.asignarFuncionalidades(JSON.stringify(funcionalidadesSeleccionados), JSON.stringify(areasSeleccionadas), usuarioEncontrado.Id)
            .onSuccess(function (rto) {
                if (rto == 'ok') {
                    //window.location.reload();
                    alertify.success("Se ha asignado la funcionalidad correctamente");
                    _this.getFuncionalidadesDelUsuario();
                    $("#funcionalidadesSeleccionadas").empty();
                    $("#listadoAreasElegidas").empty();
                } else {
                    alertify.error(rto);
                }

            })
            .onError(function (e) {

            });

        });

    },
    /*getFuncionalidadesPerfilesAreas: function () {
        //var idUsuarioSeleccionado = sessionStorage.getItem("idUsuario");

        Backend.GetFuncionalidadesPerfilesAreasDeUnUsuario(usuarioEncontrado.Id)
            .onSuccess(function (rto) {
                if (rto) {
                    console.log(rto);
                } else {
                    alertify.error('Error');
                }

            })
            .onError(function (e) {

            });

    },*/
    getPerfilesConFuncionalidades: function () {

        Backend.GetPerfilesConFuncionalidades()
            .onSuccess(function (rto) {
                if (rto) {
                    console.log(rto);
                } else {
                    alertify.error('Error');
                }

            })
            .onError(function (e) {

            });
    },
    completarDatosDeLaSesion: function () {
        $("#nombre_empleado").html(sessionStorage.getItem("nombre"));
        $("#apellido_empleado").html(sessionStorage.getItem("apellido"));
        var idImagen = parseInt(sessionStorage.getItem("idImagen"));
        if (idImagen >= 0) {
            var img = new VistaThumbnail({ id: idImagen, contenedor: $(".imagen") });
        }
    },
    validarUsuarioCargado: function () {
        if (usuarioEncontrado.Id == 0) {
            alert('Debe seleccionar un usuario antes de proseguir');
            window.location.replace("DefinicionDeUsuario.aspx");
            return false;
            
        }
        return true;
    }

}
