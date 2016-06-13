$(function () {
    Backend.start(function () {
        var param = document.URL.split('?')[1];

//        if (param !== parseInt(param))
//            param = 1;


//        if (param < 0 && param > 16)
//            param = 1;

        Backend.ObtenerVehiculoPorID(param).onSuccess(function (vehiculo) {
            $("#marca").text(vehiculo.Marca);
            $("#Modelo").text(vehiculo.Modelo);
            $("#segmento").text(vehiculo.Segmento);
            $("#dominio").text(vehiculo.Dominio);
            $("#año").text(vehiculo.Anio);
            $("#Motor").text(vehiculo.Motor);
            $("#chasis").text(vehiculo.Chasis);
            $("#area").text(vehiculo.Area);
            $("#responsable").text(vehiculo.Apellido + ', ' + vehiculo.Nombre);
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

