function HabilitarBuscarComite() {
    if ($('#id_comite').val() == "") {
        $('#id_perfil').prop("disabled", true);
        $('#btn_filtrar').prop("disabled", true);
    } else {
        $('#id_perfil').prop("disabled", false);
        $('#btn_filtrar').prop("disabled", false);
        BuscarPreinscriptos();
    }

};

function BuscarPreinscriptos() {
    var id_comite = $('#id_comite').val();

    Backend.BuscarPostulacionesDePreinscriptos(id_comite)
    .onSuccess(function (resultado) {
        for (var i = 0; i < resultado.length; i++) {
            DibujarTabla();
        }
    });
};

function DibujarTabla() {

    var divGrilla = $('#tabla_postulaciones');

    var columnas = [];
    columnas.push(new Columna("Nro Postulación", { generar: function (una_postulacion) { return una_postulacion.Denominacion } }));
};

function FiltarPorComite() { };





