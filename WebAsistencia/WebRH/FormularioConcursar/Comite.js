var Comite = {
    mostrarComite: function () {
        var _this = this;

        var proveedor_ajax = new ProveedorAjax();

        var span_comite = $('#comite');

        proveedor_ajax.postearAUrl({ url: "GetObjetoEnSesion",
            data: {
                nombre: 'comite'
            },
            success: function (respuesta) {
                var comite = JSON.parse(respuesta);
                //alertify.alert("Comite numero : " + comite.Numero);
                span_comite.text("Datos del comité: Número " + comite.Numero + ". Integrantes: " + comite.Integrantes);
                //alModificar(respuesta);
                //$(".modal_close_concursar").click();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("Error al querer ver el comite.");
            }
        });



    }
}





