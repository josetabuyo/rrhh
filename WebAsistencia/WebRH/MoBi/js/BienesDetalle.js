
$(function () {
    Backend.start(function () {

        var id_Tipo_Evento_Presionado;
        var observaciones;

        var id_bien = localStorage.getItem("idBien");
        var id_estado = localStorage.getItem("idEstado");
        var id_Area_Seleccionada = localStorage.getItem("idAreaSeleccionada");
        //$("#hid").val(id_bien);
        //$("#hidEstado").val(id_estado);
        //$("#hidAreaSeleccionada").val(id_Area_Seleccionada);

        $('#Controles_Persona_Area').hide(); //Buscador Area y Persona

        //$('#divBuscadorArea').hide(); //Buscador Area
        //$('#divBuscadorPersona').hide(); //Buscador Persona
        //$("#btn_Aceptar").hide();

        /*
        var documento = $('#documento').text().trim();
        if (documento == "") {
        documento = 0;
        }

        var idarea = $('#hfIdArea').val();
        if (idarea == "") {
        idarea = 0;
        }
        */

        //DATOS DEL VEHICULO
        Backend.ObtenerVehiculoPorID(id_bien).onSuccess(function (respuesta_vehiculo) {
            console.log("hola");
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
        Backend.Mobi_GetAcciones(id_bien, id_estado, id_Area_Seleccionada).onSuccess(function (acciones) {
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
                //id_Tipo_Evento_Presionado = 0;
            },

            //Asignar
            1: function () {
                id_Tipo_Evento_Presionado = 2;
                observaciones = "Asignación del bien"
                $('#Controles_Persona_Area').show();
            },

            //Dar en préstamo
            2: function () {
                id_Tipo_Evento_Presionado = 4;
                observaciones = "Prestamo del bien"
                $('#Controles_Persona_Area').show();
            },

            //Mandar a reparar
            3: function () {
                //id_Tipo_Evento_Presionado = 8;
                //observaciones = "Reparación"
                //$('#Controles_Persona_Area').show();
            },

            //Rehabilitar
            4: function () {
                //alert("FALTA Rehabilitar");
            },

            //Dar de baja
            5: function () {
                //alert("FALTA Dar de baja");
            },

            //Devolver a origen
            6: function () {
                id_Tipo_Evento_Presionado = 5;
                observaciones = "Devolución del bien"
                //$('#Controles_Persona_Area').show();
            },

            //Tomar
            7: function () {
                //alert("FALTA Tomar");
            }

        };


        //AGREGO EL BOTON ACEPTAR
        $("#btn_guardar").click(function () {

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
                    Backend.Mobi_Alta_Vehiculo_Evento_Asignacion_Prestamo(id_bien, id_Tipo_Evento_Presionado, observaciones, idarea, -1).onSuccess(function () {
                        alertify.success("Asignación Correcta");
                        $('#Controles_Persona_Area').show();
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
                Backend.Mobi_Alta_Vehiculo_Evento_Asignacion_Prestamo(id_bien, id_Tipo_Evento_Presionado, observaciones, idarea, documento).onSuccess(function () {
                    alertify.success("Asignación Correcta");
                    $('#Controles_Persona_Area').show();
                })
                .onError(function(){
                    alertify.error("Se produjo un error");
                });
                
            }


        });


        //------------------ MOVIMIENTOS -------------------------
        /*
        var Consultar = function () {
        ContenedorGrilla.html("");
        $("#ContenedorPersona").empty();

        spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

        getConsulta(function () {
        DibujarGrillaDDJJ();
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

        var DibujarGrillaDDJJ = function () {
        var grilla;

        $("#ContenedorPersona").empty();

        if (consultaSeleccionada == "PERSONA") {
        grilla = new Grilla(
        [
        new Columna("Mes", { generar: function (consulta) { return consulta.mes; } }),
        new Columna("Año", { generar: function (consulta) { return consulta.anio; } }),
        new Columna("Area", { generar: function (consulta) { return consulta.area_generacion.Nombre; } }),
        new Columna("Apellido", { generar: function (consulta) { return consulta.persona.Apellido; } }),
        new Columna("Nombre", { generar: function (consulta) { return consulta.persona.Nombre; } }),
        new Columna("Fecha Generación", { generar: function (consulta) { return consulta.fecha_generacion; } }),
        new Columna("Usuario Generación", { generar: function (consulta) { return consulta.usuario_generacion; } }),
        new Columna("Fecha Recibido", { generar: function (consulta) { return consulta.fecha_recibido; } }),
        new Columna("Usuario Recibido", { generar: function (consulta) { return consulta.usuario_recibido; } }),
        new Columna("Firmante", { generar: function (consulta) { return consulta.firmante; } }),
        new Columna("Categoria", { generar: function (consulta) { return consulta.persona.Categoria; } }),
        new Columna("Mod Contratación", { generar: function (consulta) { return consulta.mod_contratacion; } }),
        new Columna("Estado", { generar: function (consulta) { return consulta.estado_descrip; } })
        ]);
        }

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
        */
        //-------------------------------------------------------





        //--------------------------------------------------

    });
});
