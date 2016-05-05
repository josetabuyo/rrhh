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
            console.log(vehiculo);
        });
    });
});