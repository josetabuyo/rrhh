var ContenedorGrilla;
ContenedorGrilla = $("#ContenedorGrilla");
$("#ContenedorMovimientos").empty();


$(function () {
    Backend.start(function () {

        var id_Tipo_Evento_Presionado;
        var observaciones;
        var titulo;
        var mensaje;

        var id_bien = localStorage.getItem("idBien");
        var id_estado = localStorage.getItem("idEstado");
        var id_Area_Seleccionada = localStorage.getItem("idAreaSeleccionada");
        var id_Area_Receptora = localStorage.getItem("idAreaReceptora");
        var id_Area_Propietaria = localStorage.getItem("idAreaPropietaria");

        $('#Controles_Persona_Area').hide(); //Buscador Area y Persona

        //DATOS DEL VEHICULO
        Backend.ObtenerVehiculoPorID(id_bien).onSuccess(function (respuesta_vehiculo) {
            console.log("Vehiculo");
            if (respuesta_vehiculo.Respuesta == 0) {
                return;
            }
            $("#marca").text(respuesta_vehiculo.vehiculo.Marca);
            $("#Modelo").text(respuesta_vehiculo.vehiculo.Modelo);
            $("#segmento").text(respuesta_vehiculo.vehiculo.Segmento);
            $("#dominio").text(respuesta_vehiculo.vehiculo.Dominio);
            $("#año").text(respuesta_vehiculo.vehiculo.Anio);
            $("#Motor").text(respuesta_vehiculo.vehiculo.Motor);
            $("#chasis").text(respuesta_vehiculo.vehiculo.Chasis);
            $("#area").text(respuesta_vehiculo.vehiculo.Area);
            if (respuesta_vehiculo.vehiculo.Conductor.Nombre == "") {
                $("#responsable").text("");
            }
            else {
                $("#responsable").text(respuesta_vehiculo.vehiculo.Conductor.Apellido + ', ' + respuesta_vehiculo.vehiculo.Conductor.Nombre);
            }
        });

        //------------ CARGO LAS IMAGENES DEL VEHICULO ---------------
        //Backend.ElUsuarioLogueadoTienePermisosPara(37).onSuccess(function (tiene_permisos_de_edicion) {
        Backend.Mobi_GetImagenesBienPorId(id_bien).onSuccess(function (bien) {
            if (bien.Imagenes.length > 0) {
                $("#descrip_hay_imagen_cargadas").empty();
                $("#btn_ver_imagen").show();
            } else {
                $("#descrip_hay_imagen_cargadas").text("No hay imagenes cargadas");
            }

            _.forEach(bien.Imagenes, function (id_imagen) {
                var cont_imagen = $('<div class="imagen_bien"></div>');
                var opt_vista = {
                    id: id_imagen,
                    contenedor: cont_imagen
                };
                //                    if (tiene_permisos_de_edicion)
                //                        opt_vista.alEliminar = function () {
                //                            vex.dialog.confirm({
                //                                message: 'Está seguro que desea eliminar esta imágen?',
                //                                callback: function (value) {
                //                                    if (value) {
                //                                        Backend.Mobi_DesAsignarImagenABien(id_bien, id_imagen).onSuccess(function () {
                //                                            img.contenedor.remove();
                //                                        });
                //                                    }
                //                                }
                //                            });
                //                        };
                var img = new VistaThumbnail(opt_vista);
                $("#ed_contenedor_imagenes").append(cont_imagen);

            });
        });
        //});


        //AGREGO EL BOTON PARA VER LA IMAGEN
        $("#btn_ver_imagen").click(function () {
            vex.defaultOptions.className = 'vex-theme-os';
            vex.open({
                afterOpen: function ($vexContent) {
                    var ui = $("#ed_contenedor_imagenes").clone();
                    $vexContent.append(ui);
                    ui.show();
                    return ui;
                }
            })
        });

        //---------------------------------------------

        // ----- CARGO LOS BOTONES DE ACCIONES ------------
        Backend.Mobi_GetAcciones(id_bien, id_estado, id_Area_Seleccionada, id_Area_Receptora, id_Area_Propietaria).onSuccess(function (acciones) {
            _.forEach(acciones, function (accion) {
                GeneradorBotones(accion);
            });
        });

        var GeneradorBotones = function (accion) {
            var ContenedorBotones = $("#DivBotones");
            var boton;

            boton = $("<input type='button'>");
            boton.val(accion.Descripcion);

            boton.click(function () {
                acciones[accion.IdAccion]();
            });

            ContenedorBotones.append(boton);
            return ContenedorBotones;
        };

        var acciones = {
            //Movimientos
            0: function () {
                LimpiarPantalla();
                Consultar();
            },

            //Asignar
            1: function () {
                LimpiarPantalla();
                id_Tipo_Evento_Presionado = 2;
                observaciones = "Asignación del bien"
                $('#Controles_Persona_Area').show();
            },

            //Préstamo
            2: function () {
                LimpiarPantalla();
                id_Tipo_Evento_Presionado = 4;
                observaciones = "Prestamo del bien"
                $('#Controles_Persona_Area').show();
            },

            //Reparar
            3: function () {
                titulo = "Reparar vehiculo";
                id_Tipo_Evento_Presionado = 8;
                observaciones = "Reparación del bien";
                mensaje = "Desea mandar a reparar el vehiculo?";

                RealizarAccion(id_bien, id_Tipo_Evento_Presionado, observaciones, id_Area_Seleccionada, 0);
            },

            //Rehabilitar
            4: function () {
                titulo = "Rehabilitar vehiculo";
                id_Tipo_Evento_Presionado = 2;
                observaciones = "Rehabilitación del bien";
                mensaje = "Desea rehabilitar el vehiculo?";

                RealizarAccion(id_bien, id_Tipo_Evento_Presionado, observaciones, id_Area_Propietaria, 0);
            },

            //Baja
            5: function () {
                //alert("FALTA Dar de baja");
            },


            //Devolver a origen
            6: function () {
                titulo = "Devolver vehiculo";
                id_Tipo_Evento_Presionado = 5;
                observaciones = "Devolución del bien";
                mensaje = "Desea devolver el vehiculo al area de origen?";

                RealizarAccion(id_bien, id_Tipo_Evento_Presionado, observaciones, id_Area_Propietaria, -1);
            },

            //Tomar
            7: function () {
                titulo = "Tomar vehiculo";
                id_Tipo_Evento_Presionado = 2;
                observaciones = "Tomar vehiculo";
                mensaje = "Desea tomar el vehiculo?";

                RealizarAccion(id_bien, id_Tipo_Evento_Presionado, observaciones, id_Area_Propietaria, 0);
            },


            //Asignar/Cambiar Chofer
            8: function () {
                //                titulo = "Asignar chofer";
                //                id_Tipo_Evento_Presionado = 2;
                //                observaciones = "Asignar/Cambiar chofer";
                //                mensaje = "Desea asignar el chofer al vehiculo?";

                LimpiarPantalla();
                id_Tipo_Evento_Presionado = 3;
                observaciones = "Asignar responsable al bien"

                $('#Controles_Persona_Area').show();
                $('#divBuscadorArea').hide();


            }
        };


        //AGREGO EL BOTON ACEPTAR
        $("#btn_guardar").click(function () {

            if ($('#divBuscadorArea').is(":visible")) {

                //VALIDO QUE INGRESE EL AREA
                var idarea = $('#hfIdArea').val();
                if (idarea == "") {
                    alertify.alert("Asignación de Area", "Debe ingresar el Area en la cual desea asignar el vehiculo.");
                    return;
                }

                //VALIDO SI INGRESO EL RESPONSABLE
                //int id_bien, int id_tipoevento, string observaciones, int id_receptor
                var documento = $('#documento').text().trim();
                if (documento == "") {
                    alertify.confirm("Asignación de Responsable", "¿Desea enviar el vehiculo sin una persona responsable?", function () {
                        //ACEPTO SIN RESPONSABLE
                        Backend.Mobi_Alta_Vehiculo_Evento(id_bien, id_Tipo_Evento_Presionado, observaciones, idarea, -1).onSuccess(function () {
                            //alertify.success("Asignación Correcta");
                            //$('#Controles_Persona_Area').hide();
                            Mostrar_Mensaje_OK_y_CERRAR("Asignación");
                        })
                    .onError(function () {
                        alertify.error("Se produjo un error");
                    });

                    }, function () {
                        alertify.success("Asignación cancelada");
                    }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });
                }
                else {
                    //ACEPTO CON RESPONSABLE
                    Backend.Mobi_Alta_Vehiculo_Evento(id_bien, id_Tipo_Evento_Presionado, observaciones, idarea, documento).onSuccess(function () {
                        //alertify.success("Asignación Correcta");
                        //$('#Controles_Persona_Area').hide();
                        Mostrar_Mensaje_OK_y_CERRAR("Asignación");
                    })
                .onError(function () {
                    alertify.error("Se produjo un error");
                });
                }

            }
            else {
            
                //ACEPTO CON RESPONSABLE
                var documento = $('#documento').text().trim();
                if (documento == "") {
                    alertify.alert("Asignación de Responsable", "Debe ingresar el responsable para asignarlo al vehiculo.");
                    return;
                }

                Backend.Mobi_Alta_Vehiculo_Evento_Persona(id_bien, id_Tipo_Evento_Presionado, observaciones, documento).onSuccess(function () {
                    Mostrar_Mensaje_OK_y_CERRAR("Asignación de Responsable");
                })
                    .onError(function () {
                        alertify.error("Se produjo un error");
                    });
            }

        });



        var LimpiarPantalla = function () {
            ContenedorGrilla.html("");
            $('#Controles_Persona_Area').hide();
            $("#ContenedorMovimientos").empty();

            $('#divBuscadorArea').show();
            $('#divBuscadorPersona').show();
        };

        var Mostrar_Mensaje_OK_y_CERRAR = function (titulo) {
            window.showAlert = function () {
                alertify.alert(titulo, 'Se realizo la operación correctamente', function () {
                    window.close();
                });
            }
            alertify.alert().setting('modal', true);
            window.showAlert();
        }



        //---------- ACCIONES INICIO ------------------

        var RealizarAccion = function (idbien, idtipoevento, observacion, idarea, responsable) {

            LimpiarPantalla();

            alertify.confirm(titulo, mensaje, function () {
                Backend.Mobi_Alta_Vehiculo_Evento(idbien, idtipoevento, observacion, idarea, responsable).onSuccess(function () {
                    Mostrar_Mensaje_OK_y_CERRAR(titulo);
                })
                .onError(function () {
                    alertify.error("Se produjo un error");
                });
            }
                , function () {
                    alertify.success("Se cancelo la operación");
                }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });

        };

        //---------- ACCIONES FINAL ------------------




        //---------- MOVIMIENTOS INICIO ------------------

        var Consultar = function () {

            spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

            getConsulta(function () {
                DibujarGrillaMovEventos();
                spinner.stop();
            });

            //$('#DivBotonExcel').show();
        }

        var getConsulta = function (callback) {
            Backend.Mobi_GetMovimientos(id_bien)
        .onSuccess(function (respuesta) {
            lista_areas_del_usuario = respuesta;
            callback();
        })
        .onError(function (error, as, asd) {
            alertify.alert("", error);
        });
        }

        var DibujarGrillaMovEventos = function () {
            var grilla;

            //$("#ContenedorMovimientos").empty();

            grilla = new Grilla(
        [
        new Columna("Id_Evento", { generar: function (consulta) { return consulta.Id; } }),
        new Columna("Tipo_Evento", { generar: function (consulta) { return consulta.TipoEvento; } }),
        new Columna("Observaciones", { generar: function (consulta) { return consulta.Observaciones; } }),
        new Columna("Descripcion_Receptor", { generar: function (consulta) { return consulta.Receptor; } }),
            //new Columna("Fecha", { generar: function (consulta) { return consulta.Fecha; } }),
        new Columna("Fecha", { generar: function (consulta) {
            var fecha_sin_hora = consulta.Fecha.split("T");
            var fecha = fecha_sin_hora[0].split("-");
            return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        }
        }),
        ]);

            grilla.CargarObjetos(lista_areas_del_usuario);
            grilla.DibujarEn(ContenedorGrilla);

            //            $("#DivBotonExcel").empty();
            //            var divBtnExportarExcel = $("#DivBotonExcel")
            //            botonExcel = $("<input type='button'>");
            //            botonExcel.val("Exportar a Excel");
            //            botonExcel.click(function () {
            //                BuscarExcel();
            //            });
            //            botonExcel.addClass("btn btn-primary");
            //            divBtnExportarExcel.append(botonExcel);

            grilla.SetOnRowClickEventHandler(function () {
                return true;
            });
        }

        //---------- MOVIMIENTOS FINAL ------------------





        //--------------------------------------------------

    });
});



