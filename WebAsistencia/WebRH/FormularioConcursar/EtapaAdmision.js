function visualizacionDeBuscarComite() {
    if ($('#id_comite').val() == "") {
        $('#id_perfil').prop("disabled", true);
        $('#btn_buscar_postulaciones').prop("disabled", true);
    } else {
        $('#id_perfil').prop("disabled", false);
        $('#btn_buscar_postulaciones').prop("disabled", false);
    }

};

function buscarComite() {
    var id_comite = $('#id_comite').val();
    var id_perfil = $('#id_perfil').val();

    Backend.GetPostulacionesPorComiteYPerfil(id_comite, id_perfil)
    .onSuccess(function (resultado) {
        alertify.alert(resultado);
        location.reload();
    });
};





