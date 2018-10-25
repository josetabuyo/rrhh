
var ambitoIdSeleccionado;
var ambitoDescripSeleccionado;
var cargoIdSeleccionado;
var cargoDescripSeleccionado;

Backend.start(function () {
    $(document).ready(function () {
        completarComboAmbitos();
        completarComboCargo();
    });
});

var completarComboAmbitos = function () {
    var ambitos = $('#cmbAmbitos');
    ambitos.html("");
    Backend.GetAmbitos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            $(item).html(respuesta[i].descripcion);
            ambitos.append(item);
        }
        ambitos.change(function () {
            ambitoIdSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[0]);
            ambitoDescripSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[1]);

            //alert(ambitoIdSeleccionado);
            //alert(ambitoDescripSeleccionado);

        });

        ambitos.change();
        ambitos.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}


var completarComboCargo = function () {
    var cargo = $('#cmbCargo');
    cargo.html("");
    Backend.GetCargos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            $(item).html(respuesta[i].descripcion);
            cargo.append(item);
        }
        cargo.change(function () {
            cargoIdSeleccionado = parseInt($("#cmbCargo").val().split("-")[0]);
            cargoDescripSeleccionado = parseInt($("#cmbCargo").val().split("-")[1]);

            //alert(cargoIdSeleccionado);
            //alert(cargoDescripSeleccionado);

        });

        cargo.change();
        cargo.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}

