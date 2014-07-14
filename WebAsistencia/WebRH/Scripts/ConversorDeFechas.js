var ConversorDeFechas = {
    deIsoAFechaEnCriollo: function (fecha_en_iso) {
        var fecha = new Date(fecha_en_iso);
        return fecha.getUTCDate().toString() + "/" + (fecha.getUTCMonth() + 1).toString() + "/" + fecha.getUTCFullYear();
    }
}