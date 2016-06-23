$(function () {
    Backend.start(function () {
        var param = document.URL.split('?')[1];

        Backend.ObtenerVehiculoPorIDVerificacion(param).onSuccess(function (respuesta_vehiculo) {

            if (respuesta_vehiculo.Respuesta == 0) {
                $("#mensaje_error").show();
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
            $("#responsable").text(respuesta_vehiculo.vehiculo.Apellido + ', ' + respuesta_vehiculo.vehiculo.Nombre);
            $(".tabla-principal").show();
            $(".contenedor-imagen-vehiculo").show();
            $(".tabla-principal").addClass("animated slideInLeft");
            $("#contenedor-vehiculos").addClass("animated slideInRight");
            $("#contenedor-conductor").addClass("animated slideInRight");
            $(".contenedor-imagen-vehiculo").addClass("animated zoomIn");
            $("#contenedor-banner-parrafo").addClass("animated slideInDown");
            $("#barra_menu_contenedor_imagen").addClass("animated slideInDown");

        });

    });
});

