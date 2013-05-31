describe("Tengo un buscador de legajos para digitalizacion", function () {
    var input_numero = {};
    var boton_buscar = {};
    var mock_repo_legajos = {};

    beforeEach(function () {
        var ui_buscador = $('<div>');
        input_numero = $('<input id="input_numero" type="text">');
        boton_buscar = $('<input id="boton_buscar" type="button">');
        ui_buscador.append(input_numero);
        ui_buscador.append(boton_buscar);  
              
        mock_repo_legajos = {
            getLegajo: function () {
            }
        };

        spyOn(mock_repo_legajos, 'getLegajo');

        var buscador = new BuscadorDeLegajos({
            ui: ui_buscador,
            repositorioDeLegajos: mock_repo_legajos
        });
    });
    it("Al ingresar el numero de legajo y presionar el boton buscar el buscador deberia pedir el legajo al repositorio", function () {
        input_numero.val('123');
        boton_buscar.click();

        expect(mock_repo_legajos.getLegajo).toHaveBeenCalledWith(123);
    });
});