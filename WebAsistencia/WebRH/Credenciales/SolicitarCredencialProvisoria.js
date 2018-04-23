$(document).ready(function () {
    Backend.start(function () {
        var id_foto;
        $("#btn_guardar").click(function () {
            Backend.SolicitarCredencialProvisoria(
                $("#txt_dni").val(),
                $("#txt_apellidoynombre").val(),
                $("#txt_email").val(),
                $("#dtp_fechanacimiento").val(),
                $("#txt_telefono").val(),
                id_foto,
                $("#cmb_tipocredencal").val(),
                $("#cmb_autorizante").val(),
                $("#cmb_vinculo").val(),
                $("#cmb_lugarentrega").val()            
            );
        });
    });
});
