
$(function () {
    Backend.start(function () {
        var id_bien = localStorage.getItem("idBien");
        Backend.ElUsuarioLogueadoTienePermisosPara(37).onSuccess(function (tiene_permisos_de_edicion) {
            Backend.Mobi_GetBienPorId(id_bien).onSuccess(function (bien) {
                $("#ed_descripcion_bien").text(bien.Descripcion);
                
                $("#hdescripBien").text(bien.Descripcion); //GER20160926
                localStorage.setItem("descripBien", bien.Descripcion); //GER20160926
                
                $("#ed_contenedor_imagenes").empty();
                _.forEach(bien.Imagenes, function (id_imagen) {
                    var cont_imagen = $('<div class="imagen_bien"></div>');
                    var opt_vista = {
                        id: id_imagen,
                        contenedor: cont_imagen
                    };
                    if (tiene_permisos_de_edicion)
                        opt_vista.alEliminar = function () {
                            vex.dialog.confirm({
                                message: 'Está seguro que desea eliminar esta imágen?',
                                callback: function (value) {
                                    if (value) {
                                        Backend.Mobi_DesAsignarImagenABien(id_bien, id_imagen).onSuccess(function () {
                                            img.contenedor.remove();
                                        });
                                    }
                                }
                            });
                        };
                    var img = new VistaThumbnail(opt_vista);
                    $("#ed_contenedor_imagenes").append(cont_imagen);
                });
            });
        });


        //------------DATOS DEL VEHICULO-----------------------
        var idVerificador = localStorage.getItem("idVerificador");

        Backend.ObtenerVehiculoPorIDVerificacion(idVerificador).onSuccess(function (respuesta_vehiculo) {

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
            if (respuesta_vehiculo.vehiculo.Apellido == "Sin Asignación") {
                $("#responsable").text(respuesta_vehiculo.vehiculo.Apellido);
            }
            else {
                $("#responsable").text(respuesta_vehiculo.vehiculo.Apellido + ', ' + respuesta_vehiculo.vehiculo.Nombre);
            }
        });

        //------------------------------------


    });



});
