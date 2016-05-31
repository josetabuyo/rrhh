$(function () {
    Backend.start(function () {
        Backend.ObtenerVehiculoPorID(document.URL.split('?')[1]).onSuccess(function (vehiculo) {
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
        });
    });
});