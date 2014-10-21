var ConversorDeFechas = {
    deIsoAFechaEnCriollo: function (fecha_en_iso) {

        var regexp_fecha_iso = /(\d{1,4}\-\d{1,2}\-\d{1,2})T(\d{1,2}\:\d{1,2}\:\d{1,2})/;

        if (regexp_fecha_iso.test(fecha_en_iso)) {
            fecha_en_iso = (regexp_fecha_iso.exec(fecha_en_iso)[1]).replace("-","/");
        }

        var fecha = new Date(fecha_en_iso);
        return fecha.getUTCDate().toString() + "/" + (fecha.getUTCMonth() + 1).toString() + "/" + fecha.getUTCFullYear();
    }
}