describe("----------------------------------------------------------------COMIENZO TEST SACC----------------------------------------------------------------", function () {
    it("EJECUCIÓN DE PRUEBAS", function () {
    });
});



describe("Se inicializa el Botón de Asistencias", function () {
    it("El botón debería ser un cuadrado Blanco y estar en Status Asistencia No Cargada", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_blanco_clicked");
        expect(botonAsistencia.val()).toEqual("  ");

    });

});


describe("El botón de Asistencia está Cuadrado Blanco y se clickea", function () {
    it("El botón cambia a color Verde P y su Status es Presente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 1 vez
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_verde_clicked");
        expect(botonAsistencia.val()).toEqual("P");

    });
    
});


describe("El botón de Asistencia está Cuadrado Verde y se clickea", function () {
    it("El botón cambia a color Amarillo A y su Status es Ausente", function () {

        var botonAsistencia = new CrearBotonAsistencia("Agus10022013", "0");
        //Clickea 2 veces
        botonAsistencia.click();
        botonAsistencia.click();

        expect(botonAsistencia).toBeDefined();
        expect(botonAsistencia.attr('class')).toEqual("btn_amarillo_clicked");
        expect(botonAsistencia.val()).toEqual("A");

    });

});