//-------------------------------------------------------------------------------------------------------
//                id_Tipo_Evento_Presionado = 2;
//                observaciones = "Toma del bien"
//                Backend.Mobi_Alta_Vehiculo_Evento(id_bien, id_Tipo_Evento_Presionado, observaciones, id_Area_Propietaria, 0).onSuccess(function () {
//                    alertify.success("Se tomó Correctamente");
//                    $('#Controles_Persona_Area').hide();
//                })
//                    .onError(function () {
//                        alertify.error("Se produjo un error");
//                    });
//            }
//-------------------------------------------------------------------------------------------------------
//                titulo = "Reparar bien";
//                alertify.confirm(titulo, 'Desea mandar a reparar el vehiculo?', function () {
//                    LimpiarPantalla();
//                    id_Tipo_Evento_Presionado = 8;
//                    observaciones = "Reparación del bien"
//                    Backend.Mobi_Alta_Vehiculo_Evento(
//id_bien, 
//id_Tipo_Evento_Presionado, 
//observaciones, 
//id_Area_Seleccionada, 
//0).onSuccess(function () {
//                        //alertify.success("Vehiculo enviado a reparación");
//                        //$('#Controles_Persona_Area').hide();
//                        Mostrar_Mensaje_OK_y_CERRAR(titulo);
//                    })
//                    .onError(function () {
//                        alertify.error("Se produjo un error");
//                    });
//                }
//                , function () {
//                    alertify.success("Se cancelo la operación");
//                }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });
//-------------------------------------------------------------------------------------------------------
//                titulo = "Rehabilitar bien";
//                alertify.confirm(titulo, 'Desea rehabilitar el vehiculo?', function () {
//                    LimpiarPantalla();
//                    id_Tipo_Evento_Presionado = 2;
//                    observaciones = "Rehabilitación del bien"
//                    Backend.Mobi_Alta_Vehiculo_Evento(
//id_bien, 
//id_Tipo_Evento_Presionado, 
//observaciones, 
//id_Area_Propietaria, 
//0).onSuccess(function () {
//                        //alertify.success("Vehiculo rehabilitado con exito");
//                        //$('#Controles_Persona_Area').hide();
//                        Mostrar_Mensaje_OK_y_CERRAR(titulo);
//                    })
//                    .onError(function () {
//                        alertify.error("Se produjo un error");
//                    });
//                }
//                , function () {
//                    alertify.success("Se cancelo la operación");
//                }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });
//-------------------------------------------------------------------------------------------------------
//                titulo = "Devolver bien";
//                alertify.confirm(titulo, 'Desea devolver el bien al area de origen?', function () {
//                    LimpiarPantalla();
//                    id_Tipo_Evento_Presionado = 5;
//                    observaciones = "Devolución del bien"
//                    Backend.Mobi_Alta_Vehiculo_Evento(
//                        id_bien, 
//                        id_Tipo_Evento_Presionado, 
//                        observaciones, 
//                        id_Area_Propietaria, 
//                        -1).onSuccess(function () {
//                        //alertify.success("Devolución Correcta");
//                        //$('#Controles_Persona_Area').hide();
//                        Mostrar_Mensaje_OK_y_CERRAR(titulo);
//                    })
//                    .onError(function () {
//                        alertify.error("Se produjo un error");
//                    });
//                }
//                , function () {
//                    alertify.error("Se cancelo la operación");
//                }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });
