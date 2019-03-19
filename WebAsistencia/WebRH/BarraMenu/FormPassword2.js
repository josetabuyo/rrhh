function CapturarTeclaEnter(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.type == "password")) { $("#pass").click(); return false; }
}


$(document).ready(function () {
    //Al presionarse Enter luego de Ingresar el DNI, se fuerza a realizar la búsqueda de dicho DNI para no tener que hacer necesariamente un click en el botón Buscar

    document.onkeypress = CapturarTeclaEnter;

    $("#pass").click(function () {

        var pass_actual = $('#pass_actual').val();
        var pass_nueva = $('#pass_nueva').val();
        var pass_nueva_repetida = $('#pass_nueva_repetida').val();

        if (!(ValidarCamposVacios(pass_actual, pass_nueva, pass_nueva_repetida))) {
            return false;
        }

        if (pass_nueva != pass_nueva_repetida) {
            alertify.alert("", "Las contrase&ntilde;as no coinciden");
            return;
        }
        //FC: agregar estas validaciones cuando salgamos a produccion
        if (pass_nueva.length < 8) {
            alertify.alert("", "La contrase&ntilde;a debe ser tener al menos 8 d&iacute;gitos ");
            return;
        }

        if (pass_nueva == pass_actual) {
            alertify.alert("", "La contrase&ntilde;a debe ser distinta de la actual");
            return;
        }

        var matches = pass_nueva.match(/\d+/g);
        if (matches == null) {
            alertify.alert('', 'La contrase&ntilde;a debe tener algun n&uacute;mero');
            return false;
        }

        //                var data_post = JSON.stringify({
        //                    pass_actual: pass_actual,
        //                    pass_nueva: pass_nueva
        //                });
        _this = this;

        Backend.CambiarPassword(pass_actual, pass_nueva)
            .onSuccess(function (resp_string) {
                var respuesta = JSON.parse(resp_string);
                if (respuesta.tipoDeRespuesta == "cambioPassword.ok") {
                    alertify.alert("", "Se cambio la contrase&ntilde;a correctamente");
                    $(".modal_close").click();
                    $('#pass_actual').val("");
                    $('#pass_nueva').val("");
                    $('#pass_nueva_repetida').val("");
                    return;
                }

                if (respuesta.tipoDeRespuesta == "cambioPassword.error") {
                    alertify.alert("", "La contrase&ntilde;a actual no es correcta");
                    $(".modal_close").click();
                    return;
                }
            })
            .onError(function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            });
        //                $.ajax({
        //                    url: $('#BarraMenu_FormPassword_urlAjax').val().concat("AjaxWS.asmx/CambiarPassword"),
        //                    type: "POST",
        //                    data: data_post,
        //                    dataType: "json",
        //                    contentType: "application/json; charset=utf-8",
        //                    success: function (respuestaJson) {
        //                        var respuesta = JSON.parse(respuestaJson.d);
        //                        if (respuesta.tipoDeRespuesta == "cambioPassword.ok") {

        //                            alertify.alert("", "Se cambio la contrase&ntilde;a correctamente");
        //                            $(".modal_close").click();
        //                            $('#pass_actual').val("");
        //                            $('#pass_nueva').val("");
        //                            $('#pass_nueva_repetida').val("");
        //                            return;
        //                        }

        //                        if (respuesta.tipoDeRespuesta == "cambioPassword.error") {
        //                            alertify.alert("", "La contrase&ntilde;a actual no es correcta");
        //                            $(".modal_close").click();
        //                            return;
        //                        }

        //                    },
        //                    error: function (XMLHttpRequest, textStatus, errorThrown) {
        //                        alertify.alert(errorThrown);
        //                    }
        //                });
    });
});

var ValidarCamposVacios = function (pass_actual, pass_nueva, pass_nueva_repetida) {
    if (pass_actual == "" || pass_nueva == "" || pass_nueva_repetida == "") {
        alertify.alert("", "Complete todos los campos");
        return false;
    }
    return true;
};


$(function () {
    $('a[rel*=leanModal]').leanModal({ top: 200, closeButton: ".modal_close" });
});
