

describe("Administrador de Mensajes", function () {
    it("Debería mostrar un mensaje de Error", function () {
        var mostrador_de_mensajes = {
            mostrar: function () { }
        };

        spyOn(mostrador_de_mensajes, 'mostrar');

        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, 'error');

        expect(mostrador_de_mensajes.mostrar).toHaveBeenCalledWith("error");
    });

    it("No debería mostrar un mensaje de Error cuando se le pasa un string vacio", function () {
        var mostrador_de_mensajes = {
            mostrar: function () { }
        };

        spyOn(mostrador_de_mensajes, 'mostrar');

        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, '');

        expect(mostrador_de_mensajes.mostrar).not.toHaveBeenCalled();
    });

//    it("Debería aparecer un popup con un mensaje de error", function () {
//        loadFixtures('mensaje_error.html');

//        var mostrador_de_mensajes = {
//            mostrarPopUp: function () { }
//        };

//        spyOn(mostrador_de_mensajes, 'mostrarPopUp');


//        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, 'div-mensaje');
//        administrador.informarAlUsuarioPorPopUp();

//        expect(mostrador_de_mensajes.mostrar).toHaveBeenCalledWith("error");
//    });

//    it("Debería aparecer un popup con un mensaje de error", function () {
//        loadFixtures('mensaje_exito.html');

//        var mostrador_de_mensajes = {
//            mostrarPopUp: function () { }
//        };

//        spyOn(mostrador_de_mensajes, 'mostrarPopUp');


//        var administrador = new AdministradorDeMensajes(mostrador_de_mensajes, 'div-mensaje');
//        administrador.informarAlUsuarioPorPopUp();

//        var mensaje_recibido = mostrador_de_mensajes.mostrarPopUp;

//        expect(mensaje_recibido).toHaveBeenCalledWith("Exito");
//    });


});

