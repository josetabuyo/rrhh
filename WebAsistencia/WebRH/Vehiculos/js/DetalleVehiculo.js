$(function () {
    Backend.start(function () {
        var param = document.URL.split('?')[1];

        Backend.ObtenerVehiculoPorIDdeTarjeton(param).onSuccess(function (respuesta_vehiculo) {
            $("#volver").addClass("animated slideInLeft");
            $("#boton-imagenes").addClass("animated slideInLeft");       

            if (respuesta_vehiculo.Respuesta == 0) {
                $("#mensaje_error").show();
                $("#mensaje_error").addClass("animated slideInDown");
                $("#Contenido").hide();
                return;
            }

            if (respuesta_vehiculo.vehiculo.Apellido == "Sin Asignación") {
                $("#responsable").text(respuesta_vehiculo.vehiculo.Apellido);
            }
            else {
                $("#responsable").text(respuesta_vehiculo.vehiculo.Apellido + ', ' + respuesta_vehiculo.vehiculo.Nombre);
            }

            $("#marca").text(respuesta_vehiculo.vehiculo.Marca);
            $("#Modelo").text(respuesta_vehiculo.vehiculo.Modelo);
            $("#segmento").text(respuesta_vehiculo.vehiculo.Segmento);
            $("#dominio").text(respuesta_vehiculo.vehiculo.Dominio);
            $("#año").text(respuesta_vehiculo.vehiculo.Anio);
            $("#Motor").text(respuesta_vehiculo.vehiculo.Motor);
            $("#chasis").text(respuesta_vehiculo.vehiculo.Chasis);
            $("#area").text(respuesta_vehiculo.vehiculo.Area);

            $(".tabla-principal").show();
            $(".contenedor-imagen-vehiculo").show();
            $("#mensaje_error").hide();
            $(".tabla-principal").addClass("animated slideInLeft");
            $("#titulo-separador-vehiculos").addClass("animated slideInRight");
            $("#contenedor-conductor").addClass("animated slideInRight");
            $(".contenedor-imagen-vehiculo").addClass("animated zoomIn");
            $("#contenedor-banner-parrafo").addClass("animated slideInDown");
            $("#barra_menu_contenedor_imagen").addClass("animated slideInDown");

            $("#boton-imagenes").click(function () {
                document.location.href = "#contenedor-imagen-vehiculo";
            });

            

            $("#myCarousel").carousel({
                interval: 5000,
                pause: true
            });

           

            _.forEach(respuesta_vehiculo.vehiculo.imagenes, function (id_imagen) {
                var cont_imagen = $('<div class="item" style="height:100%; width:100%; position:relative"></div>');
                var img = new VistaThumbnail({ id: id_imagen, contenedor: cont_imagen });
                $(".carousel-inner").append(cont_imagen);
            });

            if (respuesta_vehiculo.vehiculo.imagenes.length == 0 ) {
                $("#myCarousel").hide();
                $("#boton-imagenes").hide(); 
            }


        });

    });
});

