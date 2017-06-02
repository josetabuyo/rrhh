
$(function () {
    Backend.start(function () {
        var id_bien = localStorage.getItem("idBien");
        var id_estado = localStorage.getItem("idEstado");
        var id_Area_Seleccionada = localStorage.getItem("idAreaSeleccionada");
        $("#hid").val(id_bien);
        $("#hidEstado").val(id_estado);
        $("#hidAreaSeleccionada").val(id_Area_Seleccionada);

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
            //Asignar
            1: function () {
                alert("Asignar");
            },

            //Dar en préstamo
            2: function () {
                alert("Dar en préstamo");
            },

            //Mandar a reparar
            3: function () {
                alert("Mandar a reparar");
            },

            //Rehabilitar
            4: function () {
                alert("Rehabilitar");
            },

            //Dar de baja
            5: function () {
                alert("Dar de baja");
            },

            //Devolver a origen
            6: function () {
                alert("Devolver a origen");
            },

            //Tomar
            7: function () {
                alert("Tomar");
            }
        };
        //--------------------------------------------------








        //----------
    });
});
