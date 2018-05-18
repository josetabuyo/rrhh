$(document).ready(function () {
    Backend.start(function () {
        var id_foto;
        var ui = $("#formulario_solicitud");
        Backend.GetLugaresEntregaCredencial()
            .onSuccess(function (lugares) {
                _.forEach(lugares, function (lugar) {
                    var opt = $("<option>");
                    opt.text(lugar.Descripcion);
                    opt.attr("value", lugar.IdLugar);
                    ui.find("#cmb_lugarentrega").append(opt);
                    $('#cmb_lugarentrega option[value=1924]').prop('selected', true);
                });
            });

        Backend.GetTiposDeCredencial()
            .onSuccess(function (tipos) {
                _.forEach(tipos, function (tipo) {
                    var opt = $("<option>");
                    opt.text(tipo.Descripcion);
                    opt.attr("value", tipo.Id);
                    ui.find("#cmb_tipocredencal").append(opt);
                });
            });

        Backend.GetVinculosCredenciales()
            .onSuccess(function (vinculos) {
                _.forEach(vinculos, function (vinculo) {
                    var opt = $("<option>");
                    opt.text(vinculo.Descripcion);
                    opt.attr("value", vinculo.Id);
                    ui.find("#cmb_vinculo").append(opt);
                });
            });

        //        Backend.GetAutorizantesCredenciales()
        //            .onSuccess(function (autorizantes) {
        //                _.forEach(autorizantes, function (autorizante) {
        //                    var opt = $("<option>");
        //                    opt.text(autorizante.Apellido + ", " + autorizante.Nombre);
        //                    opt.attr("value", autorizante.Id);
        //                    ui.find("#cmb_autorizante").append(opt);
        //                });
        //            });
        $("#btn_guardar").click(function () {
            Backend.SolicitarCredencialExterna(
                $("#txt_dni").val(),
                $("#txt_apellido").val(),
                $("#txt_nombres").val(),
                $("#txt_email").val(),
                $("#dtp_fechanacimiento").val(),
                $("#txt_telefono").val(),
                id_foto,
                $("#cmb_tipocredencal").val(),
                $("#cmb_autorizante").val(),
                $("#cmb_vinculo").val(),
                $("#cmb_lugarentrega").val()
            )
            .onSuccess(function () {

            })
            .onError(function () {

            });
        });

    });
});
