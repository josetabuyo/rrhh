
var GraficoHerramientas = {

    ConvertirFecha: function (fecha) {
        var dia = fecha.substring(8, 10);
        var mes = fecha.substring(5, 7);
        var anio = fecha.substring(0, 4);
        return dia + "/" + mes + "/" + anio;
    },

    VerificarSoporteDeStorage: function () {
        if (typeof (Storage) !== "undefined") {
            return true;
        } else {
            return false;
            alertify.error("El Navegador que está utilizando no soporta la Aplicación de Gráficos. Utilice un navegador más moderno")
            console.log("No soporta localStorage");
        }
    }
}
