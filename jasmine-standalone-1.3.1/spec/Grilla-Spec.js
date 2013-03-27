describe("Tengo una grilla", function () {
    var grilla;
    beforeEach(function () {
        grilla = new Grilla([new Columna('Columna1', { generar: function (doc) { return doc.descripcion; } })]);
        var proveedor = {
            pedirDatos: function (callback) {
                var docus = [{ descripion: "documento1" }, { descripion: "documento2"}];
                setTimeout(function () { callback(docus) },
                            50);
            }
        };
        grilla.setProveedorDeDatos(proveedor);
    });

    it("al refrescar la grilla deberia vaciarse, llamar al proveedor de datos y cuando este encuentre los documentos, popularse", function () {
        grilla.refrescar();
        runs(function () {
            expect(grilla.Objetos().length).toEqual(0);
        });
        waits(0);
        waitsFor(function () {
            return grilla.Objetos().length == 2;
        });
    });

    it("mientras la grilla se popula deberia mostrar una barra de progreso", function () {
        grilla.refrescar();
        runs(function () {
            expect(grilla.mostrandoProgressBar()).toBeTruthy();
        });
        waits(0);
        waitsFor(function () {
            return grilla.Objetos().length == 2;
        });
        runs(function () {
            expect(grilla.mostrandoProgressBar()).toBeFalsy();
        });
    });

});