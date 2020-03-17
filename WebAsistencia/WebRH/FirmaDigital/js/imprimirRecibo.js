﻿var spinner;
var mes;
var idUsuario;
var usuarioEncontrado;
var idPersonaActual;

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
        idPersonaActual = la_persona_seleccionada.id;
        $('#panel_datos_usuario').hide();
        _this.repositorioDeUsuarios.getUsuarioPorIdPersona(
            la_persona_seleccionada.id,
            function (usuario) {
                //se encontro a la persona con id, entonces cargo los datos correspondientes
                //_this.cargarUsuario(usuario);
                _this.cargarUsuario(usuario, la_persona_seleccionada.id);
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
    getRecibos: function (idPersona,modo) {
        Backend.GetRecibos(idPersona,modo).onSuccess(function (listaRecibos) {

            listaRecibosConformados = [];//reseteo la lista de recibos que indican cuales estan conformado:1, no conformado:0, resto anterios al inicio de los recibos digitales:-1

            var capaListaRecibos = document.getElementById("listaRecibosConfomadosPersonal");
            var i;
            var resp = JSON.parse(listaRecibos);
            var longitud; //tamaño de la lista de recibos conformados por el agente
            longitud = Object.keys(resp).length;
            
            var capaInicio = ''; //representa la capa que muestran a las liquidaciones
            var capaFin = '';
            var capaRecibos = '';
            var capaAcumulada = '';
            
            capaInicio = '<div style="height: 307px;overflow: auto;margin-bottom:20px"><table class="stripedGris tablexxx table-striped table-bordered table-condensedxxx" style="width:100%;border-collapse: inherit;"><tbody class="listxxx"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 10pt;font-weight: bold;text-align:center;padding:5px;width:34%" >Liquidación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 10pt;font-weight: bold;text-align:center" >Area</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:10px;text-align:center" >&nbsp;</td></tr>';

            capaFin = '</tbody></table></div>';

            capaAcumulada = capaInicio;
            //genero la lista de recibos conformados
            for (i = 0; i < longitud; i++) {
                
                //la lista va a ser de clave: 'id' +idRecibo y valor: conformado:1,no conformado:0, resto:-1
                var s;
                s = 'id' +resp[i].idRecibo; 
               
                capaRecibos = '<tr style="text-align:left;">  <td style="padding-left:5px;"><div style="margin-top:5px">' + resp[i].descripcionLiquidacion + '</div></td>  <td style="padding-left:5px;"><div style="margin-top:5px">' + resp[i].area_desc + '</div></td> <td style="text-align: center;padding:6px;"><input type="checkbox" class="chk_listado" id="' + resp[i].idRecibo + '" style="cursor: pointer;" value="' + resp[i].idArchivo + '"  /></td></tr>';

                listaRecibosConformados[s] = resp[i].conformado;
                capaAcumulada = capaAcumulada + capaRecibos;


            }
            //alert(Object.keys(listaRecibosConformados).length);
            capaAcumulada = capaAcumulada + capaFin;
            capaListaRecibos.innerHTML = capaAcumulada;

            /*permite solo seleccionar un checkbox a la vez del grupo de clase chk_listado*/
            $('.chk_listado').click(function () {
                $('.chk_listado').not(this).prop('checked', false);
            });

        });


    },

    /**
     *TODO limpiar e iniciar la lista de recibos conformados
     */
    //FC: cuando seleccione una persona del buscador de Personas
    cargarUsuario: function (usuario,idPersona) {
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

        Backend.getAreaDeLaPersona().onSuccess(function (descripcionArea) {
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

        /*obtengo los recibos de la personas seleccionada,recientes o hisoricas dependiendo de la seleccion
         por default el modo es 0, osea solo obtener recibos recientes*/
        this.getRecibos(idPersona,0); 


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
    },
    getPersonasDeBajaConPermisos: function () {
        var _this = this;
        Backend.BuscarPersonaDeBajaConPermisos().onSuccess(function (data) {
            _this.armarTabla($('#tabla_personas_de_baja'), data, _this);
        });

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
    },
    backendBuscarUsuariosPorArea: function (contexto, nombre_area) {
        $("body").addClass("loading");
        Backend.BuscarUsuariosPorArea(nombre_area).onSuccess(function (data) {
            $("body").removeClass("loading");
            $("#p_nombre_area").html("Área: " + nombre_area);
            contexto.armarTabla($('#tabla_usuarios_por_area'), data, contexto);
        });
    },
    armarTabla: function (tabla, data, contexto_para_row_click) {

        var columnas = [];

        columnas.push(new Columna("Apellido", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Nombre } }));
        columnas.push(new Columna("Documento", { generar: function (un_usuario) { if (un_usuario.Owner != null) return un_usuario.Owner.Documento } }));
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
    }


}