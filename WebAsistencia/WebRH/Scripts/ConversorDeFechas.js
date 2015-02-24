var ConversorDeFechas = {
    deIsoAFechaEnCriollo: function (fecha_en_iso) {

        var regexp_fecha_iso = /(\d{1,4}\-\d{1,2}\-\d{1,2})T(\d{1,2}\:\d{1,2}\:\d{1,2})/;
        if (regexp_fecha_iso.test(fecha_en_iso)) {
            fecha_en_iso = (regexp_fecha_iso.exec(fecha_en_iso)[1]).replace(/-/g, "/");
        }
        var fecha = new Date(fecha_en_iso);
        if (fecha.getUTCDate().toString() == "NaN") return "";
        return fecha.getUTCDate().toString() + "/" + (fecha.getUTCMonth() + 1).toString() + "/" + fecha.getUTCFullYear();
    },
    PrimeraFechaCriolloMayor: function (fechaMayor, fechaMenor) {
        var lista_fecha1 = fechaMayor.split('/');
        var lista_fecha2 = fechaMenor.split('/');
        var dia1 = parseInt(lista_fecha1[0], 10);
        var mes1 = parseInt(lista_fecha1[1], 10);
        var anio1 = parseInt(lista_fecha1[2], 10);
        var dia2 = parseInt(lista_fecha2[0], 10);
        var mes2 = parseInt(lista_fecha2[1], 10);
        var anio2 = parseInt(lista_fecha2[2], 10);

        if (anio1 > anio2) {
            return true;
        }
        else {
            if (anio1 == anio2) {
                if (mes1 > mes2) {
                    return true;
                }
                else {
                    if (mes1 == mes2) {
                        if (dia1 > dia2) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        return false;
                    }
                }
            }
            else {
                return false;
            }
        }

    },
    ConvertirDateNowDeJS: function (fecha) {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd
        }

        if (mm < 10) {
            mm = '0' + mm
        }
        return today = yyyy + '-' + mm + '-' + dd + 'T03:00:00.000Z';

    }
}