var AsistenteDeAgregadoACombos = function () {
    
};

AsistenteDeAgregadoACombos.prototype.AgregarElementoProvisorioALista = function (elemento, data_provider, id_combo) {
    Backend.AgregarElementoProvisorioALista(elemento, tabla).onSucccess(function () {
        $("#" + id_combo)
    });
};